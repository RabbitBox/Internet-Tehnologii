namespace DTJD.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DTJD.Models.DTJD_Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DTJD.Models.DTJD_Db";
        }

        protected override void Seed(DTJD.Models.DTJD_Db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
