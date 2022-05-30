using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rn.NetCore.Metrics.Abstractions;
using Rn.NetCore.Metrics.Configuration;

namespace Rn.NetCore.Metrics.Outputs;

// DOCS: docs\outputs\ConsoleMetricOutput.md
public class ConsoleMetricOutput : IMetricOutput
{
  public bool Enabled { get; }
  public string Name => nameof(ConsoleMetricOutput);
  private readonly IConsole _console;

  public ConsoleMetricOutput(
    RnMetricsConfig metricsConfig,
    IConsole console)
  {
    _console = console;
    Enabled = metricsConfig.EnableConsoleOutput && metricsConfig.Enabled;
  }

  public ConsoleMetricOutput(RnMetricsConfig metricsConfig)
    : this(metricsConfig, new ConsoleWrapper())
  { }

  public async Task SubmitMetric(CoreMetric metric) =>
    await SubmitMetrics(new List<CoreMetric> {metric});

  public async Task SubmitMetrics(List<CoreMetric> metrics)
  {
    await Task.CompletedTask;

    foreach (var metric in metrics)
    {
      _console.ForegroundColor = ConsoleColor.Green;
      _console.WriteLine(ProcessMetric(metric));
      _console.ResetColor();
    }
  }

  private static string ProcessMetric(CoreMetric metric)
  {
    return new StringBuilder("[")
      .Append(metric.UtcTimestamp.ToLocalTime().ToString("s"))
      .Append("] \"")
      .Append(metric.Measurement)
      .Append('"')
      .Append(GenerateTagsString(metric))
      .Append(GenerateFieldsString(metric))
      .ToString();
  }

  private static string GenerateTagsString(CoreMetric metric)
  {
    if (metric.Tags.Count == 0)
      return string.Empty;

    var tags = new List<string>();
    foreach (var (key, value) in metric.Tags)
    {
      tags.Add(new StringBuilder($"{key} => ")
        .Append(string.IsNullOrWhiteSpace(value) ? "NULL" : value)
        .ToString());
    }

    return " " + string.Join(", ", tags);
  }

  private static string GenerateFieldsString(CoreMetric metric)
  {
    if (metric.Fields.Count == 0)
      return string.Empty;

    var tags = new List<string>();
    foreach (var (key, value) in metric.Fields)
    {
      tags.Add($"({key} => {FieldToString(value)})");
    }

    return " " + string.Join(" ", tags);
  }

  private static string FieldToString(object field)
  {
    return field switch
    {
      string strField => strField,
      long longField => longField.ToString("D"),
      int intField => intField.ToString("D"),
      float floatField => floatField.ToString("G"),
      double doubleField => doubleField.ToString("G"),
      decimal decimalField => decimalField.ToString("G"),
      byte byteField => byteField.ToString("D"),
      short shortField => shortField.ToString("G"),
      ushort ushortField => ushortField.ToString("G"),
      uint uintField => uintField.ToString("G"),
      ulong ulongField => ulongField.ToString("G"),
      bool boolField => boolField ? "true" : "false",
      sbyte sbyteField => sbyteField.ToString("D"),
      TimeSpan tsField => tsField.ToString("g"),
      _ => throw new Exception("Field type is not supported")
    };
  }
}
