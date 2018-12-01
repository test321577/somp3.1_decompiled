// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.EcmultGenContext
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class EcmultGenContext
  {
    public GeStorage[][] Prec;
    public Scalar Blind;
    public GeJ Initial;

    public void PrecInit()
    {
      this.Prec = new GeStorage[64][];
      for (int index1 = 0; index1 < 64; ++index1)
      {
        this.Prec[index1] = new GeStorage[16];
        for (int index2 = 0; index2 < 16; ++index2)
          this.Prec[index1][index2] = new GeStorage();
      }
      this.Blind = new Scalar();
      this.Initial = new GeJ();
    }
  }
}
