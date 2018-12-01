// Decompiled with JetBrains decompiler
// Type: PenisWallet.PassPhraseGen
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using Cryptography.ECDSA;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PenisWallet
{
  public class PassPhraseGen
  {
    public static PassPhraseGen.Config config = PassPhraseGen.Config.Classic;
    public static Random rand = new Random(Hex.ToString(Secp256K1Manager.GenerateRandomKey()).GetHashCode());
    private static string[] bigram = new string[669]
    {
      "th",
      "he",
      "in",
      "er",
      "an",
      "re",
      "on",
      "at",
      "en",
      "nd",
      "ti",
      "es",
      "or",
      "te",
      "of",
      "ed",
      "is",
      "it",
      "al",
      "ar",
      "st",
      "to",
      "nt",
      "ng",
      "se",
      "ha",
      "as",
      "ou",
      "io",
      "le",
      "ve",
      "co",
      "me",
      "de",
      "hi",
      "ri",
      "ro",
      "ic",
      "ne",
      "ea",
      "ra",
      "ce",
      "li",
      "ch",
      "ll",
      "be",
      "ma",
      "si",
      "om",
      "ur",
      "ca",
      "el",
      "ta",
      "la",
      "ns",
      "di",
      "fo",
      "ho",
      "pe",
      "ec",
      "pr",
      "no",
      "ct",
      "us",
      "ac",
      "ot",
      "il",
      "tr",
      "ly",
      "nc",
      "et",
      "ut",
      "ss",
      "so",
      "rs",
      "un",
      "lo",
      "wa",
      "ge",
      "ie",
      "wh",
      "ee",
      "wi",
      "em",
      "ad",
      "ol",
      "rt",
      "po",
      "we",
      "na",
      "ul",
      "ni",
      "ts",
      "mo",
      "ow",
      "pa",
      "im",
      "mi",
      "ai",
      "sh",
      "ir",
      "su",
      "id",
      "os",
      "iv",
      "ia",
      "am",
      "fi",
      "ci",
      "vi",
      "pl",
      "ig",
      "tu",
      "ev",
      "ld",
      "ry",
      "mp",
      "fe",
      "bl",
      "ab",
      "gh",
      "ty",
      "op",
      "wo",
      "sa",
      "ay",
      "ex",
      "ke",
      "fr",
      "oo",
      "av",
      "ag",
      "if",
      "ap",
      "gr",
      "od",
      "bo",
      "sp",
      "rd",
      "do",
      "uc",
      "bu",
      "ei",
      "ov",
      "by",
      "rm",
      "ep",
      "tt",
      "oc",
      "fa",
      "ef",
      "cu",
      "rn",
      "sc",
      "gi",
      "da",
      "yo",
      "cr",
      "cl",
      "du",
      "ga",
      "qu",
      "ue",
      "ff",
      "ba",
      "ey",
      "ls",
      "va",
      "um",
      "pp",
      "ua",
      "up",
      "lu",
      "go",
      "ht",
      "ru",
      "ug",
      "ds",
      "lt",
      "pi",
      "rc",
      "rr",
      "eg",
      "au",
      "ck",
      "ew",
      "mu",
      "br",
      "bi",
      "pt",
      "ak",
      "pu",
      "ui",
      "rg",
      "ib",
      "tl",
      "ny",
      "ki",
      "rk",
      "ys",
      "ob",
      "mm",
      "fu",
      "ph",
      "og",
      "ms",
      "ye",
      "ud",
      "mb",
      "ip",
      "ub",
      "oi",
      "rl",
      "gu",
      "dr",
      "hr",
      "cc",
      "tw",
      "ft",
      "wn",
      "nu",
      "af",
      "hu",
      "nn",
      "eo",
      "vo",
      "rv",
      "nf",
      "xp",
      "gn",
      "sm",
      "fl",
      "iz",
      "ok",
      "nl",
      "my",
      "gl",
      "aw",
      "ju",
      "oa",
      "eq",
      "sy",
      "sl",
      "ps",
      "jo",
      "lf",
      "nv",
      "je",
      "nk",
      "kn",
      "gs",
      "dy",
      "hy",
      "ze",
      "ks",
      "xt",
      "bs",
      "ik",
      "dd",
      "cy",
      "rp",
      "sk",
      "xi",
      "oe",
      "oy",
      "ws",
      "lv",
      "dl",
      "rf",
      "eu",
      "dg",
      "wr",
      "xa",
      "yi",
      "nm",
      "eb",
      "rb",
      "tm",
      "xc",
      "eh",
      "tc",
      "gy",
      "ja",
      "hn",
      "yp",
      "za",
      "gg",
      "ym",
      "sw",
      "bj",
      "lm",
      "cs",
      "ii",
      "ix",
      "xe",
      "oh",
      "lk",
      "dv",
      "lp",
      "ax",
      "ox",
      "uf",
      "dm",
      "iu",
      "sf",
      "bt",
      "ka",
      "yt",
      "ek",
      "pm",
      "ya",
      "gt",
      "wl",
      "rh",
      "yl",
      "hs",
      "ah",
      "yc",
      "yn",
      "rw",
      "hm",
      "lw",
      "hl",
      "ae",
      "zi",
      "az",
      "lc",
      "py",
      "aj",
      "iq",
      "nj",
      "bb",
      "nh",
      "uo",
      "kl",
      "lr",
      "tn",
      "gm",
      "sn",
      "nr",
      "fy",
      "mn",
      "dw",
      "sb",
      "yr",
      "dn",
      "sq",
      "zo",
      "oj",
      "yd",
      "lb",
      "wt",
      "lg",
      "ko",
      "np",
      "sr",
      "nq",
      "ky",
      "ln",
      "nw",
      "tf",
      "fs",
      "cq",
      "dh",
      "sd",
      "vy",
      "dj",
      "hw",
      "xu",
      "ao",
      "ml",
      "uk",
      "uy",
      "ej",
      "ez",
      "hb",
      "nz",
      "nb",
      "mc",
      "yb",
      "tp",
      "xh",
      "ux",
      "tz",
      "bv",
      "mf",
      "wd",
      "oz",
      "yw",
      "kh",
      "gd",
      "bm",
      "mr",
      "ku",
      "uv",
      "dt",
      "hd",
      "aa",
      "xx",
      "df",
      "db",
      "ji",
      "kr",
      "xo",
      "cm",
      "zz",
      "nx",
      "yg",
      "xy",
      "kg",
      "tb",
      "dc",
      "bd",
      "sg",
      "wy",
      "zy",
      "aq",
      "hf",
      "cd",
      "vu",
      "kw",
      "zu",
      "bn",
      "ih",
      "tg",
      "xv",
      "uz",
      "bc",
      "xf",
      "yz",
      "km",
      "dp",
      "lh",
      "wf",
      "kf",
      "pf",
      "cf",
      "mt",
      "yu",
      "cp",
      "pb",
      "td",
      "zl",
      "sv",
      "hc",
      "mg",
      "pw",
      "gf",
      "pd",
      "pn",
      "pc",
      "rx",
      "tv",
      "ij",
      "wm",
      "uh",
      "wk",
      "wb",
      "bh",
      "oq",
      "kt",
      "rq",
      "kb",
      "cg",
      "vr",
      "cn",
      "pk",
      "uu",
      "yf",
      "wp",
      "cz",
      "kp",
      "dq",
      "wu",
      "fm",
      "wc",
      "md",
      "kd",
      "zh",
      "gw",
      "rz",
      "cb",
      "iw",
      "xl",
      "hp",
      "mw",
      "vs",
      "fc",
      "rj",
      "bp",
      "mh",
      "hh",
      "yh",
      "uj",
      "fg",
      "fd",
      "gb",
      "pg",
      "tk",
      "kk",
      "hq",
      "fn",
      "lz",
      "vl",
      "gp",
      "hz",
      "dk",
      "yk",
      "qi",
      "lx",
      "vd",
      "zs",
      "bw",
      "xq",
      "mv",
      "uw",
      "hg",
      "fb",
      "sj",
      "ww",
      "gk",
      "uq",
      "bg",
      "sz",
      "jr",
      "ql",
      "zt",
      "hk",
      "vc",
      "xm",
      "gc",
      "fw",
      "pz",
      "kc",
      "hv",
      "xw",
      "zw",
      "fp",
      "iy",
      "pv",
      "vt",
      "jp",
      "cv",
      "zb",
      "vp",
      "zr",
      "fh",
      "yv",
      "zg",
      "zm",
      "zv",
      "qs",
      "kv",
      "vn",
      "zn",
      "qa",
      "yx",
      "jn",
      "bf",
      "mk",
      "cw",
      "jm",
      "lq",
      "jh",
      "kj",
      "jc",
      "gz",
      "js",
      "tx",
      "fk",
      "jl",
      "vm",
      "lj",
      "tj",
      "jj",
      "cj",
      "vg",
      "mj",
      "jt",
      "pj",
      "wg",
      "vh",
      "bk",
      "vv",
      "jd",
      "tq",
      "vb",
      "jf",
      "dz",
      "xb",
      "jb",
      "zc",
      "fj",
      "yy",
      "qn",
      "xs",
      "qr",
      "jk",
      "jv",
      "qq",
      "xn",
      "vf",
      "px",
      "zd",
      "qt",
      "zp",
      "qo",
      "dx",
      "hj",
      "gv",
      "jw",
      "qc",
      "jy",
      "gj",
      "qb",
      "pq",
      "jg",
      "bz",
      "mx",
      "qm",
      "mz",
      "qf",
      "wj",
      "zq",
      "xr",
      "zk",
      "cx",
      "fx",
      "fv",
      "bx",
      "vw",
      "vj",
      "mq",
      "qv",
      "zf",
      "qe",
      "yj",
      "gx",
      "kx",
      "xg",
      "qd",
      "xj",
      "sx",
      "vz",
      "vx",
      "wv",
      "yq",
      "bq",
      "gq",
      "vk",
      "zj",
      "xk",
      "qp",
      "hx",
      "fz",
      "qh",
      "qj",
      "jz",
      "vq",
      "kq",
      "xd",
      "qw",
      "jx",
      "qx",
      "kz",
      "wx",
      "fq",
      "xz",
      "zx"
    };
    private static int counter = 0;
    public static EmailPhraseProvider emails = new EmailPhraseProvider();
    public static string[] words;
    public static string[] names;
    public static string[] culture;

    static PassPhraseGen()
    {
      if (PassPhraseGen.words != null)
        return;
      File.WriteAllBytes("001.bin", GZipUtil.Decompress(File.ReadAllBytes("001.dat")));
      File.WriteAllBytes("002.bin", GZipUtil.Decompress(File.ReadAllBytes("002.dat")));
      File.WriteAllBytes("003.bin", GZipUtil.Decompress(File.ReadAllBytes("003.dat")));
      PassPhraseGen.words = File.ReadAllLines("001.bin");
      PassPhraseGen.names = File.ReadAllLines("002.bin");
      PassPhraseGen.culture = File.ReadAllLines("003.bin");
      File.Delete("001.bin");
      File.Delete("002.bin");
      File.Delete("003.bin");
    }

    private static string GetCulturePass()
    {
      bool flag1 = PassPhraseGen.rand.Next(100) > 50;
      int num1 = PassPhraseGen.rand.Next(100) > 90 ? 1 : 0;
      int num2 = PassPhraseGen.rand.Next(100) > 95 ? 1 : 0;
      int num3 = PassPhraseGen.rand.Next(100) > 75 ? 1 : 0;
      bool flag2 = PassPhraseGen.rand.Next(100) > 90;
      bool flag3 = PassPhraseGen.rand.Next(100) > 50;
      bool flag4 = PassPhraseGen.rand.Next(100) > 50;
      string s = PassPhraseGen.culture[PassPhraseGen.rand.Next(PassPhraseGen.culture.Length)].Trim();
      if (num3 != 0)
        s = s.ToLower();
      if (num2 != 0)
        s = s.ToUpper();
      if (num1 == 0 & flag1)
        s = s.Replace(" ", "");
      if (num1 != 0)
        s = s.Replace(" ", PassPhraseGen.rand.Next(100) > 50 ? "_" : "-");
      if (flag2 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        s = !flag3 ? (!flag4 ? Hex.ToString(Encoding.UTF8.GetBytes(s)) : Hex.ToString(Sha256Manager.GetHash(Sha256Manager.GetHash(Encoding.UTF8.GetBytes(s))))) : Hex.ToString(Sha256Manager.GetHash(Encoding.UTF8.GetBytes(s)));
      return s;
    }

    private static string GetGibberishPass()
    {
      int num1 = 3 + PassPhraseGen.rand.Next(5) + (PassPhraseGen.rand.Next(100) > 75 ? PassPhraseGen.rand.Next(5) : 0);
      string str1 = "";
      char ch1 = "eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890"[PassPhraseGen.rand.Next("eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890".Length)];
      string str2 = str1 + ch1.ToString();
      for (int index1 = 1; index1 < num1; ++index1)
      {
        if (PassPhraseGen.rand.Next(100) > 15)
        {
          float length = (float) PassPhraseGen.bigram.Length;
          float num2 = (float) PassPhraseGen.rand.NextDouble();
          if (PassPhraseGen.rand.Next(100) > 25)
            num2 /= 2f;
          if (PassPhraseGen.rand.Next(100) > 25)
            num2 /= 2f;
          if (PassPhraseGen.rand.Next(100) > 25)
            num2 /= 2f;
          if (PassPhraseGen.rand.Next(100) > 25)
            num2 /= 2f;
          int index2 = (int) Math.Floor((double) num2 * (double) length);
          string str3 = PassPhraseGen.bigram[index2];
          ch1 = str3[1];
          str2 += str3;
        }
        else
        {
          char ch2 = "eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890"[PassPhraseGen.rand.Next("eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890".Length)];
          if ("1234567890".Contains<char>(ch2))
            ch2 = "eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890"[PassPhraseGen.rand.Next("eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890".Length)];
          if ("aeiou".Contains<char>(ch2) && "aeiou".Contains<char>(ch1))
            ch2 = "eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890"[PassPhraseGen.rand.Next("eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890".Length)];
          else if (!"aeiou".Contains<char>(ch2) && !"aeiou".Contains<char>(ch1))
            ch2 = "eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890"[PassPhraseGen.rand.Next("eeeeeeeeeeeetttttttttaaaaaaaaoooooooiiiiiiinnnnnnnssssssrrrrrrhhhhhhddddlllluuucccmmmffyywwggppbbvkxqjz1234567890".Length)];
          str2 += ch2.ToString();
          ch1 = ch2;
        }
      }
      return str2;
    }

    private static string GetEmailPass()
    {
      string[] strArray1 = new string[8]
      {
        "@gmail.com",
        "@gmail.com",
        "@gmail.com",
        "@gmail.com",
        "@gmail.com",
        "@yahoo.com",
        "@yahoo.com",
        "@ymail.com"
      };
      if (PassPhraseGen.rand.Next(1000) > 990)
      {
        if (PassPhraseGen.rand.Next(100) > 95)
          return new string(PassPhraseGen.rand.Next(10).ToString()[0], PassPhraseGen.rand.Next(1, 16)) + strArray1[PassPhraseGen.rand.Next(strArray1.Length)];
        return PassPhraseGen.rand.Next(1073741824).ToString() + strArray1[PassPhraseGen.rand.Next(strArray1.Length)];
      }
      string[] strArray2 = new string[3]{ "-", ".", "_" };
      string str1 = strArray2[PassPhraseGen.rand.Next(strArray2.Length)];
      string str2 = PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)];
      if (PassPhraseGen.rand.Next(100) > 50)
      {
        str2 = str2 + str1 + PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)];
        if (PassPhraseGen.rand.Next(100) > 50)
          str2 = PassPhraseGen.rand.Next(100) <= 50 ? (PassPhraseGen.rand.Next(100) <= 50 ? str2 + str1 + (object) PassPhraseGen.rand.Next(1000) : str2 + str1 + (object) (PassPhraseGen.rand.Next(66) + 1966)) : str2 + str1 + (object) ((PassPhraseGen.rand.Next(66) + 66) % 100);
      }
      else
      {
        if (PassPhraseGen.rand.Next(100) > 50)
          str1 = "";
        if (PassPhraseGen.rand.Next(100) > 50)
          str2 = PassPhraseGen.rand.Next(100) <= 50 ? (PassPhraseGen.rand.Next(100) <= 50 ? str2 + str1 + (object) PassPhraseGen.rand.Next(1000) : str2 + str1 + (object) (PassPhraseGen.rand.Next(66) + 1966)) : str2 + str1 + (object) ((PassPhraseGen.rand.Next(66) + 66) % 100);
      }
      string str3 = str2 + strArray1[PassPhraseGen.rand.Next(strArray1.Length)];
      if (PassPhraseGen.rand.Next(100) > 20)
        str3 = str3.ToLower();
      if (PassPhraseGen.rand.Next(100) > 95)
        str3 = str3.ToUpper();
      return str3;
    }

    private static string GetNamePass()
    {
      int num1 = PassPhraseGen.rand.Next(100) > 50 ? 1 : 2;
      int num2 = PassPhraseGen.rand.Next(3);
      string[] strArray = new string[11]
      {
        " ",
        "",
        "_",
        "-",
        "",
        "_",
        "-",
        "",
        "_",
        "",
        "_"
      };
      string str = (2018 - PassPhraseGen.rand.Next(50)).ToString();
      if (str.Length > 0 && PassPhraseGen.rand.Next(100) > 50)
        str = str.Substring(2);
      if (str.Length > 0 && PassPhraseGen.rand.Next(100) > 75)
        str = "_" + str;
      if (PassPhraseGen.rand.Next(100) > 75)
        str = str.Replace("_", "-");
      if (num2 == 0 && PassPhraseGen.rand.Next(100) > 20)
        num2 = PassPhraseGen.rand.Next(2) + 1;
      switch (num2)
      {
        case 0:
          if (num1 == 2)
            return (PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)] + strArray[PassPhraseGen.rand.Next(strArray.Length)] + PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)]).ToUpper() + str;
          return PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)].ToUpper() + str;
        case 1:
          if (num1 == 2)
            return (PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)] + strArray[PassPhraseGen.rand.Next(strArray.Length)] + PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)]).ToLower() + str;
          return PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)].ToLower() + str;
        case 2:
          if (num1 == 2)
            return PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)] + strArray[PassPhraseGen.rand.Next(strArray.Length)] + PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)] + str;
          return PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)] + str;
        default:
          return "";
      }
    }

    private static string GetAlphaNumPass()
    {
      string str1 = "";
      int num = PassPhraseGen.rand.Next(7) + 1;
      string[] strArray = new string[10]
      {
        "One",
        "Two",
        "Three",
        "Four",
        "Five",
        "Six",
        "Seven",
        "Eight",
        "Nine",
        "Zero"
      };
      for (int index = 0; index < num; ++index)
        str1 = str1 + strArray[PassPhraseGen.rand.Next(strArray.Length)] + " ";
      string str2 = str1.Trim();
      if (PassPhraseGen.rand.Next(100) > 25)
        str2 = str2.Replace(" ", "");
      if (PassPhraseGen.rand.Next(100) > 75)
        str2 = str2.ToLower();
      if (PassPhraseGen.rand.Next(100) > 90)
        str2 = str2.ToUpper();
      return str2;
    }

    private static string GetRepetitionPass()
    {
      string str1 = PassPhraseGen.rand.Next(100) > 25 ? PassPhraseGen.words[PassPhraseGen.rand.Next(PassPhraseGen.words.Length)] : PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)];
      string str2 = str1[0].ToString().ToUpper() + str1.Substring(1).ToLower();
      int num = PassPhraseGen.rand.Next(2, 12);
      if (PassPhraseGen.rand.Next(100) > 50 && num > 4)
        num /= 2;
      string[] strArray = new string[5]
      {
        " ",
        "",
        "-",
        "_",
        "."
      };
      string str3 = strArray[PassPhraseGen.rand.Next(strArray.Length)];
      string str4 = "";
      for (int index = 0; index < num; ++index)
        str4 = str4 + str2 + (index == num - 1 ? "" : str3);
      string str5 = str4.Trim();
      if (PassPhraseGen.rand.Next(100) > 90)
        str5 = str5.ToUpper();
      if (PassPhraseGen.rand.Next(100) > 80)
        str5 = str5.ToLower();
      return str5;
    }

    private static string GetUnderscoringPass()
    {
      string str1 = PassPhraseGen.rand.Next(100) > 25 ? PassPhraseGen.words[PassPhraseGen.rand.Next(PassPhraseGen.words.Length)] : PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)];
      char ch = str1[0];
      string str2 = ch.ToString().ToUpper() + str1.Substring(1).ToLower();
      string str3 = "";
      for (int index = 0; index < str2.Length; ++index)
      {
        string str4 = str3;
        ch = str2[index];
        string str5 = ch.ToString();
        string str6 = "_";
        str3 = str4 + str5 + str6;
      }
      if (PassPhraseGen.rand.Next(100) > 50)
        str3 = str3.ToUpper();
      if (PassPhraseGen.rand.Next(100) > 50)
        str3 = str3.ToLower();
      if (PassPhraseGen.rand.Next(100) > 80)
        str3 = str3.Replace("_", "-");
      else if (PassPhraseGen.rand.Next(100) > 80)
        str3 = str3.Replace("_", " ");
      else if (PassPhraseGen.rand.Next(100) > 80)
        str3 = str3.Replace("_", ".");
      return str3.TrimEnd('_', ' ', '-', '.');
    }

    private static string GetProlongationPass()
    {
      string str1 = PassPhraseGen.rand.Next(100) > 25 ? PassPhraseGen.words[PassPhraseGen.rand.Next(PassPhraseGen.words.Length)] : PassPhraseGen.names[PassPhraseGen.rand.Next(PassPhraseGen.names.Length)];
      string str2 = str1[0].ToString().ToUpper() + str1.Substring(1).ToLower();
      int count = PassPhraseGen.rand.Next(2, 12);
      if (PassPhraseGen.rand.Next(100) > 50 && count > 4)
        count /= 2;
      string str3 = "";
      for (int index = 0; index < str2.Length; ++index)
        str3 += new string(str2[index], count);
      if (PassPhraseGen.rand.Next(100) > 50)
        str3 = str3.ToUpper();
      if (PassPhraseGen.rand.Next(100) > 50)
        str3 = str3.ToLower();
      return str3;
    }

    private static string GetPhonePass()
    {
      string str1 = "+DF (ABC) WER-TY-UI";
      if (PassPhraseGen.rand.Next(100) > 80)
        str1 = "WER-TY-UI";
      if (PassPhraseGen.rand.Next(100) > 80)
        str1 = "(ABC) WER-TY-UI";
      if (PassPhraseGen.rand.Next(100) > 90)
        str1 = str1.Replace("WER-TY-UI", "WE-RT-YUI");
      else if (PassPhraseGen.rand.Next(100) > 95)
        str1 = str1.Replace("WER-TY-UI", "WE-RTY-UI");
      if (PassPhraseGen.rand.Next(100) > 80)
        str1 = str1.Replace("+DF", "+1");
      if (PassPhraseGen.rand.Next(100) > 70)
        str1 = str1.Replace("A", "2");
      if (PassPhraseGen.rand.Next(100) > 90)
        str1 = str1.Replace("WER", "555");
      string str2 = str1;
      string oldValue1 = "W";
      int num = PassPhraseGen.rand.Next(10);
      string newValue1 = num.ToString();
      string str3 = str2.Replace(oldValue1, newValue1);
      string oldValue2 = "E";
      num = PassPhraseGen.rand.Next(10);
      string newValue2 = num.ToString();
      string str4 = str3.Replace(oldValue2, newValue2);
      string oldValue3 = "R";
      num = PassPhraseGen.rand.Next(10);
      string newValue3 = num.ToString();
      string str5 = str4.Replace(oldValue3, newValue3);
      string oldValue4 = "T";
      num = PassPhraseGen.rand.Next(10);
      string newValue4 = num.ToString();
      string str6 = str5.Replace(oldValue4, newValue4);
      string oldValue5 = "Y";
      num = PassPhraseGen.rand.Next(10);
      string newValue5 = num.ToString();
      string str7 = str6.Replace(oldValue5, newValue5);
      string oldValue6 = "U";
      num = PassPhraseGen.rand.Next(10);
      string newValue6 = num.ToString();
      string str8 = str7.Replace(oldValue6, newValue6);
      string oldValue7 = "I";
      num = PassPhraseGen.rand.Next(10);
      string newValue7 = num.ToString();
      string str9 = str8.Replace(oldValue7, newValue7);
      string oldValue8 = "A";
      num = PassPhraseGen.rand.Next(10);
      string newValue8 = num.ToString();
      string str10 = str9.Replace(oldValue8, newValue8);
      string oldValue9 = "B";
      num = PassPhraseGen.rand.Next(10);
      string newValue9 = num.ToString();
      string str11 = str10.Replace(oldValue9, newValue9);
      string oldValue10 = "C";
      num = PassPhraseGen.rand.Next(10);
      string newValue10 = num.ToString();
      string str12 = str11.Replace(oldValue10, newValue10);
      string oldValue11 = "D";
      num = PassPhraseGen.rand.Next(9) + 1;
      string newValue11 = num.ToString();
      string str13 = str12.Replace(oldValue11, newValue11);
      string oldValue12 = "F";
      string newValue12;
      if (PassPhraseGen.rand.Next(100) <= 50)
      {
        num = PassPhraseGen.rand.Next(10);
        newValue12 = num.ToString();
      }
      else
        newValue12 = "";
      string str14 = str13.Replace(oldValue12, newValue12).Replace("+", PassPhraseGen.rand.Next(100) > 90 ? "" : "+");
      if (PassPhraseGen.rand.Next(100) > 50)
        str14 = str14.Replace("-", PassPhraseGen.rand.Next(100) > 50 ? " " : "");
      if (PassPhraseGen.rand.Next(100) > 75)
        str14 = str14.Replace(" ", "");
      if (PassPhraseGen.rand.Next(100) > 75)
        str14 = str14.Replace("(", "").Replace(")", "");
      return str14;
    }

    private static string ConvertL337(string pass)
    {
      string source = "abcdefghijklmnopqrstuvwxyz";
      string str1 = "@8cd3f9h1jklmn0pqr57uvwxy2";
      string str2 = "";
      char ch;
      for (int index1 = 0; index1 < pass.Length; ++index1)
      {
        if (source.Contains<char>(pass[index1]))
        {
          int index2 = source.IndexOf(pass[index1]);
          string str3 = str2;
          ch = str1[index2];
          string str4 = ch.ToString();
          str2 = str3 + str4;
        }
        else
        {
          string str3 = str2;
          ch = pass[index1];
          string str4 = ch.ToString();
          str2 = str3 + str4;
        }
      }
      return str2;
    }

    public static string GetRandomPass()
    {
      if (PassPhraseGen.config == PassPhraseGen.Config.TrueRandom)
        return (string) null;
      if (PassPhraseGen.rand.Next(1000) > 900 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        PassPhraseGen.emails.GetNextEmail();
      string randomPassBase = PassPhraseGen.GetRandomPassBase();
      if (PassPhraseGen.rand.Next(1000) > 990 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        return PassPhraseGen.ConvertL337(randomPassBase);
      if (PassPhraseGen.rand.Next(1000) > 990 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        return new string(randomPassBase.Reverse<char>().ToArray<char>());
      return randomPassBase;
    }

    private static string GetRandomPassBase()
    {
      ++PassPhraseGen.counter;
      if (PassPhraseGen.counter % 5000 == 0)
      {
        int num1 = Hex.ToString(Sha256Manager.GetHash(Secp256K1Manager.GenerateRandomKey())).GetHashCode() + DateTime.UtcNow.Millisecond;
        DateTime utcNow = DateTime.UtcNow;
        int second = utcNow.Second;
        int num2 = num1 + second;
        utcNow = DateTime.UtcNow;
        int minute = utcNow.Minute;
        PassPhraseGen.rand = new Random(num2 + minute);
      }
      if (PassPhraseGen.rand.Next(1000) > 970 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        return PassPhraseGen.GetUnderscoringPass();
      if (PassPhraseGen.rand.Next(1000) > 990 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        return PassPhraseGen.GetRepetitionPass();
      if (PassPhraseGen.rand.Next(1000) > 975 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        return PassPhraseGen.GetPhonePass();
      if (PassPhraseGen.rand.Next(1000) > 985 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        return PassPhraseGen.GetAlphaNumPass();
      if (PassPhraseGen.rand.Next(1000) > 950 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
      {
        if (PassPhraseGen.rand.Next(1000) > 900)
          return new string("!@#$%^&*()_=+-[]\\/{},.<>~`'\"abcdefghijlkmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890"[PassPhraseGen.rand.Next("!@#$%^&*()_=+-[]\\/{},.<>~`'\"abcdefghijlkmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890".Length)], PassPhraseGen.rand.Next(1, 100));
        return string.Concat((object) PassPhraseGen.rand.Next(20183131));
      }
      if (PassPhraseGen.rand.Next(1000) > 980 && PassPhraseGen.config != PassPhraseGen.Config.AllBots)
        return PassPhraseGen.GetProlongationPass();
      if ((PassPhraseGen.config == PassPhraseGen.Config.Classic || PassPhraseGen.config == PassPhraseGen.Config.AllBots) && PassPhraseGen.rand.Next(1000) > 980)
        return PassPhraseGen.GetCulturePass();
      if ((PassPhraseGen.config == PassPhraseGen.Config.Classic || PassPhraseGen.config == PassPhraseGen.Config.UniquePhrases) && PassPhraseGen.rand.Next(1000) > 800)
        return PassPhraseGen.GetNamePass();
      int length = PassPhraseGen.rand.Next(1, 60) / 5;
      if (length == 0)
        length = 1;
      if (PassPhraseGen.rand.Next(100) > 20 && length > 2)
        length = 2;
      if (PassPhraseGen.rand.Next(100) > 20 && length > 3)
        length = 3;
      if (PassPhraseGen.rand.Next(100) > 80)
        length = 1;
      if (PassPhraseGen.config != PassPhraseGen.Config.AllBots && PassPhraseGen.config != PassPhraseGen.Config.Classic && length < 2)
        length = 2;
      if (PassPhraseGen.config == PassPhraseGen.Config.AllBots)
        length = 1;
      bool flag1 = PassPhraseGen.rand.Next(100) > 50;
      bool flag2 = PassPhraseGen.rand.Next(100) > 95;
      bool flag3 = PassPhraseGen.rand.Next(100) > 75;
      bool flag4 = PassPhraseGen.rand.Next(100) > 90;
      bool flag5 = PassPhraseGen.rand.Next(100) > 50;
      bool flag6 = PassPhraseGen.rand.Next(100) > 50;
      bool flag7 = PassPhraseGen.rand.Next(100) > 95;
      string[] strArray = new string[length];
      for (int index = 0; index < length; ++index)
      {
        strArray[index] = PassPhraseGen.rand.Next(100) <= 85 || PassPhraseGen.config == PassPhraseGen.Config.AllBots ? PassPhraseGen.words[PassPhraseGen.rand.Next(PassPhraseGen.words.Length)] : PassPhraseGen.GetGibberishPass();
        if (flag7)
        {
          strArray[index] = strArray[index].ToLower();
          strArray[index] = strArray[index][0].ToString().ToUpper() + strArray[index].Substring(1);
        }
      }
      string s = string.Join(flag1 ? "" : " ", strArray);
      if (!flag7 & flag3)
        s = s.ToLower();
      if (!flag7 & flag2)
        s = s.ToUpper();
      if ((uint) PassPhraseGen.config > 0U & flag4)
        s = !flag5 ? (!flag6 ? Hex.ToString(Encoding.UTF8.GetBytes(s)) : Hex.ToString(Sha256Manager.GetHash(Sha256Manager.GetHash(Encoding.UTF8.GetBytes(s))))) : Hex.ToString(Sha256Manager.GetHash(Encoding.UTF8.GetBytes(s)));
      else if (length <= 2 && PassPhraseGen.config != PassPhraseGen.Config.AllBots && PassPhraseGen.rand.Next(100) > 95)
      {
        int num = PassPhraseGen.rand.Next(PassPhraseGen.rand.Next(100) > 75 ? 2020 : 99);
        s += (string) (object) num;
      }
      return s;
    }

    public enum Config
    {
      AllBots,
      Classic,
      UniquePhrases,
      TrueRandom,
      AltDict,
    }
  }
}
