namespace DentistSpace.Web
{
    using System.Data.Entity;
    using DentistSpace.Data;
    using DentistSpace.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DentistSpaceDbContext, Configuration>());
            DentistSpaceDbContext.Create().Database.Initialize(true);
        }
    }
}