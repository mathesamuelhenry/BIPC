using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace BIPCAccounting
{
    public class Item
    {
        public string _Name;
        public string _Id;

        public Item(string name, string id)
        {
            _Name = name;
            _Id = id;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    } 
 
    public class CVD
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        private string sql = @"SELECT tc.table_name,
       tc.column_name,
       cvd.value,
       cvd.description
  FROM table_column tc
       JOIN column_value_desc cvd
          ON tc.table_column_id = cvd.table_column_id AND cvd.status = 1
 WHERE tc.status = 1;";

        public List<CVD> CVDList = new List<CVD>();

        public CVD()
        {

        }

        public CVD(DataRow dRow)
        {
            this.TableName = dRow["table_name"].ToString();
            this.ColumnName = dRow["column_name"].ToString();
            this.Value = dRow["value"].ToString();
            this.Description = dRow["description"].ToString();
        }

        public CVD(MySqlConnection mySqlConn)
        {
            MySqlCommand cmdDataBase = new MySqlCommand(this.sql, mySqlConn);

            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmdDataBase;
            System.Data.DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dRow in dt.Rows)
                {
                    this.CVDList.Add(new CVD(dRow));
                }
            }
        }

        public List<CVD> GetCVD(string table_name, string column_name)
        {
            var query = from cvd in this.CVDList
                        where cvd.TableName == table_name && cvd.ColumnName == column_name
                        select cvd;

            return (List<CVD>)query.ToList();
        }
    }
}
