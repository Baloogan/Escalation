using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation.Context
{
    public class GameContextMutexException : GameContextException
    {
        public GameContextMutexException(string Message) : base(Message)
        {
        }
    }
}