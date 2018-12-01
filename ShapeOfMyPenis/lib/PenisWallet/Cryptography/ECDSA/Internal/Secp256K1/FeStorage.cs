// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.FeStorage
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class FeStorage
  {
    public uint[] N;

    public FeStorage()
    {
      this.N = new uint[8];
    }

    public FeStorage(uint[] arr)
    {
      this.N = arr;
    }

    public FeStorage(FeStorage other)
    {
      this.N = new uint[other.N.Length];
      Array.Copy((Array) other.N, (Array) this.N, other.N.Length);
    }

    public FeStorage Clone()
    {
      return new FeStorage(this);
    }
  }
}
