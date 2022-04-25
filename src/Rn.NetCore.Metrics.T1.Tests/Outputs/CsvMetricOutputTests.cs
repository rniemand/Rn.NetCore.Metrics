using NUnit.Framework;
using Rn.NetCore.Metrics.Outputs;

namespace Rn.NetCore.Metrics.T1.Tests.Outputs;

[TestFixture]
public class CsvMetricOutputTests
{
  [Test]
  public void CsvMetricOutput_GivenConstructed_ShouldSetEnabledFalse()
  {
    // act
    var output = new CsvMetricOutput();

    // assert
    Assert.IsFalse(output.Enabled);
  }

  [Test]
  public void CsvMetricOutput_GivenConstructed_ShouldSetName()
  {
    // act
    var output = new CsvMetricOutput();

    // assert
    Assert.AreEqual("CsvMetricOutput", output.Name);
  }
}