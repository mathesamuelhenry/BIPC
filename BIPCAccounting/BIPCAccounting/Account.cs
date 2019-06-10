using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIPCAccounting
{
    public class Account
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string InitialBalance { get; set; }
        public bool IsClosed { get; set; }

        public Account() { }

        public Account(DataRow dRow)
        {
            this.AccountId = dRow["account_id"].ToString();
            this.AccountName = dRow["account_name"].ToString();
            this.AccountNumber = dRow["account_number"].ToString();
            this.BankName = dRow["bank_name"].ToString();
            this.InitialBalance = dRow["initial_balance"].ToString();

            IsClosed = !string.IsNullOrEmpty(dRow["account_end_date"].ToString());
        } 
    }
}
