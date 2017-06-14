using Sandbox.Web.Models.Requests;
using Sandbox.Web.Models.Responses;
using Sandbox.Web.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sandbox.Web.Controllers.Api
{
    [RoutePrefix("api/emails")]
    public class EmailApiController : ApiController
    {
        IEmailService _emailService;

        public EmailApiController()
        {
            _emailService = new Sandbox.Web.Services.EmailService();
        }

        [Route]
        [HttpPost]
        public async Task<HttpResponseMessage> Post(EmailPostRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                string message = "<div>From: " + model.Name + " (" + model.Email + ")</div>"
                + "<div><em>" + model.Website + "<em></div>"
                + "<div>" + model.Message + "</div>";
                string subject = "Message from " + ConfigurationManager.AppSettings["BaseUrl"];
                string to = ConfigurationManager.AppSettings["SiteAdminEmailAddress"];
                bool isSuccessful = await _emailService.SendAsync(model.Email, to, subject, message);

                if (isSuccessful)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Transmission failed!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
