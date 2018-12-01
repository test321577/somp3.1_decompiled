// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Sha256.Sha256T
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace Cryptography.ECDSA.Internal.Sha256
{
  internal class Sha256T
  {
    public uint[] S;
    public uint[] Buf;
    public uint Bytes;

    public Sha256T()
    {
      this.S = new uint[8];
      this.Buf = new uint[16];
      this.Bytes = 0U;
    }
  }
}
