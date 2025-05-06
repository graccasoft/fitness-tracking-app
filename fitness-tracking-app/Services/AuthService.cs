using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Models;
using fitness_tracking_app.Repositories;

namespace fitness_tracking_app.Services
{
    internal class AuthService
    {
        private readonly BaseRepository<User> repository;

        public AuthService()
        {
            repository = new BaseRepository<User>();
        }

        public User authenticate(User user)
        {
            String whereClause = $"WHERE Username = '{user.Username}' AND Password = '{user.Password}'";

            User authenticatedUser = repository.customQueryGet(whereClause);

            if (authenticatedUser == null)
            {
                Notifications.warn("Invalid username or password");
            }

            return authenticatedUser;
        }

        public User register(User user)
        {
            if (!Validator.isValidUsername(user.Username))
            {
                Notifications.warn("Username is not valid.\nUsername must contain letters and underscores only");
                return null;
            }
            if (!Validator.isValidPassword(user.Password))
            {
                Notifications.warn("Password is not valid.\nPassword must contain at least 1 lowercase, uppercase and a digit.");
                return null;
            }
            var existingUser = repository.customQueryGet($"WHERE Username = '{user.Username}'");
            if(existingUser != null) {
                Notifications.warn("Username already exists");
                return null;
            }
            repository.save(user);
            Notifications.info("User registered successfully");

            return user;
        }

    }
}
