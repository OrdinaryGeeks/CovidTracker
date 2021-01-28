﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidTracker.Models
{
    public class CovidTrackerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DOContext>
    {

        protected override void Seed(DOContext context)
        {
         

            var Users = new List<UserDO> { new UserDO { FName = "Alecto", LName = "Perfecto", PhoneNumber = 9012231212 },
            new UserDO { FName = "Natty", LName = "Trey", PhoneNumber = 9012111212 } };

            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var LatLongGroups = new List<LatLongGroupDO> { new LatLongGroupDO { NorthWestLat = 34.9616669, NorthWestLong = -90.046665, SouthEastLat = 34.9616673, SouthEastLong = -90.046669 } };
            LatLongGroups.ForEach(s => context.LatLongGroups.Add(s));
            context.SaveChanges();
            var TimeBlocks = new List<TimeBlockDO> { new Models.TimeBlockDO { Begin = new DateTime(2020, 12, 29, 8, 0, 0), End = new DateTime(2020, 12, 29, 11, 59, 0) } };
            TimeBlocks.ForEach(s => context.TimeBlocks.Add(s));
            context.SaveChanges();
            var Associations = new List<AssociationDO> { new AssociationDO { LatLongGroupID = 0, TimeBlockID = 0 } };
            Associations.ForEach(s => context.Associations.Add(s));
            context.SaveChanges();


            base.Seed(context);
        }
    }
}