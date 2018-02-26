namespace BusinessCards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Position : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessCards", "Position", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusinessCards", "Position");
        }
    }
}
