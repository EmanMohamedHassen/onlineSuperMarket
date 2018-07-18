namespace OnlineMarket.Market.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddressAndIsAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserAddress", c => c.String());
            AddColumn("dbo.AspNetUsers", "isAdmin", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "isAdmin");
            DropColumn("dbo.AspNetUsers", "UserAddress");
        }
    }
}
