using System;
using Rn.NetCore.Common.Extensions;

namespace Rn.NetCore.Metrics.Builders;

// DOCS: docs\builders\CronMetricBuilder.md
public sealed class CronMetricBuilder : CoreMetricBuilder<CronMetricBuilder>
{
  private string _cronClass = string.Empty;
  private string _cronMethod = string.Empty;
  private string _category = string.Empty;
  private string _subCategory = string.Empty;

  private int _queryCount;
  private int _resultsCount;

  public CronMetricBuilder()
    : base("cron_job")
  {
    SetSuccess(true);
  }

  public CronMetricBuilder(string cronClass, string cronMethod)
    : this()
  {
    ForCronJob(cronClass, cronMethod);
  }

  public CronMetricBuilder ForCronJob(string cronClass, string cronMethod)
  {
    _cronClass = cronClass;
    _cronMethod = cronMethod;
    return this;
  }

  public CronMetricBuilder WithCategory(string category, string subCategory, bool skipToLower = true)
  {
    _category = skipToLower ? category : category.LowerTrim();
    _subCategory = skipToLower ? subCategory : subCategory.LowerTrim();
    return this;
  }

  public CronMetricBuilder WithException(Exception ex)
  {
    SetException(ex);
    return this;
  }

  public CronMetricBuilder WithQueryCount(int queryCount)
  {
    _queryCount = queryCount;
    return this;
  }

  public CronMetricBuilder IncrementQueryCount(int amount = 1)
  {
    _queryCount += amount;
    return this;
  }

  public CronMetricBuilder WithResultsCount(int resultsCount)
  {
    _resultsCount = resultsCount;
    return this;
  }

  public CronMetricBuilder IncrementResultsCount(int amount = 1)
  {
    _resultsCount += amount;
    return this;
  }

  public CronMetricBuilder CountResult(object? result = null)
  {
    if (result != null)
      _resultsCount += 1;

    return this;
  }

  public override CoreMetric Build()
  {
    // Append required metric tags
    AddAction(m => { m.SetTag("cron_class", _cronClass, true); })
      .AddAction(m => { m.SetTag("cron_method", _cronMethod, true); })
      .AddAction(m => { m.SetTag("category", _category, true); })
      .AddAction(m => { m.SetTag("sub_category", _subCategory, true); })
      .AddAction(m => { m.SetField("query_count", _queryCount); })
      .AddAction(m => { m.SetField("results_count", _resultsCount); });

    return base.Build();
  }
}
