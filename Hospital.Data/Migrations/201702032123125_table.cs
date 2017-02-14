namespace Hospital.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patientinfoes",
                c => new
                    {
                        PatientInfoID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PatientInfoID);
            
            CreateTable(
                "dbo.PatientLogins",
                c => new
                    {
                        PatientLoginID = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        PassWord = c.String(),
                    })
                .PrimaryKey(t => t.PatientLoginID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PatientLogins");
            DropTable("dbo.Patientinfoes");
        }
    }
}
