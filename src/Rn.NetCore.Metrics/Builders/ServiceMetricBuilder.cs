using System;
using System.Collections.Generic;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders;

public class ServiceMetricBuilder : MetricBuilderBase, IServiceMetricBuilder
{
  public bool IsNullMetricBuilder { get; }

  private int _queryCount;
  private int _resultsCount;
  private readonly List<int> _customInt = new() { 0, 0, 0, 0, 0 };
  private readonly List<long> _customLong = new() { 0, 0, 0 };

  // Constructors
  public ServiceMetricBuilder()
    : base("service_call")
  {
    IsNullMetricBuilder = false;

    // Tags
    SetTag(Tags.ServiceName, string.Empty);
    SetTag(Tags.ServiceMethod, string.Empty);
    SetTag(Tags.Category, string.Empty);
    SetTag(Tags.SubCategory, string.Empty);
    SetTag(MetricTag.Tag1, string.Empty);
    SetTag(MetricTag.Tag2, string.Empty);
    SetTag(MetricTag.Tag3, string.Empty);
    SetTag(MetricTag.Tag4, string.Empty);

    // Fields
    SetField(Fields.QueryCount, 0);
    SetField(Fields.ResultsCount, 0);
    SetField(MetricField.UserId, 0);
    SetField(MetricField.Timing1, (long)0);
    SetField(MetricField.Timing2, (long)0);
    SetField(MetricField.Timing3, (long)0);
    SetField(MetricField.Int1, 0);
    SetField(MetricField.Int2, 0);
    SetField(MetricField.Int3, 0);
    SetField(MetricField.Int4, 0);
    SetField(MetricField.Int5, 0);
    SetField(MetricField.Long1, (long)0);
    SetField(MetricField.Long2, (long)0);
    SetField(MetricField.Long3, (long)0);
  }

  public ServiceMetricBuilder(string serviceName, string methodName)
    : this()
  {
    ForService(serviceName, methodName);
  }


  // Builders
  public IServiceMetricBuilder ForService(string serviceName, string methodName, bool skipToLower = true)
  {
    SetTag(Tags.ServiceName, serviceName, skipToLower);
    SetTag(Tags.ServiceMethod, methodName, skipToLower);

    return this;
  }

  public IServiceMetricBuilder WithCategory(string category, string subCategory, bool skipToLower = true)
  {
    SetTag(Tags.Category, category, skipToLower);
    SetTag(Tags.SubCategory, subCategory, skipToLower);
    return this;
  }

  public IServiceMetricBuilder WithQueryCount(int queryCount)
  {
    _queryCount = queryCount;
    return this;
  }

  public IServiceMetricBuilder IncrementQueryCount(int amount = 1)
  {
    _queryCount += amount;
    return this;
  }

  public IServiceMetricBuilder WithResultsCount(int resultsCount)
  {
    _resultsCount = resultsCount;
    return this;
  }

  public IServiceMetricBuilder IncrementResultsCount(int amount = 1)
  {
    _resultsCount += amount;
    return this;
  }

  public IServiceMetricBuilder CountResult(object result = null)
  {
    if (result != null)
      _resultsCount += 1;

    return this;
  }

  public IServiceMetricBuilder WithException(Exception ex)
  {
    SetException(ex);
    return this;
  }

  public IServiceMetricBuilder MarkFailed(int resultsCount = -1)
  {
    SetSuccess(false);

    if (resultsCount > -1)
      _resultsCount = resultsCount;

    return this;
  }

  public IServiceMetricBuilder MarkSuccess(int resultsCount = -1)
  {
    SetSuccess(true);

    if (resultsCount > -1)
      _resultsCount = resultsCount;

    return this;
  }
    
  public IServiceMetricBuilder WithUserId(int userId)
  {
    SetField(MetricField.UserId, userId);
    return this;
  }

  public IServiceMetricBuilder WithSuccess(bool success)
  {
    SetSuccess(success);
    return this;
  }

  public IServiceMetricBuilder WithCustomInt1(int value)
  {
    _customInt[0] = value;
    return this;
  }

  public IServiceMetricBuilder IncrementCustomInt1(int amount = 1)
  {
    _customInt[0] += amount;
    return this;
  }

  public IServiceMetricBuilder WithCustomInt2(int value)
  {
    _customInt[1] = value;
    return this;
  }

  public IServiceMetricBuilder IncrementCustomInt2(int amount = 1)
  {
    _customInt[1] += amount;
    return this;
  }

  public IServiceMetricBuilder WithCustomInt3(int value)
  {
    _customInt[2] = value;
    return this;
  }

  public IServiceMetricBuilder IncrementCustomInt3(int amount = 1)
  {
    _customInt[2] += amount;
    return this;
  }

  public IServiceMetricBuilder WithCustomInt4(int value)
  {
    _customInt[3] = value;
    return this;
  }

  public IServiceMetricBuilder IncrementCustomInt4(int amount = 1)
  {
    _customInt[3] += amount;
    return this;
  }

  public IServiceMetricBuilder WithCustomInt5(int value)
  {
    _customInt[4] = value;
    return this;
  }

  public IServiceMetricBuilder IncrementCustomInt5(int amount = 1)
  {
    _customInt[4] += amount;
    return this;
  }

  public IServiceMetricBuilder WithCustomLong1(long value)
  {
    _customLong[0] = value;
    return this;
  }

  public IServiceMetricBuilder IncrementCustomLong1(long amount = 1)
  {
    _customLong[0] += amount;
    return this;
  }

  public IServiceMetricBuilder WithCustomLong2(long value)
  {
    _customLong[1] = value;
    return this;
  }

  public IServiceMetricBuilder IncrementCustomLong2(long amount = 1)
  {
    _customLong[1] += amount;
    return this;
  }

  public IServiceMetricBuilder WithCustomLong3(long value)
  {
    _customLong[2] = value;
    return this;
  }

  public IServiceMetricBuilder IncrementCustomLong3(long amount = 1)
  {
    _customLong[2] += amount;
    return this;
  }

  public IServiceMetricBuilder WithCustomTag1(object value, bool skipToLower = false)
  {
    SetObjectTag(MetricTag.Tag1, value, skipToLower);
    return this;
  }

  public IServiceMetricBuilder WithCustomTag2(object value, bool skipToLower = false)
  {
    SetObjectTag(MetricTag.Tag2, value, skipToLower);
    return this;
  }

  public IServiceMetricBuilder WithCustomTag3(object value, bool skipToLower = false)
  {
    SetObjectTag(MetricTag.Tag3, value, skipToLower);
    return this;
  }

  public IServiceMetricBuilder WithCustomTag4(object value, bool skipToLower = false)
  {
    SetObjectTag(MetricTag.Tag4, value, skipToLower);
    return this;
  }


  // Timings
  public IMetricTimingToken WithTiming()
    => new MetricTimingToken(CoreMetric, MetricField.Value);

  public IMetricTimingToken WithCustomTiming1()
    => new MetricTimingToken(CoreMetric, MetricField.Timing1);

  public IMetricTimingToken WithCustomTiming2()
    => new MetricTimingToken(CoreMetric, MetricField.Timing2);

  public IMetricTimingToken WithCustomTiming3()
    => new MetricTimingToken(CoreMetric, MetricField.Timing3);


  // Finalization
  public CoreMetric Build()
  {
    SetField(Fields.QueryCount, _queryCount);
    SetField(Fields.ResultsCount, _resultsCount);
    SetField(MetricField.Int1, _customInt[0]);
    SetField(MetricField.Int2, _customInt[1]);
    SetField(MetricField.Int3, _customInt[2]);
    SetField(MetricField.Int4, _customInt[3]);
    SetField(MetricField.Int5, _customInt[4]);
    SetField(MetricField.Long1, _customLong[0]);
    SetField(MetricField.Long2, _customLong[1]);
    SetField(MetricField.Long3, _customLong[2]);

    return CoreMetric;
  }


  // Misc.
  public static class Tags
  {
    public const string ServiceName = "service_name";
    public const string ServiceMethod = "service_method";
    public const string Category = "category";
    public const string SubCategory = "sub_category";
  }

  public static class Fields
  {
    public const string QueryCount = "query_count";
    public const string ResultsCount = "results_count";
  }
}