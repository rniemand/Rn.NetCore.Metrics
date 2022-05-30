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

  public RnMetricsConfig Build() => _config;
}
