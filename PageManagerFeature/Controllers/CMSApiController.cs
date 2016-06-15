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

        // POST: Create Page
        [Route("websiteId"), HttpPost]
        public HttpResponseMessage CreateCMSPageWithWebsiteId(CMSAddPageRequestModel model)

        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = _pagesManagerService.InsertWithWebsiteId(model);

            if (model.attrArray != null)
            {
                foreach (CmsPageAttributesRequestModel item in model.attrArray)
                {
                    _pagesManagerService.cmsPageAttrInsert(item, response.Item);
                }
            }

            if (model.metaArray != null)
            {
                foreach (CmsPageMetaTagRequestModel meta in model.metaArray)
                {
                    _pagesManagerService.cmsMetaTagsInsert(meta, response.Item);
                }
            }

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

        // GET: List Page by websiteId
        [Route("website/{websiteId:int}"), HttpGet]
        public HttpResponseMessage GetPageByWebsiteId(int websiteId)

        {

            ItemsResponse<CMSPage> response = new ItemsResponse<CMSPage>();

            response.Items = _pagesManagerService.GetPageByWebsiteId(websiteId);

            return Request.CreateResponse(response);

        }

        // GET: List Page by Id
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

            // delete previous attr
            _pagesManagerService.DeletePagesAttributes(pagesId);

            if (model.attrArray != null)
            {
                foreach (CmsPageAttributesRequestModel item in model.attrArray)
                {
                    _pagesManagerService.cmsPageAttrInsert(item, pagesId);
                }
            }

            _pagesManagerService.DeletePagesMeta(pagesId);

            if (model.metaArray != null)
            {
                foreach (CmsPageMetaTagRequestModel meta in model.metaArray)
                {
                    _pagesManagerService.cmsMetaTagsInsert(meta, pagesId);
                }
            }

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

        // GET: List Page by Id
        [Route("checkSlug"), HttpGet]
        public HttpResponseMessage checkSlug([FromUri]CmsPageSlugCheckRequestModel model)
        {
            System.Diagnostics.Debug.WriteLine("model is ", model);
            ItemResponse<string> response = new ItemResponse<string>();

            response.Item = _pagesManagerService.checkSlug(model);

            return Request.CreateResponse(response);

        }


    }
}



