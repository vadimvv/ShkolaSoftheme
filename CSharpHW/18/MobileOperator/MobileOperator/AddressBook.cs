using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    class AddressBook
    {
        private List<MobileAccount> addressBook;

        public AddressBook()
        {
            addressBook = new List<MobileAccount>();
        }

        public void Add(MobileAccount user)
        {
            addressBook.Add(new MobileAccount(user.Name, user.Number));
        }
    }
}
