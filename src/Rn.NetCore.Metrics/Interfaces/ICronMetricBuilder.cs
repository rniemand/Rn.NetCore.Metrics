using System;

namespace Rn.NetCore.Metrics.Interfaces
{
  public interface ICronMetricBuilder : IMetricBuilder
  {
    ICronMetricBuilder ForCronJob(string cronClass, string cronMethod);
    ICronMetricBuilder WithCategory(string category, string subCategory, bool skipToLower = true);
    ICronMetricBuilder MarkFailed();
    ICronMetricBuilder WithException(Exception ex);
    ICronMetricBuilder WithQueryCount(int queryCount);
    ICronMetricBuilder IncrementQueryCount(int amount = 1);
    ICronMetricBuilder WithResultsCount(int resultsCount);
    ICronMetricBuilder IncrementResultsCount(int amount = 1);
    ICronMetricBuilder CountResult(object result = null);
    ICronMetricBuilder WithUserId(int userId);
    ICronMetricBuilder WithSuccess(bool success);
    ICronMetricBuilder WithCustomTag1(object value, bool skipToLower = false);
    ICronMetricBuilder WithCustomTag2(object value, bool skipToLower = false);
    ICronMetricBuilder WithCustomTag3(object value, bool skipToLower = false);
    ICronMetricBuilder WithCustomTag4(object value, bool skipToLower = false);
    ICronMetricBuilder WithCustomInt1(int value);
    ICronMetricBuilder IncrementCustomInt1(int amount = 1);
    ICronMetricBuilder WithCustomInt2(int value);
    ICronMetricBuilder IncrementCustomInt2(int amount = 1);
    ICronMetricBuilder WithCustomInt3(int value);
    ICronMetricBuilder IncrementCustomInt3(int amount = 1);
    ICronMetricBuilder WithCustomLong1(long value);
    ICronMetricBuilder IncrementCustomLong1(long amount = 0);
    ICronMetricBuilder WithCustomLong2(long value);
    ICronMetricBuilder IncrementCustomLong2(long amount = 0);
    ICronMetricBuilder WithCustomLong3(long value);
    ICronMetricBuilder IncrementCustomLong3(long amount = 0);
    IMetricTimingToken WithTiming();
    IMetricTimingToken WithCustomTiming1();
    IMetricTimingToken WithCustomTiming2();
    IMetricTimingToken WithCustomTiming3();
  }
}