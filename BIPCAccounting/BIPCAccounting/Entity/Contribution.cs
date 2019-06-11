using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIPCAccounting.Entity
{
    public class Contribution
    {
        public string ContributionId { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string ContributorName { get; set; }
        public string Category { get; set; }
        public string TransactionType { get; set; }
        public string TransactionMode { get; set; }
        public string Amount { get; set; }
        public string CheckNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Note { get; set; }
        public DateTime DateAdded { get; set; }

        public Contribution() { }
        public Contribution(DataRow dRow)
        {
            this.ContributionId = dRow["Contribution Id"].ToString();
            this.AccountId = dRow["AccountId"].ToString();
            this.AccountName = dRow["account_name"].ToString();
            this.ContributorName = dRow["Name"].ToString();
            this.Category = dRow["Category"].ToString();
            this.TransactionType = dRow["Type"].ToString();
            this.TransactionMode = dRow["Mode"].ToString();
            this.Amount = dRow["Amount"].ToString();
            this.CheckNumber = dRow["Check #"].ToString();
            this.TransactionDate = dRow.Field<DateTime>("Trans DT");
            this.Note = dRow["Note"].ToString();
            this.DateAdded = dRow.Field<DateTime>("Date Added");
        }
    }
}
