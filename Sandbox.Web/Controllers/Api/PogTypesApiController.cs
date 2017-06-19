using Newtonsoft.Json;
using Sandbox.Web.Classes;
using Sandbox.Web.Domain;
using Sandbox.Web.Models.Requests;
using Sandbox.Web.Models.Responses;
using Sandbox.Web.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sandbox.Web.Controllers.Api
{
    [RoutePrefix("api/pogtypes")]
    public class PogTypesApiController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                ItemsResponse<PogType> resp = new ItemsResponse<PogType>();
                resp.Items = PogTypeService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new ErrorResponse(ex));
            }

        } // Search

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            try
            {
                ItemResponse<PogType> itemResponse = new ItemResponse<PogType>();
                itemResponse.Item = PogTypeService.SelectById(id);
                response = itemResponse;
                statusCode = HttpStatusCode.OK;
            }
            catch (Exception Error)
            {
                response = new ErrorResponse(Error);
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Request.CreateResponse(statusCode, response);
        } // GetById



        [Route, HttpPost]
        public HttpResponseMessage Post(PogTypeAddRequest model)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                ItemResponse<int> itemResponse = new ItemResponse<int>();
                itemResponse.Item = PogTypeService.Insert(model);
                response = itemResponse;
                statusCode = HttpStatusCode.OK;
            }
            catch (Exception Error)
            {
                response = new ErrorResponse(Error);
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Request.CreateResponse(statusCode, response);
        } // Post

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Put(PogTypeUpdateRequest model)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = new HttpStatusCode();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                PogTypeService.Update(model);
                response = new SuccessResponse();
                statusCode = HttpStatusCode.OK;
            }
            catch (Exception Error)
            {
                response = new ErrorResponse(Error);
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Request.CreateResponse(statusCode, response);
        } // Put

      
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            try
            {
                PogTypeService.Delete(id);
                response = new SuccessResponse();
                statusCode = HttpStatusCode.OK;
            }
            catch (Exception Error)
            {
                response = new ErrorResponse(Error);
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Request.CreateResponse(statusCode, response);
        } // Delete

      
    }
}
