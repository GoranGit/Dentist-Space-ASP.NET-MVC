namespace DentistSpace.Services.Web
{
    using System.Configuration;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class Mailer : IMailer
    {
        private static readonly object LockObject = new object();
        private static Mailer instance = null;

        protected Mailer()
        {
        }

        public static Mailer GetMailer()
        {
            if (instance == null)
            {
                lock (LockObject)
                {
                    if (instance == null)
                    {
                        instance = new Mailer();
                    }
                }
            }

            return instance;
        }

        public async Task Send(string toEmail, string subject, string body)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["MailerHost"];
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["MailerPort"]);
            smtp.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["MailerSSL"]);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            string username = ConfigurationManager.AppSettings["MailerUsername"];
            bool isHtml = bool.Parse(ConfigurationManager.AppSettings["MailerBodyIsHtml"]);

            smtp.Credentials = new NetworkCredential(username, ConfigurationManager.AppSettings["MailerPass"]);

            using (var message = new MailMessage(username, toEmail))
            {
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHtml;
               await smtp.SendMailAsync(message);
            }
        }
    }
}