using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileOperator
{
    class MobileOperator
    {
        List<MobileAccount> accounts;

        public MobileOperator()
        {
            accounts = new List<MobileAccount>();
        }

        private void OnConversationStarted(MobileAccount first, MobileAccount second)
        {
            Console.Write("{0} began to talk with {1}; --- ", first.Name,second.Name);
            second.ShowCallingName(first);
            
        }

        private void OnSmsConversationStarted(MobileAccount first, MobileAccount second)
        {
            Console.Write("{0} sent sms to {1}; --- ", first.Name, second.Name);
            second.ShowSenderName(first);
        }

        public void Add(MobileAccount mobileAccount)
        {
            if (!IsExsist(mobileAccount))
            {
                accounts.Add(mobileAccount);
                mobileAccount.ConversationStarted += OnConversationStarted;
                mobileAccount.SMSConversationStarded+=OnSmsConversationStarted;
            }
            else
                Console.WriteLine("This phone number already exsist! ({0})",mobileAccount.Phone);
        }

        public bool IsExsist(MobileAccount mobileAccount)
        {
            return accounts.Any(a => a.Phone == mobileAccount.Phone);
        }

    }
}
