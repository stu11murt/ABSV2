using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaABSV2.Models
{
    public class Messaging
    {
        public int MessagingID { get; set; }

        public string UserID { get; set; }

        public string Message { get; set; }

        public bool Read { get; set; }

        public bool Archived { get; set; }

        public bool Deleted { get; set; }

        public DateTime Created { get; set; }

    }
}