using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Models;
using Microsoft.Data.Sqlite;

namespace fitness_tracking_app.Repositories
{
    internal class BaseRepository<T> where T : BaseEntity, new()
    {
        private string connectionString = FitnessDatabase._connectionString;

        public bool Save(T entity)
        {
            // Set createdAt and updatedAt to the current time
            DateTime currentTime = DateTime.UtcNow;
            entity.CreatedAt = currentTime;
            entity.UpdatedAt = currentTime;

            Dictionary<string, object> fieldValues = entity.GetFieldValues();
            if (!fieldValues.ContainsKey("id") || fieldValues["id"] == null || (int)fieldValues["id"] == 0)
            {
                fieldValues["id"] = GetNextId();
            }

            string tableName = entity.GetTableName();
            string columns = string.Join(", ", fieldValues.Keys);
            string values = string.Join(", ", fieldValues.Values.Select(v => $"'{v}'"));

            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }

        public T Get(int id)
        {
            T entity = null;
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName} WHERE id = {id}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = new T();
                            entity.LoadFromReader(reader);
                        }
                    }
                }
            }

            return entity;
        }

        public T GetWhere(string where)
        {
            T entity = null;
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName} {where}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = new T();
                            entity.LoadFromReader(reader);
                        }
                    }
                }
            }

            return entity;
        }

        public List<T> GetAll()
        {
            List<T> entities = new List<T>();
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T entity = new T();
                            entity.LoadFromReader(reader);
                            entities.Add(entity);
                        }
                    }
                }
            }

            return entities;
        }

        public List<T> GetAllWhere(string where)
        {
            List<T> entities = new List<T>();
            string tableName = new T().GetTableName();
            string query = $"SELECT * FROM {tableName} {where}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T entity = new T();
                            entity.LoadFromReader(reader);
                            entities.Add(entity);
                        }
                    }
                }
            }

            return entities;
        }
        public bool Update(T entity)
        {
            Dictionary<string, object> fieldValues = entity.GetFieldValues();
            string tableName = entity.GetTableName();

            fieldValues.Remove("Id");

            string setClause = string.Join(", ", fieldValues.Select(kv => $"{kv.Key} = '{kv.Value}'"));

            string query = $"UPDATE {tableName} SET {setClause} WHERE Id = {entity.Id}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private int GetNextId()
        {
            int nextId = 1;
            string tableName = new T().GetTableName();
            string query = $"SELECT MAX(id) FROM {tableName}";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        nextId = Convert.ToInt32(result) + 1;
                    }
                }
            }

            return nextId;
        }
    }
}
