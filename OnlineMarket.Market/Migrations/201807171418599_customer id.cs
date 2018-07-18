namespace OnlineMarket.Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CustomerId");
        }
    }
}
