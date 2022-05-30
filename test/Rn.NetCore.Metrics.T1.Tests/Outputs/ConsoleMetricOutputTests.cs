using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Metrics.Abstractions;
using Rn.NetCore.Metrics.Configuration;
using Rn.NetCore.Metrics.Outputs;
using Rn.NetCore.Metrics.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.Metrics.T1.Tests.Outputs;

[TestFixture]
public class ConsoleMetricOutputTests
{
  private readonly RnMetricsConfig _config = new RnMetricsConfigBuilder()
    .WithEnableConsoleOutput(true)
    .WithEnabled(true)
    .Build();

  [Test]
  public void ConsoleMetricOutput_GivenConstructed_ShouldSetName() =>
    Assert.That(new ConsoleMetricOutput(_config).Name, Is.EqualTo("ConsoleMetricOutput"));

  [Test]
  public async Task SubmitMetric_GivenCalled_ShouldSetConsoleColor()
  {
    // arrange
    var console = Substitute.For<IConsole>();
    var metric = new CoreMetric("my_metric");

    var output = new ConsoleMetricOutput(_config, console);

    // act
    await output.SubmitMetric(metric);

    // assert
    console.Received(1).ForegroundColor = ConsoleColor.Green;
  }

  [Test]
  public async Task SubmitMetric_GivenCalled_ShouldResetConsoleColor()
  {
    // arrange
    var console = Substitute.For<IConsole>();
    var metric = new CoreMetric("my_metric");

    var output = new ConsoleMetricOutput(_config, console);

    // act
    await output.SubmitMetric(metric);

    // assert
    console.Received(1).ResetColor();
  }

  [Test]
  public async Task SubmitMetric_GivenCalled_ShouldLogProcessedMetric()
  {
    // arrange
    var console = Substitute.For<IConsole>();
    var metric = new CoreMetric("my_metric")
      .WithDate(new DateTime(2022, 1, 1, 1, 1, 2, 2, DateTimeKind.Utc));

    var output = new ConsoleMetricOutput(_config, console);

    // act
    await output.SubmitMetric(metric);

    // assert
    console.Received(1).WriteLine("[2021-12-31T18:01:02] \"my_metric\"");
  }

  [Test]
  public async Task ProcessMetric_GivenCalled_ShouldHandleSingleTag()
  {
    // arrange
    var console = Substitute.For<IConsole>();
    var metric = new CoreMetric("my_metric")
      .WithDate(new DateTime(2022, 1, 1, 1, 1, 2, 2, DateTimeKind.Utc));

    metric.Tags["tag1"] = "value1";

    var output = new ConsoleMetricOutput(_config, console);

    // act
    await output.SubmitMetric(metric);

    // assert
    console.Received(1).WriteLine(Arg.Is<string>(s =>
      s.Contains("tag1 => value1")));
  }

  [Test]
  public async Task ProcessMetric_GivenCalled_ShouldHandleMultipleTags()
  {
    // arrange
    var console = Substitute.For<IConsole>();
    var metric = new CoreMetric("my_metric")
      .WithDate(new DateTime(2022, 1, 1, 1, 1, 2, 2, DateTimeKind.Utc));

    metric.Tags["tag1"] = "value1";
    metric.Tags["tag2"] = "value2";

    var output = new ConsoleMetricOutput(_config, console);

    // act
    await output.SubmitMetric(metric);

    // assert
    console.Received(1).WriteLine(Arg.Is<string>(s =>
      s.Contains("tag1 => value1, tag2 => value2")));
  }

  [Test]
  public async Task ProcessMetric_GivenCalled_ShouldHandleSingleField()
  {
    // arrange
    var console = Substitute.For<IConsole>();
    var metric = new CoreMetric("my_metric")
      .WithDate(new DateTime(2022, 1, 1, 1, 1, 2, 2, DateTimeKind.Utc));

    metric.Fields["field1"] = 12;

    var output = new ConsoleMetricOutput(_config, console);

    // act
    await output.SubmitMetric(metric);

    // assert
    console.Received(1).WriteLine(Arg.Is<string>(s =>
      s.Contains("(field1 => 12)")));
  }

  [Test]
  public async Task ProcessMetric_GivenCalled_ShouldHandleMultipleFields()
  {
    // arrange
    var console = Substitute.For<IConsole>();
    var metric = new CoreMetric("my_metric")
      .WithDate(new DateTime(2022, 1, 1, 1, 1, 2, 2, DateTimeKind.Utc));

    metric.Fields["field1"] = 12;
    metric.Fields["field2"] = 13;

    var output = new ConsoleMetricOutput(_config, console);

    // act
    await output.SubmitMetric(metric);

    // assert
    console.Received(1).WriteLine(Arg.Is<string>(s =>
      s.Contains("(field1 => 12) (field2 => 13)")));
  }

  [TestCase("hello", "hello")]
  // ReSharper disable once RedundantCast
  [TestCase((long)9223372036854775, "9223372036854775")]
  [TestCase((ulong)9223372036854775, "9223372036854775")]
  // ReSharper disable once RedundantCast
  [TestCase((int)2147483647, "2147483647")]
  [TestCase((uint)2147483647, "2147483647")]
  [TestCase((float)3.4028235E+38, "3.4028235E+38")]
  // ReSharper disable once RedundantCast
  [TestCase((double)1.7976931348623157, "1.7976931348623157")]
  [TestCase((short)32767, "32767")]
  [TestCase((ushort)32767, "32767")]
  [TestCase((byte)255, "255")]
  [TestCase((sbyte)-42, "-42")]
  [TestCase(true, "true")]
  [TestCase(1.79769313486232, "1.79769313486232")]
  public async Task ProcessMetric_GivenCalled_ShouldHandleTypedField(object field, string expected)
  {
    // arrange
    var console = Substitute.For<IConsole>();
    var metric = new CoreMetric("my_metric")
      .WithDate(new DateTime(2022, 1, 1, 1, 1, 2, 2, DateTimeKind.Utc));

    metric.Fields["field1"] = field;

    var output = new ConsoleMetricOutput(_config, console);

    // act
    await output.SubmitMetric(metric);

    // assert
    console.Received(1).WriteLine(Arg.Is<string>(s =>
      s.Contains($"(field1 => {expected})")));
  }
}
