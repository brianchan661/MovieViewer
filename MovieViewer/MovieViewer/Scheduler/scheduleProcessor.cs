using Microsoft.Extensions.DependencyInjection;
using MovieViewer.Service;
using NCrontab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Abstract class for schedule task class
/// </summary>
namespace MovieViewer.Scheduler
{
    public abstract class ScheduleProcessor : ScopeProcessService
    {
        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        protected abstract string Schedule { get; }
        public ScheduleProcessor(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            _schedule = CrontabSchedule.Parse(Schedule);
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                var nextrun = _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    await Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); //delay 5 seconds 
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}
