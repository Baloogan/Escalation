using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation.Model
{
    public class Game
    {
        public string Name { get; set; }
        public virtual User User { get; set; }//can be null
        public virtual List<State> States { get; set; } = new List<State>();
        public virtual State CurrentState { get; set; } // never null
        public string LeaderName { get; set; }
    }
}