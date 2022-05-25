using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.Metrics.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddRnMetricsBase(this IServiceCollection services)
  {
    services.TryAddSingleton<IMetricService, MetricService>();
    services.TryAddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
    services.TryAddSingleton<IDateTimeAbstraction, DateTimeAbstraction>();
    services.TryAddSingleton<IMetricServiceUtils, MetricServiceUtils>();

    return services;
  }
}
