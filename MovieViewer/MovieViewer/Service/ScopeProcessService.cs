using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieViewer.Service
{
    public abstract class ScopeProcessService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ScopeProcessService(IServiceScopeFactory serviceScopeFactory) : base()
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task Process()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                await ProcessInScope(scope.ServiceProvider);
            }
        }

        public abstract Task ProcessInScope(IServiceProvider serviceProvider);
    }
}
