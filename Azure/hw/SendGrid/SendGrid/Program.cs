using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> users = new Dictionary<string, string>();
            users.Add("2ivashyn.vadym@gmail.com","Vadym Ivashyn");
            users.Add("second@gmail.com","Second Vadym");


            var myMessage = new SendGrid.SendGridMessage();

            myMessage.From = new MailAddress("you@youremail.com", "Title");

            foreach (var u in users)
            {
                myMessage.AddTo(u.Key);
            }

            List<string> userNames = users.Values.ToList();
            myMessage.AddSubstitution("%user%", userNames);
            myMessage.AddSubstitution("%title%", new List<string> { "Hello from title" });
            myMessage.AddSubstitution("%body%", new List<string> { "Some text from body" });

            myMessage.EnableTemplateEngine("57ece6c2-b625-4bd6-92e7-2def1a3b0693");

            

            myMessage.Html = "Email content here";

            myMessage.Subject = "Email subject here";


            NetworkCredential nc = new NetworkCredential("azure_4c1f2e65473355288c560030a6e88b2a@azure.com", "KPgZDZiM7c8hXHz");
            var transportWeb = new SendGrid.Web(nc);

            transportWeb.DeliverAsync(myMessage).Wait();
            Console.WriteLine("Good");
            Console.ReadLine();
        }
    }
}
