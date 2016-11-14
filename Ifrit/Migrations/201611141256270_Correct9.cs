namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BusinessCards", "User_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.BusinessCards", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessCards", "User_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.BusinessCards", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
