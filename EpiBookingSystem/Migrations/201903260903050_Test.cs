namespace EpiBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Customer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Appointments", "Customer_Id");
            AddForeignKey("dbo.Appointments", "Customer_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Customer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "Customer_Id" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.Appointments", "Customer_Id");
        }
    }
}
