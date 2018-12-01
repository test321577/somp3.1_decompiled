// Decompiled with JetBrains decompiler
// Type: PenisWallet.GZipUtil
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System.IO;
using System.IO.Compression;

namespace PenisWallet
{
  public static class GZipUtil
  {
    public static void CopyTo(this Stream input, Stream output)
    {
      byte[] buffer = new byte[16384];
      int count;
      while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
        output.Write(buffer, 0, count);
    }

    public static byte[] Compress(byte[] input)
    {
      try
      {
        using (MemoryStream memoryStream1 = new MemoryStream())
        {
          using (GZipStream gzipStream = new GZipStream((Stream) memoryStream1, CompressionMode.Compress))
          {
            using (MemoryStream memoryStream2 = new MemoryStream(input))
              memoryStream2.CopyTo((Stream) gzipStream);
          }
          return memoryStream1.ToArray();
        }
      }
      catch
      {
        return (byte[]) null;
      }
    }

    public static byte[] Decompress(byte[] input)
    {
      try
      {
        using (MemoryStream memoryStream1 = new MemoryStream())
        {
          using (MemoryStream memoryStream2 = new MemoryStream(input))
          {
            using (GZipStream gzipStream = new GZipStream((Stream) memoryStream2, CompressionMode.Decompress))
              gzipStream.CopyTo((Stream) memoryStream1);
          }
          return memoryStream1.ToArray();
        }
      }
      catch
      {
        return (byte[]) null;
      }
    }
  }
}
