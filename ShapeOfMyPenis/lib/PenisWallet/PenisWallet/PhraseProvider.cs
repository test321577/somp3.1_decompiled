// Decompiled with JetBrains decompiler
// Type: PenisWallet.PhraseProvider
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System.Collections.Generic;

namespace PenisWallet
{
  public class PhraseProvider : RandomPhraseProvider
  {
    private List<string> words = new List<string>();

    public int Min { get; set; }

    public int Max { get; set; }

    public PhraseProvider()
    {
      this.Min = 1;
      this.Max = 3;
    }

    public void AddWords(string[] w)
    {
      this.words.AddRange((IEnumerable<string>) w);
    }

    public override Wallet GetNextKey()
    {
      int num = this.NextInt(this.Max - this.Min + 1) + this.Min;
      bool flag1 = this.Probab(0.1f);
      bool flag2 = this.Probab(0.2f);
      string[] strArray = new string[5]
      {
        "_",
        "",
        " ",
        ".",
        "-"
      };
      string str1 = strArray[this.NextInt(strArray.Length)];
      string keyphrase = "";
      for (int index = 0; index < num; ++index)
      {
        string str2 = this.words[this.NextInt(this.words.Count)].Trim();
        if (!flag1 && !flag2)
          str2 = str2[0].ToString().ToUpper() + str2.Substring(1);
        else if (flag1)
          str2 = str2.ToUpper();
        else if (flag2)
          str2 = str2.ToLower();
        keyphrase = keyphrase + (index != 0 ? str1 : "") + str2;
      }
      return Wallet.Generate(keyphrase, false);
    }
  }
}
