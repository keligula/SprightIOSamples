using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spright.Web.Domain
{
    public class CMSPage
    {

        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public int PageTemplate { get; set; }
        public bool PageIsActive { get; set; }
        
    }
}
