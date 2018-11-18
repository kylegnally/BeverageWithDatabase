using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment5
{
    interface IBeverageCollection
    {
        /// getall
        string FindById(string id);
        void AddNewItem(string id, string name, string pack, decimal price, bool active);

        bool update(string id);
        /// delete
    }
}
