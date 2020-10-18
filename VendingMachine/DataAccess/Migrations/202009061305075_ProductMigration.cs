namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        ItemsLeft = c.Int(nullable: false),
                        ItemsSold = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Money",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MoneyType=c.String(),
                    MoneyQuantity = c.Int(nullable: false),



                }

                );
            
        }


        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Money");
        }
    }
}
