using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Sandbox.Web.Services
{
    public class EmailService : IEmailService
    {

        private static string SendGridApiKey = System.Configuration.ConfigurationManager.AppSettings["SendGridApiKey"];

        public async Task<bool> SendAsync(string from, string to, string subject, string message)
        {
            SendGridAPIClient sg = new SendGridAPIClient(SendGridApiKey);

            Email fromEmail = new Email(from);
            Email toEmail = new Email(to);
            Content content = new Content("text/html", message);
            Mail mail = new Mail(fromEmail, subject, toEmail, content);

            SendGrid.CSharp.HTTP.Client.Response r = await sg.client.mail.send.post(requestBody: mail.Get());
            bool success = r.StatusCode == HttpStatusCode.Accepted ;
            return success;
        }

        public async Task<bool> SendToSiteAdminAsync(string from, string message)
        {
            string subject = "Message from " + ConfigurationManager.AppSettings["BaseUrl"];
            string to = ConfigurationManager.AppSettings["SiteAdminEmailAddress"];
            return await SendAsync(from, to, subject, message);
        }


    }
}