using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidTracker.Models
{
    public class User
    {


        public int UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public string Password { get; set; }
        public long PhoneNumber { get; set; }

        public ICollection<Association> Associations;
    }
}