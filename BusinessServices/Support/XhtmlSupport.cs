using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.IO;

namespace Blaze.Engine.Support
{
  public static class XhtmlSupport
  {
    public static string EncodeToDiv(string text)
    {
      // Initialise StringWriter instance.
      StringWriter stringWriter = new StringWriter();

      // Put HtmlTextWriter in using block because it needs to call Dispose.
      using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
      {
        writer.RenderBeginTag(HtmlTextWriterTag.Div);
        //##Issues## if I and the <p> tag I get an empty name-space on the tag like this: <p xmlns="">
        //It is the Hl7.Fhir API adding this, not sure why or even if it is wrong.
        //writer.RenderBeginTag(HtmlTextWriterTag.P);
        writer.WriteEncodedText(text);        
        //writer.RenderEndTag();
        writer.RenderEndTag(); 
      }
      // Return the result.
      return stringWriter.ToString();
    }

    public static string EncodeToString(string text)
    {
      return System.Web.HttpUtility.HtmlEncode(text);      
    }

  }
}
