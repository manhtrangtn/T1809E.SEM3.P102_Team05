namespace T1809E.SEM3.P102_Team05.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttrProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Thumbnail", c => c.String());
            AddColumn("dbo.Products", "CreateAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "UpdateAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DeleteAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "InStock", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Status");
            DropColumn("dbo.Products", "InStock");
            DropColumn("dbo.Products", "DeleteAt");
            DropColumn("dbo.Products", "UpdateAt");
            DropColumn("dbo.Products", "CreateAt");
            DropColumn("dbo.Products", "Thumbnail");
        }
    }
}
