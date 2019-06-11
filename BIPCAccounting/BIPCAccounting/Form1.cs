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
using BIPCAccounting.Entity;
using System.Configuration;

namespace BIPCAccounting
{
    public partial class Form1 : Form
    {
        string connString = string.Empty;
        CVD cvd = null;
        Dictionary<string, Contributor> ContributorList = new Dictionary<string, Contributor>();
        Dictionary<string, Account> AccountList = new Dictionary<string, Account>();
        Dictionary<string, Contribution> ContributionList = new Dictionary<string, Contribution>();

        public Form1()
        {
            InitializeComponent();

            connString = ConfigurationManager.ConnectionStrings["PROD"].ConnectionString;

            this.LoadFormData();
        }

        private void LoadFormData()
        {
            EditModeHidden.Text = "dasd";

            this.LoadCVD();
            this.LoadExpenditureCategoryComboBox();
            this.LoadContributorIdComboBox();
            
            // Load accounts data grid
            this.LoadAccountDataGridView();

            this.LoadAccountNameComboBox();

            string selectedAccountId = string.Empty;
            if (!string.IsNullOrEmpty(AccountNameComboBox.Text))
            {
                Item selectedAccountIdItem = (Item)AccountNameComboBox.SelectedItem;
                selectedAccountId = selectedAccountIdItem.Id;
            }

            // Load Contributions Data Grid
            this.LoadContributionsDataGridView();

            // Load Contributor Names Data Grid
            this.LoadContributorNamesDataGridView();

            // Load loan contributor data grid
            this.LoadLoanContributorDataGridView();
            
            // Load search tab
            this.LoadSearchTabDropDowns();
            this.LoadSearchResultDataGrid();
            
            // Load all names into dictionary
            this.LoadAllContributorNames();
            this.LoadOpeningBalance();
            
            this.LoadBalancesOnExpenditureTab(selectedAccountId);
            
            OpeningBalanceTooltip.SetToolTip(OpeningBalanceLabel, "Display Opening Balance");
            this.SetToolTipProp(OpeningBalanceTooltip);

            TotalBalanceFromOpeningBalanceToolTip.SetToolTip(TotalBalanceByOpeningLabel, "Total Balance on the Account.");
            this.SetToolTipProp(TotalBalanceFromOpeningBalanceToolTip);

            SearchBalanceToolTip.SetToolTip(CurrentSearchBalanceLabel, "Display Opening Balance + Search Balance");
            this.SetToolTipProp(SearchBalanceToolTip);
        }
        
        private void LoadContributorNamesDataGridView()
        {
            try
            {
                this.LoadAllContributorNames();

                ContributorNameGridView.Rows.Clear();
                ContributorNameGridView.Refresh();

                if (this.ContributorList != null)
                {
                    foreach (KeyValuePair<string, Contributor> namePair in this.ContributorList)
                    {
                        Contributor contName = namePair.Value;

                        int n = ContributorNameGridView.Rows.Add();
                        ContributorNameGridView.Rows[n].Cells["ContributorId"].Value = namePair.Key;
                        ContributorNameGridView.Rows[n].Cells["FirstName"].Value = contName.FirstName;
                        ContributorNameGridView.Rows[n].Cells["LastName"].Value = contName.LastName;
                        ContributorNameGridView.Rows[n].Cells["ContributorLastUpdated"].Value = contName.LastUpdated;
                    }
                }

                ContributorNameGridView.AutoResizeRows();
            }
            finally
            {
                
            }
        }

        private void SetToolTipProp(System.Windows.Forms.ToolTip ttip)
        {
            ttip.IsBalloon = true;
        }

        private void LoadBalancesOnExpenditureTab(string account_id)
        {
            decimal TotalBalance = 0;
            decimal OpeningBalance = 0;
            decimal CreditAmount = 0;
            decimal DebitAmount = 0;
            
            OpeningBalance = Convert.ToDecimal(this.AccountList
                .Where(acc => acc.Key == account_id.ToString())
                .FirstOrDefault()
                .Value
                .InitialBalance);

            var currentContributionList = this.ContributionList
                .Where(con => con.Value.AccountId == account_id.ToString())
                .ToList();
            try
            {
                foreach (KeyValuePair<string, Contribution> ctbnKvp in currentContributionList)
                {
                    if (ctbnKvp.Value.TransactionType.Equals("Credit", StringComparison.InvariantCultureIgnoreCase))
                    {
                        CreditAmount += decimal.Parse(ctbnKvp.Value.Amount);
                    }
                    else
                    {
                        DebitAmount += decimal.Parse(ctbnKvp.Value.Amount);
                    }
                }

                TotalBalance = OpeningBalance + CreditAmount - DebitAmount;
                //Total = CreditAmount - DebitAmount;
                TotalBalanceLabel.Text = TotalBalance.ToString();
                OpeningBalanceValue.Text = OpeningBalance.ToString();
                //TotalLabel.Text = Total.ToString();
            }
            finally
            {
            }
        }
    
        private void LoadOpeningBalance()
        {
            decimal OpeningBalance = 0M;
            List<CVD> openingBalanceList = this.cvd.GetCVD("TEMP", "opening_balance");
            OpeningBalance = openingBalanceList.Count > 0 ? decimal.Parse(openingBalanceList[0].Value) : OpeningBalance;
            OpeningBalanceTextBox.Text = OpeningBalance.Equals(0M) ? string.Empty : OpeningBalance.ToString();

            if (OpeningBalance != 0M)
                OpeningBalanceAddUpdateButton.Text = "Update";
            else
                OpeningBalanceAddUpdateButton.Text = "Add";
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
            finally
            {
                dt.Clear();
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

        /// <summary>
        /// Load "Add Expenditure" Category Combo Box
        /// </summary>
        private void LoadExpenditureCategoryComboBox()
        {
            if (cvd == null)
            {
                this.LoadCVD();
            }
            else
            {
                var categoryCVDList = this.cvd.GetCVD("contribution", "category");

                CategoryCombo.Items.Clear();

                CategoryCombo.ValueMember = "Id";
                CategoryCombo.DisplayMember = "Name";

                CategoryCombo.Items.Add(new Item("", ""));

                foreach (CVD categoryCVD in categoryCVDList)
                {
                    CategoryCombo.Items.Add(new Item(categoryCVD.Description, categoryCVD.Value));
                }
            }
        }

        private void LoadCategoryDropDown()
        {
            MySqlConnection mySqlConn = null;

            try
            {
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                Dictionary<string, string> CategoryList = Utils.LoadColumnValueDescription(mySqlConn, "contribution", "category");
                
                CategoryCombo.Items.Clear();

                CategoryCombo.ValueMember = "Id";
                CategoryCombo.DisplayMember = "Name";

                CategoryCombo.Items.Add(new Item("", ""));

                foreach (KeyValuePair<string, string> CategoryPair in CategoryList)
                {
                    CategoryCombo.Items.Add(new Item(CategoryPair.Value, CategoryPair.Key));
                }
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

        private Dictionary<int, string> GetContributorListDictionary()
        {
            DataTable dt = new DataTable();
            Dictionary<int, string> contributorList = new Dictionary<int, string>();

            dt = this.GetContributorIdList();

            if (dt != null & dt.Rows.Count > 0)
            {
                foreach (DataRow dRow in dt.Rows)
                {
                    contributorList.Add(int.Parse(dRow["contributor_id"].ToString()), dRow["contributor_name"].ToString());
                }
            }

            return contributorList;
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

                loanComboBox.Items.Clear();
                
                foreach (DataRow dRow in dt.Rows)
                {
                    loanComboBox.Items.Add(new Item(dRow["contributor_name"].ToString(), dRow["contributor_id"].ToString()));
                }

                loanComboBox.ValueMember = "Id";
                loanComboBox.DisplayMember = "Name";
            }
            catch (Exception)
            {

            }
        }
        
        public void LoadAllContributions()
        {
            this.ContributionList.Clear();

            MySqlConnection mySqlConn = new MySqlConnection(connString);
            MySqlCommand cmdDataBase = new MySqlCommand(@"SELECT cn.contribution_id AS 'Contribution Id',
       acc.account_name,
       cn.account_id as 'AccountId',
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
       LEFT JOIN account acc
          ON acc.account_id = cn.account_id AND acc.status = 1
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

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        this.ContributionList.Add(dRow["Contribution Id"].ToString(), new Contribution(dRow));
                    }
                }
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void LoadContributionsDataGridView()
        {
            string selectedAccountId = string.Empty;

            try
            {
                // Load all contributions
                this.LoadAllContributions();
                
                if (!string.IsNullOrEmpty(AccountNameComboBox.Text))
                {
                    Item selectedAccountIdItem = (Item)AccountNameComboBox.SelectedItem;
                    selectedAccountId = selectedAccountIdItem.Id;
                }

                var currentContributionList = this.ContributionList
                    .Where(con => con.Value.AccountId == selectedAccountId)
                    .ToList();

                DashboardContributionsDataGridView.Rows.Clear();
                DashboardContributionsDataGridView.Refresh();

                if (this.ContributionList != null && currentContributionList.Count > 0)
                {
                    foreach (KeyValuePair<string, Contribution> contribution in currentContributionList)
                    {
                        int n = DashboardContributionsDataGridView.Rows.Add();
                        DashboardContributionsDataGridView.Rows[n].Cells["ID"].Value = contribution.Value.ContributionId;
                        DashboardContributionsDataGridView.Rows[n].Cells["CDataGridAccountName"].Value = contribution.Value.AccountName;
                        DashboardContributionsDataGridView.Rows[n].Cells["CName"].Value = contribution.Value.ContributorName;
                        DashboardContributionsDataGridView.Rows[n].Cells["Category"].Value = contribution.Value.Category;
                        DashboardContributionsDataGridView.Rows[n].Cells["Type"].Value = contribution.Value.TransactionType;
                        DashboardContributionsDataGridView.Rows[n].Cells["Mode"].Value = contribution.Value.TransactionMode;
                        DashboardContributionsDataGridView.Rows[n].Cells["Checkno"].Value = contribution.Value.CheckNumber;
                        DashboardContributionsDataGridView.Rows[n].Cells["Amount"].Value = contribution.Value.Amount;
                        DashboardContributionsDataGridView.Rows[n].Cells["TransDt"].Value = contribution.Value.TransactionDate;
                        DashboardContributionsDataGridView.Rows[n].Cells["Note"].Value = contribution.Value.Note;
                        DashboardContributionsDataGridView.Rows[n].Cells["DateAdded"].Value = contribution.Value.DateAdded;
                    }

                    DashboardContributionsDataGridView.Rows[0].Selected = true;
                }

                DashboardContributionsDataGridView.AutoResizeRows();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            /*MySqlConnection mySqlConn = new MySqlConnection(connString);
            MySqlCommand cmdDataBase = new MySqlCommand(@"SELECT 
      cn.contribution_id as 'Contribution Id',                          
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

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells["ID"].Value = dRow["Contribution Id"].ToString();
                        dataGridView1.Rows[n].Cells["CName"].Value = dRow["Name"].ToString();
                        dataGridView1.Rows[n].Cells["Category"].Value = dRow["Category"].ToString();
                        dataGridView1.Rows[n].Cells["Type"].Value = dRow["Type"].ToString();
                        dataGridView1.Rows[n].Cells["Mode"].Value = dRow["Mode"].ToString();
                        dataGridView1.Rows[n].Cells["Checkno"].Value = dRow["Check #"].ToString();
                        dataGridView1.Rows[n].Cells["Amount"].Value = dRow["Amount"].ToString();
                        dataGridView1.Rows[n].Cells["TransDt"].Value = dRow["Trans DT"].ToString();
                        dataGridView1.Rows[n].Cells["Note"].Value = dRow["Note"].ToString();
                        dataGridView1.Rows[n].Cells["DateAdded"].Value = dRow["Date Added"].ToString();
                    }

                    dataGridView1.Rows[0].Selected = true;
                }

                dataGridView1.AutoResizeRows();
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
            */

            this.LoadBalancesOnExpenditureTab(selectedAccountId);
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
                string accountId = string.Empty;

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
                else if (CheckRadionButton.Checked)
                    transactionMode = CheckRadionButton.Text;
                else if (OnlineRadioButton.Checked)
                    transactionMode = OnlineRadioButton.Text;
                else
                    transactionMode = CardRadioButton.Text;
                
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

                // Read account name combo box
                if (!string.IsNullOrEmpty(AccountNameComboBox.Text))
                {
                    Item SelectedAccountName = (Item)AccountNameComboBox.SelectedItem;
                    accountId = SelectedAccountName.Id;
                }
    
                this.LoadCVD();
                this.LoadSearchCategoryDropDown();

                DateTime TransactionDate = TransactionDateTimePicker.Value;
                
                /*
                 * Validation
                 */
                
                // Account Name
                if (string.IsNullOrEmpty(accountId))
                {
                    MessageBox.Show("Account Name cannot be empty");
                    valid = false;
                }

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

                Account acc = this.AccountList.Where(x => x.Key == accountId)
                    .FirstOrDefault()
                    .Value;

                if (acc.IsClosed)
                    throw new Exception($"Account [{acc.AccountName}] is closed. Transactions cannot be added/updated on this account. Please re-open the account to make any changes to the account");

                if (valid)
                {
                    if (EditModeHidden.Text == "EDIT")
                    {
                        count = this.UpdateRecord(ContributorId, accountId, NameTextBox.Text, Category, transactionType, transactionMode, CheckTextBox.Text, AmountTextBox.Text, TransactionDate, NoteTextBox.Text);

                        if (count > 0)
                            MessageBox.Show("Record updated");
                        else
                            MessageBox.Show("Record not updated");
                        
                        this.CancelEditMode();
                    }
                    else
                    {
                        count = this.Insert(ContributorId, accountId, NameTextBox.Text, Category, transactionType, transactionMode, CheckTextBox.Text, AmountTextBox.Text, TransactionDate, NoteTextBox.Text);

                        if (count > 0)
                            MessageBox.Show("Record added");
                        else
                            MessageBox.Show("Record not added");
                    }
                    
                    this.LoadContributionsDataGridView();
                    this.LoadSearchResultDataGrid();
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
                    string insertSql = string.Format(@"
INSERT INTO column_value_desc(column_value_desc_id,
                              table_column_id,
                              value,
                              description,
                              date_added)
   VALUES (
             fn_get_nextid('BIPC', 'column_value_desc'),
             (SELECT table_column_id
                FROM table_column
               WHERE     table_name = 'contribution'
                     AND column_name = 'category'
                     AND status = 1),
             (SELECT IFNULL(max(CAST(value AS UNSIGNED)) + 1, 1)
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

                    this.LoadExpenditureCategoryComboBox();
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

        private int Insert(string contributor_id, string account_id, string name, string category, string trans_type, string trans_mode, string checque_number, string amount, DateTime transaction_date, string note)
        {
            int count = 0;
            MySqlConnection mySqlConn = null;

            try
            {
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();
                string sql = string.Format(@" 
INSERT INTO contribution (contribution_id
  ,contributor_id
  ,account_id
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
) VALUES (fn_get_nextid('BIPC', 'contribution')
  ,{0}   -- contributor_id - IN int(11)
  ,{1}   -- account_id - IN int(11)
  ,{2}  -- contribution_name - IN varchar(60)
  ,{3}  -- category - IN varchar(50)
  ,{4}   -- transaction_type - IN int(11)
  ,{5} -- transaction_mode - IN int(11)
  ,{6} -- amount - IN decimal(11,2)
  ,{7}  -- check_number - IN varchar(50)
  ,{8}  -- transaction_date - IN datetime
  ,{9}  -- note 
  ,1   -- status - IN tinyint(4)
  ,now()  -- date_added - IN datetime
)", Utils.FormatDBIntegers(contributor_id)
  , Utils.FormatDBIntegers(account_id)
  , Utils.FormatDBText(name)
  , Utils.FormatDBText(category)
  , Utils.FormatDBIntegers(trans_type)
  , Utils.FormatDBIntegers(trans_mode)
  , Utils.FormatDBIntegers(amount)
  , Utils.FormatDBText(checque_number)
  , Utils.FormatDBText(transaction_date.ToString("yyyy-MM-dd"))
  , Utils.FormatDBText(note));

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
        
        private void button3_Click(object sender, EventArgs e)
        {
            Control.ControlCollection collection = this.tabControl1.SelectedTab.Controls;
            Control GroupControl = (Control)collection.Cast<Control>().Where(x => x.AccessibleName == "SearchGroupBox").FirstOrDefault();
           
            Utils.ResetAllControls(GroupControl);
        }
        private void LoadSearchResultDataGrid()
        {
            string searchSQL = this.GetSearchSQL();
            
            MySqlConnection mySqlConn = new MySqlConnection(connString);
            mySqlConn.Open();

            decimal SearchAmount = 0;
            decimal OpeningBalance = 0;

            try
            {
                List<CVD> openingBalanceList = this.cvd.GetCVD("TEMP", "opening_balance");
                OpeningBalance = openingBalanceList.Count > 0 ? decimal.Parse(openingBalanceList[0].Value) : OpeningBalance;
                
                System.Data.DataTable dt = new System.Data.DataTable();

                dt = Utils.GetDataTable(mySqlConn, searchSQL);
                
                SearchResultsDataGridView.Rows.Clear();
                SearchResultsDataGridView.Refresh();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        int n = SearchResultsDataGridView.Rows.Add();
                        SearchResultsDataGridView.Rows[n].Cells["IDSearch"].Value = dRow["Contribution Id"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["AccountNameSearch"].Value = dRow["Account Name"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["CNameSearch"].Value = dRow["Name"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["CategorySearch"].Value = dRow["Category"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["TypeSearch"].Value = dRow["Type"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["ModeSearch"].Value = dRow["Mode"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["ChecknoSearch"].Value = dRow["Check #"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["AmountSearch"].Value = dRow["Amount"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["TransDtSearch"].Value = dRow["Trans DT"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["NoteSearch"].Value = dRow["Note"].ToString();
                        SearchResultsDataGridView.Rows[n].Cells["DateAddedSearch"].Value = dRow["Date Added"].ToString();

                        if (dRow["Type"].ToString().Equals("Debit", StringComparison.InvariantCultureIgnoreCase))
                            SearchAmount = SearchAmount - decimal.Parse(dRow["Amount"].ToString());
                        else
                            SearchAmount = SearchAmount + decimal.Parse(dRow["Amount"].ToString());
                    }

                    SearchResultsDataGridView.Rows[0].Selected = true;
                }
                
                SearchResultsDataGridView.AutoResizeRows();
                SearchAmountValue.Text = SearchAmount.ToString();

                SearchTabOpeningBalanceValue.Text = OpeningBalance.ToString();
                CurrentSearchBalance.Text = (OpeningBalance + SearchAmount).ToString();
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

            string searchSQL = string.Format(@"SELECT 
       cn.contribution_id as 'Contribution Id',
       acc.account_name as 'Account Name',
       CASE
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
       JOIN account acc on acc.account_id = cn.account_id
          AND acc.status = 1
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

            if (!string.IsNullOrEmpty(SearchAccountNameComboBox.Text))
            {
                if (!string.IsNullOrEmpty(where))
                    where += " and ";

                Item accountNameItem = (Item)SearchAccountNameComboBox.SelectedItem;

                where += string.Format("cn.account_id = {0}", accountNameItem.Id);
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

                    //sb.AppendLine();
                    //sb.AppendFormat("{0},,,,{1},,,,", "Total", total);

                    File.WriteAllText(Path, sb.ToString());

                    MessageBox.Show(string.Format("File [{0}] created", sfd.FileName));
                }
            }
            else
            {
                MessageBox.Show("No records returned to be exported.");
            }
        }

        private void OpeningBalanceAddUpdateButton_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConn = null;

            try
            {
                int count = 0;
                decimal ob = 0M;
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                DialogResult result = MessageBox.Show("Please confirm?", "Confirm", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!string.IsNullOrEmpty(OpeningBalanceTextBox.Text))
                    {
                        if (decimal.TryParse(OpeningBalanceTextBox.Text, out ob))
                        {
                            if (!decimal.Equals(decimal.Parse(OpeningBalanceTextBox.Text), 0M))
                            {
                                if (this.cvd.GetCVD("TEMP", "opening_balance").Count > 0)
                                {
                                    int column_value_desc_id = this.cvd.GetCVD("TEMP", "opening_balance")[0].ColumnValueDescID;
                                    string updateSql = string.Format(@"UPDATE column_value_desc cvd
   SET value = '{0}',
       description = '{0}',
       date_changed = now()
 WHERE column_value_desc_id = {1};", OpeningBalanceTextBox.Text
                                               , column_value_desc_id);

                                    MySqlCommand cmd = new MySqlCommand(updateSql, mySqlConn);
                                    count = cmd.ExecuteNonQuery();

                                    MessageBox.Show("Opening Balance Updated.");
                                }
                                else
                                {
                                    string addSql = string.Format(@"
DROP TABLE IF EXISTS t_OB;
CREATE TEMPORARY TABLE t_OB(table_name varchar(30), column_name varchar(30));

INSERT INTO t_OB
VALUES ('TEMP', 'opening_balance');

INSERT INTO table_column(table_column_id,
                         table_name,
                         column_name,
                         status,
                         date_added)
   SELECT fn_get_nextid('BIPC', 'table_column'),
          t.table_name,
          t.column_name,
          1,
          now()
     FROM t_OB t
          LEFT JOIN table_column tc
             ON     tc.table_name = t.table_name
                AND tc.column_name = t.column_name
    WHERE tc.table_column_id IS NULL;

INSERT INTO column_value_desc(column_value_desc_id,
                              table_column_id,
                              value,
                              description,
                              date_added)
   VALUES (  fn_get_nextid('BIPC', 'column_value_desc'),
             (SELECT table_column_id
                FROM table_column
               WHERE table_name = 'TEMP' AND column_name = 'opening_balance' and status = 1),
             '{0}',
             '{0}',
             now());", OpeningBalanceTextBox.Text);

                                    MySqlCommand cmd = new MySqlCommand(addSql, mySqlConn);
                                    count = cmd.ExecuteNonQuery();

                                    MessageBox.Show("Opening Balance Added.");

                                    OpeningBalanceAddUpdateButton.Text = "Update";
                                }

                                this.LoadCVD();
                                this.LoadOpeningBalance();
                                this.LoadSearchResultDataGrid();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid decimal value");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Opening balance entered is either invalid or 0");
                    }
                }
                else
                {
                    this.LoadOpeningBalance();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(string.Format("Error Adding/Updating Opening balance : {0}", ex.Message));
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.LoadFormData();

            MessageBox.Show("All Form data loaded.", "Result", MessageBoxButtons.OK);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataGridViewRow row = dataGridView1.CurrentRow;
            //MessageBox.Show(row.Cells["ID"].Value.ToString());

        }

        private void EditSearchRow_Click(object sender, EventArgs e)
        {
            if (SearchResultsDataGridView.SelectedRows.Count > 0)
            {
                if (SearchResultsDataGridView.SelectedRows.Count > 1)
                    MessageBox.Show("Multiple records cannot be selected to EDIT. Please select only one.");
                else
                {
                    DialogResult result = MessageBox.Show("Inorder to EDIT, need to Redirect to EDIT Mode screen?", "Redirect?", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        tabControl1.SelectedTab = AddUpdateExpenditureTab;
                        EditModeLabel.ForeColor = Color.DarkGoldenrod;
                        EditModeLabel.Text = string.Format("EDIT MODE, PREPOPULATED WITH VALUES FROM EXPENDITURE ID {0}", SearchResultsDataGridView.SelectedRows[0].Cells["IDSearch"].Value.ToString());

                        EditModelink.ActiveLinkColor = Color.DarkGoldenrod;
                        EditModelink.Text = "CANCEL EDIT MODE";

                        AddUpdateFormGroup.BackColor = Color.DarkGoldenrod;

                        AddUpdateButton.Text = "Update";

                        ContributionIdHidden.Text = SearchResultsDataGridView.SelectedRows[0].Cells["IDSearch"].Value.ToString();

                        foreach(DataGridViewRow row in DashboardContributionsDataGridView.Rows)
                        {
                            string ID = row.Cells["ID"].Value.ToString();
                            if (ID.Equals(SearchResultsDataGridView.SelectedRows[0].Cells["IDSearch"].Value.ToString()))
                            {
                                DashboardContributionsDataGridView.ClearSelection();
                                DashboardContributionsDataGridView.Rows[row.Index].Selected = true;
                            }
                        }

                        this.PreloadEditModeFormWithValues(SearchResultsDataGridView.SelectedRows[0].Cells["IDSearch"].Value.ToString());

                        EditModeHidden.Text = "EDIT";
                    }
                }
            }
            else
            {
                MessageBox.Show("No rows were selected");
            }
        }

        private void PreloadEditModeFormWithValues(string contribution_id)
        {
            MySqlConnection mySqlConn = null;

            try
            {
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                string sql = string.Format(@"SELECT cn.contribution_id,
           cn.contribution_name,
           cn.contributor_id,
           cn.account_id,
           cn.category,
           cn.transaction_type,
           cn.transaction_mode,
           cn.amount,
           cn.check_number,
           cn.transaction_date,
           cn.note
      FROM contribution cn
     WHERE cn.contribution_id = {0}", contribution_id);

                System.Data.DataTable dt = new System.Data.DataTable();

                dt = Utils.GetDataTable(mySqlConn, sql);

                if (dt != null)
                {
                    foreach(DataRow dRow in dt.Rows)
                    {
                        // Load account name
                        foreach(Item accountNameItem in AccountNameComboBox.Items)
                        {
                            if(accountNameItem.Id == dRow["account_id"].ToString())
                            {
                                AccountNameComboBox.SelectedItem = accountNameItem;
                                break;
                            }
                        }

                        // Load Contributor name
                        NameTextBox.Text = dRow["contribution_name"].ToString();

                        // Load Contributor Id/Name combo box
                        foreach (Item d in ContributorIdComboBox.Items)
                        {
                            if (d.Id == dRow["contributor_id"].ToString())
                            {
                                ContributorIdComboBox.SelectedItem = d;
                                break;
                            }
                        }

                        foreach (Item cc in CategoryCombo.Items)
                        {
                            if (cc.Id == dRow["category"].ToString())
                            {
                                CategoryCombo.SelectedItem = cc;
                                break;
                            }
                        }

                        if (this.cvd.GetCVDDescription("contribution", "transaction_type", dRow["transaction_type"].ToString()).Equals("Credit", StringComparison.InvariantCultureIgnoreCase))
                        {
                            CreditRadioButton.Checked = true;
                        }
                        else
                        {
                            DebitRadionButton.Checked = true;
                        }

                        if (this.cvd.GetCVDDescription("contribution", "transaction_mode", dRow["transaction_mode"].ToString()).Equals("Cash", StringComparison.InvariantCultureIgnoreCase))
                        {
                            CashRadionButton.Checked = true;
                        }
                        else if (this.cvd.GetCVDDescription("contribution", "transaction_mode", dRow["transaction_mode"].ToString()).Equals("Check", StringComparison.InvariantCultureIgnoreCase))
                        {
                            CheckRadionButton.Checked = true;
                        }
                        else if(this.cvd.GetCVDDescription("contribution", "transaction_mode", dRow["transaction_mode"].ToString()).Equals("Online", StringComparison.InvariantCultureIgnoreCase))
                        {
                            OnlineRadioButton.Checked = true;
                        }
                        else
                        {
                            CardRadioButton.Checked = true;
                        }

                        AmountTextBox.Text = dRow["amount"].ToString();
                        CheckTextBox.Text = dRow["check_number"].ToString();
                        NoteTextBox.Text = dRow["note"].ToString();
                        TransactionDateTimePicker.Value = Convert.ToDateTime(dRow["transaction_date"].ToString()); 
                    }
                }

            }
            catch
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private int UpdateRecord(string contributor_id, string account_id, string name, string category, string trans_type, string trans_mode, string checque_number, string amount, DateTime transaction_date, string note)
        {
            int count = 0;
            MySqlConnection mySqlConn = null;

            try
            {
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();
                string updateSql = string.Format(@"UPDATE contribution
   SET contributor_id = {0},
       account_id = {1},
       contribution_name = {2},
       category = {3},
       transaction_type = {4},
       transaction_mode = {5},
       amount = {6},
       check_number = {7},
       transaction_date = {8},
       note = {9},
       date_changed = now()
 WHERE contribution_id = {10}", Utils.FormatDBIntegers(contributor_id)
  , Utils.FormatDBIntegers(account_id)
  , Utils.FormatDBText(name)
  , Utils.FormatDBText(category)
  , Utils.FormatDBIntegers(trans_type)
  , Utils.FormatDBIntegers(trans_mode)
  , Utils.FormatDBIntegers(amount)
  , Utils.FormatDBText(checque_number)
  , Utils.FormatDBText(transaction_date.ToString("yyyy-MM-dd"))
  , Utils.FormatDBText(note)
  , ContributionIdHidden.Text);

                MySqlCommand cmd = new MySqlCommand(updateSql, mySqlConn);
                count = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
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

        private void DeleteSearchRow_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConn = null;

            try
            {
                int count = 0;
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();
                List<string> contributionIdList = new List<string>();
                string contributionIds = string.Empty;

                if (SearchResultsDataGridView.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete these records?", "Confirm", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in SearchResultsDataGridView.SelectedRows)
                        {
                            Account acc = this.AccountList.Where(x => x.Value.AccountName == row.Cells["AccountNameSearch"].Value.ToString())
                                           .FirstOrDefault()
                                           .Value;

                            if (acc.IsClosed)
                                throw new Exception($"Account [{acc.AccountName}] is closed. Transactions cannot be deleted on this account. Please re-open the account to make any changes to the account");
                            
                            contributionIdList.Add(row.Cells["IDSearch"].Value.ToString());
                        }

                        contributionIds = string.Join(",", contributionIdList);

                        string sql = string.Format(@"UPDATE contribution
   SET status = 0, date_changed = now()
 WHERE contribution_id IN ({0})", contributionIds);

                        MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                        count = cmd.ExecuteNonQuery();

                        MessageBox.Show(string.Format("{0} expenditure records deleted.", contributionIdList.Count));
                        
                        this.LoadContributionsDataGridView();
                        this.LoadSearchResultDataGrid();
                    }
                }
                else
                {
                    MessageBox.Show("No rows were selected");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void EditModelink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.CancelEditMode();
        }

        private void CancelEditMode()
        {
            EditModeLabel.ForeColor = Color.Green;
            EditModeLabel.Text = string.Empty;

            EditModelink.ActiveLinkColor = Color.Green;
            EditModelink.Text = string.Empty;

            Control.ControlCollection collection = AddUpdateExpenditureTab.Controls;
            Control GroupControl = (Control)collection.Cast<Control>().Where(x => x.AccessibleName == "AddUpdateFormGroup").FirstOrDefault();

            Utils.ResetAllControls(GroupControl);

            DashboardContributionsDataGridView.ClearSelection();
            DashboardContributionsDataGridView.Rows[0].Selected = true;

            AddUpdateFormGroup.BackColor = Color.Transparent;

            AddUpdateButton.Text = "Add";
            EditModeHidden.Text = string.Empty;
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            SearchResultsDataGridView.SelectAll();
        }

        private void DeselectAll_Click(object sender, EventArgs e)
        {
            SearchResultsDataGridView.ClearSelection();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedTab == SearchExpendituresTab || tabControl1.SelectedTab == MiscellaneousTab)
            {
                if (EditModeHidden.Text == "EDIT")
                {
                    DialogResult result = MessageBox.Show("Would you like to cancel EDIT mode?", "Cancel Edit Mode?", MessageBoxButtons.YesNo);

                    if (result != System.Windows.Forms.DialogResult.Yes)
                    {
                        tabControl1.SelectedTab = AddUpdateExpenditureTab;
                    }
                    else
                    {
                        this.CancelEditMode();
                    }
                }
            }
        }

        private void DeleteInAddUpdatePage_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConn = null;

            try
            {
                int count = 0;
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();
                List<string> contributionIdList = new List<string>();
                string contributionIds = string.Empty;

                if (DashboardContributionsDataGridView.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete these records?", "Confirm", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in DashboardContributionsDataGridView.SelectedRows)
                        {
                            Account acc = this.AccountList.Where(x => x.Value.AccountName == row.Cells["CDataGridAccountName"].Value.ToString())
                                        .FirstOrDefault()
                                        .Value;

                            if (acc.IsClosed)
                                throw new Exception($"Account [{acc.AccountName}] is closed. Transactions cannot be deleted on this account. Please re-open the account to make any changes to the account");

                            contributionIdList.Add(row.Cells["ID"].Value.ToString());
                        }

                        contributionIds = string.Join(",", contributionIdList);

                        string sql = string.Format(@"UPDATE contribution
   SET status = 0, date_changed = now()
 WHERE contribution_id IN ({0})", contributionIds);

                        MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                        count = cmd.ExecuteNonQuery();

                        MessageBox.Show(string.Format("{0} expenditure records deleted.", contributionIdList.Count));
                        
                        this.LoadContributionsDataGridView();
                        this.LoadSearchResultDataGrid();
                    }
                }
                else
                {
                    MessageBox.Show("No rows were selected");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void EditInAddUpdatePage_Click(object sender, EventArgs e)
        {
            if (DashboardContributionsDataGridView.SelectedRows.Count > 0)
            {
                if (DashboardContributionsDataGridView.SelectedRows.Count > 1)
                    MessageBox.Show("Multiple records cannot be selected to EDIT. Please select only one.");
                else
                {
                    EditModeLabel.ForeColor = Color.DarkGoldenrod;
                    EditModeLabel.Text = string.Format("EDIT MODE, PREPOPULATED WITH VALUES FROM EXPENDITURE ID {0}", DashboardContributionsDataGridView.SelectedRows[0].Cells["ID"].Value.ToString());

                    EditModelink.ActiveLinkColor = Color.DarkGoldenrod;
                    EditModelink.Text = "CANCEL EDIT MODE";

                    AddUpdateFormGroup.BackColor = Color.DarkGoldenrod;

                    AddUpdateButton.Text = "Update";

                    ContributionIdHidden.Text = DashboardContributionsDataGridView.SelectedRows[0].Cells["ID"].Value.ToString();

                    this.PreloadEditModeFormWithValues(DashboardContributionsDataGridView.SelectedRows[0].Cells["ID"].Value.ToString());

                    EditModeHidden.Text = "EDIT";
                }
            }
            else
            {
                MessageBox.Show("No rows were selected");
            }
        }

        private void SelectAllOnAddUpdatePage_Click(object sender, EventArgs e)
        {
            DashboardContributionsDataGridView.SelectAll();
        }

        private void DeSelectAllOnAddUpdatePage_Click(object sender, EventArgs e)
        {
            DashboardContributionsDataGridView.ClearSelection();
        }

        private void LoadAllContributorNames()
        {
            MySqlConnection mySqlConn = new MySqlConnection(connString);
            MySqlCommand cmdDataBase = new MySqlCommand(@"select contributor_id, first_name, last_name, IFNULL(date_changed, date_added) as last_updated  from contributor where status = 1;", mySqlConn);

            ContributorList.Clear();
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        ContributorList.Add(dRow["contributor_id"].ToString(), new Contributor(dRow));
                    }
                }
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void UpdateNamesTableButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            MySqlConnection mySqlConn = null;
            bool validationFlag = true;
                
            try
            {
                DialogResult result = MessageBox.Show("Are you sure to Add/Update this record set?", "Confirm", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    mySqlConn = new MySqlConnection(connString);
                    mySqlConn.Open();

                    foreach (DataGridViewRow NGVRow in ContributorNameGridView.Rows)
                    {
                        if (string.IsNullOrEmpty((string)NGVRow.Cells["ContributorId"].Value))
                        {
                            if (string.IsNullOrEmpty((string)NGVRow.Cells["FirstName"].Value) &&
                                (string.IsNullOrEmpty((string)NGVRow.Cells["LastName"].Value)))
                            {
                            }
                            else
                            {
                                string FirstName = (string)NGVRow.Cells["FirstName"].Value;
                                string LastName = (string)NGVRow.Cells["LastName"].Value;

                                if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
                                {
                                    validationFlag = false;
                                }
                                else
                                {
                                    string sql = string.Format(@"
INSERT INTO contributor (
   contributor_id
  ,first_name
  ,last_name
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'contributor')
  ,'{0}' -- first_name - IN varchar(50)
  ,'{1}'  -- last_name - IN varchar(50)
  ,now()  -- date_added - IN datetime
)", FirstName, LastName);

                                    MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                                    count = cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            Contributor c = (Contributor)this.ContributorList.Where(s => s.Key == (string)NGVRow.Cells["ContributorId"].Value).FirstOrDefault().Value;

                            string FirstName = (string)NGVRow.Cells["FirstName"].Value;
                            string LastName = (string)NGVRow.Cells["LastName"].Value;

                            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
                            {
                                validationFlag = false;
                            }
                            else
                            {
                                if (!c.FirstName.Equals(FirstName) ||
                                    !c.LastName.Equals(LastName))
                                {
                                    string sql = string.Format(@"Update contributor 
                                                    set first_name = {0},
                                                        last_name = {1},
                                                        date_changed = now()
                                                    where contributor_id = {2}", Utils.FormatDBText(FirstName)
                                                                                       , Utils.FormatDBText(LastName)
                                                                                       , (string)NGVRow.Cells["ContributorId"].Value);

                                    MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                                    count = cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    this.LoadContributorNamesDataGridView();
                    this.LoadSearchNameDropDown();
                    this.LoadContributorIdComboBox();

                    if (!validationFlag)
                        MessageBox.Show("First Name / Last Name cannot be empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failure");
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void DeleteNames_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConn = null;

            try
            {
                int count = 0;
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();
                List<string> contributorIdList = new List<string>();
                string contributorIds = string.Empty;

                if (ContributorNameGridView.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete these records?", "Confirm", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in ContributorNameGridView.SelectedRows)
                        {
                            contributorIdList.Add(row.Cells["ContributorId"].Value.ToString());
                        }

                        contributorIds = string.Join(",", contributorIdList);

                        string sql = string.Format(@"UPDATE contributor
   SET status = 0, date_changed = now()
 WHERE contributor_id IN ({0})", contributorIds);

                        MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                        count = cmd.ExecuteNonQuery();

                        MessageBox.Show(string.Format("{0} name record(s) deleted.", contributorIdList.Count));

                        this.LoadContributorNamesDataGridView();
                        this.LoadSearchNameDropDown();
                        this.LoadContributorIdComboBox();
                    }
                }
                else
                {
                    MessageBox.Show("No rows were selected");
                }
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        #region Loan

        private void AddLoanButton_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConn = null;
            bool valid = true;

            try
            {
                int count = 0;
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                string contributorName = string.Empty;
                
                // Contributor name
                if (!string.IsNullOrEmpty(loanComboBox.Text))
                {
                    Item SelectedCategory = (Item)loanComboBox.SelectedItem;
                    contributorName = SelectedCategory.Id;
                }
                else
                {
                    MessageBox.Show("Name cannot be empty");
                    valid = false;
                }

                // Amount
                string amount = loanAmountTextBox.Text;
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
                    string sql = $@"INSERT INTO contributor_loan(
   contributor_loan_id
  ,contributor_id
  ,loan_amount
  ,date_added
) VALUES (
   fn_get_nextid('BIPC', 'contributor_loan') -- contributor_loan_id - IN int(11)
  ,'{contributorName}' -- contributor_id - IN int(11)
  ,{amount} -- loan_amount - IN decimal(11,2)
  ,now()  -- date_added - IN datetime
);";

                    MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                    count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        MessageBox.Show($"{count} loan records added");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failure");
            }
            finally
            {
                if (mySqlConn != null)
                {
                    mySqlConn.Close();
                }
            }
        }

        private void LoadLoanContributorNames()
        {
            MySqlConnection mySqlConn = new MySqlConnection(connString);
            MySqlCommand cmdDataBase = new MySqlCommand(@"SELECT c.contributor_id,
       c.first_name,
       c.last_name,
       cl.loan_amount,
       cl.date_added,
       cl.date_changed
FROM contributor_loan cl
     JOIN contributor c
        ON c.contributor_id = cl.contributor_id AND c.status = 1
WHERE cl.status = 1;", mySqlConn);
            
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        ContributorList.Add(dRow["contributor_id"].ToString(), new Contributor(dRow));
                    }
                }
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }
        
        public List<ContributorLoan> LoadLoanContributorList()
        {
            MySqlConnection mySqlConn = new MySqlConnection(connString);
            List<ContributorLoan> contributorLoanList = new List<ContributorLoan>();

            try
            {
                MySqlCommand cmdDataBase = new MySqlCommand(@"SELECT cl.contributor_loan_id,
    c.contributor_id,
    c.first_name,
    c.last_name,
    cl.loan_amount,
    cl.date_added,
    cl.date_changed
FROM contributor_loan cl
    JOIN contributor c
    ON c.contributor_id = cl.contributor_id AND c.status = 1
WHERE cl.status = 1;", mySqlConn);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        contributorLoanList.Add(new ContributorLoan
                        {
                            ContributorLoanId = dRow["contributor_loan_id"].ToString(),
                            ContributorId = dRow["contributor_id"].ToString(),
                            FirstName = dRow["first_name"].ToString(),
                            LastName = dRow["last_name"].ToString(),
                            LoanAmount = decimal.Parse(dRow["loan_amount"].ToString())
                        });
                    }
                }
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }

            return contributorLoanList;
        }

        public void LoadLoanContributorDataGridView()
        {
            MySqlConnection mySqlConn = new MySqlConnection(connString);

            try
            {
                MySqlCommand cmdDataBase = new MySqlCommand(@"SELECT cl.contributor_loan_id,
       c.contributor_id,
       c.first_name,
       c.last_name,
       cl.loan_amount,
       cl.date_added,
       cl.date_changed
FROM contributor_loan cl
     JOIN contributor c
        ON c.contributor_id = cl.contributor_id AND c.status = 1
WHERE cl.status = 1;", mySqlConn);

                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                loanContributorDataGridView.Rows.Clear();
                loanContributorDataGridView.Refresh();

                LoanLookupTransComboBox.Items.Clear();
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        int n = loanContributorDataGridView.Rows.Add();
                        loanContributorDataGridView.Rows[n].Cells["ContributorLoanId"].Value = dRow["contributor_loan_id"];
                        loanContributorDataGridView.Rows[n].Cells["ContributorIdNotVisible"].Value = dRow["Contributor_id"];
                        loanContributorDataGridView.Rows[n].Cells["LoanFirstLastName"].Value = $"{dRow["last_name"].ToString()}, {dRow["first_name"].ToString()}";
                        loanContributorDataGridView.Rows[n].Cells["LoanAmountGrid"].Value = dRow["loan_amount"];
                        
                        LoanLookupTransComboBox.Items.Add(new Item($"{dRow["last_name"].ToString()}, {dRow["first_name"].ToString()}", dRow["contributor_id"].ToString()));

                        LoanLookupTransComboBox.ValueMember = "Id";
                        LoanLookupTransComboBox.DisplayMember = "Name";
                        LoanLookupTransComboBox.SelectedIndex = 0;
                    }
                }

                loanContributorDataGridView.AutoResizeRows();
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        public void LoadLoanTransactionsDataGrid()
        {
            string contributorId = string.Empty;

            // Contributor name
            if (!string.IsNullOrEmpty(LoanLookupTransComboBox.Text))
            {
                Item SelectedCategory = (Item)LoanLookupTransComboBox.SelectedItem;
                contributorId = SelectedCategory.Id;
                
                string searchSQL = $@"SELECT 
       cn.contribution_id as 'Contribution Id',
       CASE
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
             AND cvd_transmode.status = 1
       where cn.contributor_id = {contributorId}
         AND cvd.description = 'LOAN'
         AND cvd_transtype.description = 'Credit'";

                MySqlConnection mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();

                try
                {
                    decimal totalLoanPayment = 0.0m;
                    System.Data.DataTable dt = new System.Data.DataTable();

                    dt = Utils.GetDataTable(mySqlConn, searchSQL);

                    LoanTransactionsGridView.Rows.Clear();
                    LoanTransactionsGridView.Refresh();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dRow in dt.Rows)
                        {
                            int n = LoanTransactionsGridView.Rows.Add();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsName"].Value = dRow["Name"].ToString();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsCategory"].Value = dRow["Category"].ToString();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsType"].Value = dRow["Type"].ToString();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsMode"].Value = dRow["Mode"].ToString();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsCheckNumber"].Value = dRow["Check #"].ToString();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsAmount"].Value = dRow["Amount"].ToString();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsTransDt"].Value = dRow["Trans DT"].ToString();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsNote"].Value = dRow["Note"].ToString();
                            LoanTransactionsGridView.Rows[n].Cells["LoanTransactionsDateAdded"].Value = dRow["Date Added"].ToString();

                            if (dRow["Type"].ToString() == "Credit")
                                totalLoanPayment = totalLoanPayment + decimal.Parse(dRow["Amount"].ToString());
                            else
                                totalLoanPayment = totalLoanPayment - decimal.Parse(dRow["Amount"].ToString());
                        }

                        LoanTransactionsGridView.Rows[0].Selected = true;
                    }

                    LoanTransactionsGridView.AutoResizeRows();

                    List<ContributorLoan> contributorLoanList = LoadLoanContributorList();
                    decimal loanAmount = contributorLoanList.Where(x => x.ContributorId == contributorId)
                        .Select(x => x.LoanAmount)
                        .ToList()
                        .FirstOrDefault();

                    RemainingLoanAmountLabel.Text = (loanAmount - totalLoanPayment).ToString();

                }
                finally
                {
                    if (mySqlConn != null)
                        mySqlConn.Close();
                }
            }
        }
        
        #endregion

        private void DeleteLoanContrubutorButton_Click(object sender, EventArgs e)
        {

        }

        private void AddUpdateLoanContributorButtonGrid_Click(object sender, EventArgs e)
        {
            int count = 0;
            MySqlConnection mySqlConn = null;

            try
            {
                DialogResult result = MessageBox.Show("Are you sure to Add/Update this record set?", "Confirm", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    mySqlConn = new MySqlConnection(connString);
                    mySqlConn.Open();

                    foreach (DataGridViewRow NGVRow in loanContributorDataGridView.Rows)
                    {
                        if (NGVRow.Cells["ContributorLoanId"].Value != null)
                        {
                            if (string.IsNullOrEmpty(NGVRow.Cells["ContributorLoanId"].Value.ToString()))
                            {
                                if (string.IsNullOrEmpty(NGVRow.Cells["LoanFirstName"].Value.ToString()) &&
                                    (string.IsNullOrEmpty(NGVRow.Cells["LoanLastName"].Value.ToString())) &&
                                    string.IsNullOrEmpty(NGVRow.Cells["LoanAmountGrid"].Value.ToString()))
                                {
                                }
                                else
                                {
                                    string FirstName = NGVRow.Cells["LoanFirstName"].Value.ToString();
                                    string LastName = NGVRow.Cells["LoanFirstName"].Value.ToString();
                                    Decimal AmountGrid = Decimal.Parse(NGVRow.Cells["LoanAmountGrid"].Value.ToString());

                                    if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
                                    {
                                        MessageBox.Show("First Name / Last Name cannot be empty");
                                        break;
                                    }
                                    else
                                    {
                                        string sql = string.Format(@"
INSERT INTO contributor_loan (
   contributor_loan_id
  ,first_name
  ,last_name
  ,date_added
) VALUES (
  fn_get_nextid('BIPC', 'contributor')
  ,'{0}' -- first_name - IN varchar(50)
  ,'{1}'  -- last_name - IN varchar(50)
  ,now()  -- date_added - IN datetime
)", FirstName, LastName);

                                        MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                                        count = cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                Contributor c = (Contributor)this.ContributorList.Where(s => s.Key == NGVRow.Cells["ContributorIdNotVisible"].Value.ToString()).FirstOrDefault().Value;

                                string loanAmount = NGVRow.Cells["LoanAmountGrid"].Value.ToString();

                                decimal tLoanAmount;
                                if (!decimal.TryParse(loanAmount, out tLoanAmount))
                                {
                                    MessageBox.Show("Loan amount is not a valid decimal");
                                    break;
                                }

                                Decimal loanAmountGrid = Decimal.Parse(NGVRow.Cells["LoanAmountGrid"].Value.ToString());

                                string sql = string.Format(@"Update contributor_loan 
                                            set loan_amount = {0},
                                                date_changed = now()
                                            where contributor_id = {1}", Utils.FormatDBText(loanAmountGrid.ToString())
                                                                            , NGVRow.Cells["ContributorIdNotVisible"].Value.ToString());

                                MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                                count = cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failure");
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void LoanLookupTransComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadLoanTransactionsDataGrid();
        }
        
        private void UpdateAccountButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            bool validationFlag = true;
            bool recordsUpdated = false;

            MySqlConnection mySqlConn = null;
            string errorMsg = string.Empty;
            
            try
            {
                DialogResult result = MessageBox.Show("Are you sure to Add/Update this record set?", "Confirm", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    mySqlConn = new MySqlConnection(connString);
                    mySqlConn.Open();

                    string accountNumber = string.Empty;
                    string accountName = string.Empty;
                    string bankName = string.Empty;
                    bool isClosed = false;
                    string openingBalance = string.Empty;
                    
                    foreach (DataGridViewRow NGVRow in AccountDataGrid.Rows)
                    {
                        accountNumber = (string)NGVRow.Cells["AccountNumberDataGridColumn"].Value;
                        accountName = (string)NGVRow.Cells["AccountNameDataGridColumn"].Value;
                        bankName = (string)NGVRow.Cells["BankNameDataGridColumn"].Value;
                        if ((NGVRow.Cells["IsClosedDataGridColumn"].Value != null && (bool)NGVRow.Cells["IsClosedDataGridColumn"].Value != false))
                            isClosed = true;
                        else
                            isClosed = false;

                        openingBalance = (string)NGVRow.Cells["OpeningBalanceDataGridColumn"].Value;

                        if (string.IsNullOrEmpty(accountNumber) &&
                            string.IsNullOrEmpty(accountName) &&
                            string.IsNullOrEmpty(bankName) &&
                            string.IsNullOrEmpty(openingBalance))
                        {
                        }
                        else
                        {
                            if (string.IsNullOrEmpty((string)NGVRow.Cells["AccountIdDataGridColumn"].Value))
                            {
                                // Insert into Account table
                                string sql = string.Format(@"
INSERT INTO account(account_id,
                         account_number,
                         account_name,
                         bank_name,
                         account_end_date,
                         initial_balance,
                         date_added)
VALUES (fn_get_nextid('bipc', 'account'),
        {0},
        {1},
        {2},
        {3},
        {4},
        now());"
            , Utils.FormatDBText(accountNumber)
            , Utils.FormatDBText(accountName)
            , Utils.FormatDBText(bankName)
            , isClosed ? "now()" : Utils.FormatDBText(string.Empty)
            , Utils.FormatDBIntegers(openingBalance));

                                MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                                count = cmd.ExecuteNonQuery();

                                recordsUpdated = true;
                            }
                            else
                            {
                                Account c = (Account)this.AccountList.Where(s => s.Key == (string)NGVRow.Cells["AccountIdDataGridColumn"].Value).FirstOrDefault().Value;

                                if (string.IsNullOrEmpty(accountName))
                                {
                                    validationFlag = false;
                                }

                                if (validationFlag)
                                {
                                    if (!c.AccountName.Equals(accountName) ||
                                        !c.AccountNumber.Equals(accountNumber) ||
                                        !c.BankName.Equals(bankName) ||
                                        !c.InitialBalance.Equals(openingBalance) ||
                                        !c.IsClosed.Equals(isClosed))
                                    {
                                        string sql = string.Format(@"UPDATE account
SET account_number = {0} -- varchar(50)
  ,account_name = {1} -- varchar(100)
  ,bank_name = {2} -- varchar(50)
  ,account_end_date = {3} -- datetime
  ,initial_balance = {4} -- decimal(11,2)
  ,date_changed = now() -- datetime
WHERE account_id = {5} -- int(11)", Utils.FormatDBText(accountNumber)
                                      , Utils.FormatDBText(accountName)
                                      , Utils.FormatDBText(bankName)
                                      , isClosed ? "now()" : Utils.FormatDBText(string.Empty)
                                      , Utils.FormatDBIntegers(openingBalance)
                                      , (string)NGVRow.Cells["AccountIdDataGridColumn"].Value);

                                        MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                                        count = cmd.ExecuteNonQuery();

                                        recordsUpdated = true;
                                    }
                                }
                            }
                        }
                    }
                    
                    if (!validationFlag)
                        MessageBox.Show("Some required fields are empty");

                    if (recordsUpdated)
                        MessageBox.Show("Accounts have been updated", "Success");
                    else
                        MessageBox.Show("No records were updated");

                    // Refresh all accounts
                    this.LoadAccountDataGridView();
                    this.LoadAccountNameComboBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failure");
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void LoadAccountDataGridView()
        {
            try
            {
                this.LoadAllAccounts();

                AccountDataGrid.Rows.Clear();
                AccountDataGrid.Refresh();

                if (this.AccountList != null)
                {
                    foreach (KeyValuePair<string, Account> namePair in this.AccountList)
                    {
                        Account acc = namePair.Value;

                        int n = AccountDataGrid.Rows.Add();
                        AccountDataGrid.Rows[n].Cells["AccountIdDataGridColumn"].Value = namePair.Key;
                        AccountDataGrid.Rows[n].Cells["AccountNumberDataGridColumn"].Value = acc.AccountNumber;
                        AccountDataGrid.Rows[n].Cells["AccountNameDataGridColumn"].Value = acc.AccountName;
                        AccountDataGrid.Rows[n].Cells["BankNameDataGridColumn"].Value = acc.BankName;
                        AccountDataGrid.Rows[n].Cells["IsClosedDataGridColumn"].Value = acc.IsClosed;
                        AccountDataGrid.Rows[n].Cells["OpeningBalanceDataGridColumn"].Value = acc.InitialBalance;
                    }
                }

                AccountDataGrid.AutoResizeRows();
            }
            finally
            {

            }
        }

        public void LoadAllAccounts()
        {
            MySqlConnection mySqlConn = new MySqlConnection(connString);
            MySqlCommand cmdDataBase = new MySqlCommand(@"SELECT account_id,
       account_number,
       account_name,
       bank_name,
       account_end_date,
       initial_balance,
       date_added
  FROM account
 WHERE status = 1
 ORDER BY date_added;
;", mySqlConn);

            AccountList.Clear();
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                System.Data.DataTable dt = new System.Data.DataTable();
                sda.Fill(dt);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dRow in dt.Rows)
                    {
                        AccountList.Add(dRow["account_id"].ToString(), new Account(dRow));
                    }
                }
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConn = null;

            try
            {
                string errorMsg = string.Empty;
                int resultCount = 0;
                mySqlConn = new MySqlConnection(connString);
                mySqlConn.Open();
                List<string> accountIdList = new List<string>();
                string accountIds = string.Empty;

                if (AccountDataGrid.SelectedRows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("Are you sure to delete these records?", "Confirm", MessageBoxButtons.YesNo);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in AccountDataGrid.SelectedRows)
                        {
                            var accountId = row.Cells["AccountIdDataGridColumn"].Value.ToString();
                            var accountName = row.Cells["AccountNameDataGridColumn"].Value.ToString();

                            // Exists Contributions for account
                            var count = this.ContributionList
                                .Where(x => x.Value.AccountId == accountId)
                                .ToList()
                                .Count;

                            if (count == 0)
                                accountIdList.Add(row.Cells["AccountIdDataGridColumn"].Value.ToString());
                            else
                                errorMsg += $"Account with Account Name [{accountName}] cannot be deleted as there are Contributions existing on the Account. ";
                        }

                        if (accountIdList.Count > 0)
                        {
                            accountIds = string.Join(",", accountIdList);

                            string sql = string.Format(@"UPDATE account
   SET status = 0, date_changed = now()
 WHERE account_id IN ({0})", accountIds);

                            MySqlCommand cmd = new MySqlCommand(sql, mySqlConn);
                            resultCount = cmd.ExecuteNonQuery();

                            MessageBox.Show(string.Format("{0} name record(s) deleted.", accountIdList.Count));
                        }

                        // Refresh all accounts
                        this.LoadAccountDataGridView();
                        this.LoadAccountNameComboBox();

                        if (!string.IsNullOrEmpty(errorMsg))
                            MessageBox.Show(errorMsg);
                    }
                }
                else
                {
                    MessageBox.Show("No rows were selected");
                }
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        public void LoadChart()
        {
            /*this.chart1.Series["Amount"].Points.AddXY("Food", 2000);
            this.chart1.Series["Amount"].Points.AddXY("Ministry", 1300);
            this.chart1.Series["Amount"].Points.AddXY("Condo", 3396);
            this.chart1.Series["Amount"].Points.AddXY("Rent", 4800);*/
        }

        /// <summary>
        /// Load Account Name Combo Box
        /// </summary>
        public void LoadAccountNameComboBox()
        {       
            AccountNameComboBox.Items.Clear();
            SearchAccountNameComboBox.Items.Clear();
                
            foreach (KeyValuePair<string, Account> accountKvp in this.AccountList)
            {
                AccountNameComboBox.Items.Add(new Item(accountKvp.Value.AccountName, accountKvp.Key));
                SearchAccountNameComboBox.Items.Add(new Item(accountKvp.Value.AccountName, accountKvp.Key));
            }

            AccountNameComboBox.ValueMember = "Id";
            AccountNameComboBox.DisplayMember = "Name";
            SearchAccountNameComboBox.ValueMember = "Id";
            SearchAccountNameComboBox.DisplayMember = "Name";

            if (this.AccountList.Count > 0)
                AccountNameComboBox.SelectedIndex = 0;
            else
                AccountNameComboBox.SelectedValue = "";
        }

        private void AccountNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAccountId = string.Empty;
            if (!string.IsNullOrEmpty(AccountNameComboBox.Text))
            {
                Item selectedAccountIdItem = (Item)AccountNameComboBox.SelectedItem;
                selectedAccountId = selectedAccountIdItem.Id;
            }

            this.LoadBalancesOnExpenditureTab(selectedAccountId);

            // Load Contributions Data Grid
            this.LoadContributionsDataGridView();
        }
    }
}
