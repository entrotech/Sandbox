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
    [RoutePrefix("api/pogs")]
    public class PogsApiController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage Search([FromUri]PogSearchRequest model)
        {
            try
            {
                int rowCount = 0;
                List<Pog> items = PogService.Search(model, out rowCount);
                PagedItemsResponse<Pog> resp = new PagedItemsResponse<Pog>(
                    model.CurrentPage ?? 1,
                    model.ItemsPerPage ?? 12,
                    rowCount,
                    items);
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
                ItemResponse<Pog> itemResponse = new ItemResponse<Pog>();
                itemResponse.Item = PogService.SelectById(id);
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
        public HttpResponseMessage Post(PogPostRequest model)
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
                itemResponse.Item = PogService.Insert(model);
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
        public HttpResponseMessage Put(PogPutRequest model)
        {
            BaseResponse response = null;
            HttpStatusCode statusCode = new HttpStatusCode();
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                PogService.Update(model);
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
                PogService.Delete(id);
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

        /// <summary>
        /// Uploads a single PogsFile with related info
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ItemResponse with full url of uploaded file</returns>
        [HttpPost]
        [Route("{pogId:int}/uploadImage")]
        public async Task<HttpResponseMessage> UploadImage(int pogId)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            try
            {
                Stream stream = null;
                string fileName = "";
                PogFileAddRequest insertRequest = null;


                MultipartMemoryStreamProvider provider = await Request.Content.ReadAsMultipartAsync();


                foreach (HttpContent content in provider.Contents)
                {
                    if (content.Headers.ContentDisposition.Name == "\"file\"")
                    {
                        stream = await content.ReadAsStreamAsync();

                        // Dig out the file name and make it unique.
                        fileName = provider.Contents[0].Headers.ContentDisposition.FileName;
                        if (fileName != null && fileName.Length > 2)
                        {
                            // strip leading and trailing quotation marks
                            fileName = fileName.Substring(1, fileName.Length - 2);
                            string extension = Path.GetExtension(fileName);
                            string rootFileName = Path.GetFileNameWithoutExtension(fileName);
                            fileName = rootFileName + "-" + Guid.NewGuid().ToString() + extension;
                        }
                        else
                        {
                            fileName = Guid.NewGuid().ToString() + ".png";
                        }
                    }
                    else if (content.Headers.ContentDisposition.Name == "\"data\"")
                    {
                        string jsonString = await content.ReadAsStringAsync();
                        insertRequest = JsonConvert.DeserializeObject<PogFileAddRequest>(jsonString);
                    }
                }

                string key = StorageService.UploadBlob(stream, fileName);
                if (insertRequest == null)
                {
                    insertRequest = new PogFileAddRequest();
                }
                insertRequest.FileKey = key;
                PogService.InsertPogFile(insertRequest);

                string url = ServiceConfig.GetUrlForFile(key);
                ItemResponse<string> response = new ItemResponse<string>
                {
                    Item = url
                };
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (UnauthorizedAccessException)
            {
                var resp = new ErrorResponse("Access denied.");
                return Request.CreateResponse(HttpStatusCode.Forbidden, resp);
            }
            catch (Exception ex)
            {
                var resp = new ErrorResponse(ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, resp);
            }
        }

    }
}
