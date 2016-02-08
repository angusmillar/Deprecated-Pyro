using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using Hl7.Fhir.Model;

namespace Blaze.Formatters
{
  public class FhirMediaTypeFormatter : MediaTypeFormatter
  {
    protected HttpRequestMessage requestMessage;

    public FhirMediaTypeFormatter()
      : base()
    {
      this.SupportedEncodings.Clear();
      this.SupportedEncodings.Add(Encoding.UTF8);
    }

    public override bool CanReadType(Type type)
    {

      bool can = typeof(Resource).IsAssignableFrom(type);  /* || type == typeof(Bundle) || (type == typeof(TagList) ) */
      return can;
    }

    public override bool CanWriteType(Type type)
    {
      return typeof(Resource).IsAssignableFrom(type);
    }


    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    {
      base.SetDefaultContentHeaders(type, headers, mediaType);
      //setEntryHeaders(headers);
    }

    public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request, MediaTypeHeaderValue mediaType)
    {
      //this.entry = request.GetEntry();
      //MediaTypeHeaderValue MediaThing = null;
      //foreach(var thing in  request.Headers.Accept)
      //{
      //  MediaThing = thing;
      //}
      //return base.GetPerRequestFormatterInstance(type, request, MediaThing);
      
      return base.GetPerRequestFormatterInstance(type, request, mediaType);
    }

    protected string ReadBodyFromStream(Stream readStream, HttpContent content)
    {
      var charset = content.Headers.ContentType.CharSet ?? Encoding.UTF8.HeaderName;
      var encoding = Encoding.GetEncoding(charset);

      if (encoding != Encoding.UTF8)
        throw new ApplicationException("FHIR supports UTF-8 encoding exclusively, not " + encoding.WebName);
      //throw Error.BadRequest("FHIR supports UTF-8 encoding exclusively, not " + encoding.WebName);

      StreamReader reader = new StreamReader(readStream, Encoding.UTF8, true);
      return reader.ReadToEnd();
    }

  }
}