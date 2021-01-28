using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidTracker.Models
{
    public class TimeBlockDO
    {
        public int TimeBlockDOID { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
}