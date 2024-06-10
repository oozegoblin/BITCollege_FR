namespace BITCollege_Felipe_Rincon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Data_Annotations_Remove : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CourseNumber", c => c.String(nullable: false));
        }
    }
}
