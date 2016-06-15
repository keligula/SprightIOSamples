using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabio.Web.Domain
{
    public class CMSPage
    {

        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public int PageTemplate { get; set; }
        public bool PageIsActive { get; set; }
        public int WebsiteId { get; set; }
        public string Slug { get; set; }
        public int EntityId { get; set; }
        public List<CmsPageAttributes> attrArray { get; set; }
        public List<CmsPageMetaTag> metaArray { get; set; }

    }
}