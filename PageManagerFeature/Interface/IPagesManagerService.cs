using Spright.Web.Domain;
using Spright.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spright.Web.Services.Interfaces
{
    public interface IPagesManagerService

    {

        int Insert(CMSAddPageRequestModel model);
        int InsertWithWebsiteId(CMSAddPageRequestModel model);
        List<CMSPage> List();
        CMSPage GetPageBySlugAndWebsiteId(string slug, int pagesId);
        CMSPage GetPageById(int pagesId);
        List<CMSPage> GetPageByWebsiteId(int websiteId);
        void Update(CMSAddPageRequestModel model, int pagesId);
        void DeletePagesAttributes(int pagesId);
        void DeletePagesMeta(int pagesId);
        void DeletePagesById(int pagesId);
        string checkSlug(CmsPageSlugCheckRequestModel model);
        void cmsPageAttrInsert(CmsPageAttributesRequestModel model, int pageId);
        void cmsMetaTagsInsert(CmsPageMetaTagRequestModel model, int pageId);
        List<CmsPageAttributes> ListAttrByPageId(int pageId);

    }
}
