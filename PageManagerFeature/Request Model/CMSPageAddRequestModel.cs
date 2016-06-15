using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabio.Web.Models.Requests
{
    public class CMSAddPageRequestModel
    {

        [Required]
        public string PageName { get; set; }

        [Required]
        public string PageDescription { get; set; }

        [Required]
        public int PageTemplate { get; set; }

        public bool PageIsActive { get; set; }

        //[Required]
        public int WebsiteId { get; set; }

        //[Required]
        public string Slug { get; set; }

        public string EntityId { get; set; }

        public List<CmsPageAttributesRequestModel> attrArray { get; set; }

        public List<CmsPageMetaTagRequestModel> metaArray { get; set; }

    }
}

