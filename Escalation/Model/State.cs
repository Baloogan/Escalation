using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Escalation.Model
{
    public class Rank
    {
        public string Name { get; set; }
        public int Played { get; set; }
        public int InHand { get; set; }
    }
    public class State
    {
        public int StateId { get; set; }
        public virtual Game Game { get; set; }
        public virtual DateTime DateTime { get; set; }
        public string VertexName { get; set; }
        public string EdgeName { get; set; } //null/empty for the tip of the spear

        public string Title { get; set; }

        [Index]
        public bool CurrentState { get; set; }

        public bool ShowDebug { get; set; }
        public bool ShowDelta { get; set; }



        public string Nation { get; set; }

        public string EnemyNation { get; set; }
        public string EnemyLeader { get; set; }

        public double EnemyResolve { get; set; }
        public double EnemyInflexibility { get; set; }

        public double PerceivedResolve { get; set; }
        public double PerceivedInflexibility { get; set; }





        /*
        public double Leadership { get; set; }
        public double Prestige { get; set; }

        public double Stakes { get; set; }
        
        public double Pressure { get; set; }

        public double PublicAwareness { get; set; }

        public double Casualties { get; set; }
        public double FriendlyCasualties { get; set; }
        public double EnemyCasualties { get; set; }
        */


        public Rank Rank1 { get; set; } = new Rank() { Name = "Ostensible Crisis" };
        public Rank Rank2_poli { get; set; } = new Rank() { Name = "Political Gestures" };
        public Rank Rank2_econ { get; set; } = new Rank() { Name = "Economic Gestures" };
        public Rank Rank2_dipl { get; set; } = new Rank() { Name = "Diplomatic Gestures" };
        public Rank Rank3 { get; set; } = new Rank() { Name = "Solemn And Formal Declarations" };



    }
}