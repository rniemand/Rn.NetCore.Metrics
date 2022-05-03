﻿using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.NullServiceMetricBuilderTests;

[TestFixture]
public class TimingTests
{
  [Test]
  public void WithTiming_GivenCalled_ShouldReturnTimingToken()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var timingToken = builder.WithTiming();

    // assert
    Assert.IsNotNull(timingToken);
    Assert.IsInstanceOf<IMetricTimingToken>(timingToken);
  }

  [Test]
  public void WithCustomTiming1_GivenCalled_ShouldReturnTimingToken()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var timingToken = builder.WithCustomTiming1();

    // assert
    Assert.IsNotNull(timingToken);
    Assert.IsInstanceOf<IMetricTimingToken>(timingToken);
  }

  [Test]
  public void WithCustomTiming2_GivenCalled_ShouldReturnTimingToken()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var timingToken = builder.WithCustomTiming2();

    // assert
    Assert.IsNotNull(timingToken);
    Assert.IsInstanceOf<IMetricTimingToken>(timingToken);
  }

  [Test]
  public void WithCustomTiming3_GivenCalled_ShouldReturnTimingToken()
  {
    // arrange
    var builder = new NullServiceMetricBuilder();

    // act
    var timingToken = builder.WithCustomTiming3();

    // assert
    Assert.IsNotNull(timingToken);
    Assert.IsInstanceOf<IMetricTimingToken>(timingToken);
  }
}