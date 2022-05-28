[Home](/README.md) / [Extensions](/docs/extensions/README.md) / ServiceCollectionExtensions

# ServiceCollectionExtensions
More to come...

```cs
public static IServiceCollection AddRnMetricsBase(this IServiceCollection services, IConfiguration configuration)
{
  services.TryAddSingleton<IMetricService, MetricService>();
  services.TryAddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
  services.TryAddSingleton<IDateTimeAbstraction, DateTimeAbstraction>();

  var rnMetricsConfig = GetMetricsConfig(configuration);
  services.TryAddSingleton(rnMetricsConfig);

  if(rnMetricsConfig.EnableConsoleOutput)
    services.TryAddSingleton<IMetricOutput, ConsoleMetricOutput>();

  return services;
}
```