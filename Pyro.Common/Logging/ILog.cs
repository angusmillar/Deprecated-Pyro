using System;

namespace Pyro.Common.Logging
{
  public interface ILog
  {
    void Debug(Exception exception, string message);
    void Debug(string message);
    void Error(Exception exception, string message);
    void Error(string message);
    void Fatal(Exception exception, string message);
    void Fatal(string message);
    void Info(Exception exception, string message);
    void Info(string message);
    void Trace(Exception exception, string message);
    void Trace(string message);
    void Warn(Exception exception, string message);
    void Warn(string message);
  }
}