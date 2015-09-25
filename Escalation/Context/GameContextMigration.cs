using Escalation.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
namespace Escalation.Context
{//raistlin31



    public partial class GameContext : DbContext
    {
        internal static readonly bool destructive_init = true;
    }


    internal sealed class GameContextConfiguration : DbMigrationsConfiguration<GameContext>
    {
        public GameContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        public class info_schema
        {
            public string TABLE_CATALOG { get; set; }
            public string TABLE_SCHEMA { get; set; }
            public string TABLE_NAME { get; set; }
            public string TABLE_TYPE { get; set; }
        }
        public class table_counter
        {
            public int counter { get; set; }
        }


        protected override void Seed(GameContext context)
        {
            User gameUser = new User() { Name = "Escalation" };
            context.Users.AddOrUpdate(gameUser);

            //Game.Seed.MainSeed.SeedDatabase(context);
            
            context.SaveChanges();


        }
    }

    public class DropCreateAndMigrateDatabaseInitializer<TContext, TMigrationsConfiguration> : IDatabaseInitializer<TContext>
   where TContext : DbContext
   where TMigrationsConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<TContext>, new()
    {
        public void InitializeDatabase(TContext context)
        {

            if (GameContext.destructive_init)
            {
                if (Environment.MachineName.ToUpper() == "STONEBURNER")
                {

                    context.Database.Delete();
                }
                else
                {
                    if (context.Database.Exists())
                    {
                        // set the database to SINGLE_USER so it can be dropped
                        context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "ALTER DATABASE [" + context.Database.Connection.Database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");

                        // drop the database
                        context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, "USE master DROP DATABASE [" + context.Database.Connection.Database + "]");
                    }
                }
                
                var migrator = new MigrateDatabaseToLatestVersion<TContext, TMigrationsConfiguration>();
                migrator.InitializeDatabase(context);
            }

        }
    }
    public class MigrationsGameContextFactory : IDbContextFactory<GameContext>
    {
        public GameContext Create()
        {
            return GameContext.Create();
        }
    }
}