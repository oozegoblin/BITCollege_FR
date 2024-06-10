namespace BITCollege_Felipe_Rincon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    /*
* Name: Felipe Rincon
* Course: COMP-1281 C# Programming 3
* Created: 2024-02-22
* Updated: 2024-02-27
*/
    /// Third add Migration, StoredProcedures Customatization.
    /// In the migration code that is generated code the up and down methods.
    public partial class StoredProcedures : DbMigration
    {
        public override void Up()
        {
            //call script to create the stored procedure
            this.Sql(Properties.Resources.create_next_number1);
            /// this.Sql(Properties.Resources.create_next_number);
        }

        public override void Down()
        {
            //call script to drop the stored procedure
            this.Sql(Properties.Resources.drop_next_number1);
            ///this.Sql(Properties.Resources.drop_next_number);
        }
    }
}
