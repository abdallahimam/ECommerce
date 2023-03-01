namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 500),
                        Address = c.String(),
                        Logo = c.String(maxLength: 1024),
                        Location = c.String(maxLength: 1024),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                        MarketType_Id = c.Int(),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MarketTypes", t => t.MarketType_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .Index(t => t.MarketType_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Markets", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Markets", "MarketType_Id", "dbo.MarketTypes");
            DropIndex("dbo.Markets", new[] { "Owner_Id" });
            DropIndex("dbo.Markets", new[] { "MarketType_Id" });
            DropTable("dbo.Markets");
        }
    }
}
