using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsletterClass;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Configuration;


namespace NewsletterService
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            c1.getDatafromDB();
            List<string> brands = new List<string>();
            brands.Add("Jack & Jones");
            brands.Add("Criminal Damage");
            brands.Add("Boxeur des Rues");
            brands.Add("Nike");
            brands.Add("Farah");
            brands.Add("G-Star");
            brands.Add("Superdry");
            brands.Add("Selected Homme");
            brands.Add("Zara");
            brands.Add("Adidas");
            List<string> player = c1.getDatafromDB();
            sendMail(player);
            sendMail(brands);
            Console.ReadKey(true);
        }

        public static void sendMail(List<string> List)
        {
            string newsletterEmailHost = ConfigurationManager.AppSettings["newsletterEmailHost"].ToString();
            string newsletterEmailFrom = ConfigurationManager.AppSettings["newsletterEmailFrom"].ToString();
            string newsletterEmailFromName = ConfigurationManager.AppSettings["newsletterEmailFromName"].ToString();
            string newsletterEmailSubject = ConfigurationManager.AppSettings["newsletterEmailSubject"].ToString();
            //string = "IAM DISAPOINTED string";
            SmtpClient smtpClient = new SmtpClient(newsletterEmailHost);
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(newsletterEmailFrom, newsletterEmailFromName);
            mailMessage.To.Add(new MailAddress("akeel.shariffdeen@futurecom.ch"));
            mailMessage.Subject = newsletterEmailSubject;
            mailMessage.IsBodyHtml = false;

            foreach (string s in List)
            {
                mailMessage.Body += s + Environment.NewLine;
            }

            smtpClient.Send(mailMessage);
            mailMessage.Dispose();
            smtpClient.Dispose();
        }
    }
}
