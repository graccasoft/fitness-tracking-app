using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Models;

namespace fitness_tracking_app.Services {
    internal class GoalService {
        private readonly BaseRepository<UserGoal> repository;
        
        public GoalService() {
            repository = new BaseRepository<UserGoal>();
            
        }

       

    }
}
