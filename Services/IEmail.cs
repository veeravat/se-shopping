using System.Threading.Tasks;

namespace ShoppingModule.Services
{
    public interface IEmail
    {
        string AddressSMTP { get; set; }
        string ErrorMessage { get; set; }
        string LoginSender { get; set; }
        string PasswordSender { get; set; }
        int PortSMTP { get; set; }

        Task<bool> SendMailO365(string pAddressRecive, string pTopicName, string pMessage);
    }
}