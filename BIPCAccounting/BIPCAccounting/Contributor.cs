using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BIPCAccounting
{
    class Contributor
    {
        public string ContributorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastUpdated { get; set; }

        public Contributor()
        {

        }

        public Contributor(DataRow dRow)
        {
            this.ContributorId = dRow["contributor_id"].ToString();
            this.FirstName = dRow["first_name"].ToString();
            this.LastName = dRow["last_name"].ToString();
            this.LastUpdated = dRow["last_updated"].ToString();
        }
    }
}
