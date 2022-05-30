using Rn.NetCore.Metrics.Configuration;

namespace Rn.NetCore.Metrics.T1.Tests.TestSupport.Builders;

public class RnMetricsConfigBuilder
{
  public static RnMetricsConfig Default => new RnMetricsConfigBuilder().Build();

  private readonly RnMetricsConfig _config = new();

  public RnMetricsConfigBuilder WithEnabled(bool enabled)
  {
    _config.Enabled = enabled;
    return this;
  }

  public RnMetricsConfigBuilder WithEnableConsoleOutput(bool enabled)
  {
    _config.EnableConsoleOutput = enabled;
    return this;
  }

  public RnMetricsConfigBuilder WithMetricOverride(string key, string value)
  {
    _config.Overrides[key] = value;
    return this;
  }

  public RnMetricsConfigBuilder WithTemplate(string template)
  {
    _config.Template = template;
    return this;
  }

  public RnMetricsConfigBuilder WithEnvironment(string environment)
  {
    _config.Environment = environment;
    return this;
  }

  public RnMetricsConfigBuilder WithApplication(string application)
  {
    _config.Application = application;
    return this;
  }

  public RnMetricsConfig Build() => _config;
}
