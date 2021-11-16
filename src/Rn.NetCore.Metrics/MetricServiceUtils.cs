using Microsoft.Extensions.Configuration;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Configuration;
using Rn.NetCore.Metrics.Exceptions;

namespace Rn.NetCore.Metrics
{
  public interface IMetricServiceUtils
  {
    MetricsConfig GetConfiguration();
  }

  public class MetricServiceUtils : IMetricServiceUtils
  {
    private readonly ILoggerAdapter<MetricServiceUtils> _logger;
    private readonly IConfiguration _configuration;

    public MetricServiceUtils(
      ILoggerAdapter<MetricServiceUtils> logger,
      IConfiguration configuration)
    {
      _logger = logger;
      _configuration = configuration;
    }


    // Interface methods
    public MetricsConfig GetConfiguration()
    {
      var boundConfig = new MetricsConfig();
      var configSection = _configuration.GetSection(MetricsConfig.ConfigKey);

      if (configSection.Exists())
      {
        configSection.Bind(boundConfig);
      }
      else
      {
        _logger.Warning("Metrics disabled (config '{key}' missing)",
          MetricsConfig.ConfigKey
        );
      }

      ProcessConfiguration(boundConfig);
      return boundConfig;
    }


    // Internal methods
    public static void ProcessConfiguration(MetricsConfig config)
    {
      if (!config.Enabled)
        return;

      // Ensure that all required values are present
      if (string.IsNullOrWhiteSpace(config.Application))
        throw new MetricConfigException("ApplicationName is required");

      if (string.IsNullOrWhiteSpace(config.Environment))
        config.Environment = "development";

      if (string.IsNullOrWhiteSpace(config.Template))
        config.Template = "{app}/{measurement}";

      // Ensure that all casing is correct for metric logging
      config.Application = config.Application.LowerTrim();
      config.Environment = config.Environment.LowerTrim();
    }
  }
}
