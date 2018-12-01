// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Hex
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptography.ECDSA
{
  public static class Hex
  {
    public static int HexToInteger(byte[] hex)
    {
      int num = 0;
      for (int index = 0; index < hex.Length; ++index)
        num = num << 8 | (int) hex[index];
      return num;
    }

    public static byte[] HexToBytes(string hex)
    {
      if (hex.Length % 2 != 0)
        hex = "0" + hex;
      byte[] numArray = new byte[hex.Length >> 1];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = (byte) ((Hex.GetHexVal(hex[index << 1]) << 4) + Hex.GetHexVal(hex[(index << 1) + 1]));
      return numArray;
    }

    private static int GetHexVal(char hex)
    {
      int num = (int) hex;
      return num - (num < 58 ? 48 : (num < 97 ? 55 : 87));
    }

    public static byte[] Join(params byte[][] values)
    {
      byte[] numArray1 = new byte[((IEnumerable<byte[]>) values).Sum<byte[]>((Func<byte[], int>) (i => i.Length))];
      int destinationIndex = 0;
      for (int index = 0; index < values.Length; ++index)
      {
        byte[] numArray2 = values[index];
        if (numArray2.Length != 0)
        {
          Array.Copy((Array) numArray2, 0, (Array) numArray1, destinationIndex, numArray2.Length);
          destinationIndex += numArray2.Length;
        }
      }
      return numArray1;
    }

    public static string ToString(byte[] hex)
    {
      return string.Join(string.Empty, ((IEnumerable<byte>) hex).Select<byte, string>((Func<byte, string>) (i => i.ToString("x2"))));
    }
  }
}
