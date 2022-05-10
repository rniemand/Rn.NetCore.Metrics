using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Rn.NetCore.Metrics.Configuration;

// DOCS: docs\configuration\appsettings.md
public class MetricsConfig
{
  public const string ConfigKey = "Rn.Metrics";

  [ConfigurationKeyName("enabled")]
  public bool Enabled { get; set; }

  [ConfigurationKeyName("application")]
  public string Application { get; set; } = string.Empty;

  [ConfigurationKeyName("template")]
  public string Template { get; set; } = "{app}/{measurement}";

  [ConfigurationKeyName("overrides")]
  public Dictionary<string, string> Overrides { get; set; } = new();

  [ConfigurationKeyName("environment")]
  public string Environment { get; set; } = "development";
}
