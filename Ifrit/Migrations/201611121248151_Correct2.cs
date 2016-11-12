namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vacancies", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vacancies", "Salary", c => c.String());
        }
    }
}
