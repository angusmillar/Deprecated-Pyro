namespace Pyro.Common.Interfaces.Tools
{
  public interface IFhirNarativeSupport
  {
    void AppendParagraph(string Value);
    void AppendValuePairList(string Desciption, string Value);
    string Generate();
    void NewParagraph(string Value, string Heading = null, int HeaderStrength = 1);
    void NewRow(params string[] Values);
    void NewTable(string Heading = null, int HeaderStrength = 1, bool IsHeaderRow = false, params string[] Values);
    void NewValuePairList(string Desciption, string Value, string Heading = null, int HeaderStrength = 1);
  }
}