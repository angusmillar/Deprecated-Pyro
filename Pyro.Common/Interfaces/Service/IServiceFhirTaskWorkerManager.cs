namespace Pyro.Common.Interfaces.Service
{
  public interface IServiceFhirTaskWorkerManager
  {
    void WorkerConnected(string ConnectionId);
    void WorkerDisconnected(string ConnectionId);
    void PyroServerStartup();
  }
}