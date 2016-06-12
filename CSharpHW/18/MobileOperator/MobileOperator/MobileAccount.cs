using System;


namespace MobileOperator
{
    class MobileAccount : ICloneable
    {
        public delegate void ActionsHandler(MobileAccount first, MobileAccount second);

        public event ActionsHandler ConversationStarted;
        public event ActionsHandler SMSConversationStarded;

        public string Name { get; set; }
        public string Phone { get; set; }
        public AddressBook addressBook { get; set; }

        public MobileAccount(string phone, string name)
        {
            Name = name;
            Phone = phone;
            addressBook = new AddressBook();
        }


        /*----------------------Methods------------------------*/

        public void SendSMS(MobileAccount recipient, string sms)
        {
            if (SMSConversationStarded != null)
                SMSConversationStarded.Invoke(this, recipient);
            Console.WriteLine("You have received a letter");
        }

        public void MakeCall(MobileAccount recipient)
        {
            if (ConversationStarted != null)
                ConversationStarted.Invoke(this, recipient);
            Console.WriteLine("Conversation");
        }

        public void ShowCallingName(MobileAccount incomingAccount)
        {
            if (addressBook.IsExsist(incomingAccount))
                Console.WriteLine("Incoming: " + addressBook.GetName(incomingAccount));
            else Console.WriteLine("Incoming: " + incomingAccount.Phone);
        }

        public void ShowSenderName(MobileAccount senderAccount)
        {
            if (addressBook.IsExsist(senderAccount))
                Console.WriteLine("Sender: " + addressBook.GetName(senderAccount));
            else Console.WriteLine("Sender: " + senderAccount.Phone);
        }

        public void AddContact(string phone, string name)
        {
            addressBook.Add(phone, name);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
