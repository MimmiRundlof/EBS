namespace EpiBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        Treatment_TreatmentId = c.Int(),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Treatments", t => t.Treatment_TreatmentId)
                .Index(t => t.Treatment_TreatmentId);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TreatmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Treatment_TreatmentId", "dbo.Treatments");
            DropIndex("dbo.Appointments", new[] { "Treatment_TreatmentId" });
            DropTable("dbo.Treatments");
            DropTable("dbo.Appointments");
        }
    }
}
