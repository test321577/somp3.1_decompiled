// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.GeJ
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class GeJ
  {
    public Fe X;
    public Fe Y;
    public Fe Z;
    public bool Infinity;

    public GeJ()
    {
      this.X = new Fe();
      this.Y = new Fe();
      this.Z = new Fe();
    }

    public GeJ(Fe xVal, Fe yVal, Fe zVal)
    {
      this.X = xVal ?? new Fe();
      this.Y = yVal ?? new Fe();
      this.Z = zVal ?? new Fe();
    }

    public GeJ Clone()
    {
      return new GeJ(this.X?.Clone(), this.Y?.Clone(), this.Z?.Clone());
    }
  }
}
