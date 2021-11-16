using System;
using System.Globalization;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics
{
  public abstract class MetricBuilderBase
  {
    protected CoreMetric CoreMetric { get; }


    protected MetricBuilderBase(string measurement, string source = null)
    {
      CoreMetric = new CoreMetric(measurement);

      if (string.IsNullOrWhiteSpace(source))
        source = GetType().Name;

      // Set all default metric tags
      SetTag(MetricTag.Source, source, true);
      SetTag(MetricTag.Success, true);
      SetTag(MetricTag.HasException, false);
      SetTag(MetricTag.ExceptionName, string.Empty);
      SetTag(MetricTag.Environment, string.Empty);
      SetTag(MetricTag.Application, string.Empty);

      // Set all default metric fields
      SetField(MetricField.Value, (long) 0);
      SetField(MetricField.CallCount, 1);
    }


    // Helper methods
    protected void SetException(Exception ex)
      => SetException(ex.GetType().Name);

    protected void SetException(string exceptionName)
    {
      SetSuccess(false);
      SetTag(MetricTag.HasException, true);
      SetTag(MetricTag.ExceptionName, exceptionName, true);
    }

    protected void SetSuccess(bool success)
      => SetTag(MetricTag.Success, success);

    protected void SetObjectTag(string tag, object value, bool skipToLower = false)
    {
      var castValue = CastTagValue(value);
      CoreMetric.Tags[tag] = skipToLower ? castValue : castValue.LowerTrim();
    }

    protected void SetTag(string tag, string value, bool skipToLower = false)
    {
      CoreMetric.Tags[tag] = skipToLower ? value : value.LowerTrim();
    }

    protected void SetTag(string tag, bool value)
    {
      CoreMetric.Tags[tag] = value ? "true" : "false";
    }

    protected void SetTag(string tag, int value)
    {
      CoreMetric.Tags[tag] = value.ToString("D");
    }

    protected void SetField(string field, long value)
    {
      CoreMetric.Fields[field] = value;
    }

    protected void SetField(string field, double value)
    {
      CoreMetric.Fields[field] = value;
    }

    protected void SetField(string field, float value)
    {
      CoreMetric.Fields[field] = value;
    }

    protected void SetField(string field, int value)
    {
      CoreMetric.Fields[field] = value;
    }


    // Internal methods
    public static string CastTagValue(object value)
    {
      return value switch
      {
        string sValue => sValue,
        bool bValue => bValue ? "true" : "false",
        int iValue => iValue.ToString("D"),
        long lValue => lValue.ToString("D"),
        double dValue => dValue.ToString(CultureInfo.InvariantCulture),
        byte b => b.ToString(),
        DateTime dateValue => dateValue.ToString("u"),
        _ => null
      };
    }
  }
}