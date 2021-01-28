using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;


namespace CovidTracker.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DBContext :DbContext
    {




        public DBContext() :base("DOContext")
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


        public DbSet<Association> Associations { get; set; }
        public DbSet<LatLongGroup> LatLongGroups { get; set; }
        public DbSet<TimeBlock> TimeBlocks { get; set; }
        public DbSet<User> Users { get; set; }


    }
}