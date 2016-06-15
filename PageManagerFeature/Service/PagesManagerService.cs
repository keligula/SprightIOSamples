using Sabio.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using Sabio.Data;
using Sabio.Web.Domain;
using Sabio.Web.Services.Interfaces;
using System.Text.RegularExpressions;
using Sabio.Web.Controllers.Api;

namespace Sabio.Web.Services
{
    public class PagesManagerService : BaseService, IPagesManagerService

    {
        // POST: Create new page
        public int Insert(CMSAddPageRequestModel model)

        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.CMSPages_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@PageName", model.PageName);
                   paramCollection.AddWithValue("@PageDescription", model.PageDescription);
                   paramCollection.AddWithValue("@PageTemplate", model.PageTemplate);
                   paramCollection.AddWithValue("@PageIsActive", model.PageIsActive);
                   paramCollection.AddWithValue("@WebsiteId", model.WebsiteId);
                   paramCollection.AddWithValue("@Slug", model.Slug);
                   paramCollection.AddWithValue("@EntityId", model.EntityId);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)

               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
               );

            return id;
        }

        // POST: Create new page with websiteId
        public int InsertWithWebsiteId(CMSAddPageRequestModel model)

        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.CMSPages_InsertWithWebsiteId"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@PageName", model.PageName);
                   paramCollection.AddWithValue("@PageDescription", model.PageDescription);
                   paramCollection.AddWithValue("@PageTemplate", model.PageTemplate);
                   paramCollection.AddWithValue("@PageIsActive", model.PageIsActive);
                   paramCollection.AddWithValue("@WebsiteId", model.WebsiteId);
                   paramCollection.AddWithValue("@Slug", model.Slug);
                   paramCollection.AddWithValue("@EntityId", model.EntityId);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
               );

            return id;
        }

        // insert cms page attributes
        public void cmsPageAttrInsert(CmsPageAttributesRequestModel model, int pageId)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.CmsPageAttributes_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@CmsPageId", pageId);
                   paramCollection.AddWithValue("@Filter", model.Filter);
                   paramCollection.AddWithValue("@AttributeId", model.Id);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
               }
               );
        }

        // insert cms page metaTags
        public void cmsMetaTagsInsert(CmsPageMetaTagRequestModel model, int pageId)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.CMSPages_MetaTag_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@metaKey", model.metaKey);
                   paramCollection.AddWithValue("@metaValue", model.metaValue);
                   paramCollection.AddWithValue("@pageId", pageId);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
               }
               );
        }

        // GET: List the Pages Index
        public List<Domain.CMSPage> List()
        {

            List<Domain.CMSPage> returnList = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.CMSPages_List"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {

               }, map: delegate (IDataReader reader, short set)
               {

                   Domain.CMSPage p = new Domain.CMSPage();
                   int startingIndex = 0;

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.PageName = reader.GetSafeString(startingIndex++);
                   p.PageDescription = reader.GetSafeString(startingIndex++);
                   p.PageTemplate = reader.GetSafeInt32(startingIndex++);
                   p.PageIsActive = reader.GetSafeBool(startingIndex++);
                   if (returnList == null)
                   {
                       returnList = new List<Domain.CMSPage>();
                   }
                   returnList.Add(p);

               });

            return returnList;
        }

        // GET: Select Page by slug AND websiteId
        public CMSPage GetPageBySlugAndWebsiteId(string slug, int pagesId)
        {
            CMSPage p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.CMSPages_SelectBySlugAndWebsiteId"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@WebsiteId", pagesId);
                  paramCollection.AddWithValue("@Slug", slug);

              }, map: delegate (IDataReader reader, short set)

              {
                  p = new CMSPage();
                  int startingIndex = 0;

                  p.Id = reader.GetSafeInt32(startingIndex++);
                  p.PageName = reader.GetSafeString(startingIndex++);
                  p.PageDescription = reader.GetSafeString(startingIndex++);
                  p.PageTemplate = reader.GetSafeInt32(startingIndex++);
                  p.PageIsActive = reader.GetSafeBool(startingIndex++);
                  p.WebsiteId = reader.GetSafeInt32(startingIndex++);
                  p.Slug = reader.GetSafeString(startingIndex++);
              }
              );

            return p;
        }

        // GET: Select Page by ID
        public Domain.CMSPage GetPageById(int pagesId)
        {
            Domain.CMSPage p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.CMSPages_SelectById"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@Id", pagesId);

              }, map: delegate (IDataReader reader, short set)

              {
                  if (set == 0)
                  {
                      p = new CMSPage();
                      int startingIndex = 0;

                      p.Id = reader.GetSafeInt32(startingIndex++);
                      p.PageName = reader.GetSafeString(startingIndex++);
                      p.PageDescription = reader.GetSafeString(startingIndex++);
                      p.PageTemplate = reader.GetSafeInt32(startingIndex++);
                      p.PageIsActive = reader.GetSafeBool(startingIndex++);
                      p.WebsiteId = reader.GetSafeInt32(startingIndex++);
                      p.Slug = reader.GetSafeString(startingIndex++);
                      p.EntityId = reader.GetSafeInt32(startingIndex++);
                      p.attrArray = new List<CmsPageAttributes>();
                      p.metaArray = new List<CmsPageMetaTag>();
                  }
                  else if (set == 1)
                  {
                      int startingIndex = 0;
                      CmsPageAttributes attr = new CmsPageAttributes();
                      attr.Id = reader.GetSafeInt32(startingIndex++);
                      attr.Filter = reader.GetSafeString(startingIndex++);
                      p.attrArray.Add(attr);
                  }
                  else if (set == 2)
                  {
                      int startingIndex = 0;
                      CmsPageMetaTag meta = new CmsPageMetaTag();
                      meta.metaKey = reader.GetSafeString(startingIndex++);
                      meta.metaValue = reader.GetSafeString(startingIndex++);
                      p.metaArray.Add(meta);
                  }

              }
              );

            return p;
        }

        // GET: Select Page by websiteID 
        public List<CMSPage> GetPageByWebsiteId(int websiteId)
        {
            List<CMSPage> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.CMSPages_SelectByWebsiteId"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@websiteId", websiteId);

              }, map: delegate (IDataReader reader, short set)

              {
                  CMSPage p = new CMSPage();
                  int startingIndex = 0;

                  p.Id = reader.GetSafeInt32(startingIndex++);
                  p.PageName = reader.GetSafeString(startingIndex++);
                  p.PageDescription = reader.GetSafeString(startingIndex++);
                  p.PageDescription = Regex.Replace(p.PageDescription, @"<[^>]*>", String.Empty); // remove html tags
                  p.PageTemplate = reader.GetSafeInt32(startingIndex++);
                  p.PageIsActive = reader.GetSafeBool(startingIndex++);
                  p.Slug = reader.GetSafeString(startingIndex++);

                  if (list == null)
                  {
                      list = new List<CMSPage>();
                  }
                  list.Add(p);
              }
              );

            return list;
        }

        // PUT: Update Pages by Id
        public void Update(CMSAddPageRequestModel model, int pagesId)

        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.CMSPages_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", pagesId);
                   paramCollection.AddWithValue("@PageName", model.PageName);
                   paramCollection.AddWithValue("@PageDescription", model.PageDescription);
                   paramCollection.AddWithValue("@PageTemplate", model.PageTemplate);
                   paramCollection.AddWithValue("@PageIsActive", model.PageIsActive);
                   paramCollection.AddWithValue("@Slug", model.Slug);
                   paramCollection.AddWithValue("@EntityId", model.EntityId);

               }, returnParameters: delegate (SqlParameterCollection param)
               {

               });
        }

        // DELETE Pages by Id
        public void DeletePagesById(int pagesId)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.CMSPages_Delete"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@ID", pagesId);

              }, returnParameters: delegate (SqlParameterCollection param)
               {

               }
               );
        }

        // DELETE Pages by Id
        public void DeletePagesAttributes(int pagesId)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.CmsPageAttributes_DeleteById"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@CmsPageId", pagesId);

              }, returnParameters: delegate (SqlParameterCollection param)
              {

              }
               );
        }

        // DELETE Pages by Id
        public void DeletePagesMeta(int pagesId)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.CmsPageMeta_DeleteById"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@CmsPageId", pagesId);

              }
              );
        }

        // check slug
        public string checkSlug(CmsPageSlugCheckRequestModel model)
        {
            string slugVal = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.CMSPages_checkSlug"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@WebsiteId", model.websiteId);
                  paramCollection.AddWithValue("@Slug", model.slug);

              }, map: delegate (IDataReader reader, short set)

              {
                  int startingIndex = 0;

                  slugVal = reader.GetSafeString(startingIndex++);

              }
              );

            return slugVal;
        }

        // GET: List Attributes by PageId
        public List<CmsPageAttributes> ListAttrByPageId(int pageId)
        {
            List<CmsPageAttributes> List = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.CMSPageAttributes_ListAttr_By_PageId"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@PageId", pageId);

              }, map: delegate (IDataReader reader, short set)

              {

                  int startingIndex = 0;
                  CmsPageAttributes attr = new CmsPageAttributes();
                  attr.EntityId = reader.GetSafeInt32(startingIndex++);
                  attr.CmsPageId = reader.GetSafeInt32(startingIndex++);
                  attr.Id = reader.GetSafeInt32(startingIndex++);
                  attr.Filter = reader.GetSafeString(startingIndex++);
                  if (List == null)
                  {
                      List = new List<CmsPageAttributes>();
                  }
                  List.Add(attr);
              }
              );

            return List;
        }

    }

}
