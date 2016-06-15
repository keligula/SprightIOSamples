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
        List<CMSPage> List();
        CMSPage GetPageById(int pagesId);
        void Update(CMSAddPageRequestModel model, int pagesId);
        void DeletePagesById(int pagesId);
        
    }
}
