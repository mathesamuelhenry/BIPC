using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;

namespace BIPCAccounting
{
    public class CVD
    {
        public int ColumnValueDescID { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

        private string sql = @"SELECT cvd.column_value_desc_id, 
       tc.table_name,
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
            this.ColumnValueDescID = int.Parse(dRow["column_value_desc_id"].ToString());
            this.TableName = dRow["table_name"].ToString();
            this.ColumnName = dRow["column_name"].ToString();
            this.Value = dRow["value"].ToString();
            this.Description = dRow["description"].ToString();
        }

        public CVD(MySqlConnection mySqlConn)
        {
            MySqlCommand cmdDataBase = new MySqlCommand(this.sql, mySqlConn);
            this.CVDList = new List<CVD>();

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

        public string GetCVD(string table_name, string column_name, string description)
        {
            var query = from cvd in this.CVDList
                        where cvd.TableName == table_name && cvd.ColumnName == column_name && cvd.Description == description
                        select cvd.Value;

            return query.FirstOrDefault();
        }

        public string GetCVDDescription(string table_name, string column_name, string value)
        {
            var query = from cvd in this.CVDList
                        where cvd.TableName == table_name && cvd.ColumnName == column_name && cvd.Value == value
                        select cvd.Description;

            return query.FirstOrDefault();
        }
    }
}
