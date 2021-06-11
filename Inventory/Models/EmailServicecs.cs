using System;
using System.Net.Mail;
using System.Text;

namespace InventoryService.Models
{
    public class EmailServicecs
    {
        public static string SendEmail(string toEmail, string subject, string body)
        {
            string to = "toaddress@gmail.com"; //To address    
            string from = "fromaddress@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("yourmail id", "Password");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "Email sent.";
        }
    }
}
