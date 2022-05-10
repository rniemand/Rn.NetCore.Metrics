using System;
using System.Runtime.Serialization;

namespace Rn.NetCore.Metrics.Exceptions;

// docs\exceptions\MetricConfigException.md
[Serializable]
public class MetricConfigException : Exception
{
  public string Property { get; set; }

  protected MetricConfigException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  { }

  public MetricConfigException(string message)
    : base(message)
  {
    Property = string.Empty;
  }

  public MetricConfigException(string property, string message)
    : this(message)
  {
    Property = property;
  }
}
