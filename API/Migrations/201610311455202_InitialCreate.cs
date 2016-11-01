namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        First = c.String(),
                        Lastname = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Town = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Active = c.Boolean(nullable: false),
                        Self = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profiles");
        }
    }
}
