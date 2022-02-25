using Polly;
using Polly.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp_Angular.Integration.Policies
{
    public static class ResiliencyPolicy
    {
        public static IAsyncPolicy<HttpResponseMessage> RetryPolicy(int maxRetryCount)
        {
            var rnd = new Random();
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(maxRetryCount, retryAttempt =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                        + TimeSpan.FromMilliseconds(rnd.Next(0, 100))
                    );
        }
    }
}
