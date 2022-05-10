# Rn.NetCore.Metrics
Metrics abstractions for your application.

> **NOTE**: This project is still a `work-in-progress` and may change a lot during development.

## Configuration
The following configuration documentation is available.

- [appsettings.json](/docs/configuration/appsettings.md) - covers all available configuration supported in `appsettings.json`.

## Metric Builders
More to come...

- [ServiceMetricBuilder](/docs/builders/ServiceMetricBuilder.md) - used to build service related metrics.
- [NullServiceMetricBuilder](/docs/builders/NullServiceMetricBuilder.md) - `noop` metric builder.
- [CronMetricBuilder](/docs/builders/CronMetricBuilder.md) - used to build `CRON` related metrics.
- [NullCronMetricBuilder](/docs/builders/NullCronMetricBuilder.md) - `noop` metric builder.

## Enums
More to come...

- [MetricField](/docs/enums/MetricField.md)
- [MetricPlaceholder](/docs/enums/MetricPlaceholder.md)
- [MetricTag](/docs/enums/MetricTag.md)

## Exceptions
More to come...

- [MetricConfigException](/docs/exceptions/MetricConfigException.md)

<!--(Rn.BuildScriptHelper){
	"version": "1.0.106",
	"replace": false
}(END)-->