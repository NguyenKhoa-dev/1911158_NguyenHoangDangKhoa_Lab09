namespace Lab09_Entity_Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                        FoodCategoryID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.FoodCategoryID, cascadeDelete: true)
                .Index(t => t.FoodCategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Food", "FoodCategoryID", "dbo.Category");
            DropIndex("dbo.Food", new[] { "FoodCategoryID" });
            DropTable("dbo.Food");
            DropTable("dbo.Category");
        }
    }
}
