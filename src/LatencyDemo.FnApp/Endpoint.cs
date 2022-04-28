using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceStack.Redis;
using LatencyDemo.FnApp.Data;

namespace LatencyDemo.FnApp
{
    public static class Endpoint
    {
        /* connection_string
         * resource_region
         * host_region
         * redis_host
         * redis_key
         */
        [FunctionName("Endpoint")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var body = await (new StreamReader(req.Body).ReadToEndAsync());
            var correlationId = Guid.NewGuid().ToString();
            var resourceRegion = Environment.GetEnvironmentVariable("resource_region");
            var hostRegion = Environment.GetEnvironmentVariable("host_region");
            var redisHost = Environment.GetEnvironmentVariable("redis_host");
            var redisKey = Environment.GetEnvironmentVariable("redis_key");


            var startTime = DateTime.UtcNow;
            RedisClient client = new RedisClient(redisHost, 6379, redisKey);
            var result = client.Get<string>(Environment.GetEnvironmentVariable("redis_key"));
            var endTime = DateTime.UtcNow;

            var timeTaken = (endTime - startTime).Milliseconds;

            LatencyContext ctx = new LatencyContext();
            ctx.LatencyTestRun.Add(new LatencyTestRun
            {
                CorrelationId = correlationId,
                StartTime = startTime,
                EndTime = endTime,
                FromRegion = hostRegion,
                ToRegion = resourceRegion,
                Request = body
            });
            ctx.SaveChanges();
            return new OkObjectResult($"Completed {timeTaken}ms");
        }
    }
}
