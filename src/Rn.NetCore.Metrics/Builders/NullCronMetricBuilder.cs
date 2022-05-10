using System;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders;

// DOCS: docs\builders\NullCronMetricBuilder.md
public class NullCronMetricBuilder : ICronMetricBuilder
{
  public bool IsNullMetricBuilder { get; }
    
  public NullCronMetricBuilder()
  {
    IsNullMetricBuilder = true;
  }

  public ICronMetricBuilder ForCronJob(string cronClass, string cronMethod) => this;
  public ICronMetricBuilder WithCategory(string category, string subCategory, bool skipToLower = true) => this;
  public ICronMetricBuilder MarkFailed() => this;
  public ICronMetricBuilder WithException(Exception ex) => this;
  public ICronMetricBuilder WithQueryCount(int queryCount) => this;
  public ICronMetricBuilder IncrementQueryCount(int amount = 1) => this;
  public ICronMetricBuilder WithResultsCount(int resultsCount) => this;
  public ICronMetricBuilder IncrementResultsCount(int amount = 1) => this;
  public ICronMetricBuilder CountResult(object result = null) => this;
  public ICronMetricBuilder WithUserId(int userId) => this;
  public ICronMetricBuilder WithSuccess(bool success) => this;
  public ICronMetricBuilder WithCustomTag1(object value, bool skipToLower = false) => this;
  public ICronMetricBuilder WithCustomTag2(object value, bool skipToLower = false) => this;
  public ICronMetricBuilder WithCustomTag3(object value, bool skipToLower = false) => this;
  public ICronMetricBuilder WithCustomTag4(object value, bool skipToLower = false) => this;
  public ICronMetricBuilder WithCustomInt1(int value) => this;
  public ICronMetricBuilder IncrementCustomInt1(int amount = 1) => this;
  public ICronMetricBuilder WithCustomInt2(int value) => this;
  public ICronMetricBuilder IncrementCustomInt2(int amount = 1) => this;
  public ICronMetricBuilder WithCustomInt3(int value) => this;
  public ICronMetricBuilder IncrementCustomInt3(int amount = 1) => this;
  public ICronMetricBuilder WithCustomLong1(long value) => this;
  public ICronMetricBuilder IncrementCustomLong1(long amount = 0) => this;
  public ICronMetricBuilder WithCustomLong2(long value) => this;
  public ICronMetricBuilder IncrementCustomLong2(long amount = 0) => this;
  public ICronMetricBuilder WithCustomLong3(long value) => this;
  public ICronMetricBuilder IncrementCustomLong3(long amount = 0) => this;

  public IMetricTimingToken WithTiming() => new NullMetricTimingToken();
  public IMetricTimingToken WithCustomTiming1() => new NullMetricTimingToken();
  public IMetricTimingToken WithCustomTiming2() => new NullMetricTimingToken();
  public IMetricTimingToken WithCustomTiming3() => new NullMetricTimingToken();

  public CoreMetric Build() => null;
}
