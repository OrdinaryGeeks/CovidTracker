using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidTracker.Models
{
    public class Association
    {
        public int ID { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}