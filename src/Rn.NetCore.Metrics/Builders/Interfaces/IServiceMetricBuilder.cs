using System;
using Rn.NetCore.Metrics.Interfaces;
using Rn.NetCore.Metrics.Models;

namespace Rn.NetCore.Metrics.Builders
{
  public interface IServiceMetricBuilder : IMetricBuilder
  {
    IServiceMetricBuilder ForService(string serviceName, string methodName, bool skipToLower = true);
    IServiceMetricBuilder WithCategory(string category, string subCategory, bool skipToLower = true);
    IServiceMetricBuilder WithQueryCount(int queryCount);
    IServiceMetricBuilder IncrementQueryCount(int amount = 1);
    IServiceMetricBuilder WithResultsCount(int resultsCount);
    IServiceMetricBuilder IncrementResultsCount(int amount = 1);
    IServiceMetricBuilder CountResult(object result = null);
    IServiceMetricBuilder WithException(Exception ex);
    IServiceMetricBuilder MarkFailed(int resultsCount = -1);
    IServiceMetricBuilder MarkSuccess(int resultsCount = -1);
    IServiceMetricBuilder WithUserId(int userId);
    IServiceMetricBuilder WithSuccess(bool success);
    IServiceMetricBuilder WithCustomInt1(int value);
    IServiceMetricBuilder IncrementCustomInt1(int amount = 1);
    IServiceMetricBuilder WithCustomInt2(int value);
    IServiceMetricBuilder IncrementCustomInt2(int amount = 1);
    IServiceMetricBuilder WithCustomInt3(int value);
    IServiceMetricBuilder IncrementCustomInt3(int amount = 1);
    IServiceMetricBuilder WithCustomInt4(int value);
    IServiceMetricBuilder IncrementCustomInt4(int amount = 1);
    IServiceMetricBuilder WithCustomInt5(int value);
    IServiceMetricBuilder IncrementCustomInt5(int amount = 1);
    IServiceMetricBuilder WithCustomLong1(long value);
    IServiceMetricBuilder IncrementCustomLong1(long amount = 1);
    IServiceMetricBuilder WithCustomLong2(long value);
    IServiceMetricBuilder IncrementCustomLong2(long amount = 1);
    IServiceMetricBuilder WithCustomLong3(long value);
    IServiceMetricBuilder IncrementCustomLong3(long amount = 1);
    IServiceMetricBuilder WithCustomTag1(object value, bool skipToLower = false);
    IServiceMetricBuilder WithCustomTag2(object value, bool skipToLower = false);
    IServiceMetricBuilder WithCustomTag3(object value, bool skipToLower = false);
    IServiceMetricBuilder WithCustomTag4(object value, bool skipToLower = false);
    IMetricTimingToken WithTiming();
    IMetricTimingToken WithCustomTiming1();
    IMetricTimingToken WithCustomTiming2();
    IMetricTimingToken WithCustomTiming3();
  }
}