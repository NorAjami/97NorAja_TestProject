using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using.Reflection;
using System.Reflection;

namespace _97NorAja_TestProject.uppgift_8
{
    public class ObjectValidator
    {

        // Metod som kontrollerar om ett objekt är null
        public bool IsNull(object obj)
        {
            return obj == null;
        }

        // Metod som returnerar en lista av null-properties i ett objekt
        public List<string> GetNullProperties(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj), "Object cannot be null.");

            var nullProperties = new List<string>();

            // Hämta alla properties för objektets typ
            var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                // Kontrollera om propertyn är null
                var value = property.GetValue(obj);
                if (value == null)
                {
                    nullProperties.Add(property.Name);
                }
            }

            return nullProperties;
        }

    }
}
