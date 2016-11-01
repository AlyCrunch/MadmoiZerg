namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Firstname", c => c.String());
            DropColumn("dbo.Profiles", "First");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "First", c => c.String());
            DropColumn("dbo.Profiles", "Firstname");
        }
    }
}
