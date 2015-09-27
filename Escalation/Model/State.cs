using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Escalation.Model
{
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


        public int HighestRung { get; set; }


        public double Leadership { get; set; }
        public double Prestige { get; set; }

        public double PerceivedCommitment { get; set; }
        public double PerceivedInflexibility { get; set; }

        public double Pressure { get; set; }

        public int PoliticalCapital { get; set; }
        public int DomesticCapital { get; set; }
        public int RelevantAmbassadorsAbroad { get; set; }

        
        public double PublicAwareness { get; set; }






        public double Casualties { get; set; }
        public double FriendlyCasualties { get; set; }
        public double EnemyCasualties { get; set; }




    }
}