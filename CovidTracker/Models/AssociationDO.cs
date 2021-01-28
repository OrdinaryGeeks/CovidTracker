using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidTracker.Models
{
    public class AssociationDO
    {
        public int AssociationDOID { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual int TimeBlockID { get; set; }
        public virtual int LatLongGroupID { get; set; }
    }
}