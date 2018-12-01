// Decompiled with JetBrains decompiler
// Type: PenisWallet.SoMPKeyProvider
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System.Security.Cryptography;

namespace PenisWallet
{
  public class SoMPKeyProvider : AbstractKeyProvider
  {
    private RandomNumberGenerator rg = RandomNumberGenerator.Create();

    public override Wallet GetNextKey()
    {
      byte[] data = new byte[1];
      this.rg.GetBytes(data);
      if (data[0] > (byte) 127 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        return Wallet.Generate(false);
      string randomPass = PassPhraseGen.GetRandomPass();
      if (randomPass != null)
        return Wallet.Generate(randomPass.Trim(), false);
      return Wallet.Generate(true);
    }
  }
}
