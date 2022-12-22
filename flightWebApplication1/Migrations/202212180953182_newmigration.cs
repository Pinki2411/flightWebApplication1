namespace flightWebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Booking_id = c.Int(nullable: false, identity: true),
                        Passenger_Name = c.String(nullable: false, maxLength: 30),
                        City = c.String(nullable: false, maxLength: 40),
                        Country = c.String(nullable: false, maxLength: 30),
                        Passport_No = c.String(nullable: false, maxLength: 12),
                        Gender = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        ReferenceNo = c.Int(nullable: false),
                        Flight_Id = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Booking_id)
                .ForeignKey("dbo.Flights", t => t.Flight_Id, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.Email, cascadeDelete: true)
                .Index(t => t.Flight_Id)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        Booking_id = c.Int(nullable: false),
                        CheckInId = c.Int(nullable: false),
                        Seat_Allocation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Booking_id)
                .ForeignKey("dbo.Bookings", t => t.Booking_id)
                .Index(t => t.Booking_id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        Flight = c.String(nullable: false, maxLength: 30),
                        To = c.String(nullable: false, maxLength: 50),
                        From = c.String(nullable: false, maxLength: 50),
                        DateAndTime = c.DateTime(nullable: false),
                        Fare = c.Single(nullable: false),
                        seatAvailable = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Email", "dbo.Registrations");
            DropForeignKey("dbo.Bookings", "Flight_Id", "dbo.Flights");
            DropForeignKey("dbo.CheckIns", "Booking_id", "dbo.Bookings");
            DropIndex("dbo.CheckIns", new[] { "Booking_id" });
            DropIndex("dbo.Bookings", new[] { "Email" });
            DropIndex("dbo.Bookings", new[] { "Flight_Id" });
            DropTable("dbo.Registrations");
            DropTable("dbo.Flights");
            DropTable("dbo.CheckIns");
            DropTable("dbo.Bookings");
        }
    }
}
