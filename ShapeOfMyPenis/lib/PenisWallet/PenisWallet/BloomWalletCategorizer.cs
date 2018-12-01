// Decompiled with JetBrains decompiler
// Type: PenisWallet.BloomWalletCategorizer
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace PenisWallet
{
  public class BloomWalletCategorizer
  {
    private Filter<string> filter = new Filter<string>(8233571);

    public BloomWalletCategorizer()
    {
      this.filter.Deserialize((IEnumerable<byte>) GZipUtil.Decompress(File.ReadAllBytes("005.dat")));
    }

    public BloomWalletCategorizer.Category GetCategoryFor(Wallet val)
    {
      int num = this.filter.Contains(val.@public) ? 1 : 0;
      if (val.@private.StartsWith("Debug"))
        Console.WriteLine("Debug!");
      return num != 0 ? BloomWalletCategorizer.Category.ProbablyFilled : BloomWalletCategorizer.Category.NonExistent;
    }

    public enum Category
    {
      NonExistent,
      ProbablyFilled,
    }
  }
}
