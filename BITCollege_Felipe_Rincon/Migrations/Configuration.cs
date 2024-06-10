namespace BITCollege_Felipe_Rincon.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    /*
* Name: Felipe Rincon
* Course: COMP-1281 C# Programming 3
* Created: 2024-02-16
* Updated: 2024-02-21
*/
    /// First Code Migration
    internal sealed class Configuration : DbMigrationsConfiguration<BITCollege_Felipe_Rincon.Data.BITCollege_Felipe_RinconContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BITCollege_Felipe_Rincon.Data.BITCollege_Felipe_RinconContext";
        }

        protected override void Seed(BITCollege_Felipe_Rincon.Data.BITCollege_Felipe_RinconContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
