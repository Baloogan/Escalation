
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Escalation.Context
{

    public partial class GameContext : DbContext
    {
        private GameContext(string connString) : base(connString)
        {
            Database.SetInitializer(new DropCreateAndMigrateDatabaseInitializer<GameContext, GameContextConfiguration>());
            Current = this;
        }


        public static Mutex Mutex = new Mutex(false, "Escalation_GameContext");
        public volatile static GameContext Current = null;
        public static GameContext Create()
        {
            if (Mutex.WaitOne(10000))
            {
                init();
                if (Environment.MachineName.ToUpper() == "STONEBURNER")
                    return new GameContext("GameContext_Stoneburner");
                else
                    return new GameContext("GameContext_Server");
            }
            else
            {
                throw new GameContextMutexException("Mutex was unable to acquire.");
            }

        }
        public static GameContext CreateDisableLazyLoading()
        {
            var a = Create();
            a.Configuration.LazyLoadingEnabled = false;
            return a;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Current = null;
            Mutex.ReleaseMutex();
        }
        private static bool need_init = true; //one per app domain
        public static Mutex InitDbMutex = new Mutex(false, "Escalation_GameContext_InitDb");
        private static void init()
        {
            if (need_init)
            {
                need_init = false; // set it just for this one app domain
                if (InitDbMutex.WaitOne(100))
                {
                    if (Environment.MachineName.ToUpper() == "STONEBURNER")
                    {
                        using (var db = Context.GameContext.Create())
                        {
                            db.Database.Initialize(true);
                            //Game.GameInstance.Instance.time_request(db.Users.First(U => U.Name == "Baloogan"), TimeSpan.FromDays(8).TotalSeconds);
                        }
                        //Game.GameInstance.Instance.time_request_skip();
                    }
                    //do NOT release!
                }
                else
                {
                    //already inited
                }
            }

        }
        public override int SaveChanges()
        {

            return base.SaveChanges();
        }

    }
}
