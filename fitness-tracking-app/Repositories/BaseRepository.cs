using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Models;
using Microsoft.Data.Sqlite;

namespace fitness_tracking_app.Repositories {
    internal class BaseRepository<T> where T : BaseEntity, new() {
        private string connectionString = FitnessDatabase._connectionString;

        public bool save(T entity) {
            // Set createdAt and updatedAt to the current time
            DateTime currentTime = DateTime.UtcNow;
            entity.CreatedAt = currentTime;
            entity.UpdatedAt = currentTime;



            Dictionary<string, object> fieldValues = entity.GetFieldValues();
            if (fieldValues.ContainsKey("id")) {
                fieldValues.Remove("id"); // Exclude the id field so the db engine can use auto increment
            }

            string tableName = entity.GetTableName();
            string columns = string.Join(", ", fieldValues.Keys);
            string values = string.Join(", ", fieldValues.Values.Select(v => $"'{v}'"));

            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            using (var connection = new SqliteConnection(connectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }

        public T get(int id) {
            T entity = null;
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName} WHERE id = {id}";

            using (var connection = new SqliteConnection(connectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            entity = new T();
                            entity.LoadFromReader(reader);
                        }
                    }
                }
            }

            return entity;
        }

        public T customQueryGet(string where) {
            T entity = null;
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName} {where}";

            using (var connection = new SqliteConnection(connectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            entity = new T();
                            entity.LoadFromReader(reader);
                        }
                    }
                }
            }

            return entity;
        }

        public List<T> getAll() {
            List<T> entities = new List<T>();
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName}";

            using (var connection = new SqliteConnection(connectionString)) {
                connection.Open();
                using (var command = connection.CreateCommand()) {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            T entity = new T();
                            entity.LoadFromReader(reader);
                            entities.Add(entity);
                        }
                    }
                }
            }

            return entities;
        }
    }
}
