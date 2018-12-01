// Decompiled with JetBrains decompiler
// Type: PenisWallet.MockDataFetcher
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace PenisWallet
{
  internal class MockDataFetcher : IDataFetcher
  {
    private int iteration;

    public void FetchDataFor(Wallet[] keyPairs)
    {
      for (int index = 0; index < keyPairs.Length; ++index)
      {
        ++this.iteration;
        if (this.iteration % 100 == 13)
        {
          keyPairs[0].Balance = 10000.0;
          keyPairs[0].Received = 5000.0;
          keyPairs[0].Tx = 50.0;
          keyPairs[0].HasData = true;
        }
        else if (this.iteration % 100 == 34)
        {
          keyPairs[0].Balance = 0.0;
          keyPairs[0].Received = 2500.0;
          keyPairs[0].Tx = 25.0;
          keyPairs[0].HasData = true;
        }
        else if (this.iteration % 100 == 57)
        {
          keyPairs[0].Balance = 0.0;
          keyPairs[0].Received = 0.0546;
          keyPairs[0].Tx = 2.0;
          keyPairs[0].HasData = true;
        }
      }
    }
  }
}
