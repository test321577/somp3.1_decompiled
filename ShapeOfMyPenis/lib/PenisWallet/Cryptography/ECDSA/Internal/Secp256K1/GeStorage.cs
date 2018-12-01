// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.GeStorage
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class GeStorage
  {
    public FeStorage X;
    public FeStorage Y;

    public GeStorage()
    {
      this.X = new FeStorage();
      this.Y = new FeStorage();
    }
  }
}
