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

        [Index]
        public bool CurrentState { get; set; }

        public double LeaderSleepNeed { get; set; }

        

    }
}