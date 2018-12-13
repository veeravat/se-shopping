using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModule.Services
{
    public class Email : IEmail
    {
        public string LoginSender { get; set; }

        public string PasswordSender { get; set; }

        public int PortSMTP { get; set; }

        public string AddressSMTP { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<bool> SendMailO365(string pAddressRecive, string pTopicName, string pMessage)
        {

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.EnableSsl = true;
            MailAddress from = new MailAddress("shopping@tuymove.com", string.Empty, System.Text.Encoding.UTF8);

            client.Credentials = new System.Net.NetworkCredential("shopping@tuymove.com", "Raz11528");

            MailAddress to = new MailAddress(pAddressRecive);
            MailMessage message = new MailMessage(from, to);
            message.Body = pMessage;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = pTopicName;
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            try
            {
                await client.SendMailAsync(message);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}