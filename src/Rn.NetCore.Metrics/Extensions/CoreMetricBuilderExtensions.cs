using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.Metrics.Extensions;

// DOCS: docs\exceptions\MetricConfigException.md
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
    builder.AddAction(m => { m.SetField("user_id", userId); });
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
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTiming("custom_timing1");

  public static IMetricTimingToken WithCustomTiming2<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTiming("custom_timing2");

  public static IMetricTimingToken WithCustomTiming3<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTiming("custom_timing3");

  public static IMetricTimingToken WithTiming<TBuilder>(this TBuilder builder)
    where TBuilder : ICoreMetricBuilder<TBuilder> => builder.WithTiming("value");

  public static IMetricTimingToken WithTiming<TBuilder>(this TBuilder builder, string? field)
    where TBuilder : ICoreMetricBuilder<TBuilder>
  {
    if (string.IsNullOrWhiteSpace(field))
      field = "value";

    return new MetricTimingToken<TBuilder>(builder, field);
  }
}
