using Escalation.Model;
using System.Data.Entity;

namespace Escalation.Context
{
    public partial class GameContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<State> States { get; set; }
    }
}