namespace T1809E.SEM3.P102_Team05.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {

      public override void Up()
      {

        DropTable("dbo.Products");
        CreateTable(
            "dbo.Products",
            c => new
            {
              Id = c.Int(nullable: false, identity: true),
              Name = c.String(),
              Price = c.Double(nullable: false),
              Thumbnail = c.String(),
              CreatedAt = c.DateTime(false),
              UpdatedAt = c.DateTime(false),
              DeletedAt = c.DateTime(false),
              InStock = c.Int(false),
              Status = c.String(false)
            })
          .PrimaryKey(t => t.Id);
        }

      public override void Down()
      {
        DropTable("dbo.Products");
      }
    }
}
