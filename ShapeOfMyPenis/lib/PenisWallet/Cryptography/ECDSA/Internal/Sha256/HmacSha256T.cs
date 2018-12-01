// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Sha256.HmacSha256T
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace Cryptography.ECDSA.Internal.Sha256
{
  internal class HmacSha256T
  {
    public Sha256T Inner;
    public Sha256T Outer;

    public HmacSha256T()
    {
      this.Inner = new Sha256T();
      this.Outer = new Sha256T();
    }
  }
}
