﻿using Prometheus.Contrib.Core;

namespace Prometheus.Contrib.EventListeners.Adapters
{
    public class PrometheusAspNetCoreCounterAdapter : ICounterAdapter
    {
        private static class AspNetCoreCountersConstants
        {
            public const string AspNetCoreRequestsPerSecond = "requests-per-second";
            public const string AspNetCoreTotalRequests = "total-requests";
            public const string AspNetCoreCurrentRequests = "current-requests";
            public const string AspNetCoreFailedRequests = "failed-requests";
        }

        private static class AspNetCorePrometheusCounters
        {
            public static Gauge AspNetCoreRequestsPerSecond = Metrics.CreateGauge("aspnetcore_requests_per_second", "Request Rate");
            public static Gauge AspNetCoreTotalRequests = Metrics.CreateGauge("aspnetcore_requests_total", "Total Requests");
            public static Gauge AspNetCoreCurrentRequests = Metrics.CreateGauge("aspnetcore_requests_current_total", "Current Requests");
            public static Gauge AspNetCoreFailedRequests = Metrics.CreateGauge("aspnetcore_requests_failed_total", "Failed Requests");
        }

        public void OnCounterEvent(string name, double value)
        {
            switch (name)
            {
                case AspNetCoreCountersConstants.AspNetCoreRequestsPerSecond:
                    AspNetCorePrometheusCounters.AspNetCoreRequestsPerSecond.Set(value);
                    break;
                case AspNetCoreCountersConstants.AspNetCoreTotalRequests:
                    AspNetCorePrometheusCounters.AspNetCoreTotalRequests.Set(value);
                    break;
                case AspNetCoreCountersConstants.AspNetCoreCurrentRequests:
                    AspNetCorePrometheusCounters.AspNetCoreCurrentRequests.Set(value);
                    break;
                case AspNetCoreCountersConstants.AspNetCoreFailedRequests:
                    AspNetCorePrometheusCounters.AspNetCoreFailedRequests.Set(value);
                    break;
            }
        }
    }
}
