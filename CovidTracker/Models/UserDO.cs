using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidTracker.Models
{
    public class UserDO
    {


        public int UserDOID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public string Password { get; set; }
        public long PhoneNumber { get; set; }

        public ICollection<Association> Associations;
    }
}