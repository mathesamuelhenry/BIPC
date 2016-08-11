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

                CategoryCombo.DataSource = dt;
                CategoryCombo.ValueMember = "value";
                CategoryCombo.DisplayMember = "description";



            }
            catch (Exception e)
            {

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
                    int amt;
                    if (!int.TryParse(amount, out amt))
                    {
                        MessageBox.Show("Amount must be a valid integer");
                        valid = false;
                    }
                }

                if (valid)
                {
                    count = this.Insert(NameTextBox.Text, CategoryCombo.SelectedValue.ToString(), transactionType, transactionMode, CheckTextBox.Text, AmountTextBox.Text, TransactionDate, NoteTextBox.Text);

                    if (count > 0)
                        MessageBox.Show("Record added");
                    else
                        MessageBox.Show("Record not added");
                }

                this.LoadTable();
            }
            finally
            {
                if (mySqlConn != null)
                    mySqlConn.Close();
            }
        }

        private int Insert(string name, string category, string trans_type, string trans_mode, string checque_number, string amount, DateTime transaction_date, string note)
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
    }
}
