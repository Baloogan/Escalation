using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation.Context
{
    public class GameContextException : Exception
    {
        public GameContextException(string Message) : base(Message)
        {
        }
    }
}