using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Escalation.Graph
{
    public static class GraphHelper
    {
        public static TEntity ShallowCopyEntity<TEntity>(TEntity source) where TEntity : class, new()
        {

            // Get properties from EF that are read/write and not marked witht he NotMappedAttribute
            var sourceProperties = typeof(TEntity)
                                    .GetProperties()
                                    .Where(p => p.CanRead && p.CanWrite
                                                 && p.GetCustomAttributes(typeof(NotMappedAttribute), true).Length == 0
                                                );
            var newObj = new TEntity();

            foreach (var property in sourceProperties)
            {

                // Copy value
                property.SetValue(newObj, property.GetValue(source, null), null);

            }

            return newObj;

        }
    }
}