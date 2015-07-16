using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaABSV2.Models
{
    public class EmailManager
    {
        public int EmailManagerID { get; set; }

        public int EmailCount { get; set; }
        
        public ICollection<string> EmailListName { get; set; }

       
        public string EmailTemplateContent { get; set; }
        public ICollection<EmailTemplates> EmailTempates { get; set; }


    }
}