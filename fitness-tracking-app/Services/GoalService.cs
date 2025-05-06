using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Forms;
using fitness_tracking_app.Models;
using fitness_tracking_app.Repositories;

namespace fitness_tracking_app.Services {
    internal class GoalService {
        private readonly BaseRepository<UserGoal> repository;
        
        public GoalService() {
            repository = new BaseRepository<UserGoal>();
            
        }

        public UserGoal FetchUserGoal() {
            var SavedGoal = repository.customQueryGet($"WHERE userId =  {MainForm.userId}");
            if (SavedGoal == null) {
                SavedGoal = new UserGoal();
                SavedGoal.UserId = MainForm.userId;
                SavedGoal.Goal = 0;
                repository.save(SavedGoal);
                return repository.customQueryGet($"WHERE userId =  {MainForm.userId}");
            }
            return SavedGoal;
            
        }

        public void SaveUserGoal(UserGoal goal) {
            repository.update(goal);
        }

    }
}
