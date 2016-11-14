namespace Ifrit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessCards", "Adress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusinessCards", "Adress");
        }
    }
}
