using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Rn.NetCore.Metrics.Exceptions;

// DOCS: docs\exceptions\MetricConfigException.md
[Serializable, ExcludeFromCodeCoverage]
public class MetricConfigException : Exception
{
  public string Property { get; set; } = string.Empty;

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
