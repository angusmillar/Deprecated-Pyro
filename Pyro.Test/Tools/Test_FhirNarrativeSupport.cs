using System;
using NUnit.Framework;
using Pyro.Common.Tools;
using NUnit.Framework.Constraints;
using Pyro.Common.Interfaces.Tools.HtmlSupport;

namespace Pyro.Test.Tools
{
  [TestFixture]
  [Category("Tools")]
  public class Test_FhirNarrativeSupport
  {
    [Test]
    public void Test_NarativeGeneration()
    {
      var Narative = new HtmlGenerationSupport();

      Narative.NewValuePairList("Dog", "Peppa", "Things", 3);
      Narative.AppendValuePairList("Cat", "meow");
      Narative.AppendValuePairList("Monkey", "Chimp");
      Narative.AppendValuePairList("Human", "Angus");

      Narative.NewValuePairList("Dad", "Angus", "Millar Family");
      Narative.AppendValuePairList("Mum", "Megan");
      Narative.AppendValuePairList("Child", "Zach");
      Narative.AppendValuePairList("Child", "Harry");


      Narative.NewParagraph("The brown fox went for a walk on my screen and never came back", "HeadingTitle", 2);
      Narative.AppendParagraph("Second paragraph of The brown fox went for a walk on my screen and never came back");

      Narative.NewParagraph("The brown fox went for a walk on my screen and never came back", "Other Paragraph");
      Narative.AppendParagraph("Second paragraph of The brown fox went for a walk on my screen and never came back");

      Narative.NewTable("Table Header", 4, true, "AData1", "AData2", "AData3", "AData4");
      Narative.NewRow("BData1", "BData2", "BData3", "BData4");
      Narative.NewRow("CData1", "CData2", "CData3", "CData4");



      string result = Narative.Generate();
    }
  }
}
