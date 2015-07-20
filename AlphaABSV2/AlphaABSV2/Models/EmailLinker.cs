using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AlphaABSV2.Models
{
    public class EmailLinker
    {
        public int EmailLinkerID { get; set; }

        [ForeignKey("EmailTemplates")]
        public int EmailTemplatesID { get; set; }

        public EmailTemplates EmailTemplates { get; set; }

        [ForeignKey("EmailCategories")]
        public int EmailCategoriesID { get; set; }

        public EmailCategories EmailCategories { get; set; }
    }
}