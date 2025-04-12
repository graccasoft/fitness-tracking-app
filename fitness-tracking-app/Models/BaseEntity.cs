using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace fitness_tracking_app.Models {
    internal abstract class BaseEntity {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public abstract string GetTableName();

        public Dictionary<string, object> GetFieldValues() {
            Dictionary<string, object> fieldValues = new Dictionary<string, object>();
            Type type = this.GetType();

            foreach (PropertyInfo property in type.GetProperties()) {
                fieldValues[property.Name] = property.GetValue(this);
            }

            return fieldValues;
        }
    }
}
