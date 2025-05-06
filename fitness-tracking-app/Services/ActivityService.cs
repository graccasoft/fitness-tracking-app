using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Models;
using fitness_tracking_app.Repositories;

namespace fitness_tracking_app.Services {

    
    internal class ActivityService {
        private readonly BaseRepository<ActivityMetric> metricRepository;
        private readonly BaseRepository<UserActivity> activityRepository;

        public ActivityService() {
            metricRepository = new BaseRepository<ActivityMetric>();
            activityRepository = new BaseRepository<UserActivity>();
        }

        public List<ActivityMetric> GetActivityMetricList() {
            return metricRepository.getAll() ;
        }

        public void save(UserActivity userActivity) {
            activityRepository.save(userActivity);
        }
    }
}
