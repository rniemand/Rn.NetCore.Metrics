using System;
using System.Collections.Generic;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders;

public interface ICoreMetricBuilder<TBuilder>
{
  ICoreMetricBuilder<TBuilder> AddAction(Action<CoreMetric> action);
  void SetSuccess(bool success);
  CoreMetric Build();
}

public class CoreMetricBuilder<TBuilder> : ICoreMetricBuilder<TBuilder>
{
  private readonly List<Action<CoreMetric>> _actions = new();
  private readonly string _measurement;

  private bool _success;
  private bool _hasException;
  private string _exName = string.Empty;

  public CoreMetricBuilder(string measurement)
  {
    _measurement = measurement;
  }

  public ICoreMetricBuilder<TBuilder> AddAction(Action<CoreMetric> action)
  {
    _actions.Add(action);
    return this;
  }

  public void SetSuccess(bool success)
  {
    _success = success;
  }

  protected void SetException(Exception ex) =>
    SetException(ex.GetType().Name);

  protected void SetException(string exceptionName)
  {
    SetSuccess(false);
    _hasException = true;
    _exName = exceptionName;
  }

  public virtual CoreMetric Build()
  {
    // Ensure that core fields and tags exist
    AddAction(m => { m.SetTag("success", _success); })
      .AddAction(m => { m.SetTag("has_ex", _hasException); })
      .AddAction(m => { m.SetTag("ex_name", _exName, true); });

    // Compile and build the metric
    var metric = new CoreMetric(_measurement);
    _actions.ForEach(a => a(metric));
    return metric;
  }
}
