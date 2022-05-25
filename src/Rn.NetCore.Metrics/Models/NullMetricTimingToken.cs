namespace Rn.NetCore.Metrics.Models;

public class NullMetricTimingToken : IMetricTimingToken
{
  public string FieldName { get; }

  public NullMetricTimingToken()
  {
    FieldName = string.Empty;
  }

  public NullMetricTimingToken(string fieldName)
    : this()
  {
    FieldName = fieldName;
  }

  public void Dispose()
  {
    // Swallow
  }
}
