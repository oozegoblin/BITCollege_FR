namespace BITCollege_Felipe_Rincon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    /*
* Name: Felipe Rincon
* Course: COMP-1281 C# Programming 3
* Created: 2024-02-16
* Updated: 2024-02-21
*/
    /// Second add migration
    public partial class StudentCardAndControllers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NextUniqueNumbers",
                c => new
                    {
                        NextUniqueNumberId = c.Int(nullable: false, identity: true),
                        NextAvailableNumber = c.Long(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NextUniqueNumberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NextUniqueNumbers");
        }
    }
}
