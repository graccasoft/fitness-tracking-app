using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fitness_tracking_app.Models;
using fitness_tracking_app.Repositories;

namespace fitness_tracking_app.Services
{


    internal class ActivityService
    {
        private readonly BaseRepository<ActivityMetric> metricRepository;
        private readonly BaseRepository<UserActivity> activityRepository;

        public ActivityService()
        {
            metricRepository = new BaseRepository<ActivityMetric>();
            activityRepository = new BaseRepository<UserActivity>();
        }

        public List<ActivityMetric> GetActivityMetricList()
        {
            return metricRepository.getAll();
        }

        public void save(UserActivity userActivity)
        {
            activityRepository.save(userActivity);
        }

        public List<UserActivityView> GetUserActivityViewByUserId(int userId)
        {
            // Fetch all user activities for the given userId
            var userActivities = activityRepository.getAllWhere($"WHERE UserId = {userId}");

            // Fetch all activity metrics
            var activityMetrics = metricRepository.getAll();

            // Join user activities with activity metrics and map to UserActivityView
            var result = (from ua in userActivities
                          join am in activityMetrics on ua.MetricId equals am.Id
                          select new UserActivityView
                          {
                              Id = ua.Id,
                              CreatedAt = ua.CreatedAt,
                              Activity = ua.MetricId,
                              ActivityMetric = am.Id,
                              Value = ua.Value,
                              Calories = CalculateCalories(ua, am) // Example calculation
                          }).ToList();

            return result;
        }

        private double CalculateCalories(UserActivity activity, ActivityMetric activityMetric)
        {
            if (activity.Metric == "metric1")
            {
                formula = activityMetric.Metric1Formulae;
            }
            else if (activity.Metric == "metric2")
            {
                formula = activityMetric.Metric2Formulae;
            }
            else if (activity.Metric == "metric3")
            {
                formula = activityMetric.Metric3Formulae;
            }

            formula = formula.Replace("x", activity.Value.ToString());
            try
            {
                using (var dataTable = new System.Data.DataTable())
                {
                    var result = dataTable.Compute(formula, string.Empty);
                    return Convert.ToDouble(result);
                }
            }
            catch
            {
                throw 0;
            }
        }
    }
}
