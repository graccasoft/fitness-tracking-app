using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Models;

namespace fitness_tracking_app.Repositories {
    internal class BaseRepository<T> where T : BaseEntity, new() {
        private string connectionString = "";

        public bool save(T entity) {
            Dictionary<string, object> filedValues = entity.GetFieldValues();
            string tableName = entity.GetTableName();
            string columns = string.Join(", ", filedValues.Keys);
            string values = string.Join(", ", filedValues.Values.Select(v => $"'{v}'"));

            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            Console.WriteLine(query);
            return true;
        }

        public T get(int id) {
            T entity = null;
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName} WHERE id = {id}";
            Console.WriteLine(query);
            return entity;
        }

        public List<T> getAll() {
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName}";

            return null;
        }
    }
}
