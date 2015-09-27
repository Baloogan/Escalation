using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escalation
{
    public static class Json
    {
        public static string package(object o)
        {
            return JsonConvert.SerializeObject(
                o,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                });

        }
    }
}