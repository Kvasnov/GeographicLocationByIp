using System.Threading;
using System.Threading.Tasks;

namespace GeographicLocationByIp.ConsoleUpdater.Hangfire.Common
{
    public interface IJob
    {
        Task Run(CancellationToken cancellationToken);
    }
}