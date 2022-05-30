using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Rn.NetCore.Metrics.T1.Tests.LibRoot;

[TestFixture]
public class CoreMetricTests
{
  [Test]
  public void CoreMetric_GivenConstructed_ShouldSetMeasurement() =>
    Assert.That(new CoreMetric("MyMetric").Measurement, Is.EqualTo("MyMetric"));

  [Test]
  public void CoreMetric_GivenConstructed_ShouldDefaultUtcTimestamp() =>
    Assert.That(new CoreMetric("MyMetric").UtcTimestamp, Is.EqualTo(DateTime.MinValue));

  [Test]
  public void CoreMetric_GivenConstructed_ShouldDefaultTags() =>
    Assert.That(new CoreMetric("MyMetric").Tags, Is.InstanceOf<Dictionary<string, string>>());

  [Test]
  public void CoreMetric_GivenConstructed_ShouldDefaultFields() =>
    Assert.That(new CoreMetric("MyMetric").Fields, Is.InstanceOf<Dictionary<string, object>>());

  [TestCase("String", true, "String")]
  [TestCase("String", false, "string")]
  public void SetTag_GivenStringValue_ShouldSetTagValue(string value, bool skipToLower, string expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetTag("mytag", value, skipToLower)
      .Tags["mytag"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(true, "true")]
  [TestCase(false, "false")]
  public void SetTag_GivenBoolValue_ShouldSetTagValue(bool value, string expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetTag("mytag", value)
      .Tags["mytag"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(123, "123")]
  [TestCase(1233333333, "1233333333")]
  public void SetTag_GivenIntValue_ShouldSetTagValue(int value, string expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetTag("mytag", value)
      .Tags["mytag"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(1233333333, "1233333333")]
  public void SetTag_GivenLongValue_ShouldSetTagValue(long value, string expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetTag("mytag", value)
      .Tags["mytag"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(1233333.33, "1233333.33")]
  public void SetTag_GivenDoubleValue_ShouldSetTagValue(double value, string expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetTag("mytag", value)
      .Tags["mytag"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(12, "12")]
  public void SetTag_GivenByteValue_ShouldSetTagValue(byte value, string expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetTag("mytag", value)
      .Tags["mytag"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(144332, 144332)]
  public void SetField_GivenLongValue_ShouldSetTagValue(long value, long expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(144332, 144332)]
  public void SetField_GivenDoubleValue_ShouldSetTagValue(double value, double expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(144332, 144332)]
  public void SetField_GivenFloatValue_ShouldSetTagValue(float value, float expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(144332, 144332)]
  public void SetField_GivenIntValue_ShouldSetTagValue(int value, int expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(true, true)]
  public void SetField_GivenBoolValue_ShouldSetTagValue(bool value, bool expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(1, 1)]
  public void SetField_GivenSbyteValue_ShouldSetTagValue(sbyte value, sbyte expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(1, 1)]
  public void SetField_GivenByteValue_ShouldSetTagValue(byte value, byte expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(1, 1)]
  public void SetField_GivenShortValue_ShouldSetTagValue(short value, short expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase((ushort)1, (ushort)1)]
  public void SetField_GivenUshortValue_ShouldSetTagValue(ushort value, ushort expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase((uint)1, (uint)1)]
  public void SetField_GivenUintValue_ShouldSetTagValue(uint value, uint expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase((ulong)1, (ulong)1)]
  public void SetField_GivenUlongValue_ShouldSetTagValue(ulong value, ulong expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }

  [TestCase(1.23, 1.23)]
  public void SetField_GivenDecimalValue_ShouldSetTagValue(decimal value, decimal expected)
  {
    // arrange
    var tagValue = new CoreMetric("MyMetric")
      .SetField("myField", value)
      .Fields["myField"];

    // assert
    Assert.That(tagValue, Is.EqualTo(expected));
  }
}
