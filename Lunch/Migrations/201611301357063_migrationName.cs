namespace Lunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        BusinessName = c.String(nullable: false),
                        DishName = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Remark = c.String(),
                        Ispay = c.Boolean(nullable: false),
                        UserID = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Pwd = c.String(nullable: false),
                        UserName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
        }
    }
}
