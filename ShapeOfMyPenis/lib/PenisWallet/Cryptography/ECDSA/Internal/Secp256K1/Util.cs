// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.Util
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class Util
  {
    public static void Memcpy(Array src, uint srcOffset, Array dst, uint dstOffset, uint count)
    {
      if (count > (uint) int.MaxValue)
        throw new InvalidCastException(nameof (count));
      if (dstOffset > (uint) int.MaxValue)
        throw new InvalidCastException(nameof (dstOffset));
      if (srcOffset > (uint) int.MaxValue)
        throw new InvalidCastException(nameof (srcOffset));
      Buffer.BlockCopy(src, (int) srcOffset, dst, (int) dstOffset, (int) count);
    }

    public static void Memcpy(Array src, int srcOffset, Array dst, int dstOffset, int count)
    {
      Buffer.BlockCopy(src, srcOffset, dst, dstOffset, count);
    }

    internal static void MemSet(byte[] dest, byte val, int size)
    {
      for (int index = 0; index < size && index < dest.Length; ++index)
        dest[index] = val;
    }

    internal static void MemSet(byte[] dest, uint skip, byte val, uint size)
    {
      for (uint index = skip; index < size && (long) index < (long) dest.Length; ++index)
        dest[(int) index] = val;
    }

    internal static uint BitToUInt32Invers(byte[] b32, int index)
    {
      return (uint) ((int) b32[index + 3] | (int) b32[index + 2] << 8 | (int) b32[index + 1] << 16 | (int) b32[index] << 24);
    }
  }
}
