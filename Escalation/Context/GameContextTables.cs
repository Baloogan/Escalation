using Escalation.Model;
using System.Data.Entity;

namespace Escalation.Context
{
    public partial class GameContext
    {

        public DbSet<User> Users { get; set; }
    }
}