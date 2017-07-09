using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Pyro.Web.Formatters
{
  public interface IFhirXmlMediaTypeFormatter
  {
    bool CanReadType(Type type);
    bool CanWriteType(Type type);
    Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger);
    Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext);
  }
}