// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Ripemd160Manager
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace Cryptography.ECDSA
{
  public static class Ripemd160Manager
  {
    private static readonly uint[] K = new uint[5]
    {
      0U,
      1518500249U,
      1859775393U,
      2400959708U,
      2840853838U
    };
    private static readonly uint[] K1 = new uint[5]
    {
      1352829926U,
      1548603684U,
      1836072691U,
      2053994217U,
      0U
    };
    private static readonly byte[] R = new byte[80]
    {
      (byte) 0,
      (byte) 1,
      (byte) 2,
      (byte) 3,
      (byte) 4,
      (byte) 5,
      (byte) 6,
      (byte) 7,
      (byte) 8,
      (byte) 9,
      (byte) 10,
      (byte) 11,
      (byte) 12,
      (byte) 13,
      (byte) 14,
      (byte) 15,
      (byte) 7,
      (byte) 4,
      (byte) 13,
      (byte) 1,
      (byte) 10,
      (byte) 6,
      (byte) 15,
      (byte) 3,
      (byte) 12,
      (byte) 0,
      (byte) 9,
      (byte) 5,
      (byte) 2,
      (byte) 14,
      (byte) 11,
      (byte) 8,
      (byte) 3,
      (byte) 10,
      (byte) 14,
      (byte) 4,
      (byte) 9,
      (byte) 15,
      (byte) 8,
      (byte) 1,
      (byte) 2,
      (byte) 7,
      (byte) 0,
      (byte) 6,
      (byte) 13,
      (byte) 11,
      (byte) 5,
      (byte) 12,
      (byte) 1,
      (byte) 9,
      (byte) 11,
      (byte) 10,
      (byte) 0,
      (byte) 8,
      (byte) 12,
      (byte) 4,
      (byte) 13,
      (byte) 3,
      (byte) 7,
      (byte) 15,
      (byte) 14,
      (byte) 5,
      (byte) 6,
      (byte) 2,
      (byte) 4,
      (byte) 0,
      (byte) 5,
      (byte) 9,
      (byte) 7,
      (byte) 12,
      (byte) 2,
      (byte) 10,
      (byte) 14,
      (byte) 1,
      (byte) 3,
      (byte) 8,
      (byte) 11,
      (byte) 6,
      (byte) 15,
      (byte) 13
    };
    private static readonly byte[] R1 = new byte[80]
    {
      (byte) 5,
      (byte) 14,
      (byte) 7,
      (byte) 0,
      (byte) 9,
      (byte) 2,
      (byte) 11,
      (byte) 4,
      (byte) 13,
      (byte) 6,
      (byte) 15,
      (byte) 8,
      (byte) 1,
      (byte) 10,
      (byte) 3,
      (byte) 12,
      (byte) 6,
      (byte) 11,
      (byte) 3,
      (byte) 7,
      (byte) 0,
      (byte) 13,
      (byte) 5,
      (byte) 10,
      (byte) 14,
      (byte) 15,
      (byte) 8,
      (byte) 12,
      (byte) 4,
      (byte) 9,
      (byte) 1,
      (byte) 2,
      (byte) 15,
      (byte) 5,
      (byte) 1,
      (byte) 3,
      (byte) 7,
      (byte) 14,
      (byte) 6,
      (byte) 9,
      (byte) 11,
      (byte) 8,
      (byte) 12,
      (byte) 2,
      (byte) 10,
      (byte) 0,
      (byte) 4,
      (byte) 13,
      (byte) 8,
      (byte) 6,
      (byte) 4,
      (byte) 1,
      (byte) 3,
      (byte) 11,
      (byte) 15,
      (byte) 0,
      (byte) 5,
      (byte) 12,
      (byte) 2,
      (byte) 13,
      (byte) 9,
      (byte) 7,
      (byte) 10,
      (byte) 14,
      (byte) 12,
      (byte) 15,
      (byte) 10,
      (byte) 4,
      (byte) 1,
      (byte) 5,
      (byte) 8,
      (byte) 7,
      (byte) 6,
      (byte) 2,
      (byte) 13,
      (byte) 14,
      (byte) 0,
      (byte) 3,
      (byte) 9,
      (byte) 11
    };
    private static readonly byte[] S = new byte[80]
    {
      (byte) 11,
      (byte) 14,
      (byte) 15,
      (byte) 12,
      (byte) 5,
      (byte) 8,
      (byte) 7,
      (byte) 9,
      (byte) 11,
      (byte) 13,
      (byte) 14,
      (byte) 15,
      (byte) 6,
      (byte) 7,
      (byte) 9,
      (byte) 8,
      (byte) 7,
      (byte) 6,
      (byte) 8,
      (byte) 13,
      (byte) 11,
      (byte) 9,
      (byte) 7,
      (byte) 15,
      (byte) 7,
      (byte) 12,
      (byte) 15,
      (byte) 9,
      (byte) 11,
      (byte) 7,
      (byte) 13,
      (byte) 12,
      (byte) 11,
      (byte) 13,
      (byte) 6,
      (byte) 7,
      (byte) 14,
      (byte) 9,
      (byte) 13,
      (byte) 15,
      (byte) 14,
      (byte) 8,
      (byte) 13,
      (byte) 6,
      (byte) 5,
      (byte) 12,
      (byte) 7,
      (byte) 5,
      (byte) 11,
      (byte) 12,
      (byte) 14,
      (byte) 15,
      (byte) 14,
      (byte) 15,
      (byte) 9,
      (byte) 8,
      (byte) 9,
      (byte) 14,
      (byte) 5,
      (byte) 6,
      (byte) 8,
      (byte) 6,
      (byte) 5,
      (byte) 12,
      (byte) 9,
      (byte) 15,
      (byte) 5,
      (byte) 11,
      (byte) 6,
      (byte) 8,
      (byte) 13,
      (byte) 12,
      (byte) 5,
      (byte) 12,
      (byte) 13,
      (byte) 14,
      (byte) 11,
      (byte) 8,
      (byte) 5,
      (byte) 6
    };
    private static readonly byte[] S1 = new byte[80]
    {
      (byte) 8,
      (byte) 9,
      (byte) 9,
      (byte) 11,
      (byte) 13,
      (byte) 15,
      (byte) 15,
      (byte) 5,
      (byte) 7,
      (byte) 7,
      (byte) 8,
      (byte) 11,
      (byte) 14,
      (byte) 14,
      (byte) 12,
      (byte) 6,
      (byte) 9,
      (byte) 13,
      (byte) 15,
      (byte) 7,
      (byte) 12,
      (byte) 8,
      (byte) 9,
      (byte) 11,
      (byte) 7,
      (byte) 7,
      (byte) 12,
      (byte) 7,
      (byte) 6,
      (byte) 15,
      (byte) 13,
      (byte) 11,
      (byte) 9,
      (byte) 7,
      (byte) 15,
      (byte) 11,
      (byte) 8,
      (byte) 6,
      (byte) 6,
      (byte) 14,
      (byte) 12,
      (byte) 13,
      (byte) 5,
      (byte) 14,
      (byte) 13,
      (byte) 13,
      (byte) 7,
      (byte) 5,
      (byte) 15,
      (byte) 5,
      (byte) 8,
      (byte) 11,
      (byte) 14,
      (byte) 14,
      (byte) 6,
      (byte) 14,
      (byte) 6,
      (byte) 9,
      (byte) 12,
      (byte) 9,
      (byte) 12,
      (byte) 5,
      (byte) 15,
      (byte) 8,
      (byte) 8,
      (byte) 5,
      (byte) 12,
      (byte) 9,
      (byte) 12,
      (byte) 5,
      (byte) 14,
      (byte) 6,
      (byte) 8,
      (byte) 13,
      (byte) 6,
      (byte) 5,
      (byte) 15,
      (byte) 13,
      (byte) 11,
      (byte) 11
    };
    private const uint H0 = 1732584193;
    private const uint H1 = 4023233417;
    private const uint H2 = 2562383102;
    private const uint H3 = 271733878;
    private const uint H4 = 3285377520;

    public static byte[] GetHash(byte[] data)
    {
      int num1 = 72;
      int num2 = data.Length % 64;
      if (num2 > 56)
        num1 = 128 - num2;
      else if (num2 < 56)
        num1 = 64 - num2;
      uint[] x = new uint[(data.Length + num1) / 4];
      Buffer.BlockCopy((Array) data, 0, (Array) x, 0, data.Length);
      x[data.Length / 4] |= (uint) (1 << 8 * (data.Length % 4) + 7);
      x[x.Length - 2] = (uint) (data.Length << 3);
      x[x.Length - 1] = (uint) data.Length >> 29;
      return Ripemd160Manager.DoHash(x);
    }

    private static byte[] DoHash(uint[] x)
    {
      uint num1 = 1732584193;
      uint num2 = 4023233417;
      uint num3 = 2562383102;
      uint num4 = 271733878;
      uint num5 = 3285377520;
      for (int index1 = 0; index1 < x.Length / 16; ++index1)
      {
        uint num6 = num1;
        uint num7 = num1;
        uint x1 = num2;
        uint x2 = num2;
        uint y1 = num3;
        uint y2 = num3;
        uint z1 = num4;
        uint z2 = num4;
        uint num8 = num5;
        uint num9 = num5;
        for (int index2 = 0; index2 < 80; ++index2)
        {
          int j1 = index2 / 16;
          byte num10 = Ripemd160Manager.R[index2];
          uint num11 = Ripemd160Manager.K[j1];
          uint num12 = x[index1 * 16 + (int) num10];
          byte shift1 = Ripemd160Manager.S[index2];
          int num13 = (int) Ripemd160Manager.Rol(num6 + Ripemd160Manager.F(j1, x1, y1, z1) + num12 + num11, shift1) + (int) num8;
          num6 = num8;
          num8 = z1;
          z1 = Ripemd160Manager.Rol(y1, (byte) 10);
          y1 = x1;
          x1 = (uint) num13;
          int j2 = 4 - j1;
          byte num14 = Ripemd160Manager.R1[index2];
          uint num15 = Ripemd160Manager.K1[j1];
          uint num16 = x[index1 * 16 + (int) num14];
          byte shift2 = Ripemd160Manager.S1[index2];
          int num17 = (int) Ripemd160Manager.Rol(num7 + Ripemd160Manager.F(j2, x2, y2, z2) + num16 + num15, shift2) + (int) num9;
          num7 = num9;
          num9 = z2;
          z2 = Ripemd160Manager.Rol(y2, (byte) 10);
          y2 = x2;
          x2 = (uint) num17;
        }
        int num18 = (int) num2 + (int) y1 + (int) z2;
        num2 = num3 + z1 + num9;
        num3 = num4 + num8 + num7;
        num4 = num5 + num6 + x2;
        num5 = num1 + x1 + y2;
        num1 = (uint) num18;
      }
      byte[] numArray = new byte[20];
      Buffer.BlockCopy((Array) BitConverter.GetBytes(num1), 0, (Array) numArray, 0, 4);
      Buffer.BlockCopy((Array) BitConverter.GetBytes(num2), 0, (Array) numArray, 4, 4);
      Buffer.BlockCopy((Array) BitConverter.GetBytes(num3), 0, (Array) numArray, 8, 4);
      Buffer.BlockCopy((Array) BitConverter.GetBytes(num4), 0, (Array) numArray, 12, 4);
      Buffer.BlockCopy((Array) BitConverter.GetBytes(num5), 0, (Array) numArray, 16, 4);
      return numArray;
    }

    private static uint F(int j, uint x, uint y, uint z)
    {
      switch (j)
      {
        case 0:
          return x ^ y ^ z;
        case 1:
          return (uint) ((int) x & (int) y | ~(int) x & (int) z);
        case 2:
          return (x | ~y) ^ z;
        case 3:
          return (uint) ((int) x & (int) z | (int) y & ~(int) z);
        case 4:
          return x ^ (y | ~z);
        default:
          throw new ArgumentException(nameof (j));
      }
    }

    private static uint Rol(uint value, byte shift)
    {
      return value << (int) shift | value >> 32 - (int) shift;
    }
  }
}
