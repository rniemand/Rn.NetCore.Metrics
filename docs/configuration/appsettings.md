[Home](/README.md) / [Configuration](/docs/configuration/README.md) / appsettings.json

# appsettings.json
Configuration for **Rn.NetCore.Metrics** is done via your projects `appsettings.json` file, with the following values supported:

```json
{
  "Rn.Metrics": {
    "enabled": true,
    "application": "MyApp",
    "template": "{app}/{measurement}",
    "overrides": {},
    "environment": "production",
    "enableConsoleOutput": false
  }
}
```
Details on each option is listed below.

| Property | Type | Required | Default | Notes |
| --- | --- | ---- | ---- | --- |
| `enabled` | `bool` | required | `false` | Enables the usage of metrics |
| `application` | `string` | required | - | The name of your application |
| `template` | `string` | optional | `{app}/{measurement}` | Template to use when generating metrics. |
| `overrides` | `Dictionary<string, string` | optional | `{}` | Dictionary of configured metric overrides to use when generating metrics. |
| `environment` | `string` | optional | `development` | The current environment your application is running on. |
