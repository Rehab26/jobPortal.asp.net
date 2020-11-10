using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Utilities
{
    public static class Mailer
    {
        public static async Task SendMail(string from, string to, string subject, string body, NetworkCredential credential)
        {
            try//
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress("rsr.26@hotmail.com", "Rehab");
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    //smtp.SendCompleted += new SendCompletedEventHandler(Smtp_SendCompleted);

                    await Task.Run(() => smtp.Send(message));
                }
            }
            catch (Exception ex)
            {
                //log
            }
        }

        private static void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //do nothing
            var d = e.UserState;
        }
    }
}
