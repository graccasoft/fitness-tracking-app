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

        public ActivityService() {
            metricRepository = new BaseRepository<ActivityMetric>();
        }

        public List<ActivityMetric> GetActivityMetricList() {
            return metricRepository.getAll() ;
        }
    }
}
