namespace Rn.NetCore.Metrics.Models;

public class NullMetricTimingToken : IMetricTimingToken
{
  public string FieldName { get; }

  public NullMetricTimingToken()
  {
    // TODO: [TESTS] (NullMetricTimingToken) Add tests
    FieldName = string.Empty;
  }

  public NullMetricTimingToken(string fieldName)
    : this()
  {
    // TODO: [TESTS] (NullMetricTimingToken) Add tests
    FieldName = fieldName;
  }

  public void Dispose()
  {
    // Swallow
  }
}