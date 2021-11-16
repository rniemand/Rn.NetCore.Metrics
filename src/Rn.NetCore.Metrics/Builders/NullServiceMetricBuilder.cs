using System;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders
{
  public class NullServiceMetricBuilder : IServiceMetricBuilder
  {
    public bool IsNullMetricBuilder { get; }

    public NullServiceMetricBuilder()
    {
      IsNullMetricBuilder = true;
    }

    public IServiceMetricBuilder ForService(string serviceName, string methodName, bool skipToLower = true) => this;
    public IServiceMetricBuilder WithCategory(string category, string subCategory, bool skipToLower = true) => this;
    public IServiceMetricBuilder WithQueryCount(int queryCount) => this;
    public IServiceMetricBuilder IncrementQueryCount(int amount = 1) => this;
    public IServiceMetricBuilder WithResultsCount(int resultsCount) => this;
    public IServiceMetricBuilder IncrementResultsCount(int amount = 1) => this;
    public IServiceMetricBuilder CountResult(object result = null) => this;
    public IServiceMetricBuilder WithException(Exception ex) => this;
    public IServiceMetricBuilder MarkFailed(int resultsCount = -1) => this;
    public IServiceMetricBuilder MarkSuccess(int resultsCount = -1) => this;
    public IServiceMetricBuilder WithUserId(int userId) => this;
    public IServiceMetricBuilder WithSuccess(bool success) => this;
    public IServiceMetricBuilder WithCustomInt1(int value) => this;
    public IServiceMetricBuilder IncrementCustomInt1(int amount = 1) => this;
    public IServiceMetricBuilder WithCustomInt2(int value) => this;
    public IServiceMetricBuilder IncrementCustomInt2(int amount = 1) => this;
    public IServiceMetricBuilder WithCustomInt3(int value) => this;
    public IServiceMetricBuilder IncrementCustomInt3(int amount = 1) => this;
    public IServiceMetricBuilder WithCustomInt4(int value) => this;
    public IServiceMetricBuilder IncrementCustomInt4(int amount = 1) => this;
    public IServiceMetricBuilder WithCustomInt5(int value) => this;
    public IServiceMetricBuilder IncrementCustomInt5(int amount = 1) => this;
    public IServiceMetricBuilder WithCustomLong1(long value) => this;
    public IServiceMetricBuilder IncrementCustomLong1(long amount = 1) => this;
    public IServiceMetricBuilder WithCustomLong2(long value) => this;
    public IServiceMetricBuilder IncrementCustomLong2(long amount = 1) => this;
    public IServiceMetricBuilder WithCustomLong3(long value) => this;
    public IServiceMetricBuilder IncrementCustomLong3(long amount = 1) => this;
    public IServiceMetricBuilder WithCustomTag1(object value, bool skipToLower = false) => this;
    public IServiceMetricBuilder WithCustomTag2(object value, bool skipToLower = false) => this;
    public IServiceMetricBuilder WithCustomTag3(object value, bool skipToLower = false) => this;
    public IServiceMetricBuilder WithCustomTag4(object value, bool skipToLower = false) => this;

    public IMetricTimingToken WithTiming() => new NullMetricTimingToken();
    public IMetricTimingToken WithCustomTiming1() => new NullMetricTimingToken();
    public IMetricTimingToken WithCustomTiming2() => new NullMetricTimingToken();
    public IMetricTimingToken WithCustomTiming3() => new NullMetricTimingToken();

    public CoreMetric Build() => null;
  }
}