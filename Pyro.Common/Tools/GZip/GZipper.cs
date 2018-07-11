using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Tools.GZip
{
  public static class GZipper
  {
    public static byte[] Compress(byte[] InputBytes)
    {
      using (var outputStream = new System.IO.MemoryStream())
      {
        using (var gZipStream = new System.IO.Compression.GZipStream(outputStream, System.IO.Compression.CompressionLevel.Optimal))
        {
          gZipStream.Write(InputBytes, 0, InputBytes.Length);
        }
        return outputStream.ToArray();
      }
    }

    public static string Decompress(byte[] InputBytes)
    {
      using (System.IO.MemoryStream MemStream = new System.IO.MemoryStream(InputBytes))
      {
        using (var Decompress = new System.IO.Compression.GZipStream(MemStream, System.IO.Compression.CompressionMode.Decompress))
        {
          using (var StreamReader = new System.IO.StreamReader(Decompress))
          {
            return StreamReader.ReadToEnd();
          }
        }
      }
    }
  }
}
