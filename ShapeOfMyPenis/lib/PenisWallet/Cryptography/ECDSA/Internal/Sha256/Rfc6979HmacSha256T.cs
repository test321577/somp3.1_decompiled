// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Sha256.Rfc6979HmacSha256T
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace Cryptography.ECDSA.Internal.Sha256
{
  internal class Rfc6979HmacSha256T
  {
    public byte[] V;
    public byte[] K;
    public bool Retry;

    public Rfc6979HmacSha256T()
    {
      this.V = new byte[32];
      this.K = new byte[32];
      this.Retry = false;
    }
  }
}
