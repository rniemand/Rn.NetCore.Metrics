[Home](/README.md) / [Configuration](/docs/config/README.md) / RnMetricsConfig

# RnMetricsConfig
More to come...

```cs
public class RnMetricsConfig
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

  [ConfigurationKeyName("enableConsoleOutput")]
  public bool EnableConsoleOutput { get; set; } = false;
}
```