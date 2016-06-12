using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileOperator
{
    class AddressBook
    {
        private readonly List<MobileAccount> addressBook;

        public AddressBook()
        {
            addressBook = new List<MobileAccount>();
        }

        public void Add(string phone, string name)     // Brother, Sister, Developer...
        {
            addressBook.Add(new MobileAccount(phone,name));
        }

        public bool IsExsist(MobileAccount user)
        {
            if (addressBook.Any(u => u.Phone == user.Phone))
                return true;
            return false;
        }

        public string GetName(MobileAccount user)
        {
            return addressBook.FirstOrDefault(u => u.Phone == user.Phone).Name;
        }
    }
}
