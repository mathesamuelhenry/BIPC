using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace BIPCAccounting
{
    public partial class Form1 : Form
    {
        string connString = string.Empty;
        CVD cvd = null;

        public Form1()
        {
            InitializeComponent();

            connString = "DataSource=localhost;Port=3306;UID=root;PWD=;Database=BIPC;";

            this.LoadCategoryDropDown();
            this.LoadContributorIdComboBox();
            this.LoadTable();
            this.LoadCVD();
            this.LoadSearchTabDropDowns();
            this.LoadSearchResultDataGrid();
        }

        private void LoadSearchTabDropDowns()
        {
            this.LoadSearchTransModeDropDown();
            this.LoadSearchTransTypeDropDown();
            this.LoadSearchCategoryDropDown();
            this.LoadSearchNameDropDown();

            SearchFromDateTimePicker.Value = new DateTime(2000, 01, 01);
            SearchToDateTimePicker.Value = new DateTime(2099, 01, 01);
        }

        private void LoadSearchTransTypeDropDown()
        {
            List<CVD> TransTypeCVDList = this.cvd.GetCVD("contribution", "transaction_type");

            SearchTransTypeComboBox.Items.Clear();

            SearchTransTypeComboBox.Items.Add(new Item("", ""));
            foreach (CVD cvd in TransTypeCVDList)
            {
                SearchTransTypeComboBox.Items.Add(new Item(cvd.Description, cvd.Value));
            }

            SearchTransTypeComboBox.ValueMember = "Id";
            SearchTransTypeComboBox.DisplayMember = "Name";
        }

        private void LoadSearchTransModeDropDown()
        {
            List<CVD> TransModeCVDList = this.cvd.GetCVD("contribution", "transaction_mode");

            SearchTransModeComboBox.Items.Clear();

            SearchTransModeComboBox.Items.Add(new Item("", ""));
            foreach (CVD cvd in TransModeCVDList)
            {
                SearchTransModeComboBox.Items.Add(new Item(cvd.Description, cvd.Value));
            }

            SearchTransModeComboBox.ValueMember = "Id";
            SearchTransModeComboBox.DisplayMember = "Name";
        }

        private void LoadSearchCategoryDropDown()
        {
            List<CVD> CategoryCVDList = this.cvd.GetCVD("contribution", "category");

            SearchCategoryComboBox.Items.Clear();

            SearchCategoryComboBox.Items.Add(new Item("", ""));
            foreach (CVD cvd in CategoryCVDList)
            {
                SearchCategoryComboBox.Items.Add(new Item(cvd.Description, cvd.Value));
            }

            SearchCategoryComboBox.ValueMember = "Id";
            SearchCategoryComboBox.DisplayMember = "Name";
        }

        private void LoadSearchNameDropDown()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                dt = this.GetContributorIdList();

                SearchNameComboBox.Items.Clear();

                SearchNameComboBox.Items.Add(new Item("", ""));
                foreach (DataRow dRow in dt.Rows)
                {
                    SearchNameComboBox.Items.Add(new Item(dRow["contributor_name"].ToString(), dRow["contributor_id"].ToString()));
                }

                SearchNameComboBox.ValueMember = "Id";
                SearchNameComboBox.DisplayMember = "Name";
            }
            catch (Exception)
            {

            }
        }

        private void LoadCVD()
        {
            MySqlConnection mySqlConn = null;

            try
            {
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                cvd = new CVD(mySqlConn);
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void LoadCategoryDropDown()
        {
            MySqlConnection mySqlConn = null;

            try
            {
                int count = 0;
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                string sql = string.Format(@"SELECT cvd.value, cvd.description
  FROM table_column tc
       JOIN column_value_desc cvd
          ON     tc.table_column_id = cvd.table_column_id
             AND tc.table_name = 'contribution'
             AND tc.column_name = 'category'
 WHERE tc.status = 1 AND cvd.status = 1;");

                MySqlCommand cmdDataBase = new MySqlCommand(sql, mySqlConn);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                //CategoryCombo.DataSource = dt;
                CategoryCombo.ValueMember = "Id";
                CategoryCombo.DisplayMember = "Name";

                CategoryCombo.Items.Clear();

                CategoryCombo.Items.Add(new Item("", ""));
                foreach (DataRow dRow in dt.Rows)
                {
                    CategoryCombo.Items.Add(new Item(dRow["description"].ToString(), dRow["value"].ToString()));
                }

            }
            catch (Exception e)
            {
                
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }

        }

        private DataTable GetContributorIdList()
        {
            MySqlConnection mySqlConn = null;
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                string sql = string.Format(@"SELECT contributor_id, concat(last_name, ', ', first_name) AS contributor_name
  FROM contributor
 WHERE status = 1;");

                MySqlCommand cmdDataBase = new MySqlCommand(sql, mySqlConn);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                sda.Fill(dt);
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }

            return dt;
        }

        private void LoadContributorIdComboBox()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                dt = this.GetContributorIdList();

                ContributorIdComboBox.Items.Clear();

                ContributorIdComboBox.Items.Add(new Item("", ""));
                foreach (DataRow dRow in dt.Rows)
                {
                    ContributorIdComboBox.Items.Add(new Item(dRow["contributor_name"].ToString(), dRow["contributor_id"].ToString()));
                }

                ContributorIdComboBox.ValueMember = "Id";
                ContributorIdComboBox.DisplayMember = "Name";
                ContributorIdComboBox.SelectedValue = "";
            }catch(Exception)
            {

            }
        }
        
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void LoadTable()
        {
            //string connString = "DataSource=dbdprsql-bct.risk.regn.net;Port=3306;UID=mbs_ws;PWD=mbs_ws123;Database=sales_assignment;";

            MySqlConnection mySqlConn = new MySqlConnection(connString);
            MySqlCommand cmdDataBase = new MySqlCommand(@"SELECT                           
      CASE
          WHEN IFNULL(cn.contribution_name, '') = ''
          THEN
             CONCAT(cr.first_name, ' ', cr.last_name)
          ELSE
             cn.contribution_name
       END
          AS 'Name',
       cvd.description AS Category,
       cvd_transtype.description AS Type,
       cvd_transmode.description AS Mode,
       cn.amount AS Amount,
       cn.check_number AS 'Check #',
       cn.transaction_date AS 'Trans DT',
       cn.note AS 'Note',
       cn.date_added AS 'Date Added'
  FROM contribution cn
       LEFT JOIN contributor cr ON cr.contributor_id = cn.contributor_id
       LEFT JOIN table_column tc
          ON     tc.table_name = 'contribution'
             AND tc.column_name = 'category'
             AND tc.status = 1
       LEFT JOIN column_value_desc cvd
          ON     cvd.table_column_id = tc.table_column_id
             AND cvd.value = cn.category
             AND cvd.status = 1
       LEFT JOIN table_column tc_transtype
          ON     tc_transtype.table_name = 'contribution'
             AND tc_transtype.column_name = 'transaction_type'
             AND tc_transtype.status = 1
       LEFT JOIN column_value_desc cvd_transtype
          ON     cvd_transtype.table_column_id = tc_transtype.table_column_id
             AND cvd_transtype.value = cn.transaction_type
             AND cvd_transtype.status = 1
       LEFT JOIN table_column tc_transmode
          ON     tc_transmode.table_name = 'contribution'
             AND tc_transmode.column_name = 'transaction_mode'
             AND tc_transmode.status = 1
       LEFT JOIN column_value_desc cvd_transmode
          ON     cvd_transmode.table_column_id = tc_transmode.table_column_id
             AND cvd_transmode.value = cn.transaction_mode
             AND cvd_transmode.status = 1 
 WHERE cn.status = 1
 ORDER BY cn.date_added DESC;", mySqlConn);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                BindingSource bs = new BindingSource();

                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                dataGridView1.Visible = true;

            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConn = null;
            bool valid = true;

            try
            {
                int count = 0;
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                string transactionType = string.Empty;
                string Category = string.Empty;
                string ContributorId = string.Empty;

                bool isChecked = CreditRadioButton.Checked;
                if (isChecked)
                    transactionType = CreditRadioButton.Text;
                else
                    transactionType = DebitRadionButton.Text;

                transactionType = this.cvd.GetCVD("contribution", "transaction_type", transactionType);

                string transactionMode = string.Empty;
                bool isTMChecked = CashRadionButton.Checked;
                if (isTMChecked)
                    transactionMode = CashRadionButton.Text;
                else
                    transactionMode = CheckRadionButton.Text;

                
                transactionMode = this.cvd.GetCVD("contribution", "transaction_mode", transactionMode);

                if (!string.IsNullOrEmpty(CategoryCombo.Text))
                {
                    Item SelectedCategory = (Item)CategoryCombo.SelectedItem;
                    Category = SelectedCategory.Id;
                }

                string newCategory = CategoryTextBox.Text;

                if (!string.IsNullOrEmpty(ContributorIdComboBox.Text))
                {
                    Item SelectedContributor = (Item)ContributorIdComboBox.SelectedItem;
                    ContributorId = SelectedContributor.Id;
                }

                if (!string.IsNullOrEmpty(newCategory))
                    this.AddNewCategory(newCategory, out Category);

                DateTime TransactionDate = TransactionDateTimePicker.Value;
                //NAme
                if (string.IsNullOrEmpty(NameTextBox.Text) && string.IsNullOrEmpty(ContributorIdComboBox.Text))
                {
                    MessageBox.Show("Name cannot be empty");
                    valid = false;
                }

                if (string.IsNullOrEmpty(CategoryTextBox.Text) && string.IsNullOrEmpty(CategoryCombo.Text))
                {
                    MessageBox.Show("Category cannot be empty");
                    valid = false;
                }

                // Amount
                string amount = AmountTextBox.Text;
                if (string.IsNullOrEmpty(amount))
                {
                    MessageBox.Show("Amount cannot be empty.");
                    valid = false;
                }
                else
                {
                    float amt;
                    
                    if (!float.TryParse(amount, out amt))
                    {
                        MessageBox.Show(string.Format("{0} is not a valid amount.", amount), "Not Valid");
                        valid = false;
                    }
                }
               
                if (valid)
                {
                    count = this.Insert(ContributorId, NameTextBox.Text, Category, transactionType, transactionMode, CheckTextBox.Text, AmountTextBox.Text, TransactionDate, NoteTextBox.Text);

                    if (count > 0)
                        MessageBox.Show("Record added");
                    else
                        MessageBox.Show("Record not added");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Failure");
            }
            finally
            {
                if (mySqlConn != null)
                {
                    this.LoadTable();
                    mySqlConn.Close();
                }
            }
        }

        private bool AddNewCategory(string Category, out string categoryValue)
        {
            MySqlConnection mySqlConn = null;
            bool status = false;
            categoryValue = string.Empty;

            try
            {
                string valid = "0";

                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();
                string validSql = @"SELECT count(*)
  FROM table_column tc
       JOIN column_value_desc cvd
          ON     tc.table_column_id = cvd.table_column_id
             AND tc.table_name = 'contribution'
             AND tc.column_name = 'category'
             AND cvd.description = @description";

                MySqlCommand cmd = new MySqlCommand(validSql, mySqlConn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@description", Category);
                
                object res = cmd.ExecuteScalar();
                if (res != null)
                    valid = res.ToString();
                
                if (int.Parse(valid) == 0)
                {
                    string insertSql = string.Format(@"INSERT INTO column_value_desc(table_column_id,
                              value,
                              description,
                              date_added)
   VALUES (
             (SELECT table_column_id
                FROM table_column
               WHERE table_name = 'contribution' AND column_name = 'category' and status = 1),
             (SELECT max(CAST(value as UNSIGNED)) + 1
                FROM table_column tc
                     JOIN column_value_desc cvd
                        ON     tc.table_column_id = cvd.table_column_id
                           AND tc.table_name = 'contribution'
                           AND tc.column_name = 'category'
                           AND cvd.status = 1),
             '{0}',
             now());", Category);

                    MySqlCommand insertCmd = new MySqlCommand(insertSql, mySqlConn);
                    int count = insertCmd.ExecuteNonQuery();

                    if (count < 1)
                    {
                        throw new Exception("New Category Add Failed");
                    }

                    this.LoadCategoryDropDown();
                }

                string GetCategoryValueSql = string.Format(@"SELECT cvd.value
  FROM table_column tc
       JOIN column_value_desc cvd
          ON     tc.table_column_id = cvd.table_column_id
             AND tc.table_name = 'contribution'
             AND tc.column_name = 'category'
             AND cvd.description = '{0}'
             AND cvd.status = 1", Category);

                MySqlCommand GetCatVAlueCmd = new MySqlCommand(GetCategoryValueSql, mySqlConn);

                object catRes = GetCatVAlueCmd.ExecuteScalar();

                if (catRes != null)
                    categoryValue = catRes.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return status;
        }

        private int Insert(string contributor_id, string name, string category, string trans_type, string trans_mode, string checque_number, string amount, DateTime transaction_date, string note)
        {
            int count = 0;
            MySqlConnection mySqlConn = null;

            try
            {
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();
                string sql = string.Format(@" INSERT INTO contribution (
  contributor_id
  ,contribution_name
  ,category
  ,transaction_type
  ,transaction_mode
  ,amount
  ,check_number
  ,transaction_date
  ,note
  ,status
  ,date_added
) VALUES (
  {0}   -- contributor_id - IN int(11)
  ,'{1}'  -- contribution_name - IN varchar(60)
  ,'{2}'  -- category - IN varchar(50)
  ,'{3}'   -- transaction_type - IN int(11)
  ,'{4}' -- transaction_mode - IN int(11)
  ,{5} -- amount - IN decimal(11,2)
  ,'{6}'  -- check_number - IN varchar(50)
  ,'{7}'  -- transaction_date - IN datetime
  ,'{8}'  -- note 
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
)", string.IsNullOrEmpty(contributor_id) ? "NULL" : contributor_id
  , name
  , category
  , trans_type
  , trans_mode
  , amount
  , checque_number
  , transaction_date.ToString("yyyy-MM-dd")
  , note);

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                count = cmd.ExecuteNonQuery();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }

            return count;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void AddContributorButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            MySqlConnection mySqlConn = null;

            try
            {
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                string FirstName = FirstNameTextBox.Text;
                string LastName = LastNameTextBox.Text;
                string FamilyName = FamilyNameTextBox.Text;

                string sql = string.Format(@"INSERT INTO contributor (
  first_name
  ,last_name
  ,family_name
  ,date_added
) VALUES (
  '{0}' -- first_name - IN varchar(50)
  ,'{1}'  -- last_name - IN varchar(50)
  ,'{2}'  -- family_name - IN varchar(50)
  ,now()  -- date_added - IN datetime
)", FirstName, LastName, FamilyName);

                MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                count = cmd.ExecuteNonQuery();

                if (count > 0)
                    MessageBox.Show("New member added", "Success");
                else
                    MessageBox.Show("Issue adding a new member", "Failure");

                this.LoadSearchNameDropDown();
                this.LoadContributorIdComboBox();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Failure");
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }

        }

        private void ContributorIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ContributorIdComboBox.Text))
            {
                NameTextBox.Text = string.Empty;
                NameTextBox.Enabled = false;
            }
            else
            {
                NameTextBox.Enabled = true;
            }
        }

        private void CategoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CategoryCombo.Text))
            {
                CategoryTextBox.Text = string.Empty;
                CategoryTextBox.Enabled = false;
            }
            else
            {
                CategoryTextBox.Enabled = true;
            }
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                ContributorIdComboBox.SelectedValue = string.Empty;
                ContributorIdComboBox.Enabled = false;
            }
            else
            {
                ContributorIdComboBox.Enabled = true;
            }
        }

        private void NameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                ContributorIdComboBox.SelectedValue = string.Empty;
                ContributorIdComboBox.Enabled = false;
            }
            else
            {
                ContributorIdComboBox.Enabled = true;
            }
        }

        private void CategoryTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(CategoryTextBox.Text))
            {
                CategoryCombo.SelectedValue = string.Empty;
                CategoryCombo.Enabled = false;
            }
            else
            {
                CategoryCombo.Enabled = true;
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Utils.ResetAllControls(this.tabControl1.SelectedTab);
        }
        private void LoadSearchResultDataGrid()
        {
            string searchSQL = this.GetSearchSQL();

            MySqlConnection mySqlConn = new MySqlConnection(connString);
            mySqlConn.Open();

            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                dt = Utils.GetDataTable(mySqlConn, searchSQL);

                BindingSource bs = new BindingSource();

                bs.DataSource = dt;
                SearchResultsDataGridView.DataSource = bs;
                SearchResultsDataGridView.Visible = true;
                SearchResultsDataGridView.AutoResizeRows();
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.LoadSearchResultDataGrid();
        }

        private string GetSearchSQL()
        {
            string where = string.Empty;

            string searchSQL = string.Format(@"SELECT CASE
          WHEN IFNULL(cn.contribution_name, '') = ''
          THEN
             CONCAT(con.first_name, ' ', con.last_name)
          ELSE
             cn.contribution_name
       END
          AS 'Name',
       cvd.description AS Category,
       cvd_transtype.description AS Type,
       cvd_transmode.description AS Mode,
       cn.amount AS Amount,
       cn.check_number AS 'Check #',
       cn.transaction_date AS 'Trans DT',
       cn.note AS 'Note',
       cn.date_added AS 'Date Added'
  FROM contribution cn
       LEFT JOIN contributor con
          ON con.contributor_id = cn.contributor_id AND con.status = 1
       LEFT JOIN table_column tc
          ON     tc.table_name = 'contribution'
             AND tc.column_name = 'category'
             AND tc.status = 1
       LEFT JOIN column_value_desc cvd
          ON     cvd.table_column_id = tc.table_column_id
             AND cvd.value = cn.category
             AND cvd.status = 1
       LEFT JOIN table_column tc_transtype
          ON     tc_transtype.table_name = 'contribution'
             AND tc_transtype.column_name = 'transaction_type'
             AND tc_transtype.status = 1
       LEFT JOIN column_value_desc cvd_transtype
          ON     cvd_transtype.table_column_id = tc_transtype.table_column_id
             AND cvd_transtype.value = cn.transaction_type
             AND cvd_transtype.status = 1
       LEFT JOIN table_column tc_transmode
          ON     tc_transmode.table_name = 'contribution'
             AND tc_transmode.column_name = 'transaction_mode'
             AND tc_transmode.status = 1
       LEFT JOIN column_value_desc cvd_transmode
          ON     cvd_transmode.table_column_id = tc_transmode.table_column_id
             AND cvd_transmode.value = cn.transaction_mode
             AND cvd_transmode.status = 1");

            where = "cn.status = 1";

            if (!string.IsNullOrEmpty(SearchNameTextBox.Text))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                where += string.Format("cn.contribution_name like '%{0}%'", SearchNameTextBox.Text);
            }
            else if (!string.IsNullOrEmpty(SearchNameComboBox.Text))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                Item nameItem = (Item)SearchNameComboBox.SelectedItem;

                where += string.Format("con.contributor_id = '{0}'", nameItem.Id);
            }

            if (!string.IsNullOrEmpty(SearchCategoryComboBox.Text))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                Item categoryItem = (Item)SearchCategoryComboBox.SelectedItem;

                where += string.Format("cvd.value = '{0}'", categoryItem.Id);
            }

            if (!string.IsNullOrEmpty(SearchTransTypeComboBox.Text))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                Item transTypeItem = (Item)SearchTransTypeComboBox.SelectedItem;

                where += string.Format("cvd_transtype.value = '{0}'", transTypeItem.Id);
            }

            if (!string.IsNullOrEmpty(SearchTransModeComboBox.Text))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                Item transModeItem = (Item)SearchTransModeComboBox.SelectedItem;

                where += string.Format("cvd_transmode.value = '{0}'", transModeItem.Id);
            }

            if (!string.IsNullOrEmpty(SearchCheckTextBox.Text))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                where += string.Format("cn.check_number like '%{0}%'", SearchCheckTextBox.Text);
            }

            if (!string.IsNullOrEmpty(SearchFromDateTimePicker.Value.ToString()))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                where += string.Format("date_format(cn.transaction_date, '%Y-%m-%d') >= '{0}'", SearchFromDateTimePicker.Value.ToString("yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(SearchToDateTimePicker.Value.ToString()))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                where += string.Format("date_format(cn.transaction_date, '%Y-%m-%d') <= '{0}'", SearchToDateTimePicker.Value.ToString("yyyy-MM-dd"));
            }

            searchSQL = searchSQL + " where " + where;

            return searchSQL;
        }

        private void SearchNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchNameTextBox.Text))
            {
                SearchNameComboBox.SelectedValue = string.Empty;
                SearchNameComboBox.Enabled = false;
            }
            else
            {
                SearchNameComboBox.Enabled = true;
            }
        }

        private void SearchNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchNameComboBox.Text))
            {
                SearchNameTextBox.Text = string.Empty;
                SearchNameTextBox.Enabled = false;
            }
            else
            {
                SearchNameTextBox.Enabled = true;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlConnection mySqlConn = new MySqlConnection(connString);
            mySqlConn.Open();

            string SearchSQL = this.GetSearchSQL();

            System.Data.DataTable dt = Utils.GetDataTable(mySqlConn, SearchSQL);

            if (dt != null && dt.Rows.Count > 0)
            { 
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV File|*.csv";
                sfd.FileName = "My CSV File";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string Path = sfd.FileName;

                    StringBuilder sb = new StringBuilder();
                    
                    string total = dt.AsEnumerable()
                                .Sum(x => x.Field<Decimal>("amount"))
                                .ToString();

                    sb.Append("Contributor Name,Category,Transaction Type, Transaction Mode, Amount, Check #, Transaction Date, Note, Date Added");
                    sb.AppendLine();

                    foreach (DataRow dRow in dt.Rows)
                    {
                        sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8}", dRow["Name"].ToString().Replace(",", "")
                            , dRow["Category"].ToString().Replace(",", "")
                            , dRow["Type"].ToString().Replace(",", "")
                            , dRow["Mode"].ToString().Replace(",", "")
                            , dRow["Amount"].ToString().Replace(",", "")
                            , dRow["Check #"].ToString().Replace(",", "")
                            , dRow["Trans DT"].ToString().Replace(",", "")
                            , dRow["Note"].ToString().Replace(",", "")
                            , dRow["Date Added"].ToString().Replace(",", ""));

                        sb.AppendLine();
                    }

                    sb.AppendLine();
                    sb.AppendFormat("{0},,,,{1},,,,", "Total", total);

                    File.WriteAllText(Path, sb.ToString());

                    MessageBox.Show(string.Format("File [{0}] created", sfd.FileName));
                }
            }
            else
            {
                MessageBox.Show("No records returned to be exported.");
            }
        }
    }
}
