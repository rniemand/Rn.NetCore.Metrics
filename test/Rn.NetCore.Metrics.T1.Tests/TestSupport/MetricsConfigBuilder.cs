using System.Collections.Generic;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Metrics.Configuration;

namespace Rn.NetCore.Metrics.T1.Tests.TestSupport;

public class MetricsConfigBuilder
{
  private readonly RnMetricsConfig _config;

  public MetricsConfigBuilder()
  {
    _config = new RnMetricsConfig();
  }

  public MetricsConfigBuilder WithDefaults()
  {
    _config.Enabled = false;
    _config.Application = "my_app";
    _config.Template = "{app}/{measurement}";
    _config.Overrides = new Dictionary<string, string>();
    _config.Environment = "development";

    return this;
  }

  public MetricsConfigBuilder WithEnabled(bool enabled)
  {
    _config.Enabled = enabled;
    return this;
  }

  public MetricsConfigBuilder WithEnvironment(string environment)
  {
    _config.Environment = environment;
    return this;
  }

  public MetricsConfigBuilder WithApplication(string application)
  {
    _config.Application = application;
    return this;
  }

  public MetricsConfigBuilder WithTemplate(string template)
  {
    _config.Template = template;
    return this;
  }

  public MetricsConfigBuilder WithOverride(string measurement, string replacement)
  {
    _config.Overrides[measurement.LowerTrim()] = replacement;

    return this;
  }

  public RnMetricsConfig Build() => _config;

  public RnMetricsConfig BuildWithDefaults(bool enabled)
    => WithDefaults().WithEnabled(enabled).Build();

  public RnMetricsConfig BuildWithDefaults()
    => WithDefaults().Build();
}