using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace CovidTracker.Models
{

   // [DbConfigurationType(typeof(MySqlEFConfiguration))]

    public class DOContext : DbContext
    {

        public DOContext() : base("DOContext")
        {

            //    
            this.Configuration.LazyLoadingEnabled = false;

            //   Database.SetInitializer<DBContext>(new CovidTrackerInitializer());

            //   Database.CreateIfNotExists();
            //    
            //   var db = new DBContext();
            // Database.Initialize(true);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //      modelBuilder.Entity<Car>().MapToStoredProcedures();
        }


        public DbSet<AssociationDO> Associations { get; set; }
        public DbSet<LatLongGroupDO> LatLongGroups { get; set; }
        public DbSet<TimeBlockDO> TimeBlocks { get; set; }
        public DbSet<UserDO> Users { get; set; }


    }
}