﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BIPCAccounting
{
    public class Utils
    {
        public static System.Data.DataTable GetDataTable(MySqlConnection mySqlConn, string sql)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            MySqlCommand cmdDataBase = new MySqlCommand(sql, mySqlConn);

            try
            {
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

        public static void ResetAllControls(Control form)
        {   
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }

                if (control is DateTimePicker)
                {
                    DateTimePicker dateTime = (DateTimePicker)control;
                    if (dateTime.Name.Equals("SearchFromDateTimePicker"))
                    {
                        dateTime.Value = new DateTime(2000, 01, 01);
                    }
                    else if (dateTime.Name.Equals("SearchToDateTimePicker"))
                    {
                        dateTime.Value = new DateTime(2099, 01, 01);
                    }
                    else
                    {
                        dateTime.Value = DateTime.Now;
                    }
                }
            }
        }

        public static string FormatDBIntegers(string value)
        {
            return string.IsNullOrEmpty(value) ? "NULL" : value.Trim();
        }

        public static string FormatDBText(string value)
        {
            return string.IsNullOrEmpty(value) ? "NULL" : "'" + value.Trim() + "'";
        }
    }
}
