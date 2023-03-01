namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Slug = c.String(),
                        Status = c.Boolean(nullable: false),
                        Market_Id = c.Int(),
                        Parent_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Markets", t => t.Market_Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Market_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.Markets", "Address", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Market_Id", "dbo.Markets");
            DropIndex("dbo.Categories", new[] { "User_Id" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropIndex("dbo.Categories", new[] { "Market_Id" });
            AlterColumn("dbo.Markets", "Address", c => c.String());
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Categories");
        }
    }
}
