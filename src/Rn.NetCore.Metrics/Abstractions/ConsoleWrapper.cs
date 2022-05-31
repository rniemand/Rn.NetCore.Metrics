using System;
using System.Diagnostics.CodeAnalysis;

namespace Rn.NetCore.Metrics.Abstractions;

[ExcludeFromCodeCoverage]
public class ConsoleWrapper : IConsole
{
  public ConsoleColor ForegroundColor
  {
    get => Console.ForegroundColor;
    set => Console.ForegroundColor = value;
  }

  public void WriteLine(string? value) => Console.WriteLine(value);
  public void ResetColor() => Console.ResetColor();
}
