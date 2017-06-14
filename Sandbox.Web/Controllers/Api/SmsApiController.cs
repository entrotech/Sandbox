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
    [RoutePrefix("api/sms")]
    public class SmsApiController : ApiController
    {
        ISmsService _smsService;

        public SmsApiController()
        {
            _smsService = new Services.SmsService();
        }

        [Route]
        [HttpPost]
        public HttpResponseMessage Post(SmsPostRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                string toNumber = String.IsNullOrWhiteSpace(model.ToNumber)
                    ? ConfigurationManager.AppSettings["SiteAdminSmsNumber"]
                    : model.ToNumber;
                string errorMessage = _smsService.Send(toNumber, model.Message);
                if (errorMessage == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessage);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
