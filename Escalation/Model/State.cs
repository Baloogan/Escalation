using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation.Model
{
    public class State
    {
        public virtual Game Game { get; set; }
        public virtual DateTime DateTime { get; set; }
        public string VertexName { get; set; }
        public string EdgeName { get; set; } //null/empty for the tip of the spear


        
        public double LeaderSleepNeed { get; set; } 


        public State Clone()
        {
            return (State)this.MemberwiseClone();
        }

    }
}