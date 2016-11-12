namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resumes", "Body", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Vacancies", "Body", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vacancies", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Resumes", "Body", c => c.String(nullable: false));
        }
    }
}
