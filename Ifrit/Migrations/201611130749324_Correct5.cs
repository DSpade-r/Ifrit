namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            DropIndex("dbo.Vacancies", new[] { "User_Id" });
            AlterColumn("dbo.Resumes", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Vacancies", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Resumes", "User_Id");
            CreateIndex("dbo.Vacancies", "User_Id");
            AddForeignKey("dbo.Resumes", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Vacancies", new[] { "User_Id" });
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            AlterColumn("dbo.Vacancies", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Resumes", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Vacancies", "User_Id");
            CreateIndex("dbo.Resumes", "User_Id");
            AddForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Resumes", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
