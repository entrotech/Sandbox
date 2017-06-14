namespace Sandbox.Web.Services
{
    public interface ISmsService
    {
        // return null if successful, error message otherwise.
        string Send(string toNumber, string message);
        string SendToSiteAdmin(string message);
    }
}