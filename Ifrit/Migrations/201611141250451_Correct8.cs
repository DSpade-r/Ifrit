namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessCards", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusinessCards", "Title");
        }
    }
}
