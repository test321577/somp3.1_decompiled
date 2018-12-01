// Decompiled with JetBrains decompiler
// Type: ShapeOfMyPenis.Searcher
// Assembly: ShapeOfMyPenis, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21A59ED2-F9B1-44BA-B5E7-59F320D41A1B
// Assembly location: C:\Users\1\Desktop\somp3\ShapeOfMyPenis.exe

using PenisWallet;
using System.Collections.Generic;

namespace ShapeOfMyPenis
{
  public class Searcher
  {
    private TimeMeasurer timer = new TimeMeasurer();
    private IDataFetcher fetcher = (IDataFetcher) new BtcComDataFetcher();
    private WalletCategorizer categorizer = new WalletCategorizer();
    private BloomWalletCategorizer offlineCategorizer = new BloomWalletCategorizer();
    private HashSet<string> hfound = new HashSet<string>();
    public Wallet[] SearchList = new Wallet[21];
    public List<Wallet> falsePositive = new List<Wallet>();
    public bool offline;
    public const int max = 350;
    public int searches;
    public int found;
    public int bots;
    public int green;
    private long speedfix;
    private Wallet last;
    private int searchListIndex;
    private int freeSpin;

    public string Searches
    {
      get
      {
        return string.Concat((object) (this.searches * 350));
      }
    }

    public string Speed
    {
      get
      {
        return ((double) (350L * ((long) this.searches - this.speedfix)) / this.timer.GetSeconds()).ToString("n2") + " address/sec";
      }
    }

    public string Time
    {
      get
      {
        return this.timer.GetElapsed();
      }
    }

    public Wallet Last
    {
      get
      {
        return this.last;
      }
    }

    public void ResetTime()
    {
      this.timer.Reset();
      this.timer.Play();
      this.speedfix = (long) this.searches;
    }

    public void Search(AbstractKeyProvider provider)
    {
      ++this.searches;
      this.timer.Play();
      Wallet[] nextKeys = provider.GetNextKeys(350);
      if (!this.offline)
        this.fetcher.FetchDataFor(nextKeys);
      foreach (Wallet val1 in nextKeys)
      {
        lock (this)
        {
          if (this.searchListIndex >= this.SearchList.Length)
            this.searchListIndex = 0;
          this.SearchList[this.searchListIndex] = val1;
          ++this.searchListIndex;
          if (this.searchListIndex >= this.SearchList.Length)
            this.searchListIndex = 0;
        }
        WalletCategorizer.Category category = WalletCategorizer.Category.NonExistent;
        if (!this.offline)
          category = this.categorizer.GetCategoryFor(val1);
        else if (this.offlineCategorizer.GetCategoryFor(val1) == BloomWalletCategorizer.Category.ProbablyFilled || this.falsePositive.Count > 0 && this.freeSpin++ > 10000)
        {
          lock (this)
          {
            this.falsePositive.Add(val1);
            if (this.falsePositive.Count < 32)
            {
              if (this.freeSpin <= 10000)
                goto label_30;
            }
            this.freeSpin = 0;
            Wallet[] array = this.falsePositive.ToArray();
            this.fetcher.FetchDataFor(array);
            foreach (Wallet val2 in array)
            {
              if (this.categorizer.GetCategoryFor(val2) == WalletCategorizer.Category.Filled)
              {
                lock (this)
                {
                  val2.StoreToFile("green.txt");
                  ++this.green;
                  this.last = val2;
                }
              }
            }
            this.falsePositive.Clear();
          }
        }
label_30:
        switch (category)
        {
          case WalletCategorizer.Category.Bot:
            lock (this)
            {
              val1.StoreToFile("bots.txt");
              ++this.bots;
              break;
            }
          case WalletCategorizer.Category.Empty:
            if (!this.hfound.Contains(val1.@public))
            {
              val1.StoreToFile("yellow.txt");
              ++this.found;
              this.last = val1;
              this.hfound.Add(val1.@public);
              break;
            }
            break;
          case WalletCategorizer.Category.Filled:
            lock (this)
            {
              val1.StoreToFile("green.txt");
              ++this.green;
              this.last = val1;
              break;
            }
        }
      }
      this.timer.Pause();
    }
  }
}
