using System;

namespace Rn.NetCore.Metrics.Interfaces
{
  public interface IMetricTimingToken : IDisposable
  {
    string FieldName { get; }
  }
}