using Spright.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using Spright.Data;
using Spright.Web.Domain;
using Spright.Web.Services.Interfaces;
using System.Text.RegularExpressions;
using Spright.Web.Controllers.Api;

namespace Spright.Web.Services
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


        // GET: Select Page by Id
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

    }

}
