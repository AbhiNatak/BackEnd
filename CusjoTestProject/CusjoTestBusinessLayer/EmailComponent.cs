using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace CusjoTestBusinessLayer
{
    public class EmailComponent
    {
        public readonly string smtp;
        public readonly int port;
        public string EmailMessage { get; set; }
        public string Subject { get; set; }
        public string ToAddress { get; set; }
        public string CcAddress { get; set; }
        public string FromAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public EmailComponent(string smtp, int port)
        {
            this.smtp = smtp;
            this.port = port;
        }

        public bool SendEmail()
        {
            try
            {
                SmtpClient client = new SmtpClient(this.smtp, this.port);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(this.UserName, this.Password);
                MailMessage msg = new MailMessage();
                msg.To.Add(this.ToAddress);
                msg.CC.Add(this.CcAddress);
                msg.From = new MailAddress(this.FromAddress);
                msg.Body = this.EmailMessage;
                msg.Subject = this.Subject;
                client.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error While sending the Email {0}", ex.ToString());
                return false;
            }
            Console.WriteLine("Email Sent Successfully");
            return true;
        }
        
    }
}
