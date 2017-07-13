using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace Pyro.Common.Formatters
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
      return typeof(Resource).IsAssignableFrom(type);  /* || type == typeof(Bundle) || (type == typeof(TagList) ) */
    }

    public override bool CanWriteType(Type type)
    {
      return typeof(Resource).IsAssignableFrom(type);
    }

    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    {
      base.SetDefaultContentHeaders(type, headers, mediaType);
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

    public string BuildContentType(ResourceFormat format)
    {
      string contentType;

      if (format == ResourceFormat.Json)
        contentType = Hl7.Fhir.Rest.ContentType.JSON_CONTENT_HEADER;
      else if (format == ResourceFormat.Xml)
        contentType = Hl7.Fhir.Rest.ContentType.XML_CONTENT_HEADER;
      else
        throw new ArgumentException("Cannot determine content type for data format " + format);

      return contentType;
    }

  }
}