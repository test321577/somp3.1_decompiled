// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Base58
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Cryptography.ECDSA
{
  public class Base58
  {
    protected const int CheckSumSizeInBytes = 4;
    protected const string Hexdigits = "0123456789abcdefABCDEF";
    protected const string Digits = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

    public static byte[] RemoveCheckSum(byte[] data)
    {
      byte[] numArray = new byte[data.Length - 4];
      Buffer.BlockCopy((Array) data, 0, (Array) numArray, 0, data.Length - 4);
      return numArray;
    }

    public static string Encode(byte[] data)
    {
      BigInteger bigInteger = (BigInteger) 0;
      for (int index = 0; index < data.Length; ++index)
        bigInteger = bigInteger * (BigInteger) 256 + (BigInteger) data[index];
      string str = "";
      while (bigInteger > 0L)
      {
        int index = (int) (bigInteger % (BigInteger) 58);
        bigInteger /= (BigInteger) 58;
        str = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz"[index].ToString() + str;
      }
      for (int index = 0; index < data.Length && data[index] == (byte) 0; ++index)
        str = "1" + str;
      return str;
    }

    public static byte[] Decode(string base58)
    {
      BigInteger bigInteger = (BigInteger) 0;
      for (int index = 0; index < base58.Length; ++index)
      {
        int num = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz".IndexOf(base58[index]);
        if (num < 0)
          throw new FormatException(string.Format("Invalid Base58 character `{0}` at position {1}", (object) base58[index], (object) index));
        bigInteger = bigInteger * (BigInteger) 58 + (BigInteger) num;
      }
      return Enumerable.Repeat<byte>((byte) 0, base58.TakeWhile<char>((Func<char, bool>) (c => c == '1')).Count<char>()).Concat<byte>(((IEnumerable<byte>) bigInteger.ToByteArray()).Reverse<byte>().SkipWhile<byte>((Func<byte, bool>) (b => b == (byte) 0))).ToArray<byte>();
    }

    protected static byte[] DoubleHash(byte[] s)
    {
      return Sha256Manager.GetHash(Sha256Manager.GetHash(s));
    }

    protected static byte[] CutLastBytes(byte[] source, int cutCount)
    {
      byte[] numArray = new byte[source.Length - cutCount];
      Array.Copy((Array) source, (Array) numArray, numArray.Length);
      return numArray;
    }

    protected static byte[] AddLastBytes(byte[] source, int addCount)
    {
      byte[] numArray = new byte[source.Length + addCount];
      Array.Copy((Array) source, (Array) numArray, source.Length);
      return numArray;
    }

    protected static byte[] CutFirstBytes(byte[] source, int cutCount)
    {
      byte[] numArray = new byte[source.Length - cutCount];
      Array.Copy((Array) source, cutCount, (Array) numArray, 0, numArray.Length);
      return numArray;
    }

    protected static byte[] AddFirstBytes(byte[] source, int addCount)
    {
      byte[] numArray = new byte[source.Length + addCount];
      Array.Copy((Array) source, 0, (Array) numArray, addCount, source.Length);
      return numArray;
    }
  }
}
