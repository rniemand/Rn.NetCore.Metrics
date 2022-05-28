using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Configuration;

namespace Rn.NetCore.Metrics.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddRnMetricsBase(this IServiceCollection services, IConfiguration configuration)
  {
    services.TryAddSingleton<IMetricService, MetricService>();
    services.TryAddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
    services.TryAddSingleton<IDateTimeAbstraction, DateTimeAbstraction>();
    services.TryAddSingleton<IMetricServiceUtils, MetricServiceUtils>();
    services.TryAddSingleton(BindMetricsConfig(configuration));

    return services;
  }

  private static MetricsConfig BindMetricsConfig(IConfiguration configuration)
  {
    var boundConfig = new MetricsConfig();

    var section = configuration.GetSection(MetricsConfig.ConfigKey);
    if (!section.Exists())
      return boundConfig;

    section.Bind(boundConfig);
    return boundConfig;
  }
}
