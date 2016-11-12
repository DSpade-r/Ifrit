namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            DropIndex("dbo.Vacancies", new[] { "User_Id" });
            AddColumn("dbo.Resumes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Vacancies", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Resumes", "User_id", c => c.String(nullable: false));
            AlterColumn("dbo.Vacancies", "User_id", c => c.String(nullable: false));
            CreateIndex("dbo.Resumes", "ApplicationUser_Id");
            CreateIndex("dbo.Vacancies", "ApplicationUser_Id");
            AddForeignKey("dbo.Resumes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Vacancies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resumes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Vacancies", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Resumes", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Vacancies", "User_id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Resumes", "User_id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Vacancies", "ApplicationUser_Id");
            DropColumn("dbo.Resumes", "ApplicationUser_Id");
            CreateIndex("dbo.Vacancies", "User_Id");
            CreateIndex("dbo.Resumes", "User_Id");
            AddForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Resumes", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
