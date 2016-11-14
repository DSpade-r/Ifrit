namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessCards",
                c => new
                    {
                        BusinessCardId = c.Int(nullable: false, identity: true),
                        Logo = c.Binary(storeType: "image"),
                        WebSite = c.String(),
                        Description = c.String(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.BusinessCardId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessCards", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BusinessCards", new[] { "User_Id" });
            DropTable("dbo.BusinessCards");
        }
    }
}
