using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pyro.Web.Formatters
{
  public interface IFhirJsonMediaTypeFormatter
  {
    Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger);
    void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType);
    Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext);
  }
}