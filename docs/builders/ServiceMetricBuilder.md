[Home](/README.md) / [Builders](/docs/builders/README.md) / ServiceMetricBuilder

# ServiceMetricBuilder
More to come...

- ServiceMetricBuilder()
- ServiceMetricBuilder(string service, string method)
- ServiceMetricBuilder ForService(string service, string method, bool skipToLower = true)
- ServiceMetricBuilder WithCategory(string category, string subCategory, bool skipToLower = true)
- ServiceMetricBuilder WithQueryCount(int queryCount)
- ServiceMetricBuilder IncrementQueryCount(int amount = 1)
- ServiceMetricBuilder WithResultsCount(int resultsCount)
- ServiceMetricBuilder IncrementResultsCount(int amount = 1)
- ServiceMetricBuilder CountResult(object? result = null)
- ServiceMetricBuilder WithException(Exception ex)
- public override CoreMetric Build()
