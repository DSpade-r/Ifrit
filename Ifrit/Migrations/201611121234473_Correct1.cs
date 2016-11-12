namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resumes", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resumes", "Salary", c => c.String());
        }
    }
}
