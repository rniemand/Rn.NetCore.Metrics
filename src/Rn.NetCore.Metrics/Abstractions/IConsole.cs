using System;

namespace Rn.NetCore.Metrics.Abstractions;

public interface IConsole
{
  ConsoleColor ForegroundColor { get; set; }
  void WriteLine(string? value);
  void ResetColor();
}
