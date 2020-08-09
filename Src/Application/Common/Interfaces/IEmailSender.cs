using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string from, string body);
    }
}
