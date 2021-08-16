using System;
using Hangfire;

namespace GeographicLocationByIp.ConsoleUpdater.Hangfire
{
    public class ContainerJobActivator : JobActivator
    {
        public ContainerJobActivator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        private readonly IServiceProvider serviceProvider;

        public override object ActivateJob(Type type)
        {
            return serviceProvider.GetService(type);
        }
    }
}