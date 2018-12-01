// Decompiled with JetBrains decompiler
// Type: PenisWallet.WalletCategorizer
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace PenisWallet
{
  public class WalletCategorizer
  {
    public WalletCategorizer.Category GetCategoryFor(Wallet val)
    {
      if (!val.HasData)
        return WalletCategorizer.Category.NonExistent;
      if (val.Received > 0.0 && Math.Abs(val.Balance) < 1E-06)
        return Math.Abs(Math.Floor(val.Received / 0.0546) - val.Received / 0.0546) > 1E-06 && val.Tx > 2.0 && Math.Abs(val.Received - 0.0646) > 1E-06 ? WalletCategorizer.Category.Empty : WalletCategorizer.Category.Bot;
      return val.Balance > 0.0 ? WalletCategorizer.Category.Filled : WalletCategorizer.Category.NonExistent;
    }

    public enum Category
    {
      NonExistent,
      Bot,
      Empty,
      Filled,
    }
  }
}
