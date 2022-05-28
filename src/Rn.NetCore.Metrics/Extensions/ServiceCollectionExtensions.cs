using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Configuration;
using Rn.NetCore.Metrics.Exceptions;

namespace Rn.NetCore.Metrics.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddRnMetricsBase(this IServiceCollection services, IConfiguration configuration)
  {
    services.TryAddSingleton<IMetricService, MetricService>();
    services.TryAddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
    services.TryAddSingleton<IDateTimeAbstraction, DateTimeAbstraction>();
    services.TryAddSingleton(GetMetricsConfig(configuration));

    return services;
  }

  private static RnMetricsConfig GetMetricsConfig(IConfiguration configuration)
  {
    var metricsConfig = BindMetricsConfig(configuration);

    // Ensure that a valid application name is defined
    if (string.IsNullOrWhiteSpace(metricsConfig.Application))
      metricsConfig.Application = Assembly.GetEntryAssembly()?.GetName().Name ?? "";

    if(string.IsNullOrWhiteSpace(metricsConfig.Application))
      throw new MetricConfigException("ApplicationName is required");

    // Ensure that an environment value is defined
    if(string.IsNullOrWhiteSpace(metricsConfig.Environment))
      metricsConfig.Environment = "development";

    // Ensure that there is a metric template defined
    if (string.IsNullOrWhiteSpace(metricsConfig.Template))
      metricsConfig.Template = "{app}/{measurement}";

    // Ensure all value casing is correct
    metricsConfig.Application = metricsConfig.Application.LowerTrim();
    metricsConfig.Environment = metricsConfig.Environment.LowerTrim();
    
    return metricsConfig;
  }

  private static RnMetricsConfig BindMetricsConfig(IConfiguration configuration)
  {
    var boundConfig = new RnMetricsConfig();

    var section = configuration.GetSection(RnMetricsConfig.ConfigKey);
    if (!section.Exists())
      return boundConfig;

    section.Bind(boundConfig);
    return boundConfig;
  }
}
