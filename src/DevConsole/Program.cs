using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;

namespace DevConsole;

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

public static class CoreMetricBuilderExtensions
{
  public static TBuilder WithCustomTag1<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTag("custom_tag1", value, skipToLower);

  public static TBuilder WithCustomTag2<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTag("custom_tag2", value, skipToLower);

  public static TBuilder WithCustomTag3<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTag("custom_tag3", value, skipToLower);

  public static TBuilder WithCustomTag4<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTag("custom_tag4", value, skipToLower);

  public static TBuilder WithCustomTag5<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTag("custom_tag5", value, skipToLower);

  public static TBuilder WithTag<TBuilder>(this TBuilder builder, string tag, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetTag(tag, value, skipToLower); });
    return builder;
  }

  public static TBuilder WithCustomInt1<TBuilder>(this TBuilder builder, int value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WitInt("custom_int1", value);

  public static TBuilder WithCustomInt2<TBuilder>(this TBuilder builder, int value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WitInt("custom_int2", value);

  public static TBuilder WithCustomInt3<TBuilder>(this TBuilder builder, int value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WitInt("custom_int3", value);

  public static TBuilder WithCustomInt4<TBuilder>(this TBuilder builder, int value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WitInt("custom_int4", value);

  public static TBuilder WithCustomInt5<TBuilder>(this TBuilder builder, int value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WitInt("custom_int5", value);

  public static TBuilder WitInt<TBuilder>(this TBuilder builder, string field, int value)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetField(field, value); });
    return builder;
  }

  public static TBuilder WithCustomLong1<TBuilder>(this TBuilder builder, long value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithLong("custom_long1", value);

  public static TBuilder WithCustomLong2<TBuilder>(this TBuilder builder, long value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithLong("custom_long2", value);

  public static TBuilder WithCustomLong3<TBuilder>(this TBuilder builder, long value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithLong("custom_long3", value);

  public static TBuilder WithCustomLong4<TBuilder>(this TBuilder builder, long value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithLong("custom_long4", value);

  public static TBuilder WithCustomLong5<TBuilder>(this TBuilder builder, long value)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithLong("custom_long5", value);

  public static TBuilder WithLong<TBuilder>(this TBuilder builder, string field, long value)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetField(field, value); });
    return builder;
  }

  public static TBuilder WithUserId<TBuilder>(this TBuilder builder, int userId)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetField(MetricField.UserId, userId); });
    return builder;
  }

  public static TBuilder MarkFailed<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.SetSuccess(false);
    return builder;
  }

  public static TBuilder MarkSuccess<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.SetSuccess(true);
    return builder;
  }

  public static TBuilder WithSuccess<TBuilder>(this TBuilder builder, bool success)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.SetSuccess(success);
    return builder;
  }

  public static IMetricTimingToken WithCustomTiming1<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder> => WithTiming(builder, "custom_timing1");

  public static IMetricTimingToken WithCustomTiming2<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder> => WithTiming(builder, "custom_timing2");

  public static IMetricTimingToken WithCustomTiming3<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder> => WithTiming(builder, "custom_timing3");

  public static IMetricTimingToken WithTiming<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder> => WithTiming(builder, "value");

  public static IMetricTimingToken WithTiming<TBuilder>(this TBuilder builder, string? field)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    if (string.IsNullOrWhiteSpace(field))
      field = "value";

    return new MetricTimingTokenNew<TBuilder>(builder, field);
  }
}

public class MetricTimingTokenNew<TBuilder> : IMetricTimingToken
{
  public string FieldName { get; private set; }

  private readonly ICoreMetricBuilder<TBuilder> _builder;
  private readonly Stopwatch _stopwatch;

  public MetricTimingTokenNew(ICoreMetricBuilder<TBuilder> builder, string fieldName)
  {
    _builder = builder;
    FieldName = fieldName;
    _stopwatch = Stopwatch.StartNew();
  }

  public void Dispose()
  {
    var elapsedMs = _stopwatch.ElapsedMilliseconds;
    _builder.AddAction(m => { m.SetField(FieldName, elapsedMs); });
    GC.SuppressFinalize(this);
  }
}

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

public sealed class CronMetricBuilderNew : CoreMetricBuilder<CronMetricBuilderNew>
{
  private string _cronClass = string.Empty;
  private string _cronMethod = string.Empty;
  private string _category = string.Empty;
  private string _subCategory = string.Empty;

  private int _queryCount;
  private int _resultsCount;

  public CronMetricBuilderNew()
    : base("cron_job")
  { }

  public CronMetricBuilderNew(string cronClass, string cronMethod)
    : this()
  {
    ForCronJob(cronClass, cronMethod);
  }

  public CronMetricBuilderNew ForCronJob(string cronClass, string cronMethod)
  {
    _cronClass = cronClass;
    _cronMethod = cronMethod;
    return this;
  }

  public CronMetricBuilderNew WithCategory(string category, string subCategory, bool skipToLower = true)
  {
    _category = skipToLower ? category : category.LowerTrim();
    _subCategory = skipToLower ? subCategory : subCategory.LowerTrim();
    return this;
  }

  public CronMetricBuilderNew WithException(Exception ex)
  {
    SetException(ex);
    return this;
  }

  public CronMetricBuilderNew WithQueryCount(int queryCount)
  {
    _queryCount = queryCount;
    return this;
  }

  public CronMetricBuilderNew IncrementQueryCount(int amount = 1)
  {
    _queryCount += amount;
    return this;
  }

  public CronMetricBuilderNew WithResultsCount(int resultsCount)
  {
    _resultsCount = resultsCount;
    return this;
  }

  public CronMetricBuilderNew IncrementResultsCount(int amount = 1)
  {
    _resultsCount += amount;
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


/*
 * public class CronMetricBuilder : MetricBuilderBase, ICronMetricBuilder

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
 

  public static class Fields
  {
    public const string QueryCount = "query_count";
    public const string ResultsCount = "results_count";
  }
}
 */


internal class Program
{
  static void Main(string[] args)
  {
    var metricBuilder = new CronMetricBuilderNew()
      .MarkFailed();

    using (metricBuilder.WithTiming())
    {
      using (metricBuilder.WithCustomTiming1())
      {
        Thread.Sleep(125);
      }
    }

    var metric = metricBuilder.Build();
    
    Console.WriteLine();
    Console.WriteLine();
  }
}
