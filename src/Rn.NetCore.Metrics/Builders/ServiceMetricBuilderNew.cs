using System;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders;

public sealed class ServiceMetricBuilderNew : CoreMetricBuilder<ServiceMetricBuilderNew>
{
  private int _queryCount;
  private int _resultsCount;
  private string _serviceName = string.Empty;
  private string _methodName = string.Empty;
  private string _category = string.Empty;
  private string _subCategory = string.Empty;

  public ServiceMetricBuilderNew()
    : base("service_call")
  { }

  public ServiceMetricBuilderNew(string service, string method)
    : this()
  {
    ForService(service, method);
  }

  public ServiceMetricBuilderNew ForService(string service, string method, bool skipToLower = true)
  {
    _serviceName = skipToLower ? service : service.LowerTrim();
    _methodName = skipToLower ? method : method.LowerTrim();
    return this;
  }

  public ServiceMetricBuilderNew WithCategory(string category, string subCategory, bool skipToLower = true)
  {
    _category = skipToLower ? category : category.LowerTrim();
    _subCategory = skipToLower ? subCategory : subCategory.LowerTrim();
    return this;
  }

  public ServiceMetricBuilderNew WithQueryCount(int queryCount)
  {
    _queryCount = queryCount;
    return this;
  }

  public ServiceMetricBuilderNew IncrementQueryCount(int amount = 1)
  {
    _queryCount += amount;
    return this;
  }

  public ServiceMetricBuilderNew WithResultsCount(int resultsCount)
  {
    _resultsCount = resultsCount;
    return this;
  }

  public ServiceMetricBuilderNew IncrementResultsCount(int amount = 1)
  {
    _resultsCount += amount;
    return this;
  }

  public ServiceMetricBuilderNew CountResult(object? result = null)
  {
    if (result != null)
      _resultsCount += 1;

    return this;
  }

  public ServiceMetricBuilderNew WithException(Exception ex)
  {
    SetException(ex);
    return this;
  }

  public override CoreMetric Build()
  {
    // Append required metric tags
    AddAction(m => { m.SetTag("service_name", _serviceName, true); })
      .AddAction(m => { m.SetTag("service_method", _methodName, true); })
      .AddAction(m => { m.SetTag("category", _category, true); })
      .AddAction(m => { m.SetTag("sub_category", _subCategory, true); })
      .AddAction(m => { m.SetField("query_count", _queryCount); })
      .AddAction(m => { m.SetField("results_count", _resultsCount); });

    return base.Build();
  }
}
