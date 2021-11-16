using System;
using System.Collections.Generic;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Interfaces;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders
{
  public class CronMetricBuilder : MetricBuilderBase, ICronMetricBuilder
  {
    public bool IsNullMetricBuilder { get; }

    private int _queryCount;
    private int _resultsCount;
    private readonly List<int> _customInt = new() { 0, 0, 0 };
    private readonly List<long> _customLong = new() { 0, 0, 0 };

    // Constructors
    public CronMetricBuilder()
      : base("cron_job")
    {
      IsNullMetricBuilder = false;

      // Tags
      SetTag(Tags.CronClass, string.Empty);
      SetTag(Tags.CronMethod, string.Empty);
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
      SetField(MetricField.Int1, 0);
      SetField(MetricField.Int2, 0);
      SetField(MetricField.Int3, 0);
      SetField(MetricField.Long1, (long)0);
      SetField(MetricField.Long2, (long)0);
      SetField(MetricField.Long3, (long)0);
      SetField(MetricField.Timing1, (long)0);
      SetField(MetricField.Timing2, (long)0);
      SetField(MetricField.Timing3, (long)0);
    }

    public CronMetricBuilder(string cronClass, string cronMethod)
      : this()
    {
      ForCronJob(cronClass, cronMethod);
    }


    // Builders
    public ICronMetricBuilder ForCronJob(string cronClass, string cronMethod)
    {
      SetTag(Tags.CronClass, cronClass, true);
      SetTag(Tags.CronMethod, cronMethod, true);
      return this;
    }

    public ICronMetricBuilder WithCategory(string category, string subCategory, bool skipToLower = true)
    {
      SetTag(Tags.Category, category, skipToLower);
      SetTag(Tags.SubCategory, subCategory, skipToLower);
      return this;
    }

    public ICronMetricBuilder MarkFailed()
    {
      SetSuccess(false);
      return this;
    }

    public ICronMetricBuilder WithException(Exception ex)
    {
      SetException(ex);
      return this;
    }

    public ICronMetricBuilder WithQueryCount(int queryCount)
    {
      _queryCount = queryCount;
      return this;
    }

    public ICronMetricBuilder IncrementQueryCount(int amount = 1)
    {
      _queryCount += amount;
      return this;
    }

    public ICronMetricBuilder WithResultsCount(int resultsCount)
    {
      _resultsCount = resultsCount;
      return this;
    }

    public ICronMetricBuilder IncrementResultsCount(int amount = 1)
    {
      _resultsCount += amount;
      return this;
    }

    public ICronMetricBuilder CountResult(object result = null)
    {
      if (result != null)
        _resultsCount += 1;

      return this;
    }

    public ICronMetricBuilder WithUserId(int userId)
    {
      SetField(MetricField.UserId, userId);
      return this;
    }

    public ICronMetricBuilder WithSuccess(bool success)
    {
      SetSuccess(success);
      return this;
    }

    public ICronMetricBuilder WithCustomTag1(object value, bool skipToLower = false)
    {
      SetObjectTag(MetricTag.Tag1, value, skipToLower);
      return this;
    }

    public ICronMetricBuilder WithCustomTag2(object value, bool skipToLower = false)
    {
      SetObjectTag(MetricTag.Tag2, value, skipToLower);
      return this;
    }

    public ICronMetricBuilder WithCustomTag3(object value, bool skipToLower = false)
    {
      SetObjectTag(MetricTag.Tag3, value, skipToLower);
      return this;
    }

    public ICronMetricBuilder WithCustomTag4(object value, bool skipToLower = false)
    {
      SetObjectTag(MetricTag.Tag4, value, skipToLower);
      return this;
    }

    public ICronMetricBuilder WithCustomInt1(int value)
    {
      _customInt[0] = value;
      return this;
    }

    public ICronMetricBuilder IncrementCustomInt1(int amount = 1)
    {
      _customInt[0] += amount;
      return this;
    }

    public ICronMetricBuilder WithCustomInt2(int value)
    {
      _customInt[1] = value;
      return this;
    }

    public ICronMetricBuilder IncrementCustomInt2(int amount = 1)
    {
      _customInt[1] += amount;
      return this;
    }

    public ICronMetricBuilder WithCustomInt3(int value)
    {
      _customInt[2] = value;
      return this;
    }

    public ICronMetricBuilder IncrementCustomInt3(int amount = 1)
    {
      _customInt[2] += amount;
      return this;
    }

    public ICronMetricBuilder WithCustomLong1(long value)
    {
      _customLong[0] = value;
      return this;
    }

    public ICronMetricBuilder IncrementCustomLong1(long amount = 0)
    {
      _customLong[0] += amount;
      return this;
    }

    public ICronMetricBuilder WithCustomLong2(long value)
    {
      _customLong[1] = value;
      return this;
    }

    public ICronMetricBuilder IncrementCustomLong2(long amount = 0)
    {
      _customLong[1] += amount;
      return this;
    }

    public ICronMetricBuilder WithCustomLong3(long value)
    {
      _customLong[2] = value;
      return this;
    }

    public ICronMetricBuilder IncrementCustomLong3(long amount = 0)
    {
      _customLong[2] += amount;
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
      SetField(MetricField.Long1, _customLong[0]);
      SetField(MetricField.Long2, _customLong[1]);
      SetField(MetricField.Long3, _customLong[2]);

      return CoreMetric;
    }


    // Misc.
    public static class Tags
    {
      public const string CronClass = "cron_class";
      public const string CronMethod = "cron_method";
      public const string Category = "category";
      public const string SubCategory = "sub_category";
    }

    public static class Fields
    {
      public const string QueryCount = "query_count";
      public const string ResultsCount = "results_count";
    }
  }
}
