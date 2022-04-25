using System;
using NSubstitute;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.Metrics.T1.Tests.TestSupport;

public static class ServiceProviderExtensions
{
  public static IServiceProvider WithLogger<TLogger>(this IServiceProvider provider, ILoggerAdapter<TLogger>? logger = null)
  {
    provider
      .GetService(typeof(ILoggerAdapter<TLogger>))
      .Returns(logger ?? Substitute.For<ILoggerAdapter<TLogger>>());

    return provider;
  }

  public static IServiceProvider WithService<TService>(this IServiceProvider provider, TService? service = null) where TService : class
  {
    provider
      .GetService(typeof(TService))
      .Returns(service ?? Substitute.For<TService>());

    return provider;
  }
}