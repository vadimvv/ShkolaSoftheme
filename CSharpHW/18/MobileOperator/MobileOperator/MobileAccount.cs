using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    class MobileAccount
    {
        public delegate void ActionsHandler(MobileAccount first, MobileAccount second);

        public event ActionsHandler ConversationStarted;
        public event ActionsHandler SMSConversationStarded;
        public string Name { get; set; }
        public string Number { get; set; }



        public MobileAccount(string name, string number)
        {
            Name = name;
            Number = number;
        }



        public void SendSMS(MobileAccount recipient, string sms)
        {
            if (SMSConversationStarded != null)
                SMSConversationStarded.Invoke(this,recipient);
            Console.WriteLine("SMSing");
        }


        public void MakeCall(MobileAccount recipient)
        {
            if (ConversationStarted != null)
                ConversationStarted.Invoke(this, recipient);
        }
    }
}
