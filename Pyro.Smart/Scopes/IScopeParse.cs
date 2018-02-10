namespace Pyro.Smart.Scopes
{
  public interface IScopeParse
  {
    bool Parse(string item, out ISmartScope scope);
  }
}