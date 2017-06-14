using System.Threading.Tasks;

namespace Sandbox.Web.Services
{
    public interface IEmailService
    {
        Task<bool> SendAsync(string from, string to, string subject, string message);
        Task<bool> SendToSiteAdminAsync(string from, string message);
    }
}