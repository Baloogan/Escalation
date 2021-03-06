﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Escalation.Model
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }//can be null

        [InverseProperty("Game")]
        public virtual List<State> States { get; set; } = new List<State>();
        public string LeaderName { get; set; }
        //public string NationName { get; set; }
        //public string EnemyName { get; set; }

        //public string EnemyLeaderName { get; set; }

    }
}