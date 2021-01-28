namespace CovidTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
             //  DropForeignKey("Users", "dbo.Association_AssociationID", "Associations");
             //DropIndex("Users", new[] { "dbo.Association_AssociationID" });
            DropTable("dbo.AssociationDOes");
            DropTable("dbo.LatLongGroupDOes");
            DropTable("dbo.TimeBlockDOes");
            DropTable("dbo.UserDOes");

            CreateTable(
                "dbo.AssociationDOes",
                c => new
                {
                    AssociationDOID = c.Int(nullable: false, identity: true),
                    TimeBlockID = c.Int(nullable: false),
                    LatLongGroupID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AssociationDOID);

            CreateTable(
                "dbo.LatLongGroupDOes",
                c => new
                {
                    LatLongGroupDOID = c.Int(nullable: false, identity: true),
                    NorthWestLat = c.Double(nullable: false),
                    NorthWestLong = c.Double(nullable: false),
                    SouthEastLat = c.Double(nullable: false),
                    SouthEastLong = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.LatLongGroupDOID);

            CreateTable(
                "dbo.TimeBlockDOes",
                c => new
                {
                    TimeBlockDOID = c.Int(nullable: false, identity: true),
                    Begin = c.DateTime(nullable: false, precision: 0),
                    End = c.DateTime(nullable: false, precision: 0),
                })
                .PrimaryKey(t => t.TimeBlockDOID);

            CreateTable(
                "dbo.UserDOes",
                c => new
                {
                    UserDOID = c.Int(nullable: false, identity: true),
                    FName = c.String(unicode: false),
                    LName = c.String(unicode: false),
                    Password = c.String(unicode: false),
                    PhoneNumber = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.UserDOID);


       //     AddColumn("dbo.Users", "AssociationDO_AssociationDOID", c => c.Int());
            //CreateIndex("dbo.Users", "AssociationDO_AssociationDOID");
           
      //      DropColumn("Users", "Association_AssociationID");
     //       DropTable("Associations");
      //      DropTable("LatLongGroups");
      //      DropTable("TimeBlocks");

            Sql("CREATE index `IX_AssociationDOID` on `AssociationDOes` (`AssociationDOID` DESC)");
            Sql("CREATE index `IX_LatLongGroupDOID` on `LatLongGroupDOes` (`LatLongGroupDOID` DESC)");
            Sql("CREATE index `IX_TimeBlockDOID` on `TimeBlockDOes` (`TimeBlockDOID` DESC)");
            Sql("CREATE index `IX_UserDOID` on `UserDOes` (`UserDOID` DESC)");
            AddForeignKey("dbo.Users", "AssociationDO_AssociationDOID", "dbo.AssociationDOes", "AssociationDOID");

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeBlocks",
                c => new
                    {
                        TimeBlockID = c.Int(nullable: false, identity: true),
                        Begin = c.DateTime(nullable: false, precision: 0),
                        End = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.TimeBlockID);
            
            CreateTable(
                "dbo.LatLongGroups",
                c => new
                    {
                        LatLongGroupID = c.Int(nullable: false, identity: true),
                        NorthWestLat = c.Double(nullable: false),
                        NorthWestLong = c.Double(nullable: false),
                        SouthEastLat = c.Double(nullable: false),
                        SouthEastLong = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LatLongGroupID);
            
            CreateTable(
                "dbo.Associations",
                c => new
                    {
                        AssociationID = c.Int(nullable: false, identity: true),
                        TimeBlockID = c.Int(nullable: false),
                        LatLongGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssociationID);
            
            AddColumn("dbo.Users", "Association_AssociationID", c => c.Int());
            DropForeignKey("Users", "AssociationDO_AssociationDOID", "dbo.AssociationDOes");
            DropIndex("Users", new[] { "AssociationDO_AssociationDOID" });
            DropColumn("Users", "AssociationDO_AssociationDOID");
            DropTable("UserDOes");
            DropTable("TimeBlockDOes");
            DropTable("LatLongGroupDOes");
            DropTable("AssociationDOes");
            CreateIndex("Users", "Association_AssociationID");
            AddForeignKey("Users", "Association_AssociationID", "dbo.Associations", "AssociationID");
        }
    }
}
