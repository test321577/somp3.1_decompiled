// Decompiled with JetBrains decompiler
// Type: PenisWallet.BtcComDataFetcher
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace PenisWallet
{
  public class BtcComDataFetcher : IDataFetcher
  {
    private void ProcessNode(JSONNode val, Dictionary<string, Wallet> dict)
    {
      if (val.IsNull)
        return;
      string index = val["address"].Value;
      double asDouble1 = val["balance"].AsDouble;
      double asDouble2 = val["tx_count"].AsDouble;
      double num = Math.Max((double) val["unconfirmed_received"].AsInt, val["received"].AsDouble);
      dict[index].Balance = asDouble1 / 100000.0;
      dict[index].Received = num / 100000.0;
      dict[index].Tx = asDouble2;
      dict[index].HasData = true;
    }

    public void FetchDataFor(Wallet[] wallets)
    {
      string address = "https://chain.api.btc.com/v3/address/";
      Dictionary<string, Wallet> dict = new Dictionary<string, Wallet>();
      for (int index = 0; index < wallets.Length; ++index)
      {
        Wallet wallet = wallets[index];
        if (wallet.@private.StartsWith("Debug"))
          Console.WriteLine("Will fetch debug addr");
        dict[wallet.@public] = wallet;
        address += wallet.@public;
        if (index != wallets.Length - 1)
          address += ",";
      }
      int num = 0;
      while (true)
      {
        try
        {
          JSONNode val1 = JSON.Parse(new WebClient().DownloadString(address))["data"];
          if (val1.IsNull)
            break;
          if (val1.IsArray)
          {
            foreach (JSONNode val2 in val1.Values)
              this.ProcessNode(val2, dict);
            break;
          }
          this.ProcessNode(val1, dict);
          break;
        }
        catch (Exception ex)
        {
          Console.WriteLine((object) ex);
          if (num++ >= 100)
            break;
          Thread.Sleep(100);
        }
      }
    }
  }
}
