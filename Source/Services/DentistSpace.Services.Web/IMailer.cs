namespace DentistSpace.Services.Web
{
    using System.Threading.Tasks;

    public interface IMailer
    {
        Task Send(string toEmail, string subject, string body);
    }
}
