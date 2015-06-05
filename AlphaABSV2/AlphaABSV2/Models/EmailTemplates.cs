using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaABSV2.Models
{
    public class EmailTemplates
    {
        public int EmailTemplatesID { get; set; }

        public string TemplateTitle { get; set; }

        public string TemplateContent { get; set; }

        public int EmailCategoryID { get; set; }

        public bool MailChimp { get; set; }
    }
}