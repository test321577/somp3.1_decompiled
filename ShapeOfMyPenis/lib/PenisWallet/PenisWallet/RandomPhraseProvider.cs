// Decompiled with JetBrains decompiler
// Type: PenisWallet.RandomPhraseProvider
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;
using System.Security.Cryptography;

namespace PenisWallet
{
  public abstract class RandomPhraseProvider : AbstractKeyProvider
  {
    private RandomNumberGenerator rng = RandomNumberGenerator.Create();

    protected bool NextBool()
    {
      byte[] data = new byte[1];
      this.rng.GetBytes(data);
      return data[0] > (byte) 127;
    }

    protected bool Probab(float probab)
    {
      byte[] data = new byte[1];
      this.rng.GetBytes(data);
      return (double) data[0] < (double) probab * (double) byte.MaxValue;
    }

    protected int NextInt(int max = 0)
    {
      byte[] data = new byte[4];
      this.rng.GetBytes(data);
      uint uint32 = BitConverter.ToUInt32(data, 0);
      if (max == 0)
        return (int) uint32;
      return (int) ((long) uint32 % (long) max);
    }
  }
}
