using Microsoft.Extensions.Configuration;
using NSubstitute;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceUtilsTests
{
  public static class TestHelper
  {
    public static Common.Metrics.MetricServiceUtils GetMetricServiceUtils(
      ILoggerAdapter<Common.Metrics.MetricServiceUtils> logger = null,
      IConfiguration configuration = null)
    {
      return new Common.Metrics.MetricServiceUtils(
        logger ?? Substitute.For<ILoggerAdapter<Common.Metrics.MetricServiceUtils>>(),
        configuration ?? new ConfigurationBuilder().Build()
      );
    }
  }
}
