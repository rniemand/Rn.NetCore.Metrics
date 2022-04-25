using System;

namespace Rn.NetCore.Metrics.Models;

public interface IMetricTimingToken : IDisposable
{
  string FieldName { get; }
}