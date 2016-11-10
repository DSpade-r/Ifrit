namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CVs",
                c => new
                    {
                        CVId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Salary = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CVId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        VacancyId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Salary = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VacancyId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CVs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Vacancies", new[] { "User_Id" });
            DropIndex("dbo.CVs", new[] { "User_Id" });
            DropTable("dbo.Vacancies");
            DropTable("dbo.CVs");
        }
    }
}
