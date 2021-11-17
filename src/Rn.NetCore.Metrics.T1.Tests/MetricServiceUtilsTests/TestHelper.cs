using Microsoft.Extensions.Configuration;
using NSubstitute;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.Metrics.T1.Tests.MetricServiceUtilsTests
{
  public static class TestHelper
  {
    public static MetricServiceUtils GetMetricServiceUtils(
      ILoggerAdapter<MetricServiceUtils> logger = null,
      IConfiguration configuration = null)
    {
      return new MetricServiceUtils(
        logger ?? Substitute.For<ILoggerAdapter<MetricServiceUtils>>(),
        configuration ?? new ConfigurationBuilder().Build()
      );
    }
  }
}
