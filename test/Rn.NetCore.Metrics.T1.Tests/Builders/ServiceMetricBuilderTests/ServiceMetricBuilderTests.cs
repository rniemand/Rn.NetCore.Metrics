using System;
using NUnit.Framework;
using Rn.NetCore.Metrics.Builders;
using Rn.NetCore.Metrics.Enums;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.T1.Tests.Builders.ServiceMetricBuilderTests;

[TestFixture]
public class ServiceMetricBuilderTests
{
  private const string ServiceName = "ServiceName";
  private const string ServiceMethod = "ServiceMethod";
  private const string ServiceCategory = "ServiceCategory";
  private const string ServiceSubCategory = "ServiceSubCategory";

  [Test]
  public void ServiceMetricBuilder_Given_Constructed_ShouldInherit_ExpectedInterfaces()
  {
    // act
    var builder = new ServiceMetricBuilder();

    // assert
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
    Assert.IsInstanceOf<IMetricBuilder>(builder);
  }

  [Test]
  public void ServiceMetricBuilder_Given_Constructed_ShouldSet_Properties()
  {
    // act
    var builder = new ServiceMetricBuilder();

    // assert
    Assert.IsFalse(builder.IsNullMetricBuilder);
  }

  [Test]
  public void ServiceMetricBuilder_Given_Constructed_ShouldDefault_Tags()
  {
    // arrange
    var builder = new ServiceMetricBuilder();

    // act
    var metric = builder.Build();

    // assert
    Assert.AreEqual(string.Empty, metric.Tags[ServiceMetricBuilder.Tags.ServiceName]);
    Assert.AreEqual(string.Empty, metric.Tags[ServiceMetricBuilder.Tags.ServiceMethod]);
    Assert.AreEqual(string.Empty, metric.Tags[ServiceMetricBuilder.Tags.Category]);
    Assert.AreEqual(string.Empty, metric.Tags[ServiceMetricBuilder.Tags.SubCategory]);
    Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Tag1]);
    Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Tag2]);
    Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Tag3]);
    Assert.AreEqual(string.Empty, metric.Tags[MetricTag.Tag4]);

    Assert.AreEqual("ServiceMetricBuilder", metric.Tags[MetricTag.Source]);
    Assert.AreEqual("true", metric.Tags[MetricTag.Success]);
    Assert.AreEqual("false", metric.Tags[MetricTag.HasException]);
    Assert.AreEqual(string.Empty, metric.Tags[MetricTag.ExceptionName]);
  }

  [Test]
  public void ServiceMetricBuilder_Given_Constructed_ShouldDefault_Fields()
  {
    // arrange
    var builder = new ServiceMetricBuilder();

    // act
    var metric = builder.Build();

    // assert
    Assert.AreEqual(0, metric.Fields[ServiceMetricBuilder.Fields.QueryCount]);
    Assert.AreEqual(0, metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
    Assert.AreEqual(0, metric.Fields[MetricField.UserId]);
    Assert.AreEqual((long)0, metric.Fields[MetricField.Timing1]);
    Assert.AreEqual((long)0, metric.Fields[MetricField.Timing2]);
    Assert.AreEqual((long)0, metric.Fields[MetricField.Timing3]);
    Assert.AreEqual(0, metric.Fields[MetricField.Int1]);
    Assert.AreEqual(0, metric.Fields[MetricField.Int2]);
    Assert.AreEqual(0, metric.Fields[MetricField.Int3]);
    Assert.AreEqual(0, metric.Fields[MetricField.Int4]);
    Assert.AreEqual(0, metric.Fields[MetricField.Int5]);
    Assert.AreEqual((long)0, metric.Fields[MetricField.Long1]);
    Assert.AreEqual((long)0, metric.Fields[MetricField.Long2]);
    Assert.AreEqual((long)0, metric.Fields[MetricField.Long3]);
      
    Assert.AreEqual((long)0, metric.Fields[MetricField.Value]);
    Assert.AreEqual(1, metric.Fields[MetricField.CallCount]);
  }

  [Test]
  public void ServiceMetricBuilder_Given_Constructed_ShouldSet_MetricProperties()
  {
    // arrange
    var builder = new ServiceMetricBuilder();

    // act
    var metric = builder.Build();

    // assert
    Assert.AreEqual("service_call", metric.Measurement);
  }

  [Test]
  public void ServiceMetricBuilder_Given_ServiceNameAndMethod_ShouldSet_MetricProperties()
  {
    // arrange
    var builder = new ServiceMetricBuilder(ServiceName, ServiceMethod);

    // act
    var metric = builder.Build();

    // assert
    Assert.AreEqual(ServiceName, metric.Tags[ServiceMetricBuilder.Tags.ServiceName]);
    Assert.AreEqual(ServiceMethod, metric.Tags[ServiceMetricBuilder.Tags.ServiceMethod]);
  }

  [Test]
  public void ForService_Given_Called_ShouldSet_Tags()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .ForService(ServiceName, ServiceMethod)
      .Build();

    // assert
    Assert.AreEqual(ServiceName, metric.Tags[ServiceMetricBuilder.Tags.ServiceName]);
    Assert.AreEqual(ServiceMethod, metric.Tags[ServiceMetricBuilder.Tags.ServiceMethod]);
  }

  [Test]
  public void ForService_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .ForService(ServiceName, ServiceMethod);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCategory_Given_Called_ShouldSet_Tags()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCategory(ServiceCategory, ServiceSubCategory)
      .Build();

    // assert
    Assert.AreEqual(ServiceCategory, metric.Tags[ServiceMetricBuilder.Tags.Category]);
    Assert.AreEqual(ServiceSubCategory, metric.Tags[ServiceMetricBuilder.Tags.SubCategory]);
  }

  [Test]
  public void WithCategory_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCategory(ServiceCategory, ServiceSubCategory);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithQueryCount_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithQueryCount(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[ServiceMetricBuilder.Fields.QueryCount]);
    Assert.AreEqual(2, metric.Fields[ServiceMetricBuilder.Fields.QueryCount]);
  }

  [Test]
  public void WithQueryCount_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithQueryCount(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementQueryCount_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementQueryCount(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[ServiceMetricBuilder.Fields.QueryCount]);
    Assert.AreEqual(2, metric.Fields[ServiceMetricBuilder.Fields.QueryCount]);
  }

  [Test]
  public void IncrementQueryCount_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementQueryCount(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithResultsCount_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithResultsCount(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
    Assert.AreEqual(2, metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
  }

  [Test]
  public void WithResultsCount_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithResultsCount(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementResultsCount_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementResultsCount(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
    Assert.AreEqual(2, metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
  }

  [Test]
  public void IncrementResultsCount_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementResultsCount(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void CountResult_Given_Null_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .CountResult()
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
    Assert.AreEqual(0, metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
  }

  [Test]
  public void CountResult_Given_Value_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .CountResult(true)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
    Assert.AreEqual(1, metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
  }

  [Test]
  public void CountResult_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .CountResult(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithException_Given_Called_ShouldSet_Tags()
  {
    // arrange
    var ex = new ArgumentException();
    var builder = new ServiceMetricBuilder();

    // act
    var metric = builder
      .WithException(ex)
      .Build();

    // assert
    Assert.AreEqual("false", metric.Tags[MetricTag.Success]);
    Assert.AreEqual("true", metric.Tags[MetricTag.HasException]);
    Assert.AreEqual(ex.GetType().Name, metric.Tags[MetricTag.ExceptionName]);
  }

  [Test]
  public void WithException_Given_Called_ShouldReturn_Builder()
  {
    // arrange
    var ex = new ArgumentException();

    // act
    var builder = new ServiceMetricBuilder()
      .WithException(ex);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void MarkFailed_Given_Called_ShouldSet_Tag()
  {
    // arrange
    var builder = new ServiceMetricBuilder();

    // act
    var metric = builder
      .MarkFailed()
      .Build();

    // assert
    Assert.AreEqual("false", metric.Tags[MetricTag.Success]);
  }

  [Test]
  public void MarkFailed_Given_ResultCount_ShouldSet_Field()
  {
    // arrange
    var builder = new ServiceMetricBuilder();

    // act
    var metric = builder
      .MarkFailed(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
    Assert.AreEqual(2, metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
  }

  [Test]
  public void MarkFailed_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .MarkFailed();

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void MarkSuccess_Given_Called_ShouldSet_Tag()
  {
    // arrange
    var builder = new ServiceMetricBuilder();

    // act
    var metric = builder
      .MarkSuccess()
      .Build();

    // assert
    Assert.AreEqual("true", metric.Tags[MetricTag.Success]);
  }

  [Test]
  public void MarkSuccess_Given_ResultCount_ShouldSet_Field()
  {
    // arrange
    var builder = new ServiceMetricBuilder();

    // act
    var metric = builder
      .MarkSuccess(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
    Assert.AreEqual(2, metric.Fields[ServiceMetricBuilder.Fields.ResultsCount]);
  }

  [Test]
  public void MarkSuccess_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .MarkSuccess();

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithUserId_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithUserId(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.UserId]);
    Assert.AreEqual(2, metric.Fields[MetricField.UserId]);
  }

  [Test]
  public void WithUserId_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithUserId(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithSuccess_Given_Called_ShouldSet_Tag()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithSuccess(true)
      .Build();

    // assert
    Assert.AreEqual("true", metric.Tags[MetricTag.Success]);
  }

  [Test]
  public void WithSuccess_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithSuccess(true);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomInt1_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomInt1(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int1]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int1]);
  }

  [Test]
  public void WithCustomInt1_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCustomInt1(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomInt1_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementCustomInt1(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int1]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int1]);
  }

  [Test]
  public void IncrementCustomInt1_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementCustomInt1(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomInt2_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomInt2(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int2]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int2]);
  }

  [Test]
  public void WithCustomInt2_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCustomInt2(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomInt2_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementCustomInt2(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int2]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int2]);
  }

  [Test]
  public void IncrementCustomInt2_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementCustomInt2(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomInt3_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomInt3(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int3]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int3]);
  }

  [Test]
  public void WithCustomInt3_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCustomInt2(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomInt3_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementCustomInt3(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int3]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int3]);
  }

  [Test]
  public void IncrementCustomInt3_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementCustomInt3(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomInt4_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomInt4(122)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int4]);
    Assert.AreEqual(122, metric.Fields[MetricField.Int4]);
  }

  [Test]
  public void WithCustomInt4_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCustomInt4(202);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomInt4_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementCustomInt4(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int4]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int4]);
  }

  [Test]
  public void IncrementCustomInt4_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementCustomInt4(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomInt5_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomInt5(122)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int5]);
    Assert.AreEqual(122, metric.Fields[MetricField.Int5]);
  }

  [Test]
  public void WithCustomInt5_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCustomInt5(202);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomInt5_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementCustomInt5(2)
      .Build();

    // assert
    Assert.IsInstanceOf<int>(metric.Fields[MetricField.Int5]);
    Assert.AreEqual(2, metric.Fields[MetricField.Int5]);
  }

  [Test]
  public void IncrementCustomInt5_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementCustomInt5(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomLong1_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomLong1(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long1]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long1]);
  }

  [Test]
  public void WithCustomLong1_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCustomLong1(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomLong1_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementCustomLong1(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long1]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long1]);
  }

  [Test]
  public void IncrementCustomLong1_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementCustomLong1(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomLong2_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomLong2(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long2]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long2]);
  }

  [Test]
  public void WithCustomLong2_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCustomLong2(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomLong2_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementCustomLong2(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long2]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long2]);
  }

  [Test]
  public void IncrementCustomLong2_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementCustomLong2(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomLong3_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomLong3(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long3]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long3]);
  }

  [Test]
  public void WithCustomLong3_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .WithCustomLong3(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void IncrementCustomLong3_Given_Called_ShouldSet_Field()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .IncrementCustomLong3(2)
      .Build();

    // assert
    Assert.IsInstanceOf<long>(metric.Fields[MetricField.Long3]);
    Assert.AreEqual(2, metric.Fields[MetricField.Long3]);
  }

  [Test]
  public void IncrementCustomLong3_Given_Called_ShouldReturn_Builder()
  {
    // act
    var builder = new ServiceMetricBuilder()
      .IncrementCustomLong3(32);

    // assert
    Assert.IsNotNull(builder);
    Assert.IsInstanceOf<IServiceMetricBuilder>(builder);
  }

  [Test]
  public void WithCustomTag1_Given_Called_ShouldSet_Tag()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomTag1(2)
      .Build();

    // assert
    Assert.AreEqual("2", metric.Tags[MetricTag.Tag1]);
  }

  [Test]
  public void WithCustomTag2_Given_Called_ShouldSet_Tag()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomTag2(true)
      .Build();

    // assert
    Assert.AreEqual("true", metric.Tags[MetricTag.Tag2]);
  }

  [Test]
  public void WithCustomTag3_Given_Called_ShouldSet_Tag()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomTag3("hi")
      .Build();

    // assert
    Assert.AreEqual("hi", metric.Tags[MetricTag.Tag3]);
  }

  [Test]
  public void WithCustomTag4_Given_Called_ShouldSet_Tag()
  {
    // act
    var metric = new ServiceMetricBuilder()
      .WithCustomTag4("another_one")
      .Build();

    // assert
    Assert.AreEqual("another_one", metric.Tags[MetricTag.Tag4]);
  }

  [Test]
  public void WithTiming_Given_Called_ShouldReturn_TimingToken()
  {
    // act
    var timingToken = new ServiceMetricBuilder()
      .WithTiming();

    // assert
    Assert.IsInstanceOf<IMetricTimingToken>(timingToken);
    Assert.AreEqual(MetricField.Value, timingToken.FieldName);
  }

  [Test]
  public void WithCustomTiming1_Given_Called_ShouldReturn_TimingToken()
  {
    // act
    var timingToken = new ServiceMetricBuilder()
      .WithCustomTiming1();

    // assert
    Assert.IsInstanceOf<IMetricTimingToken>(timingToken);
    Assert.AreEqual(MetricField.Timing1, timingToken.FieldName);
  }

  [Test]
  public void WithCustomTiming2_Given_Called_ShouldReturn_TimingToken()
  {
    // act
    var timingToken = new ServiceMetricBuilder()
      .WithCustomTiming2();

    // assert
    Assert.IsInstanceOf<IMetricTimingToken>(timingToken);
    Assert.AreEqual(MetricField.Timing2, timingToken.FieldName);
  }

  [Test]
  public void WithCustomTiming3_Given_Called_ShouldReturn_TimingToken()
  {
    // act
    var timingToken = new ServiceMetricBuilder()
      .WithCustomTiming3();

    // assert
    Assert.IsInstanceOf<IMetricTimingToken>(timingToken);
    Assert.AreEqual(MetricField.Timing3, timingToken.FieldName);
  }
}