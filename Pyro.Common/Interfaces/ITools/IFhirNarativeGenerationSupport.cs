namespace Pyro.Common.Interfaces.ITools
{
  public interface IFhirNarativeGenerationSupport
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