// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.Fe
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class Fe
  {
    public uint[] N;

    public uint this[int index]
    {
      get
      {
        return this.N[index];
      }
    }

    public Fe()
    {
      this.N = new uint[10];
    }

    public Fe(uint[] arr)
    {
      this.N = arr;
    }

    public Fe(Fe other)
    {
      this.N = new uint[other.N.Length];
      Array.Copy((Array) other.N, (Array) this.N, other.N.Length);
    }

    public Fe Clone()
    {
      return new Fe(this);
    }
  }
}
