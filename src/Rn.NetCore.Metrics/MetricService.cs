using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Configuration;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;
using Rn.NetCore.Metrics.Outputs;

namespace Rn.NetCore.Metrics;

public interface IMetricService
{
  void SubmitBuilder(IMetricBuilder builder);
  Task SubmitBuilderAsync(IMetricBuilder builder);
  void SubmitMetric(CoreMetric coreMetric);
  Task SubmitMetricAsync(CoreMetric coreMetric);
}

public class MetricService : IMetricService
{
  private readonly ILoggerAdapter<MetricService> _logger;
  private readonly IDateTimeAbstraction _dateTime;
  private List<IMetricOutput> _outputs;
  private readonly MetricsConfig _config;


  public MetricService(IServiceProvider serviceProvider)
  {
    _logger = serviceProvider.GetRequiredService<ILoggerAdapter<MetricService>>();
    _dateTime = serviceProvider.GetRequiredService<IDateTimeAbstraction>();
    _config = serviceProvider.GetRequiredService<IMetricServiceUtils>()
      .GetConfiguration();

    if (!_config.Enabled)
    {
      _logger.LogInformation("Metric service disabled (via config)");
      return;
    }

    LoadMetricOutputs(serviceProvider);
  }


  // Interface methods
  public void SubmitBuilder(IMetricBuilder builder)
  {
    if (!_config.Enabled || builder.IsNullMetricBuilder)
      return;

    SubmitMetricAsync(builder.Build())
      .ConfigureAwait(false)
      .GetAwaiter()
      .GetResult();
  }

  public async Task SubmitBuilderAsync(IMetricBuilder builder)
  {
    if (!_config.Enabled || builder.IsNullMetricBuilder)
      return;

    await SubmitMetricAsync(builder.Build());
  }

  public void SubmitMetric(CoreMetric coreMetric)
  {
    if (!_config.Enabled)
      return;

    SubmitMetricAsync(coreMetric)
      .ConfigureAwait(false)
      .GetAwaiter()
      .GetResult();
  }

  public async Task SubmitMetricAsync(CoreMetric coreMetric)
  {
    if (!_config.Enabled)
      return;

    var finalizedMetric = FinalizeMetric(coreMetric);
    foreach (var output in _outputs)
    {
      await output.SubmitMetric(finalizedMetric);
    }
  }


  // Internal methods
  private void LoadMetricOutputs(IServiceProvider serviceProvider)
  {
    _outputs = serviceProvider.GetRequiredService<IEnumerable<IMetricOutput>>()
      .Where(x => x.Enabled)
      .ToList();

    // No enabled outputs
    if (_outputs.Count == 0)
    {
      _logger.LogWarning("No enabled outputs, disabling metric service");
      _config.Enabled = false;
      return;
    }

    // We are good to go
    _logger.LogInformation("Metric service running with {count} output(s)",
      _outputs.Count
    );
  }

  private CoreMetric FinalizeMetric(CoreMetric coreMetric)
  {
    var measurement = coreMetric.Measurement;

    if (_config.Overrides.ContainsKey(coreMetric.Measurement))
      measurement = _config.Overrides[coreMetric.Measurement];

    return coreMetric
      .WithDate(_dateTime.UtcNow)
      .SetTag(MetricTag.Environment, _config.Environment)
      .SetTag(MetricTag.Application, _config.Application)
      .UpdateMeasurement(GenerateMeasurement(measurement));
  }

  private string GenerateMeasurement(string measurement)
  {
    return _config.Template
      .Replace("{app}", _config.Application)
      .Replace("{measurement}", measurement);
  }
}