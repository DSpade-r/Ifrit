namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resumes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vacancies", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Resumes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Vacancies", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Resumes", "User_id");
            DropColumn("dbo.Vacancies", "User_id");
            RenameColumn(table: "dbo.Resumes", name: "ApplicationUser_Id", newName: "User_Id");
            RenameColumn(table: "dbo.Vacancies", name: "ApplicationUser_Id", newName: "User_Id");
            AlterColumn("dbo.Resumes", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Resumes", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Vacancies", "User_Id", c => c.String(nullable: false, maxLength: 128));
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
            AlterColumn("dbo.Vacancies", "User_Id", c => c.String(nullable: false));
            AlterColumn("dbo.Resumes", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Resumes", "User_Id", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Vacancies", name: "User_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Resumes", name: "User_Id", newName: "ApplicationUser_Id");
            AddColumn("dbo.Vacancies", "User_id", c => c.String(nullable: false));
            AddColumn("dbo.Resumes", "User_id", c => c.String(nullable: false));
            CreateIndex("dbo.Vacancies", "ApplicationUser_Id");
            CreateIndex("dbo.Resumes", "ApplicationUser_Id");
            AddForeignKey("dbo.Vacancies", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Resumes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
