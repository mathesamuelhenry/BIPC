using System;
using System.Text;
using System.Threading.Tasks;

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
}
