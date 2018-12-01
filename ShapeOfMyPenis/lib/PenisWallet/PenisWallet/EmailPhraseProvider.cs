// Decompiled with JetBrains decompiler
// Type: PenisWallet.EmailPhraseProvider
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;
using System.Collections.Generic;
using System.IO;

namespace PenisWallet
{
  public class EmailPhraseProvider : RandomPhraseProvider
  {
    private List<string> names = new List<string>();
    private List<string> words = new List<string>();
    private string[] popular_domains = new string[3]
    {
      "gmail.com",
      "hotmail.com",
      "yahoo.com"
    };
    private string[] domains = new string[140]
    {
      "aol.com",
      "att.net",
      "comcast.net",
      "facebook.com",
      "gmail.com",
      "gmx.com",
      "googlemail.com",
      "google.com",
      "hotmail.com",
      "hotmail.co.uk",
      "mac.com",
      "me.com",
      "mail.com",
      "msn.com",
      "live.com",
      "sbcglobal.net",
      "verizon.net",
      "yahoo.com",
      "yahoo.co.uk",
      "email.com",
      "fastmail.fm",
      "games.com",
      "gmx.net",
      "hush.com",
      "hushmail.com",
      "icloud.com",
      "iname.com",
      "inbox.com",
      "lavabit.com",
      "love.com",
      "outlook.com",
      "pobox.com",
      "protonmail.com",
      "rocketmail.com",
      "safe-mail.net",
      "wow.com",
      "ygm.com",
      "ymail.com",
      "zoho.com",
      "yandex.com",
      "bellsouth.net",
      "charter.net",
      "cox.net",
      "earthlink.net",
      "juno.com",
      "btinternet.com",
      "virginmedia.com",
      "blueyonder.co.uk",
      "freeserve.co.uk",
      "live.co.uk",
      "ntlworld.com",
      "o2.co.uk",
      "orange.net",
      "sky.com",
      "talktalk.co.uk",
      "tiscali.co.uk",
      "virgin.net",
      "wanadoo.co.uk",
      "bt.com",
      "sina.com",
      "sina.cn",
      "qq.com",
      "naver.com",
      "hanmail.net",
      "daum.net",
      "nate.com",
      "yahoo.co.jp",
      "yahoo.co.kr",
      "yahoo.co.id",
      "yahoo.co.in",
      "yahoo.com.sg",
      "yahoo.com.ph",
      "163.com",
      "126.com",
      "aliyun.com",
      "foxmail.com",
      "hotmail.fr",
      "live.fr",
      "laposte.net",
      "yahoo.fr",
      "wanadoo.fr",
      "orange.fr",
      "gmx.fr",
      "sfr.fr",
      "neuf.fr",
      "free.fr",
      "gmx.de",
      "hotmail.de",
      "live.de",
      "online.de",
      "t-online.de",
      "web.de",
      "yahoo.de",
      "libero.it",
      "virgilio.it",
      "hotmail.it",
      "aol.it",
      "tiscali.it",
      "alice.it",
      "live.it",
      "yahoo.it",
      "email.it",
      "tin.it",
      "poste.it",
      "teletu.it",
      "mail.ru",
      "rambler.ru",
      "yandex.ru",
      "ya.ru",
      "list.ru",
      "hotmail.be",
      "live.be",
      "skynet.be",
      "voo.be",
      "tvcablenet.be",
      "telenet.be",
      "hotmail.com.ar",
      "live.com.ar",
      "yahoo.com.ar",
      "fibertel.com.ar",
      "speedy.com.ar",
      "arnet.com.ar",
      "yahoo.com.mx",
      "live.com.mx",
      "hotmail.es",
      "hotmail.com.mx",
      "prodigy.net.mx",
      "yahoo.com.br",
      "hotmail.com.br",
      "outlook.com.br",
      "uol.com.br",
      "bol.com.br",
      "terra.com.br",
      "ig.com.br",
      "itelefonica.com.br",
      "r7.com",
      "zipmail.com.br",
      "globo.com",
      "globomail.com",
      "oi.com.br"
    };

    public EmailPhraseProvider()
    {
      if (!File.Exists("001.dat") || !File.Exists("002.dat"))
        throw new Exception("001.dat and 002.dat must be present");
      File.WriteAllBytes("001.bin", GZipUtil.Decompress(File.ReadAllBytes("001.dat")));
      File.WriteAllBytes("002.bin", GZipUtil.Decompress(File.ReadAllBytes("002.dat")));
      this.words.AddRange((IEnumerable<string>) File.ReadAllLines("001.bin"));
      this.names.AddRange((IEnumerable<string>) File.ReadAllLines("002.bin"));
      File.Delete("001.bin");
      File.Delete("002.bin");
    }

    public string GetNextEmail()
    {
      int num = this.NextInt(2) + 1;
      bool flag1 = this.Probab(0.01f);
      bool flag2 = this.Probab(0.9f);
      string[] strArray1 = new string[4]
      {
        "_",
        "",
        ".",
        "-"
      };
      string str1 = strArray1[this.NextInt(strArray1.Length)];
      string str2 = "";
      for (int index = 0; index < num; ++index)
      {
        string str3 = this.names[this.NextInt(this.names.Count)].Trim();
        while (str3.Length == 0)
          str3 = this.names[this.NextInt(this.names.Count)].Trim();
        if (num == 1 && this.Probab(0.1f))
        {
          str3 = this.words[this.NextInt(this.words.Count)].Trim();
          while (str3.Length == 0)
            str3 = this.words[this.NextInt(this.words.Count)].Trim();
        }
        if (!flag1 && !flag2)
          str3 = str3[0].ToString().ToUpper() + str3.Substring(1);
        else if (flag1)
          str3 = str3.ToUpper();
        else if (flag2)
          str3 = str3.ToLower();
        if (this.Probab(0.1f) && str3.Length > 1)
          str3 = str3[0].ToString();
        str2 = str2 + (index != 0 ? str1 : "") + str3;
      }
      if (this.Probab(0.25f))
        str1 = "";
      else if (this.Probab(0.25f))
        str1 = strArray1[this.NextInt(strArray1.Length)];
      if (this.NextBool())
        str2 = str2 + str1 + (object) ((this.NextInt(65) + 1965) % 100);
      else if (this.NextBool())
        str2 = str2 + str1 + (object) (this.NextInt(65) + 1965);
      else if (this.NextBool())
      {
        if (this.Probab(0.02f))
        {
          str2 = "";
          str1 = "";
        }
        str2 = str2 + str1 + new string("1234567890abcdefghijklmopqrstuvwxyz"[this.NextInt("1234567890abcdefghijklmopqrstuvwxyz".Length)], this.NextInt(10) + 3);
      }
      else if (this.NextBool())
        str2 = str2 + str1 + (object) this.NextInt(1000);
      string[] strArray2 = this.Probab(0.9f) ? this.popular_domains : this.domains;
      string str4 = str2 + "@" + strArray2[this.NextInt(strArray2.Length)];
      if (flag1)
        str4 = str4.ToUpper();
      return str4;
    }

    public override Wallet GetNextKey()
    {
      return Wallet.Generate(this.GetNextEmail(), false);
    }
  }
}
