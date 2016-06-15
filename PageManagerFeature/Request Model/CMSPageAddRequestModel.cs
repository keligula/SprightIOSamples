using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spright.Web.Models.Requests
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

    }
}

