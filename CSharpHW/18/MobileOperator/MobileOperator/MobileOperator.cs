using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    class MobileOperator
    {
        public delegate void ConversationHandler(MobileAccount first, MobileAccount second);
        
        List<MobileAccount> accounts;

        public MobileOperator()
        {
            accounts = new List<MobileAccount>();
        }

        private void OnConversation(MobileAccount first, MobileAccount second)
        {
            Console.WriteLine("{0} began to talk with {1}", first.Name,second.Name);
        }

        private void OnSmsConversation(MobileAccount first, MobileAccount second)
        {
            Console.WriteLine("{0} sent sms to {1}", first.Name, second.Name);
        }

        public void Add(MobileAccount mobileAccount)
        {
            if (!IsExsist(mobileAccount))
            {
                accounts.Add(mobileAccount);
                mobileAccount.ConversationStarted += OnConversation;
                mobileAccount.SMSConversationStarded+=OnSmsConversation;
            }
            else
                Console.WriteLine("This phone number already exsist! ({0})",mobileAccount.Number);
        }

        public bool IsExsist(MobileAccount mobileAccount)
        {
            return accounts.Any(a => a.Number == mobileAccount.Number);
        }

    }
}
