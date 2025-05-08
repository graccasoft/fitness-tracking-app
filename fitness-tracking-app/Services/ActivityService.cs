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
            return metricRepository.GetAll();
        }

        public void save(UserActivity userActivity)
        {
            activityRepository.Save(userActivity);
        }

        public List<UserActivityView> GetUserActivityViewByUserId(int userId)
        {
            // Fetch all user activities for the given userId
            var userActivities = activityRepository.GetAllWhere($"WHERE UserId = {userId}");

            // Fetch all activity metrics
            var activityMetrics = metricRepository.GetAll();

            // Join user activities with activity metrics and map to UserActivityView
            var result = (from ua in userActivities
                          join am in activityMetrics on ua.MetricId equals am.Id
                          select new UserActivityView
                          {
                              Id = ua.Id,
                              CreatedAt = ua.CreatedAt,
                              Activity = am.Activity,
                              ActivityMetric = ua.Metric switch {
                                  "metric1" => am.Metric1,
                                  "metric2" => am.Metric2,
                                  "metric3" => am.Metric3,
                                  _ => throw new ArgumentException("Invalid metric type")
                              }  ,
                              Value = ua.Value,
                              Calories = CalculateCalories(ua, am)
                          }).ToList();

            return result;
        }

        private double CalculateCalories(UserActivity activity, ActivityMetric activityMetric)
        {

            string formula = activity.Metric switch {
                "metric1" => activityMetric.Metric1Formulae,
                "metric2" => activityMetric.Metric2Formulae,
                "metric3" => activityMetric.Metric3Formulae,
                _ => throw new ArgumentException("Invalid metric type")
            };

            formula = formula.Replace("x", activity.Value.ToString());

            try {
                using (var dataTable = new System.Data.DataTable()) {
                    var result = dataTable.Compute(formula, string.Empty);
                    return Convert.ToDouble(result);
                }
            }
            catch {
                throw new InvalidOperationException("Failed to evaluate the formula.");
            }
        }
    }
}
