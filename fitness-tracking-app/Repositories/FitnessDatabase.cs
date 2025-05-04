using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace fitness_tracking_app.Repositories {
    internal class FitnessDatabase {

        public static string _connectionString = "Data Source=fitness.db";


        public static void InitializeDatabase() {
            using (var connection = new SqliteConnection(_connectionString)) {
                connection.Open();

                // Create tables if they don't exist
                var command = connection.CreateCommand();
                command.CommandText = @"
            CREATE TABLE IF NOT EXISTS users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL,
                Email TEXT NOT NULL,
                Password TEXT NOT NULL,
                Username TEXT NOT NULL UNIQUE,
                Gender INTEGER NOT NULL,
                DateOfBirth TEXT NOT NULL,
                CreatedAt TEXT NOT NULL,
                UpdatedAt TEXT NOT NULL
            );
            
            CREATE TABLE IF NOT EXISTS activity_metrics (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Activity TEXT NOT NULL,
                Metric1 TEXT,
                Metric1Formulae TEXT,
                Metric2 TEXT,
                Metric2Formulae TEXT,
                Metric3 TEXT,
                Metric3Formulae TEXT,
                CreatedAt TEXT NOT NULL,
                UpdatedAt TEXT NOT NULL
            );
            
            CREATE TABLE IF NOT EXISTS user_activity (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                MetricId INTEGER NOT NULL,
                Value REAL NOT NULL,
                Metric TEXT NOT NULL,
                CreatedAt TEXT NOT NULL,
                UpdatedAt TEXT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES users(Id) ON DELETE CASCADE,
                FOREIGN KEY (MetricId) REFERENCES activity_metrics(Id) ON DELETE CASCADE
            );
            
            CREATE TABLE IF NOT EXISTS user_goal (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId INTEGER NOT NULL,
                Goal REAL NOT NULL,
                CreatedAt TEXT NOT NULL,
                UpdatedAt TEXT NOT NULL,
                FOREIGN KEY (UserId) REFERENCES users(Id) ON DELETE CASCADE
            );
            
            -- Create indexes for better performance
            CREATE INDEX IF NOT EXISTS idx_user_activity_user_id ON user_activity(UserId);
            CREATE INDEX IF NOT EXISTS idx_user_activity_metric_id ON user_activity(MetricId);
            CREATE INDEX IF NOT EXISTS idx_user_goal_user_id ON user_goal(UserId);";

                command.ExecuteNonQuery();


                // Insert default metris if empty
                command.CommandText = "SELECT COUNT(*) FROM activity_metrics";
                var count = Convert.ToInt64(command.ExecuteScalar());

                if (count == 0) {
                    // Insert the 6 default activity metrics with formulas
                    command.CommandText = @"
                INSERT INTO activity_metrics 
                (Activity, Metric1, Metric1Formulae, Metric2, Metric2Formulae, Metric3, Metric3Formulae, CreatedAt, UpdatedAt)
                VALUES
                -- Walking (provided by you)
                ('Walking', 'steps', 'x * 0.04', 'distance', 'x * 60', 'time taken', 'x * 80', datetime('now'), datetime('now')),
                
                -- Swimming (provided by you)
                ('Swimming', 'number of laps', 'x * 5', 'time taken', 'x * 8.3', 'average heart rate', '(x - 60) * x * 0.12', datetime('now'), datetime('now')),
                
                -- Running
                ('Running', 'distance', 'x * 100', 'time taken', 'x * 11.5', 'average speed', '(x * 0.0175)/200', datetime('now'), datetime('now')),
                
                -- Cycling
                ('Cycling', 'distance', 'x * 35', 'time taken', 'x * 7.5', 'average speed', 'x * 0.000025)', datetime('now'), datetime('now')),
                
                -- Basketball
                ('Basketball', 'time played', 'x * 8', 'jumps', 'jumps * 0.2', 'heart rate', '(x - 60) * x * 0.1', datetime('now'), datetime('now')),
                
                -- Yoga
                ('Yoga', 'time practiced', 'x * 3.5', 'difficulty level', 'x * x * 0.8', 'heart rate', ' x * 0.05', datetime('now'), datetime('now'))
                ";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
