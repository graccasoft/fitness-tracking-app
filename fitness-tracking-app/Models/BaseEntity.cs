using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

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

        public virtual void LoadFromReader(SqliteDataReader reader) {
            Type type = this.GetType();
            foreach (PropertyInfo property in type.GetProperties()) {
                if (!reader.IsDBNull(reader.GetOrdinal(property.Name))) {
                    object value = reader[property.Name];
                    if (property.PropertyType == typeof(DateTime)) {
                        value = DateTime.Parse(value.ToString());
                    }
                    property.SetValue(this, Convert.ChangeType(value, property.PropertyType));
                }
            }
        }
    }
}
