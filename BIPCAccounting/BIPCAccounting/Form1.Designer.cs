namespace BIPCAccounting
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AddUpdateExpenditureTab = new System.Windows.Forms.TabPage();
            this.TotalTransactionsCount = new System.Windows.Forms.Label();
            this.MainAcountNamePanel = new System.Windows.Forms.Panel();
            this.AccountNameComboBox = new System.Windows.Forms.ComboBox();
            this.AddAccountNameLabel = new System.Windows.Forms.Label();
            this.ContributionIdHidden = new System.Windows.Forms.TextBox();
            this.DeSelectAllOnAddUpdatePage = new System.Windows.Forms.Button();
            this.SelectAllOnAddUpdatePage = new System.Windows.Forms.Button();
            this.DeleteInAddUpdatePage = new System.Windows.Forms.Button();
            this.TotalTransactionsLabel = new System.Windows.Forms.Label();
            this.EditInAddUpdatePage = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.OpeningBalanceValue = new System.Windows.Forms.Label();
            this.OpeningBalanceLabel = new System.Windows.Forms.Label();
            this.TotalBalanceLabel = new System.Windows.Forms.Label();
            this.TotalBalanceByOpeningLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.EditModeHidden = new System.Windows.Forms.TextBox();
            this.AddUpdateFormGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CategoryTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ContributorIdComboBox = new System.Windows.Forms.ComboBox();
            this.CategoryCombo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AddUpdateButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CardRadioButton = new System.Windows.Forms.RadioButton();
            this.OnlineRadioButton = new System.Windows.Forms.RadioButton();
            this.CheckRadionButton = new System.Windows.Forms.RadioButton();
            this.CashRadionButton = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DebitRadionButton = new System.Windows.Forms.RadioButton();
            this.CreditRadioButton = new System.Windows.Forms.RadioButton();
            this.CheckTextBox = new System.Windows.Forms.TextBox();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.TransactionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EditModelink = new System.Windows.Forms.LinkLabel();
            this.EditModeLabel = new System.Windows.Forms.Label();
            this.DashboardContributionsDataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDataGridAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checkno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchExpendituresTab = new System.Windows.Forms.TabPage();
            this.SearchTabOpeningBalanceValue = new System.Windows.Forms.Label();
            this.SearchTabOpeningBalanceLabel = new System.Windows.Forms.Label();
            this.CurrentSearchBalance = new System.Windows.Forms.Label();
            this.CurrentSearchBalanceLabel = new System.Windows.Forms.Label();
            this.SearchAmountValue = new System.Windows.Forms.Label();
            this.SearchTotalAmount = new System.Windows.Forms.Label();
            this.DeselectAll = new System.Windows.Forms.Button();
            this.SelectAll = new System.Windows.Forms.Button();
            this.DeleteSearchRow = new System.Windows.Forms.Button();
            this.EditSearchRow = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.SearchResultsDataGridView = new System.Windows.Forms.DataGridView();
            this.AccountNameSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNameSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategorySearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChecknoSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransDtSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateAddedSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SearchAccountNameComboBox = new System.Windows.Forms.ComboBox();
            this.SearchAccountNameLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.SearchFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.SearchCheckTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SearchTransModeComboBox = new System.Windows.Forms.ComboBox();
            this.SearchTransTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.SearchNameComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SearchCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SearchNameTextBox = new System.Windows.Forms.TextBox();
            this.MiscellaneousTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DeleteNames = new System.Windows.Forms.Button();
            this.ContributorNameGridView = new System.Windows.Forms.DataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContributorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContributorLastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateNamesTableButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.loanTab = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.DeleteLoanContrubutorButton = new System.Windows.Forms.Button();
            this.AddUpdateLoanContributorButtonGrid = new System.Windows.Forms.Button();
            this.loanContributorDataGridView = new System.Windows.Forms.DataGridView();
            this.ContributorLoanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContributorIdNotVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanFirstLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanAmountGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.RemainingLoanAmountLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LoanTransactionsGridView = new System.Windows.Forms.DataGridView();
            this.LoanTransactionsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanTransactionsCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanTransactionsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanTransactionsMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanTransactionsAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanTransactionsCheckNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanTransactionsTransDt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanTransactionsNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanTransactionsDateAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.LoanLookupTransComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.AddLoanButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.loanAmountTextBox = new System.Windows.Forms.TextBox();
            this.loanComboBox = new System.Windows.Forms.ComboBox();
            this.LoanAmount = new System.Windows.Forms.Label();
            this.AccountTab = new System.Windows.Forms.TabPage();
            this.DeleteAccountButton = new System.Windows.Forms.Button();
            this.UpdateAccountButton = new System.Windows.Forms.Button();
            this.AccountDataGrid = new System.Windows.Forms.DataGridView();
            this.AccountIdDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNameDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNumberDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankNameDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpeningBalanceDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsClosedDataGridColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AnalyticsTab = new System.Windows.Forms.TabPage();
            this.AnalyticsContributionsDataGridView = new System.Windows.Forms.DataGridView();
            this.AnalyticsDataGridViewContributionCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnalyticsDataGridViewAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContributionChartByYear = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AnalyticsTransTypeComboBox = new System.Windows.Forms.ComboBox();
            this.AnalyticsTransactionTypeLabel = new System.Windows.Forms.Label();
            this.AnalyticsYearComboBox = new System.Windows.Forms.ComboBox();
            this.AnalyticsYearLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.OpeningBalanceTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.TotalBalanceFromOpeningBalanceToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SearchBalanceToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.AddUpdateExpenditureTab.SuspendLayout();
            this.MainAcountNamePanel.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.AddUpdateFormGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DashboardContributionsDataGridView)).BeginInit();
            this.SearchExpendituresTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResultsDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.MiscellaneousTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContributorNameGridView)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.loanTab.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loanContributorDataGridView)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoanTransactionsGridView)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.AccountTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountDataGrid)).BeginInit();
            this.AnalyticsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnalyticsContributionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContributionChartByYear)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AddUpdateExpenditureTab);
            this.tabControl1.Controls.Add(this.SearchExpendituresTab);
            this.tabControl1.Controls.Add(this.MiscellaneousTab);
            this.tabControl1.Controls.Add(this.loanTab);
            this.tabControl1.Controls.Add(this.AccountTab);
            this.tabControl1.Controls.Add(this.AnalyticsTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1205, 657);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // AddUpdateExpenditureTab
            // 
            this.AddUpdateExpenditureTab.Controls.Add(this.TotalTransactionsCount);
            this.AddUpdateExpenditureTab.Controls.Add(this.MainAcountNamePanel);
            this.AddUpdateExpenditureTab.Controls.Add(this.ContributionIdHidden);
            this.AddUpdateExpenditureTab.Controls.Add(this.DeSelectAllOnAddUpdatePage);
            this.AddUpdateExpenditureTab.Controls.Add(this.SelectAllOnAddUpdatePage);
            this.AddUpdateExpenditureTab.Controls.Add(this.DeleteInAddUpdatePage);
            this.AddUpdateExpenditureTab.Controls.Add(this.TotalTransactionsLabel);
            this.AddUpdateExpenditureTab.Controls.Add(this.EditInAddUpdatePage);
            this.AddUpdateExpenditureTab.Controls.Add(this.tableLayoutPanel5);
            this.AddUpdateExpenditureTab.Controls.Add(this.EditModeHidden);
            this.AddUpdateExpenditureTab.Controls.Add(this.AddUpdateFormGroup);
            this.AddUpdateExpenditureTab.Controls.Add(this.EditModelink);
            this.AddUpdateExpenditureTab.Controls.Add(this.EditModeLabel);
            this.AddUpdateExpenditureTab.Controls.Add(this.DashboardContributionsDataGridView);
            this.AddUpdateExpenditureTab.Location = new System.Drawing.Point(4, 22);
            this.AddUpdateExpenditureTab.Name = "AddUpdateExpenditureTab";
            this.AddUpdateExpenditureTab.Padding = new System.Windows.Forms.Padding(3);
            this.AddUpdateExpenditureTab.Size = new System.Drawing.Size(1197, 631);
            this.AddUpdateExpenditureTab.TabIndex = 0;
            this.AddUpdateExpenditureTab.Text = "Add Expenditure";
            this.AddUpdateExpenditureTab.UseVisualStyleBackColor = true;
            // 
            // TotalTransactionsCount
            // 
            this.TotalTransactionsCount.AutoSize = true;
            this.TotalTransactionsCount.Location = new System.Drawing.Point(476, 522);
            this.TotalTransactionsCount.Name = "TotalTransactionsCount";
            this.TotalTransactionsCount.Size = new System.Drawing.Size(0, 13);
            this.TotalTransactionsCount.TabIndex = 47;
            // 
            // MainAcountNamePanel
            // 
            this.MainAcountNamePanel.BackColor = System.Drawing.Color.Gray;
            this.MainAcountNamePanel.Controls.Add(this.AccountNameComboBox);
            this.MainAcountNamePanel.Controls.Add(this.AddAccountNameLabel);
            this.MainAcountNamePanel.Location = new System.Drawing.Point(6, 6);
            this.MainAcountNamePanel.Margin = new System.Windows.Forms.Padding(2);
            this.MainAcountNamePanel.Name = "MainAcountNamePanel";
            this.MainAcountNamePanel.Size = new System.Drawing.Size(345, 35);
            this.MainAcountNamePanel.TabIndex = 46;
            // 
            // AccountNameComboBox
            // 
            this.AccountNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountNameComboBox.FormattingEnabled = true;
            this.AccountNameComboBox.Location = new System.Drawing.Point(115, 6);
            this.AccountNameComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.AccountNameComboBox.Name = "AccountNameComboBox";
            this.AccountNameComboBox.Size = new System.Drawing.Size(177, 21);
            this.AccountNameComboBox.TabIndex = 31;
            this.AccountNameComboBox.SelectedIndexChanged += new System.EventHandler(this.AccountNameComboBox_SelectedIndexChanged);
            // 
            // AddAccountNameLabel
            // 
            this.AddAccountNameLabel.AutoSize = true;
            this.AddAccountNameLabel.Location = new System.Drawing.Point(16, 9);
            this.AddAccountNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddAccountNameLabel.Name = "AddAccountNameLabel";
            this.AddAccountNameLabel.Size = new System.Drawing.Size(78, 13);
            this.AddAccountNameLabel.TabIndex = 30;
            this.AddAccountNameLabel.Text = "Account Name";
            // 
            // ContributionIdHidden
            // 
            this.ContributionIdHidden.Location = new System.Drawing.Point(29, 589);
            this.ContributionIdHidden.Name = "ContributionIdHidden";
            this.ContributionIdHidden.Size = new System.Drawing.Size(1, 20);
            this.ContributionIdHidden.TabIndex = 45;
            // 
            // DeSelectAllOnAddUpdatePage
            // 
            this.DeSelectAllOnAddUpdatePage.Location = new System.Drawing.Point(892, 522);
            this.DeSelectAllOnAddUpdatePage.Name = "DeSelectAllOnAddUpdatePage";
            this.DeSelectAllOnAddUpdatePage.Size = new System.Drawing.Size(75, 23);
            this.DeSelectAllOnAddUpdatePage.TabIndex = 44;
            this.DeSelectAllOnAddUpdatePage.Text = "Deselect All";
            this.DeSelectAllOnAddUpdatePage.UseVisualStyleBackColor = true;
            this.DeSelectAllOnAddUpdatePage.Click += new System.EventHandler(this.DeSelectAllOnAddUpdatePage_Click);
            // 
            // SelectAllOnAddUpdatePage
            // 
            this.SelectAllOnAddUpdatePage.Location = new System.Drawing.Point(781, 522);
            this.SelectAllOnAddUpdatePage.Name = "SelectAllOnAddUpdatePage";
            this.SelectAllOnAddUpdatePage.Size = new System.Drawing.Size(75, 23);
            this.SelectAllOnAddUpdatePage.TabIndex = 43;
            this.SelectAllOnAddUpdatePage.Text = "Select All";
            this.SelectAllOnAddUpdatePage.UseVisualStyleBackColor = true;
            this.SelectAllOnAddUpdatePage.Click += new System.EventHandler(this.SelectAllOnAddUpdatePage_Click);
            // 
            // DeleteInAddUpdatePage
            // 
            this.DeleteInAddUpdatePage.Location = new System.Drawing.Point(1002, 522);
            this.DeleteInAddUpdatePage.Name = "DeleteInAddUpdatePage";
            this.DeleteInAddUpdatePage.Size = new System.Drawing.Size(75, 23);
            this.DeleteInAddUpdatePage.TabIndex = 42;
            this.DeleteInAddUpdatePage.Text = "Delete";
            this.DeleteInAddUpdatePage.UseVisualStyleBackColor = true;
            this.DeleteInAddUpdatePage.Click += new System.EventHandler(this.DeleteInAddUpdatePage_Click);
            // 
            // TotalTransactionsLabel
            // 
            this.TotalTransactionsLabel.AutoSize = true;
            this.TotalTransactionsLabel.Location = new System.Drawing.Point(369, 522);
            this.TotalTransactionsLabel.Name = "TotalTransactionsLabel";
            this.TotalTransactionsLabel.Size = new System.Drawing.Size(101, 13);
            this.TotalTransactionsLabel.TabIndex = 39;
            this.TotalTransactionsLabel.Text = "Total Transactions :";
            // 
            // EditInAddUpdatePage
            // 
            this.EditInAddUpdatePage.Location = new System.Drawing.Point(1107, 522);
            this.EditInAddUpdatePage.Name = "EditInAddUpdatePage";
            this.EditInAddUpdatePage.Size = new System.Drawing.Size(75, 23);
            this.EditInAddUpdatePage.TabIndex = 41;
            this.EditInAddUpdatePage.Text = "Edit Row";
            this.EditInAddUpdatePage.UseVisualStyleBackColor = true;
            this.EditInAddUpdatePage.Click += new System.EventHandler(this.EditInAddUpdatePage_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel5.Controls.Add(this.OpeningBalanceValue, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.OpeningBalanceLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.TotalBalanceLabel, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.TotalBalanceByOpeningLabel, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.TotalLabel, 3, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(366, 570);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(816, 39);
            this.tableLayoutPanel5.TabIndex = 40;
            // 
            // OpeningBalanceValue
            // 
            this.OpeningBalanceValue.AutoSize = true;
            this.OpeningBalanceValue.Location = new System.Drawing.Point(110, 0);
            this.OpeningBalanceValue.Name = "OpeningBalanceValue";
            this.OpeningBalanceValue.Size = new System.Drawing.Size(0, 13);
            this.OpeningBalanceValue.TabIndex = 34;
            // 
            // OpeningBalanceLabel
            // 
            this.OpeningBalanceLabel.AutoSize = true;
            this.OpeningBalanceLabel.Location = new System.Drawing.Point(3, 0);
            this.OpeningBalanceLabel.Name = "OpeningBalanceLabel";
            this.OpeningBalanceLabel.Size = new System.Drawing.Size(95, 13);
            this.OpeningBalanceLabel.TabIndex = 33;
            this.OpeningBalanceLabel.Text = "Opening Balance :";
            // 
            // TotalBalanceLabel
            // 
            this.TotalBalanceLabel.AutoSize = true;
            this.TotalBalanceLabel.Location = new System.Drawing.Point(731, 0);
            this.TotalBalanceLabel.Name = "TotalBalanceLabel";
            this.TotalBalanceLabel.Size = new System.Drawing.Size(0, 13);
            this.TotalBalanceLabel.TabIndex = 38;
            // 
            // TotalBalanceByOpeningLabel
            // 
            this.TotalBalanceByOpeningLabel.AutoSize = true;
            this.TotalBalanceByOpeningLabel.Location = new System.Drawing.Point(605, 0);
            this.TotalBalanceByOpeningLabel.Name = "TotalBalanceByOpeningLabel";
            this.TotalBalanceByOpeningLabel.Size = new System.Drawing.Size(116, 13);
            this.TotalBalanceByOpeningLabel.TabIndex = 36;
            this.TotalBalanceByOpeningLabel.Text = "Total Current Balance :";
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(467, 0);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(0, 13);
            this.TotalLabel.TabIndex = 37;
            // 
            // EditModeHidden
            // 
            this.EditModeHidden.Location = new System.Drawing.Point(357, 585);
            this.EditModeHidden.Name = "EditModeHidden";
            this.EditModeHidden.Size = new System.Drawing.Size(1, 20);
            this.EditModeHidden.TabIndex = 39;
            // 
            // AddUpdateFormGroup
            // 
            this.AddUpdateFormGroup.AccessibleName = "AddUpdateFormGroup";
            this.AddUpdateFormGroup.Controls.Add(this.label1);
            this.AddUpdateFormGroup.Controls.Add(this.NameTextBox);
            this.AddUpdateFormGroup.Controls.Add(this.label2);
            this.AddUpdateFormGroup.Controls.Add(this.CategoryTextBox);
            this.AddUpdateFormGroup.Controls.Add(this.label3);
            this.AddUpdateFormGroup.Controls.Add(this.label15);
            this.AddUpdateFormGroup.Controls.Add(this.label4);
            this.AddUpdateFormGroup.Controls.Add(this.ContributorIdComboBox);
            this.AddUpdateFormGroup.Controls.Add(this.CategoryCombo);
            this.AddUpdateFormGroup.Controls.Add(this.label13);
            this.AddUpdateFormGroup.Controls.Add(this.label5);
            this.AddUpdateFormGroup.Controls.Add(this.label6);
            this.AddUpdateFormGroup.Controls.Add(this.AddUpdateButton);
            this.AddUpdateFormGroup.Controls.Add(this.label7);
            this.AddUpdateFormGroup.Controls.Add(this.groupBox2);
            this.AddUpdateFormGroup.Controls.Add(this.label8);
            this.AddUpdateFormGroup.Controls.Add(this.groupBox1);
            this.AddUpdateFormGroup.Controls.Add(this.CheckTextBox);
            this.AddUpdateFormGroup.Controls.Add(this.NoteTextBox);
            this.AddUpdateFormGroup.Controls.Add(this.AmountTextBox);
            this.AddUpdateFormGroup.Controls.Add(this.TransactionDateTimePicker);
            this.AddUpdateFormGroup.Location = new System.Drawing.Point(6, 46);
            this.AddUpdateFormGroup.Name = "AddUpdateFormGroup";
            this.AddUpdateFormGroup.Size = new System.Drawing.Size(345, 559);
            this.AddUpdateFormGroup.TabIndex = 32;
            this.AddUpdateFormGroup.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(115, 26);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(121, 20);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NameTextBox_KeyUp);
            this.NameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Category";
            // 
            // CategoryTextBox
            // 
            this.CategoryTextBox.Location = new System.Drawing.Point(115, 141);
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.Size = new System.Drawing.Size(121, 20);
            this.CategoryTextBox.TabIndex = 29;
            this.CategoryTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CategoryTextBox_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Transaction Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(112, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "(If new Category, enter below)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Transaction Mode";
            // 
            // ContributorIdComboBox
            // 
            this.ContributorIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContributorIdComboBox.FormattingEnabled = true;
            this.ContributorIdComboBox.Location = new System.Drawing.Point(115, 63);
            this.ContributorIdComboBox.Name = "ContributorIdComboBox";
            this.ContributorIdComboBox.Size = new System.Drawing.Size(121, 21);
            this.ContributorIdComboBox.TabIndex = 26;
            this.ContributorIdComboBox.SelectedIndexChanged += new System.EventHandler(this.ContributorIdComboBox_SelectedIndexChanged);
            // 
            // CategoryCombo
            // 
            this.CategoryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryCombo.FormattingEnabled = true;
            this.CategoryCombo.Location = new System.Drawing.Point(115, 101);
            this.CategoryCombo.Name = "CategoryCombo";
            this.CategoryCombo.Size = new System.Drawing.Size(121, 21);
            this.CategoryCombo.TabIndex = 5;
            this.CategoryCombo.SelectedIndexChanged += new System.EventHandler(this.CategoryCombo_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(154, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 12);
            this.label13.TabIndex = 25;
            this.label13.Text = "(OR)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Check Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Amount";
            // 
            // AddUpdateButton
            // 
            this.AddUpdateButton.Location = new System.Drawing.Point(114, 502);
            this.AddUpdateButton.Name = "AddUpdateButton";
            this.AddUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.AddUpdateButton.TabIndex = 23;
            this.AddUpdateButton.Text = "Add";
            this.AddUpdateButton.UseVisualStyleBackColor = true;
            this.AddUpdateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 401);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Transaction Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CardRadioButton);
            this.groupBox2.Controls.Add(this.OnlineRadioButton);
            this.groupBox2.Controls.Add(this.CheckRadionButton);
            this.groupBox2.Controls.Add(this.CashRadionButton);
            this.groupBox2.Location = new System.Drawing.Point(115, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 99);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // CardRadioButton
            // 
            this.CardRadioButton.AutoSize = true;
            this.CardRadioButton.Location = new System.Drawing.Point(108, 60);
            this.CardRadioButton.Name = "CardRadioButton";
            this.CardRadioButton.Size = new System.Drawing.Size(47, 17);
            this.CardRadioButton.TabIndex = 11;
            this.CardRadioButton.TabStop = true;
            this.CardRadioButton.Text = "Card";
            this.CardRadioButton.UseVisualStyleBackColor = true;
            // 
            // OnlineRadioButton
            // 
            this.OnlineRadioButton.AutoSize = true;
            this.OnlineRadioButton.Location = new System.Drawing.Point(17, 60);
            this.OnlineRadioButton.Name = "OnlineRadioButton";
            this.OnlineRadioButton.Size = new System.Drawing.Size(55, 17);
            this.OnlineRadioButton.TabIndex = 10;
            this.OnlineRadioButton.TabStop = true;
            this.OnlineRadioButton.Text = "Online";
            this.OnlineRadioButton.UseVisualStyleBackColor = true;
            // 
            // CheckRadionButton
            // 
            this.CheckRadionButton.AutoSize = true;
            this.CheckRadionButton.Location = new System.Drawing.Point(108, 19);
            this.CheckRadionButton.Name = "CheckRadionButton";
            this.CheckRadionButton.Size = new System.Drawing.Size(56, 17);
            this.CheckRadionButton.TabIndex = 9;
            this.CheckRadionButton.Text = "Check";
            this.CheckRadionButton.UseVisualStyleBackColor = true;
            // 
            // CashRadionButton
            // 
            this.CashRadionButton.AutoSize = true;
            this.CashRadionButton.Checked = true;
            this.CashRadionButton.Location = new System.Drawing.Point(17, 19);
            this.CashRadionButton.Name = "CashRadionButton";
            this.CashRadionButton.Size = new System.Drawing.Size(49, 17);
            this.CashRadionButton.TabIndex = 8;
            this.CashRadionButton.TabStop = true;
            this.CashRadionButton.Text = "Cash";
            this.CashRadionButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 434);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Note";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DebitRadionButton);
            this.groupBox1.Controls.Add(this.CreditRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(115, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 48);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // DebitRadionButton
            // 
            this.DebitRadionButton.AutoSize = true;
            this.DebitRadionButton.Location = new System.Drawing.Point(108, 19);
            this.DebitRadionButton.Name = "DebitRadionButton";
            this.DebitRadionButton.Size = new System.Drawing.Size(50, 17);
            this.DebitRadionButton.TabIndex = 7;
            this.DebitRadionButton.Text = "Debit";
            this.DebitRadionButton.UseVisualStyleBackColor = true;
            // 
            // CreditRadioButton
            // 
            this.CreditRadioButton.AutoSize = true;
            this.CreditRadioButton.Checked = true;
            this.CreditRadioButton.Location = new System.Drawing.Point(17, 19);
            this.CreditRadioButton.Name = "CreditRadioButton";
            this.CreditRadioButton.Size = new System.Drawing.Size(52, 17);
            this.CreditRadioButton.TabIndex = 6;
            this.CreditRadioButton.TabStop = true;
            this.CreditRadioButton.Text = "Credit";
            this.CreditRadioButton.UseVisualStyleBackColor = true;
            // 
            // CheckTextBox
            // 
            this.CheckTextBox.Location = new System.Drawing.Point(115, 331);
            this.CheckTextBox.Name = "CheckTextBox";
            this.CheckTextBox.Size = new System.Drawing.Size(121, 20);
            this.CheckTextBox.TabIndex = 14;
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Location = new System.Drawing.Point(115, 434);
            this.NoteTextBox.Multiline = true;
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.Size = new System.Drawing.Size(200, 55);
            this.NoteTextBox.TabIndex = 19;
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(115, 366);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(121, 20);
            this.AmountTextBox.TabIndex = 15;
            // 
            // TransactionDateTimePicker
            // 
            this.TransactionDateTimePicker.Location = new System.Drawing.Point(115, 401);
            this.TransactionDateTimePicker.Name = "TransactionDateTimePicker";
            this.TransactionDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.TransactionDateTimePicker.TabIndex = 18;
            // 
            // EditModelink
            // 
            this.EditModelink.AutoSize = true;
            this.EditModelink.Location = new System.Drawing.Point(388, 18);
            this.EditModelink.Name = "EditModelink";
            this.EditModelink.Size = new System.Drawing.Size(0, 13);
            this.EditModelink.TabIndex = 31;
            this.EditModelink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EditModelink_LinkClicked);
            // 
            // EditModeLabel
            // 
            this.EditModeLabel.AutoSize = true;
            this.EditModeLabel.ForeColor = System.Drawing.Color.Green;
            this.EditModeLabel.Location = new System.Drawing.Point(594, 18);
            this.EditModeLabel.Name = "EditModeLabel";
            this.EditModeLabel.Size = new System.Drawing.Size(0, 13);
            this.EditModeLabel.TabIndex = 30;
            // 
            // DashboardContributionsDataGridView
            // 
            this.DashboardContributionsDataGridView.AllowUserToAddRows = false;
            this.DashboardContributionsDataGridView.AllowUserToDeleteRows = false;
            this.DashboardContributionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DashboardContributionsDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.DashboardContributionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DashboardContributionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CDataGridAccountName,
            this.CName,
            this.Category,
            this.Type,
            this.Mode,
            this.Checkno,
            this.Amount,
            this.TransDt,
            this.Note,
            this.DateAdded});
            this.DashboardContributionsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DashboardContributionsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DashboardContributionsDataGridView.Location = new System.Drawing.Point(366, 54);
            this.DashboardContributionsDataGridView.Name = "DashboardContributionsDataGridView";
            this.DashboardContributionsDataGridView.Size = new System.Drawing.Size(816, 449);
            this.DashboardContributionsDataGridView.TabIndex = 24;
            this.DashboardContributionsDataGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // CDataGridAccountName
            // 
            this.CDataGridAccountName.HeaderText = "Account Name";
            this.CDataGridAccountName.Name = "CDataGridAccountName";
            this.CDataGridAccountName.ReadOnly = true;
            // 
            // CName
            // 
            this.CName.HeaderText = "Name";
            this.CName.Name = "CName";
            this.CName.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Mode
            // 
            this.Mode.HeaderText = "Mode";
            this.Mode.Name = "Mode";
            this.Mode.ReadOnly = true;
            // 
            // Checkno
            // 
            this.Checkno.HeaderText = "Check #";
            this.Checkno.Name = "Checkno";
            this.Checkno.ReadOnly = true;
            // 
            // Amount
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle1;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // TransDt
            // 
            this.TransDt.HeaderText = "Trans DT";
            this.TransDt.Name = "TransDt";
            this.TransDt.ReadOnly = true;
            // 
            // Note
            // 
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            this.Note.ReadOnly = true;
            // 
            // DateAdded
            // 
            this.DateAdded.HeaderText = "Date Added";
            this.DateAdded.Name = "DateAdded";
            this.DateAdded.ReadOnly = true;
            // 
            // SearchExpendituresTab
            // 
            this.SearchExpendituresTab.Controls.Add(this.SearchTabOpeningBalanceValue);
            this.SearchExpendituresTab.Controls.Add(this.SearchTabOpeningBalanceLabel);
            this.SearchExpendituresTab.Controls.Add(this.CurrentSearchBalance);
            this.SearchExpendituresTab.Controls.Add(this.CurrentSearchBalanceLabel);
            this.SearchExpendituresTab.Controls.Add(this.SearchAmountValue);
            this.SearchExpendituresTab.Controls.Add(this.SearchTotalAmount);
            this.SearchExpendituresTab.Controls.Add(this.DeselectAll);
            this.SearchExpendituresTab.Controls.Add(this.SelectAll);
            this.SearchExpendituresTab.Controls.Add(this.DeleteSearchRow);
            this.SearchExpendituresTab.Controls.Add(this.EditSearchRow);
            this.SearchExpendituresTab.Controls.Add(this.button2);
            this.SearchExpendituresTab.Controls.Add(this.label22);
            this.SearchExpendituresTab.Controls.Add(this.SearchResultsDataGridView);
            this.SearchExpendituresTab.Controls.Add(this.groupBox3);
            this.SearchExpendituresTab.Location = new System.Drawing.Point(4, 22);
            this.SearchExpendituresTab.Name = "SearchExpendituresTab";
            this.SearchExpendituresTab.Padding = new System.Windows.Forms.Padding(3);
            this.SearchExpendituresTab.Size = new System.Drawing.Size(1197, 631);
            this.SearchExpendituresTab.TabIndex = 1;
            this.SearchExpendituresTab.Tag = "";
            this.SearchExpendituresTab.Text = "Search Expenditures";
            this.SearchExpendituresTab.UseVisualStyleBackColor = true;
            // 
            // SearchTabOpeningBalanceValue
            // 
            this.SearchTabOpeningBalanceValue.AutoSize = true;
            this.SearchTabOpeningBalanceValue.Location = new System.Drawing.Point(1120, 578);
            this.SearchTabOpeningBalanceValue.Name = "SearchTabOpeningBalanceValue";
            this.SearchTabOpeningBalanceValue.Size = new System.Drawing.Size(22, 13);
            this.SearchTabOpeningBalanceValue.TabIndex = 20;
            this.SearchTabOpeningBalanceValue.Text = "0.0";
            // 
            // SearchTabOpeningBalanceLabel
            // 
            this.SearchTabOpeningBalanceLabel.AutoSize = true;
            this.SearchTabOpeningBalanceLabel.Location = new System.Drawing.Point(1013, 578);
            this.SearchTabOpeningBalanceLabel.Name = "SearchTabOpeningBalanceLabel";
            this.SearchTabOpeningBalanceLabel.Size = new System.Drawing.Size(101, 13);
            this.SearchTabOpeningBalanceLabel.TabIndex = 19;
            this.SearchTabOpeningBalanceLabel.Text = "Opening Balance  : ";
            // 
            // CurrentSearchBalance
            // 
            this.CurrentSearchBalance.AutoSize = true;
            this.CurrentSearchBalance.Location = new System.Drawing.Point(611, 578);
            this.CurrentSearchBalance.Name = "CurrentSearchBalance";
            this.CurrentSearchBalance.Size = new System.Drawing.Size(22, 13);
            this.CurrentSearchBalance.TabIndex = 18;
            this.CurrentSearchBalance.Text = "0.0";
            // 
            // CurrentSearchBalanceLabel
            // 
            this.CurrentSearchBalanceLabel.AutoSize = true;
            this.CurrentSearchBalanceLabel.Location = new System.Drawing.Point(473, 578);
            this.CurrentSearchBalanceLabel.Name = "CurrentSearchBalanceLabel";
            this.CurrentSearchBalanceLabel.Size = new System.Drawing.Size(132, 13);
            this.CurrentSearchBalanceLabel.TabIndex = 17;
            this.CurrentSearchBalanceLabel.Text = "Current Search Balance  : ";
            // 
            // SearchAmountValue
            // 
            this.SearchAmountValue.AutoSize = true;
            this.SearchAmountValue.Location = new System.Drawing.Point(136, 578);
            this.SearchAmountValue.Name = "SearchAmountValue";
            this.SearchAmountValue.Size = new System.Drawing.Size(22, 13);
            this.SearchAmountValue.TabIndex = 16;
            this.SearchAmountValue.Text = "0.0";
            // 
            // SearchTotalAmount
            // 
            this.SearchTotalAmount.AutoSize = true;
            this.SearchTotalAmount.Location = new System.Drawing.Point(14, 578);
            this.SearchTotalAmount.Name = "SearchTotalAmount";
            this.SearchTotalAmount.Size = new System.Drawing.Size(116, 13);
            this.SearchTotalAmount.TabIndex = 15;
            this.SearchTotalAmount.Text = "Search Total Amount : ";
            this.SearchTotalAmount.Click += new System.EventHandler(this.label10_Click);
            // 
            // DeselectAll
            // 
            this.DeselectAll.Location = new System.Drawing.Point(783, 203);
            this.DeselectAll.Name = "DeselectAll";
            this.DeselectAll.Size = new System.Drawing.Size(75, 23);
            this.DeselectAll.TabIndex = 14;
            this.DeselectAll.Text = "Deselect All";
            this.DeselectAll.UseVisualStyleBackColor = true;
            this.DeselectAll.Click += new System.EventHandler(this.DeselectAll_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.Location = new System.Drawing.Point(672, 203);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(75, 23);
            this.SelectAll.TabIndex = 13;
            this.SelectAll.Text = "Select All";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // DeleteSearchRow
            // 
            this.DeleteSearchRow.Location = new System.Drawing.Point(893, 203);
            this.DeleteSearchRow.Name = "DeleteSearchRow";
            this.DeleteSearchRow.Size = new System.Drawing.Size(75, 23);
            this.DeleteSearchRow.TabIndex = 12;
            this.DeleteSearchRow.Text = "Delete";
            this.DeleteSearchRow.UseVisualStyleBackColor = true;
            this.DeleteSearchRow.Click += new System.EventHandler(this.DeleteSearchRow_Click);
            // 
            // EditSearchRow
            // 
            this.EditSearchRow.Location = new System.Drawing.Point(998, 203);
            this.EditSearchRow.Name = "EditSearchRow";
            this.EditSearchRow.Size = new System.Drawing.Size(75, 23);
            this.EditSearchRow.TabIndex = 11;
            this.EditSearchRow.Text = "Edit Row";
            this.EditSearchRow.UseVisualStyleBackColor = true;
            this.EditSearchRow.Click += new System.EventHandler(this.EditSearchRow_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1101, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(14, 210);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(120, 16);
            this.label22.TabIndex = 2;
            this.label22.Text = "Expenditure Result";
            // 
            // SearchResultsDataGridView
            // 
            this.SearchResultsDataGridView.AllowUserToAddRows = false;
            this.SearchResultsDataGridView.AllowUserToDeleteRows = false;
            this.SearchResultsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SearchResultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchResultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountNameSearch,
            this.CNameSearch,
            this.IDSearch,
            this.CategorySearch,
            this.TypeSearch,
            this.ModeSearch,
            this.AmountSearch,
            this.ChecknoSearch,
            this.TransDtSearch,
            this.NoteSearch,
            this.DateAddedSearch});
            this.SearchResultsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.SearchResultsDataGridView.Location = new System.Drawing.Point(17, 246);
            this.SearchResultsDataGridView.Name = "SearchResultsDataGridView";
            this.SearchResultsDataGridView.Size = new System.Drawing.Size(1159, 308);
            this.SearchResultsDataGridView.TabIndex = 1;
            // 
            // AccountNameSearch
            // 
            this.AccountNameSearch.HeaderText = "Account";
            this.AccountNameSearch.Name = "AccountNameSearch";
            this.AccountNameSearch.ReadOnly = true;
            // 
            // CNameSearch
            // 
            this.CNameSearch.HeaderText = "Name";
            this.CNameSearch.Name = "CNameSearch";
            this.CNameSearch.ReadOnly = true;
            // 
            // IDSearch
            // 
            this.IDSearch.HeaderText = "ID";
            this.IDSearch.Name = "IDSearch";
            this.IDSearch.ReadOnly = true;
            this.IDSearch.Visible = false;
            // 
            // CategorySearch
            // 
            this.CategorySearch.HeaderText = "Category";
            this.CategorySearch.Name = "CategorySearch";
            this.CategorySearch.ReadOnly = true;
            // 
            // TypeSearch
            // 
            this.TypeSearch.HeaderText = "Type";
            this.TypeSearch.Name = "TypeSearch";
            this.TypeSearch.ReadOnly = true;
            // 
            // ModeSearch
            // 
            this.ModeSearch.HeaderText = "Mode";
            this.ModeSearch.Name = "ModeSearch";
            this.ModeSearch.ReadOnly = true;
            // 
            // AmountSearch
            // 
            this.AmountSearch.HeaderText = "Amount";
            this.AmountSearch.Name = "AmountSearch";
            this.AmountSearch.ReadOnly = true;
            // 
            // ChecknoSearch
            // 
            this.ChecknoSearch.HeaderText = "Check #";
            this.ChecknoSearch.Name = "ChecknoSearch";
            this.ChecknoSearch.ReadOnly = true;
            // 
            // TransDtSearch
            // 
            this.TransDtSearch.HeaderText = "Trans DT";
            this.TransDtSearch.Name = "TransDtSearch";
            this.TransDtSearch.ReadOnly = true;
            // 
            // NoteSearch
            // 
            this.NoteSearch.HeaderText = "Note";
            this.NoteSearch.Name = "NoteSearch";
            this.NoteSearch.ReadOnly = true;
            // 
            // DateAddedSearch
            // 
            this.DateAddedSearch.HeaderText = "DateAdded";
            this.DateAddedSearch.Name = "DateAddedSearch";
            this.DateAddedSearch.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleName = "SearchGroupBox";
            this.groupBox3.Controls.Add(this.SearchAccountNameComboBox);
            this.groupBox3.Controls.Add(this.SearchAccountNameLabel);
            this.groupBox3.Controls.Add(this.ResetButton);
            this.groupBox3.Controls.Add(this.SearchButton);
            this.groupBox3.Controls.Add(this.SearchToDateTimePicker);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.SearchFromDateTimePicker);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.SearchCheckTextBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.SearchTransModeComboBox);
            this.groupBox3.Controls.Add(this.SearchTransTypeComboBox);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.SearchNameComboBox);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.SearchCategoryComboBox);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.SearchNameTextBox);
            this.groupBox3.Location = new System.Drawing.Point(17, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1159, 158);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // SearchAccountNameComboBox
            // 
            this.SearchAccountNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchAccountNameComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SearchAccountNameComboBox.FormattingEnabled = true;
            this.SearchAccountNameComboBox.Location = new System.Drawing.Point(26, 56);
            this.SearchAccountNameComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.SearchAccountNameComboBox.Name = "SearchAccountNameComboBox";
            this.SearchAccountNameComboBox.Size = new System.Drawing.Size(138, 21);
            this.SearchAccountNameComboBox.TabIndex = 51;
            // 
            // SearchAccountNameLabel
            // 
            this.SearchAccountNameLabel.AutoSize = true;
            this.SearchAccountNameLabel.Location = new System.Drawing.Point(23, 34);
            this.SearchAccountNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SearchAccountNameLabel.Name = "SearchAccountNameLabel";
            this.SearchAccountNameLabel.Size = new System.Drawing.Size(78, 13);
            this.SearchAccountNameLabel.TabIndex = 50;
            this.SearchAccountNameLabel.Text = "Account Name";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(974, 105);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(151, 23);
            this.ResetButton.TabIndex = 49;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(800, 106);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(151, 23);
            this.SearchButton.TabIndex = 48;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchToDateTimePicker
            // 
            this.SearchToDateTimePicker.Location = new System.Drawing.Point(939, 70);
            this.SearchToDateTimePicker.Name = "SearchToDateTimePicker";
            this.SearchToDateTimePicker.Size = new System.Drawing.Size(186, 20);
            this.SearchToDateTimePicker.TabIndex = 47;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(822, 73);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(111, 13);
            this.label21.TabIndex = 46;
            this.label21.Text = "Transaction Date (To)";
            // 
            // SearchFromDateTimePicker
            // 
            this.SearchFromDateTimePicker.Location = new System.Drawing.Point(939, 30);
            this.SearchFromDateTimePicker.Name = "SearchFromDateTimePicker";
            this.SearchFromDateTimePicker.Size = new System.Drawing.Size(186, 20);
            this.SearchFromDateTimePicker.TabIndex = 45;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(811, 33);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(121, 13);
            this.label20.TabIndex = 44;
            this.label20.Text = "Transaction Date (From)";
            // 
            // SearchCheckTextBox
            // 
            this.SearchCheckTextBox.Location = new System.Drawing.Point(597, 109);
            this.SearchCheckTextBox.Name = "SearchCheckTextBox";
            this.SearchCheckTextBox.Size = new System.Drawing.Size(129, 20);
            this.SearchCheckTextBox.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(479, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Check Number";
            // 
            // SearchTransModeComboBox
            // 
            this.SearchTransModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchTransModeComboBox.FormattingEnabled = true;
            this.SearchTransModeComboBox.Location = new System.Drawing.Point(597, 71);
            this.SearchTransModeComboBox.Name = "SearchTransModeComboBox";
            this.SearchTransModeComboBox.Size = new System.Drawing.Size(129, 21);
            this.SearchTransModeComboBox.TabIndex = 41;
            // 
            // SearchTransTypeComboBox
            // 
            this.SearchTransTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchTransTypeComboBox.FormattingEnabled = true;
            this.SearchTransTypeComboBox.Location = new System.Drawing.Point(597, 31);
            this.SearchTransTypeComboBox.Name = "SearchTransTypeComboBox";
            this.SearchTransTypeComboBox.Size = new System.Drawing.Size(129, 21);
            this.SearchTransTypeComboBox.TabIndex = 40;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(476, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 13);
            this.label18.TabIndex = 39;
            this.label18.Text = "Transaction Mode";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(479, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 13);
            this.label19.TabIndex = 38;
            this.label19.Text = "Transaction Type";
            // 
            // SearchNameComboBox
            // 
            this.SearchNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchNameComboBox.FormattingEnabled = true;
            this.SearchNameComboBox.Location = new System.Drawing.Point(288, 69);
            this.SearchNameComboBox.Name = "SearchNameComboBox";
            this.SearchNameComboBox.Size = new System.Drawing.Size(130, 21);
            this.SearchNameComboBox.TabIndex = 35;
            this.SearchNameComboBox.SelectedIndexChanged += new System.EventHandler(this.SearchNameComboBox_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(328, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 12);
            this.label14.TabIndex = 34;
            this.label14.Text = "(OR)";
            // 
            // SearchCategoryComboBox
            // 
            this.SearchCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchCategoryComboBox.FormattingEnabled = true;
            this.SearchCategoryComboBox.Location = new System.Drawing.Point(288, 104);
            this.SearchCategoryComboBox.Name = "SearchCategoryComboBox";
            this.SearchCategoryComboBox.Size = new System.Drawing.Size(130, 21);
            this.SearchCategoryComboBox.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(215, 106);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Category";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(222, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "Name";
            // 
            // SearchNameTextBox
            // 
            this.SearchNameTextBox.Location = new System.Drawing.Point(288, 32);
            this.SearchNameTextBox.Name = "SearchNameTextBox";
            this.SearchNameTextBox.Size = new System.Drawing.Size(130, 20);
            this.SearchNameTextBox.TabIndex = 30;
            this.SearchNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchNameTextBox_KeyUp);
            // 
            // MiscellaneousTab
            // 
            this.MiscellaneousTab.Controls.Add(this.tableLayoutPanel2);
            this.MiscellaneousTab.Location = new System.Drawing.Point(4, 22);
            this.MiscellaneousTab.Name = "MiscellaneousTab";
            this.MiscellaneousTab.Padding = new System.Windows.Forms.Padding(3);
            this.MiscellaneousTab.Size = new System.Drawing.Size(1197, 631);
            this.MiscellaneousTab.TabIndex = 2;
            this.MiscellaneousTab.Text = "Miscellaneous";
            this.MiscellaneousTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(714, 321);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox5, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(426, 314);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DeleteNames);
            this.groupBox5.Controls.Add(this.ContributorNameGridView);
            this.groupBox5.Controls.Add(this.UpdateNamesTableButton);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(420, 307);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Names";
            // 
            // DeleteNames
            // 
            this.DeleteNames.Location = new System.Drawing.Point(220, 270);
            this.DeleteNames.Name = "DeleteNames";
            this.DeleteNames.Size = new System.Drawing.Size(193, 23);
            this.DeleteNames.TabIndex = 12;
            this.DeleteNames.Text = "Delete Selected Names";
            this.DeleteNames.UseVisualStyleBackColor = true;
            this.DeleteNames.Click += new System.EventHandler(this.DeleteNames_Click);
            // 
            // ContributorNameGridView
            // 
            this.ContributorNameGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ContributorNameGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContributorNameGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.ContributorId,
            this.ContributorLastUpdated});
            this.ContributorNameGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ContributorNameGridView.Location = new System.Drawing.Point(6, 27);
            this.ContributorNameGridView.Name = "ContributorNameGridView";
            this.ContributorNameGridView.Size = new System.Drawing.Size(407, 224);
            this.ContributorNameGridView.TabIndex = 10;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // ContributorId
            // 
            this.ContributorId.HeaderText = "Contributor ID";
            this.ContributorId.Name = "ContributorId";
            this.ContributorId.Visible = false;
            // 
            // ContributorLastUpdated
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.ContributorLastUpdated.DefaultCellStyle = dataGridViewCellStyle2;
            this.ContributorLastUpdated.HeaderText = "Last Updated Date";
            this.ContributorLastUpdated.Name = "ContributorLastUpdated";
            this.ContributorLastUpdated.ReadOnly = true;
            this.ContributorLastUpdated.ToolTipText = "Last Updated Date is Read Only";
            // 
            // UpdateNamesTableButton
            // 
            this.UpdateNamesTableButton.Location = new System.Drawing.Point(6, 270);
            this.UpdateNamesTableButton.Name = "UpdateNamesTableButton";
            this.UpdateNamesTableButton.Size = new System.Drawing.Size(208, 23);
            this.UpdateNamesTableButton.TabIndex = 11;
            this.UpdateNamesTableButton.Text = "Update Names Table";
            this.UpdateNamesTableButton.UseVisualStyleBackColor = true;
            this.UpdateNamesTableButton.Click += new System.EventHandler(this.UpdateNamesTableButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox6, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(445, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(266, 314);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(251, 150);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Global Refresh";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(218, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Refresh Data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // loanTab
            // 
            this.loanTab.Controls.Add(this.groupBox9);
            this.loanTab.Controls.Add(this.groupBox8);
            this.loanTab.Controls.Add(this.groupBox7);
            this.loanTab.Location = new System.Drawing.Point(4, 22);
            this.loanTab.Name = "loanTab";
            this.loanTab.Padding = new System.Windows.Forms.Padding(3);
            this.loanTab.Size = new System.Drawing.Size(1197, 631);
            this.loanTab.TabIndex = 3;
            this.loanTab.Text = "Loan";
            this.loanTab.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.DeleteLoanContrubutorButton);
            this.groupBox9.Controls.Add(this.AddUpdateLoanContributorButtonGrid);
            this.groupBox9.Controls.Add(this.loanContributorDataGridView);
            this.groupBox9.Location = new System.Drawing.Point(379, 34);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(508, 193);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Loan Borrowers";
            // 
            // DeleteLoanContrubutorButton
            // 
            this.DeleteLoanContrubutorButton.Location = new System.Drawing.Point(256, 157);
            this.DeleteLoanContrubutorButton.Name = "DeleteLoanContrubutorButton";
            this.DeleteLoanContrubutorButton.Size = new System.Drawing.Size(223, 23);
            this.DeleteLoanContrubutorButton.TabIndex = 2;
            this.DeleteLoanContrubutorButton.Text = "Delete";
            this.DeleteLoanContrubutorButton.UseVisualStyleBackColor = true;
            this.DeleteLoanContrubutorButton.Click += new System.EventHandler(this.DeleteLoanContrubutorButton_Click);
            // 
            // AddUpdateLoanContributorButtonGrid
            // 
            this.AddUpdateLoanContributorButtonGrid.Location = new System.Drawing.Point(16, 157);
            this.AddUpdateLoanContributorButtonGrid.Name = "AddUpdateLoanContributorButtonGrid";
            this.AddUpdateLoanContributorButtonGrid.Size = new System.Drawing.Size(212, 23);
            this.AddUpdateLoanContributorButtonGrid.TabIndex = 1;
            this.AddUpdateLoanContributorButtonGrid.Text = "Update";
            this.AddUpdateLoanContributorButtonGrid.UseVisualStyleBackColor = true;
            this.AddUpdateLoanContributorButtonGrid.Click += new System.EventHandler(this.AddUpdateLoanContributorButtonGrid_Click);
            // 
            // loanContributorDataGridView
            // 
            this.loanContributorDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.loanContributorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.loanContributorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContributorLoanId,
            this.ContributorIdNotVisible,
            this.LoanFirstLastName,
            this.LoanAmountGrid});
            this.loanContributorDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.loanContributorDataGridView.Location = new System.Drawing.Point(16, 19);
            this.loanContributorDataGridView.Name = "loanContributorDataGridView";
            this.loanContributorDataGridView.Size = new System.Drawing.Size(463, 132);
            this.loanContributorDataGridView.TabIndex = 0;
            // 
            // ContributorLoanId
            // 
            this.ContributorLoanId.HeaderText = "ID";
            this.ContributorLoanId.Name = "ContributorLoanId";
            this.ContributorLoanId.ReadOnly = true;
            this.ContributorLoanId.Visible = false;
            // 
            // ContributorIdNotVisible
            // 
            this.ContributorIdNotVisible.HeaderText = "Contributor Id";
            this.ContributorIdNotVisible.Name = "ContributorIdNotVisible";
            this.ContributorIdNotVisible.Visible = false;
            // 
            // LoanFirstLastName
            // 
            this.LoanFirstLastName.HeaderText = "Name";
            this.LoanFirstLastName.Name = "LoanFirstLastName";
            this.LoanFirstLastName.ReadOnly = true;
            this.LoanFirstLastName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // LoanAmountGrid
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.LoanAmountGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.LoanAmountGrid.HeaderText = "Amount";
            this.LoanAmountGrid.Name = "LoanAmountGrid";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.RemainingLoanAmountLabel);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.LoanTransactionsGridView);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.LoanLookupTransComboBox);
            this.groupBox8.Location = new System.Drawing.Point(29, 253);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(969, 276);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Loan Lookup Transactions";
            // 
            // RemainingLoanAmountLabel
            // 
            this.RemainingLoanAmountLabel.AutoSize = true;
            this.RemainingLoanAmountLabel.Location = new System.Drawing.Point(142, 239);
            this.RemainingLoanAmountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RemainingLoanAmountLabel.Name = "RemainingLoanAmountLabel";
            this.RemainingLoanAmountLabel.Size = new System.Drawing.Size(0, 13);
            this.RemainingLoanAmountLabel.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 239);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Remaining Loan Amount :";
            // 
            // LoanTransactionsGridView
            // 
            this.LoanTransactionsGridView.AllowUserToDeleteRows = false;
            this.LoanTransactionsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LoanTransactionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoanTransactionsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoanTransactionsName,
            this.LoanTransactionsCategory,
            this.LoanTransactionsType,
            this.LoanTransactionsMode,
            this.LoanTransactionsAmount,
            this.LoanTransactionsCheckNumber,
            this.LoanTransactionsTransDt,
            this.LoanTransactionsNote,
            this.LoanTransactionsDateAdded});
            this.LoanTransactionsGridView.Location = new System.Drawing.Point(17, 74);
            this.LoanTransactionsGridView.Name = "LoanTransactionsGridView";
            this.LoanTransactionsGridView.ReadOnly = true;
            this.LoanTransactionsGridView.Size = new System.Drawing.Size(938, 150);
            this.LoanTransactionsGridView.TabIndex = 2;
            // 
            // LoanTransactionsName
            // 
            this.LoanTransactionsName.HeaderText = "Name";
            this.LoanTransactionsName.Name = "LoanTransactionsName";
            this.LoanTransactionsName.ReadOnly = true;
            // 
            // LoanTransactionsCategory
            // 
            this.LoanTransactionsCategory.HeaderText = "Category";
            this.LoanTransactionsCategory.Name = "LoanTransactionsCategory";
            this.LoanTransactionsCategory.ReadOnly = true;
            // 
            // LoanTransactionsType
            // 
            this.LoanTransactionsType.HeaderText = "Type";
            this.LoanTransactionsType.Name = "LoanTransactionsType";
            this.LoanTransactionsType.ReadOnly = true;
            // 
            // LoanTransactionsMode
            // 
            this.LoanTransactionsMode.HeaderText = "Mode";
            this.LoanTransactionsMode.Name = "LoanTransactionsMode";
            this.LoanTransactionsMode.ReadOnly = true;
            // 
            // LoanTransactionsAmount
            // 
            this.LoanTransactionsAmount.HeaderText = "Amount";
            this.LoanTransactionsAmount.Name = "LoanTransactionsAmount";
            this.LoanTransactionsAmount.ReadOnly = true;
            // 
            // LoanTransactionsCheckNumber
            // 
            this.LoanTransactionsCheckNumber.HeaderText = "Check #";
            this.LoanTransactionsCheckNumber.Name = "LoanTransactionsCheckNumber";
            this.LoanTransactionsCheckNumber.ReadOnly = true;
            // 
            // LoanTransactionsTransDt
            // 
            this.LoanTransactionsTransDt.HeaderText = "Trans DT";
            this.LoanTransactionsTransDt.Name = "LoanTransactionsTransDt";
            this.LoanTransactionsTransDt.ReadOnly = true;
            // 
            // LoanTransactionsNote
            // 
            this.LoanTransactionsNote.HeaderText = "Note";
            this.LoanTransactionsNote.Name = "LoanTransactionsNote";
            this.LoanTransactionsNote.ReadOnly = true;
            // 
            // LoanTransactionsDateAdded
            // 
            this.LoanTransactionsDateAdded.HeaderText = "Date Added";
            this.LoanTransactionsDateAdded.Name = "LoanTransactionsDateAdded";
            this.LoanTransactionsDateAdded.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Name";
            // 
            // LoanLookupTransComboBox
            // 
            this.LoanLookupTransComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LoanLookupTransComboBox.FormattingEnabled = true;
            this.LoanLookupTransComboBox.Location = new System.Drawing.Point(91, 30);
            this.LoanLookupTransComboBox.Name = "LoanLookupTransComboBox";
            this.LoanLookupTransComboBox.Size = new System.Drawing.Size(226, 21);
            this.LoanLookupTransComboBox.TabIndex = 0;
            this.LoanLookupTransComboBox.SelectedIndexChanged += new System.EventHandler(this.LoanLookupTransComboBox_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.AddLoanButton);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.loanAmountTextBox);
            this.groupBox7.Controls.Add(this.loanComboBox);
            this.groupBox7.Controls.Add(this.LoanAmount);
            this.groupBox7.Location = new System.Drawing.Point(29, 34);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(317, 193);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Add Borrower";
            // 
            // AddLoanButton
            // 
            this.AddLoanButton.Location = new System.Drawing.Point(91, 120);
            this.AddLoanButton.Name = "AddLoanButton";
            this.AddLoanButton.Size = new System.Drawing.Size(75, 23);
            this.AddLoanButton.TabIndex = 4;
            this.AddLoanButton.Text = "Add";
            this.AddLoanButton.UseVisualStyleBackColor = true;
            this.AddLoanButton.Click += new System.EventHandler(this.AddLoanButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Name";
            // 
            // loanAmountTextBox
            // 
            this.loanAmountTextBox.Location = new System.Drawing.Point(91, 81);
            this.loanAmountTextBox.Name = "loanAmountTextBox";
            this.loanAmountTextBox.Size = new System.Drawing.Size(197, 20);
            this.loanAmountTextBox.TabIndex = 3;
            // 
            // loanComboBox
            // 
            this.loanComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loanComboBox.FormattingEnabled = true;
            this.loanComboBox.Location = new System.Drawing.Point(91, 48);
            this.loanComboBox.Name = "loanComboBox";
            this.loanComboBox.Size = new System.Drawing.Size(197, 21);
            this.loanComboBox.TabIndex = 1;
            // 
            // LoanAmount
            // 
            this.LoanAmount.AutoSize = true;
            this.LoanAmount.Location = new System.Drawing.Point(14, 84);
            this.LoanAmount.Name = "LoanAmount";
            this.LoanAmount.Size = new System.Drawing.Size(43, 13);
            this.LoanAmount.TabIndex = 2;
            this.LoanAmount.Text = "Amount";
            // 
            // AccountTab
            // 
            this.AccountTab.Controls.Add(this.DeleteAccountButton);
            this.AccountTab.Controls.Add(this.UpdateAccountButton);
            this.AccountTab.Controls.Add(this.AccountDataGrid);
            this.AccountTab.Location = new System.Drawing.Point(4, 22);
            this.AccountTab.Name = "AccountTab";
            this.AccountTab.Padding = new System.Windows.Forms.Padding(3);
            this.AccountTab.Size = new System.Drawing.Size(1197, 631);
            this.AccountTab.TabIndex = 4;
            this.AccountTab.Text = "Account";
            this.AccountTab.UseVisualStyleBackColor = true;
            // 
            // DeleteAccountButton
            // 
            this.DeleteAccountButton.Location = new System.Drawing.Point(323, 310);
            this.DeleteAccountButton.Name = "DeleteAccountButton";
            this.DeleteAccountButton.Size = new System.Drawing.Size(244, 23);
            this.DeleteAccountButton.TabIndex = 3;
            this.DeleteAccountButton.Text = "Delete Account";
            this.DeleteAccountButton.UseVisualStyleBackColor = true;
            this.DeleteAccountButton.Click += new System.EventHandler(this.DeleteAccountButton_Click);
            // 
            // UpdateAccountButton
            // 
            this.UpdateAccountButton.Location = new System.Drawing.Point(20, 310);
            this.UpdateAccountButton.Name = "UpdateAccountButton";
            this.UpdateAccountButton.Size = new System.Drawing.Size(244, 23);
            this.UpdateAccountButton.TabIndex = 2;
            this.UpdateAccountButton.Text = "Update Account";
            this.UpdateAccountButton.UseVisualStyleBackColor = true;
            this.UpdateAccountButton.Click += new System.EventHandler(this.UpdateAccountButton_Click);
            // 
            // AccountDataGrid
            // 
            this.AccountDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AccountDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountIdDataGridColumn,
            this.AccountNameDataGridColumn,
            this.AccountNumberDataGridColumn,
            this.BankNameDataGridColumn,
            this.OpeningBalanceDataGridColumn,
            this.IsClosedDataGridColumn});
            this.AccountDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.AccountDataGrid.Location = new System.Drawing.Point(20, 30);
            this.AccountDataGrid.Name = "AccountDataGrid";
            this.AccountDataGrid.Size = new System.Drawing.Size(547, 273);
            this.AccountDataGrid.TabIndex = 1;
            // 
            // AccountIdDataGridColumn
            // 
            this.AccountIdDataGridColumn.HeaderText = "Account ID";
            this.AccountIdDataGridColumn.Name = "AccountIdDataGridColumn";
            this.AccountIdDataGridColumn.Visible = false;
            // 
            // AccountNameDataGridColumn
            // 
            this.AccountNameDataGridColumn.HeaderText = "AccountName";
            this.AccountNameDataGridColumn.Name = "AccountNameDataGridColumn";
            // 
            // AccountNumberDataGridColumn
            // 
            this.AccountNumberDataGridColumn.HeaderText = "Account #";
            this.AccountNumberDataGridColumn.Name = "AccountNumberDataGridColumn";
            // 
            // BankNameDataGridColumn
            // 
            this.BankNameDataGridColumn.HeaderText = "Bank Name";
            this.BankNameDataGridColumn.Name = "BankNameDataGridColumn";
            // 
            // OpeningBalanceDataGridColumn
            // 
            this.OpeningBalanceDataGridColumn.HeaderText = "Opening Balance";
            this.OpeningBalanceDataGridColumn.Name = "OpeningBalanceDataGridColumn";
            // 
            // IsClosedDataGridColumn
            // 
            this.IsClosedDataGridColumn.HeaderText = "Is Closed *";
            this.IsClosedDataGridColumn.Name = "IsClosedDataGridColumn";
            this.IsClosedDataGridColumn.ToolTipText = "Mark as CLOSED when account is closed or no more transactions on the account.";
            // 
            // AnalyticsTab
            // 
            this.AnalyticsTab.Controls.Add(this.AnalyticsContributionsDataGridView);
            this.AnalyticsTab.Controls.Add(this.ContributionChartByYear);
            this.AnalyticsTab.Controls.Add(this.panel1);
            this.AnalyticsTab.Location = new System.Drawing.Point(4, 22);
            this.AnalyticsTab.Name = "AnalyticsTab";
            this.AnalyticsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AnalyticsTab.Size = new System.Drawing.Size(1197, 631);
            this.AnalyticsTab.TabIndex = 5;
            this.AnalyticsTab.Text = "Analytics";
            this.AnalyticsTab.UseVisualStyleBackColor = true;
            // 
            // AnalyticsContributionsDataGridView
            // 
            this.AnalyticsContributionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AnalyticsContributionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnalyticsContributionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnalyticsDataGridViewContributionCategory,
            this.AnalyticsDataGridViewAmount});
            this.AnalyticsContributionsDataGridView.Location = new System.Drawing.Point(23, 157);
            this.AnalyticsContributionsDataGridView.Name = "AnalyticsContributionsDataGridView";
            this.AnalyticsContributionsDataGridView.Size = new System.Drawing.Size(355, 448);
            this.AnalyticsContributionsDataGridView.TabIndex = 4;
            // 
            // AnalyticsDataGridViewContributionCategory
            // 
            this.AnalyticsDataGridViewContributionCategory.HeaderText = "Category";
            this.AnalyticsDataGridViewContributionCategory.Name = "AnalyticsDataGridViewContributionCategory";
            this.AnalyticsDataGridViewContributionCategory.ReadOnly = true;
            // 
            // AnalyticsDataGridViewAmount
            // 
            this.AnalyticsDataGridViewAmount.HeaderText = "Amount";
            this.AnalyticsDataGridViewAmount.Name = "AnalyticsDataGridViewAmount";
            this.AnalyticsDataGridViewAmount.ReadOnly = true;
            // 
            // ContributionChartByYear
            // 
            chartArea1.Name = "ChartArea1";
            this.ContributionChartByYear.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ContributionChartByYear.Legends.Add(legend1);
            this.ContributionChartByYear.Location = new System.Drawing.Point(384, 19);
            this.ContributionChartByYear.Name = "ContributionChartByYear";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Amount";
            this.ContributionChartByYear.Series.Add(series1);
            this.ContributionChartByYear.Size = new System.Drawing.Size(794, 586);
            this.ContributionChartByYear.TabIndex = 3;
            this.ContributionChartByYear.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AnalyticsTransTypeComboBox);
            this.panel1.Controls.Add(this.AnalyticsTransactionTypeLabel);
            this.panel1.Controls.Add(this.AnalyticsYearComboBox);
            this.panel1.Controls.Add(this.AnalyticsYearLabel);
            this.panel1.Location = new System.Drawing.Point(23, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 120);
            this.panel1.TabIndex = 2;
            // 
            // AnalyticsTransTypeComboBox
            // 
            this.AnalyticsTransTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnalyticsTransTypeComboBox.FormattingEnabled = true;
            this.AnalyticsTransTypeComboBox.Location = new System.Drawing.Point(135, 58);
            this.AnalyticsTransTypeComboBox.Name = "AnalyticsTransTypeComboBox";
            this.AnalyticsTransTypeComboBox.Size = new System.Drawing.Size(155, 21);
            this.AnalyticsTransTypeComboBox.TabIndex = 3;
            this.AnalyticsTransTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.AnalyticsTransTypeComboBox_SelectedIndexChanged);
            // 
            // AnalyticsTransactionTypeLabel
            // 
            this.AnalyticsTransactionTypeLabel.AutoSize = true;
            this.AnalyticsTransactionTypeLabel.Location = new System.Drawing.Point(22, 61);
            this.AnalyticsTransactionTypeLabel.Name = "AnalyticsTransactionTypeLabel";
            this.AnalyticsTransactionTypeLabel.Size = new System.Drawing.Size(90, 13);
            this.AnalyticsTransactionTypeLabel.TabIndex = 2;
            this.AnalyticsTransactionTypeLabel.Text = "Transaction Type";
            // 
            // AnalyticsYearComboBox
            // 
            this.AnalyticsYearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnalyticsYearComboBox.FormattingEnabled = true;
            this.AnalyticsYearComboBox.Location = new System.Drawing.Point(135, 14);
            this.AnalyticsYearComboBox.Name = "AnalyticsYearComboBox";
            this.AnalyticsYearComboBox.Size = new System.Drawing.Size(155, 21);
            this.AnalyticsYearComboBox.TabIndex = 1;
            this.AnalyticsYearComboBox.SelectedIndexChanged += new System.EventHandler(this.AnalyticsYearComboBox_SelectedIndexChanged);
            // 
            // AnalyticsYearLabel
            // 
            this.AnalyticsYearLabel.AutoSize = true;
            this.AnalyticsYearLabel.Location = new System.Drawing.Point(19, 17);
            this.AnalyticsYearLabel.Name = "AnalyticsYearLabel";
            this.AnalyticsYearLabel.Size = new System.Drawing.Size(29, 13);
            this.AnalyticsYearLabel.TabIndex = 0;
            this.AnalyticsYearLabel.Text = "Year";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 701);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "BIPC Accounting Tool";
            this.tabControl1.ResumeLayout(false);
            this.AddUpdateExpenditureTab.ResumeLayout(false);
            this.AddUpdateExpenditureTab.PerformLayout();
            this.MainAcountNamePanel.ResumeLayout(false);
            this.MainAcountNamePanel.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.AddUpdateFormGroup.ResumeLayout(false);
            this.AddUpdateFormGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DashboardContributionsDataGridView)).EndInit();
            this.SearchExpendituresTab.ResumeLayout(false);
            this.SearchExpendituresTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResultsDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.MiscellaneousTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContributorNameGridView)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.loanTab.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loanContributorDataGridView)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoanTransactionsGridView)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.AccountTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AccountDataGrid)).EndInit();
            this.AnalyticsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnalyticsContributionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContributionChartByYear)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AddUpdateExpenditureTab;
        private System.Windows.Forms.TabPage SearchExpendituresTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton CheckRadionButton;
        private System.Windows.Forms.RadioButton CashRadionButton;
        private System.Windows.Forms.RadioButton DebitRadionButton;
        private System.Windows.Forms.RadioButton CreditRadioButton;
        private System.Windows.Forms.ComboBox CategoryCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NoteTextBox;
        private System.Windows.Forms.DateTimePicker TransactionDateTimePicker;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.TextBox CheckTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddUpdateButton;
        private System.Windows.Forms.DataGridView DashboardContributionsDataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage MiscellaneousTab;
        private System.Windows.Forms.ComboBox ContributorIdComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox CategoryTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox SearchNameComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox SearchCategoryComboBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox SearchNameTextBox;
        private System.Windows.Forms.ComboBox SearchTransModeComboBox;
        private System.Windows.Forms.ComboBox SearchTransTypeComboBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox SearchCheckTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DateTimePicker SearchToDateTimePicker;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DateTimePicker SearchFromDateTimePicker;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView SearchResultsDataGridView;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button EditSearchRow;
        private System.Windows.Forms.Button DeleteSearchRow;
        private System.Windows.Forms.Label EditModeLabel;
        private System.Windows.Forms.LinkLabel EditModelink;
        private System.Windows.Forms.GroupBox AddUpdateFormGroup;
        private System.Windows.Forms.Button DeselectAll;
        private System.Windows.Forms.Button SelectAll;
        private System.Windows.Forms.Label OpeningBalanceValue;
        private System.Windows.Forms.Label OpeningBalanceLabel;
        private System.Windows.Forms.Label TotalBalanceLabel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.Label TotalBalanceByOpeningLabel;
        private System.Windows.Forms.ToolTip OpeningBalanceTooltip;
        private System.Windows.Forms.ToolTip TotalBalanceFromOpeningBalanceToolTip;
        private System.Windows.Forms.TextBox EditModeHidden;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button DeleteInAddUpdatePage;
        private System.Windows.Forms.Button EditInAddUpdatePage;
        private System.Windows.Forms.Button DeSelectAllOnAddUpdatePage;
        private System.Windows.Forms.Button SelectAllOnAddUpdatePage;
        private System.Windows.Forms.TextBox ContributionIdHidden;
        private System.Windows.Forms.DataGridView ContributorNameGridView;
        private System.Windows.Forms.Button UpdateNamesTableButton;
        private System.Windows.Forms.Button DeleteNames;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton OnlineRadioButton;
        private System.Windows.Forms.Label SearchTotalAmount;
        private System.Windows.Forms.Label SearchAmountValue;
        private System.Windows.Forms.RadioButton CardRadioButton;
        private System.Windows.Forms.Label CurrentSearchBalance;
        private System.Windows.Forms.Label CurrentSearchBalanceLabel;
        private System.Windows.Forms.ToolTip SearchBalanceToolTip;
        private System.Windows.Forms.Label SearchTabOpeningBalanceValue;
        private System.Windows.Forms.Label SearchTabOpeningBalanceLabel;
        private System.Windows.Forms.TabPage loanTab;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button AddLoanButton;
        private System.Windows.Forms.TextBox loanAmountTextBox;
        private System.Windows.Forms.Label LoanAmount;
        private System.Windows.Forms.ComboBox loanComboBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DataGridView loanContributorDataGridView;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox LoanLookupTransComboBox;
        private System.Windows.Forms.Button AddUpdateLoanContributorButtonGrid;
        private System.Windows.Forms.DataGridView LoanTransactionsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsCheckNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsTransDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanTransactionsDateAdded;
        private System.Windows.Forms.Button DeleteLoanContrubutorButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContributorLoanId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContributorIdNotVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanFirstLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanAmountGrid;
        private System.Windows.Forms.Label RemainingLoanAmountLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage AccountTab;
        private System.Windows.Forms.DataGridView AccountDataGrid;
        private System.Windows.Forms.Button DeleteAccountButton;
        private System.Windows.Forms.Button UpdateAccountButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDataGridAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Checkno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAdded;
        private System.Windows.Forms.ComboBox AccountNameComboBox;
        private System.Windows.Forms.Label AddAccountNameLabel;
        private System.Windows.Forms.ComboBox SearchAccountNameComboBox;
        private System.Windows.Forms.Label SearchAccountNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategorySearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChecknoSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransDtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAddedSearch;
        private System.Windows.Forms.Panel MainAcountNamePanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountIdDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNameDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNumberDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankNameDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpeningBalanceDataGridColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsClosedDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContributorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContributorLastUpdated;
        private System.Windows.Forms.TabPage AnalyticsTab;
        private System.Windows.Forms.DataVisualization.Charting.Chart ContributionChartByYear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox AnalyticsYearComboBox;
        private System.Windows.Forms.Label AnalyticsYearLabel;
        private System.Windows.Forms.ComboBox AnalyticsTransTypeComboBox;
        private System.Windows.Forms.Label AnalyticsTransactionTypeLabel;
        private System.Windows.Forms.DataGridView AnalyticsContributionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnalyticsDataGridViewContributionCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnalyticsDataGridViewAmount;
        private System.Windows.Forms.Label TotalTransactionsCount;
        private System.Windows.Forms.Label TotalTransactionsLabel;
    }
}