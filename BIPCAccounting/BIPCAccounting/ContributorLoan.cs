using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIPCAccounting
{
    public class ContributorLoan
    {
        public string ContributorLoanId { get; set; } 
        public string ContributorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal LoanAmount { get; set; }

        public ContributorLoan()
        {

        }
    }
}
