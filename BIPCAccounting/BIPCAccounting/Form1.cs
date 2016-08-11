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

namespace BIPCAccounting
{
    public partial class Form1 : Form
    {
        string connString = string.Empty;

        public Form1()
        {
            InitializeComponent();

            connString = "DataSource=localhost;Port=3306;UID=root;PWD=;Database=BIPC;";

            this.LoadDropDown();
            this.LoadContributorIdComboBox();
            this.LoadTable();

        }

        private void LoadDropDown()
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

        private void LoadContributorIdComboBox()
        {
            MySqlConnection mySqlConn = null;

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
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                //ContributorIdComboBox.DataSource = dt;
                
                ContributorIdComboBox.Items.Add(new Item("", ""));
                foreach (DataRow dRow in dt.Rows)
                {
                    ContributorIdComboBox.Items.Add(new Item(dRow["contributor_name"].ToString(), dRow["contributor_id"].ToString()));
                }

                ContributorIdComboBox.ValueMember = "Id";
                ContributorIdComboBox.DisplayMember = "Name";
                ContributorIdComboBox.SelectedValue = "";
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            MySqlCommand cmdDataBase = new MySqlCommand(@"SELECT                           -- Concat(cr.last_name, ', ', cr.first_name),
      cn.contribution_name AS 'Contributor Name',
       cvd.description AS Category,
       cn.transaction_type AS Type,
       cn.transaction_mode AS Mode,
       cn.amount AS Amount,
       cn.check_number AS 'Check #',
       cn.transaction_date AS 'Transaction DT',
       cn.note as 'Note',
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
 WHERE cn.status = 1;", mySqlConn);

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
                bool isChecked = radioButton1.Checked;
                if (isChecked)
                    transactionType = radioButton1.Text;
                else
                    transactionType = radioButton2.Text;

                string transactionMode = string.Empty;
                bool isTMChecked = radioButton3.Checked;
                if (isTMChecked)
                    transactionMode = radioButton3.Text;
                else
                    transactionMode = radioButton3.Text;
                
                string Category = CategoryCombo.SelectedValue.ToString();
                string newCategory = CategoryTextBox.Text;

                

                string ContributorId = ContributorIdComboBox.SelectedValue.ToString();

                DateTime TransactionDate = TransactionDateTimePicker.Value;
                //NAme
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    MessageBox.Show("Name cannot be empty");
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
                    count = this.Insert(ContributorId, NameTextBox.Text, CategoryCombo.SelectedValue.ToString(), transactionType, transactionMode, CheckTextBox.Text, AmountTextBox.Text, TransactionDate, NoteTextBox.Text);

                    if (count > 0)
                        MessageBox.Show("Record added");
                    else
                        MessageBox.Show("Record not added");
                }

                
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

        private void AddNewCategory(string Category)
        {
            string validSql = string.Format(@"SELECT 1
  FROM table_column tc
       JOIN column_value_desc cvd
          ON     tc.table_column_id = cvd.table_column_id
             AND tc.table_name = 'contribution'
             AND tc.column_name = 'category'
             AND description = '{0}'", Category);

            string sql = string.Format(@"INSERT INTO column_value_desc(table_column_id,
                              value,
                              description,
                              date_added)
   VALUES (
             (SELECT table_column_id
                FROM table_column
               WHERE table_name = 'contribution' AND column_name = 'category'),
             (SELECT max(value) + 1
                FROM table_column tc
                     JOIN column_value_desc cvd
                        ON     tc.table_column_id = cvd.table_column_id
                           AND tc.table_name = 'contribution'
                           AND tc.column_name = 'category'),
             '{0}',
             now());", Category);
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
)", "NULL"
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
    }
}
