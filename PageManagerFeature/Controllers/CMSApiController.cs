using Spright.Web.Domain;
using Spright.Web.Models.Requests;
using Spright.Web.Models.Responses;
using Spright.Web.Services;
using Spright.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spright.Web.Controllers.Api
{
    [RoutePrefix("api/cms")]
    public class CMSApiController : ApiController
    {
        private IPagesManagerService _pagesManagerService { get; set; }

        public CMSApiController(IPagesManagerService pagesManagerService)
        
        {
            _pagesManagerService = pagesManagerService;
        }

        // POST: Create Page
        [Route("pages"), HttpPost]
        public HttpResponseMessage CreateCMSPage(CMSAddPageRequestModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = _pagesManagerService.Insert(model);

            return Request.CreateResponse(response);

        }

        // GET: List all Pages in Index View
        [Route, HttpGet]
        public HttpResponseMessage List()
        {

            ItemsResponse<CMSPage> response = new ItemsResponse<CMSPage>();

            response.Items = _pagesManagerService.List();

            return Request.CreateResponse(response);

        }

        // GET: Page by Id
        [Route("{pagesId:int}"), HttpGet]
        public HttpResponseMessage GetPageById(int pagesId)
        {

            ItemResponse<CMSPage> response = new ItemResponse<CMSPage>();

            response.Item = _pagesManagerService.GetPageById(pagesId);

            return Request.CreateResponse(response);

        }

        // PUT: Update by pagesId
        [Route("{pagesId:int}"), HttpPut]
        public HttpResponseMessage UpdateCMSPages(CMSAddPageRequestModel model, int pagesId)
        {
            
            if (!ModelState.IsValid)
            
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            SuccessResponse response = new SuccessResponse();

            _pagesManagerService.Update(model, pagesId);

            return Request.CreateResponse(response);

        }

        // DELETE by Id
        [Route("{pagesId:int}"), HttpDelete]
        public HttpResponseMessage DeletePagesById(int pagesId)
        {
            
            SuccessResponse response = new SuccessResponse();

            _pagesManagerService.DeletePagesById(pagesId);

            return Request.CreateResponse(response);

        }


    }
}



