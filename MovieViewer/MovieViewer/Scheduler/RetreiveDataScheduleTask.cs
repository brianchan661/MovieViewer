using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// schedule task for calling movie retrieve api.
/// </summary>
namespace MovieViewer.Scheduler
{
    public class RetreiveDataScheduleTask : ScheduleProcessor
    {
        private readonly string RETREIVE_DATA_API_PATH = "/api/MovieRetriever";

        public RetreiveDataScheduleTask(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        // execute daily at 00:00
        protected override string Schedule => "* 0 * * *";

        /// <summary>
        /// Task for calling MovieRetriever api
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override Task ProcessInScope(IServiceProvider serviceProvider)
        {
            var client = new RestClient("https://localhost:5001" + RETREIVE_DATA_API_PATH);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                Console.Write("Retreive Data failed");

            return Task.CompletedTask;
        }
    }
}
