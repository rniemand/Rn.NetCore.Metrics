using System;
using System.Collections.Generic;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;

namespace DevConsole;

public interface ICoreMetricBuilder<TBuilder>
{
  string Measurement { get; }

  ICoreMetricBuilder<TBuilder> AddAction(Action<CoreMetric> action);

  CoreMetric Build();
}

public class CoreMetricBuilder<TBuilder> : ICoreMetricBuilder<TBuilder>
{
  public string Measurement { get; }
  private readonly List<Action<CoreMetric>> _actions = new();

  public CoreMetricBuilder(string measurement)
  {
    Measurement = measurement;
  }

  public ICoreMetricBuilder<TBuilder> AddAction(Action<CoreMetric> action)
  {
    _actions.Add(action);
    return this;
  }

  public virtual CoreMetric Build()
  {
    var metric = new CoreMetric(Measurement);
    _actions.ForEach(a => a(metric));
    return metric;
  }
}

public sealed class ServiceMetricBuilderNew : CoreMetricBuilder<ServiceMetricBuilderNew>
{
  private int _queryCount = 0;
  private int _resultsCount = 0;

  public ServiceMetricBuilderNew()
    :base("service_call")
  {
    // Register default tags
    AddAction(m => { m.SetTag(Tags.ServiceName, string.Empty); });
    AddAction(m => { m.SetTag(Tags.ServiceMethod, string.Empty); });
    AddAction(m => { m.SetTag(Tags.Category, string.Empty); });
    AddAction(m => { m.SetTag(Tags.SubCategory, string.Empty); });

    // Register default fields
    AddAction(m => { m.SetField(MetricField.UserId, 0); }); // unused
    AddAction(m => { m.SetField(MetricField.Timing1, 0L); }); // unused
    AddAction(m => { m.SetField(MetricField.Timing2, 0L); }); // unused
    AddAction(m => { m.SetField(MetricField.Timing3, 0L); }); // unused
    AddAction(m => { m.SetField(MetricField.Int1, 0); }); // unused
    AddAction(m => { m.SetField(MetricField.Int2, 0); }); // unused
    AddAction(m => { m.SetField(MetricField.Int3, 0); }); // unused
    AddAction(m => { m.SetField(MetricField.Int4, 0); }); // unused
    AddAction(m => { m.SetField(MetricField.Int5, 0); }); // unused
    AddAction(m => { m.SetField(MetricField.Long1, 0L); }); // unused
    AddAction(m => { m.SetField(MetricField.Long2, 0L); }); // unused
    AddAction(m => { m.SetField(MetricField.Long3, 0L); }); // unused
  }

  public ServiceMetricBuilderNew(string service, string method)
    : this()
  {
    ForService(service, method);
  }

  public ServiceMetricBuilderNew ForService(string service, string method, bool skipToLower = true)
  {
    AddAction(m => { m.SetTag(Tags.ServiceName, service, skipToLower); });
    AddAction(m => { m.SetTag(Tags.ServiceMethod, method, skipToLower); });
    return this;
  }

  public ServiceMetricBuilderNew WithCategory(string category, string subCategory, bool skipToLower = true)
  {
    AddAction(m => { m.SetTag(Tags.Category, category, skipToLower); });
    AddAction(m => { m.SetTag(Tags.SubCategory, subCategory, skipToLower); });
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

  /*
 * public class ServiceMetricBuilder : MetricBuilderBase, IServiceMetricBuilder
{
  public bool IsNullMetricBuilder { get; }

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
 */

  public override CoreMetric Build()
  {
    // Handle custom values before building
    AddAction(m => { m.SetField(Fields.QueryCount, _queryCount); });
    AddAction(m => { m.SetField(Fields.ResultsCount, _resultsCount); });

    return base.Build();
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

public static class CoreMetricBuilderExtensions
{
  public static TBuilder WithCustomTag1<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetTag(MetricTag.Tag1, value, skipToLower); });
    return builder;
  }

  public static TBuilder WithCustomTag2<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetTag(MetricTag.Tag2, value, skipToLower); });
    return builder;
  }

  public static TBuilder WithCustomTag3<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetTag(MetricTag.Tag3, value, skipToLower); });
    return builder;
  }

  public static TBuilder WithCustomTag4<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetTag(MetricTag.Tag4, value, skipToLower); });
    return builder;
  }

  public static TBuilder WithCustomTag5<TBuilder>(this TBuilder builder, string value, bool skipToLower = false)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetTag(MetricTag.Tag5, value, skipToLower); });
    return builder;
  }

  public static TBuilder WithUserId<TBuilder>(this TBuilder builder, int userId)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    builder.AddAction(m => { m.SetField(MetricField.UserId, userId); });
    return builder;
  }
}


internal class Program
{
  private static readonly IServiceProvider Services = DIContainer.Get();

  static void Main(string[] args)
  {
    var metric = new ServiceMetricBuilderNew("service", "method")
      .WithCategory("category", "subCategory")
      .IncrementQueryCount(2)
      .WithResultsCount(5)
      .Build();


    Console.WriteLine();
    Console.WriteLine();
  }
}
