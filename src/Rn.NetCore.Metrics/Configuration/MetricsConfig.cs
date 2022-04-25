using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Rn.NetCore.Metrics.Configuration;

public class MetricsConfig
{
  public const string ConfigKey = "RnCore:Metrics";

  [JsonProperty("Enabled"), JsonPropertyName("Enabled")]
  public bool Enabled { get; set; }

  [JsonProperty("Application"), JsonPropertyName("Application")]
  public string Application { get; set; }

  [JsonProperty("Template"), JsonPropertyName("Template")]
  public string Template { get; set; }

  [JsonProperty("Overrides"), JsonPropertyName("Overrides")]
  public Dictionary<string, string> Overrides { get; set; }

  [JsonProperty("Environment"), JsonPropertyName("Environment")]
  public string Environment { get; set; }

  public MetricsConfig()
  {
    Enabled = false;
    Application = string.Empty;
    Template = "{app}/{measurement}";
    Overrides = new Dictionary<string, string>();
    Environment = "development";
  }
}