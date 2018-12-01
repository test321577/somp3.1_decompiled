// Decompiled with JetBrains decompiler
// Type: PenisWallet.AbstractKeyProvider
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace PenisWallet
{
  public abstract class AbstractKeyProvider : IKeyProvider
  {
    public abstract Wallet GetNextKey();

    public Wallet[] GetNextKeys(int count)
    {
      Wallet[] walletArray = new Wallet[count];
      for (int index = 0; index < count; ++index)
        walletArray[index] = this.GetNextKey();
      return walletArray;
    }
  }
}
