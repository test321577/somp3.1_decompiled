// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.Ge
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class Ge
  {
    public Fe X;
    public Fe Y;
    public bool Infinity;

    public Ge()
    {
      this.X = new Fe();
      this.Y = new Fe();
    }

    public Ge(uint[] xarr, uint[] yarr)
    {
      this.X = new Fe(xarr);
      this.Y = new Fe(yarr);
    }
  }
}
