using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AlphaABSV2.Models
{
    public class EventParent
    {
        public int EventParentID { get; set; }

        public string EventName { get; set; }


        public virtual ICollection<Event> Events { get; set; }
    }
}