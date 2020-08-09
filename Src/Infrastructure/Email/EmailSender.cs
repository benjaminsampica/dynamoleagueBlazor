using Application.Common.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendAsync(string to, string from, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}
