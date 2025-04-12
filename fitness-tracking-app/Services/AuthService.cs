using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Models;
using fitness_tracking_app.Repositories;

namespace fitness_tracking_app.Services {
    internal class AuthService {
        private readonly BaseRepository<User> repository;

        AuthService() {
            repository = new BaseRepository<User>();
        }

        public User authenticate(User user) {

            return null;
        }

        public User register(User user) {
            if (!Validator.isValidUsername(user.Username)) {
                Notifications.warn("Username is not valid");
                return null;
            }
            if (!Validator.isValidPassword(user.Password)) {
                Notifications.warn("Password is not valid");
                return null;
            }

            repository.save(user);

            return user;
        }

    }
}
