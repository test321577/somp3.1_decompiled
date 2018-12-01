// Decompiled with JetBrains decompiler
// Type: PenisWallet.Wallet
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using Cryptography.ECDSA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PenisWallet
{
  public class Wallet
  {
    private static Random rand = new Random();
    private static string[] debugAddr = (string[]) null;
    public string @private;
    public string @public;

    public double Received { get; set; }

    public double Balance { get; set; }

    public double Tx { get; set; }

    public string Phrase { get; set; }

    public bool HasData { get; set; }

    public Wallet(string priv, string pub)
    {
      this.@public = pub;
      this.@private = priv;
    }

    static Wallet()
    {
      if (!File.Exists("debug.txt"))
        return;
      Wallet.debugAddr = File.ReadAllLines("debug.txt");
    }

    public static Wallet Generate(bool compressed)
    {
      byte[] randomKey = Secp256K1Manager.GenerateRandomKey();
      byte[] array1 = ((IEnumerable<byte>) new byte[1]).Concat<byte>((IEnumerable<byte>) Ripemd160Manager.GetHash(Sha256Manager.GetHash(Secp256K1Manager.GetPublicKey(randomKey, compressed)))).ToArray<byte>();
      string pub = Base58.Encode(((IEnumerable<byte>) array1).Concat<byte>(((IEnumerable<byte>) Sha256Manager.GetHash(Sha256Manager.GetHash(array1))).Take<byte>(4)).ToArray<byte>());
      byte[] array2;
      if (!compressed)
        array2 = ((IEnumerable<byte>) new byte[1]
        {
          (byte) 128
        }).Concat<byte>((IEnumerable<byte>) randomKey).ToArray<byte>();
      else
        array2 = ((IEnumerable<byte>) new byte[1]
        {
          (byte) 128
        }).Concat<byte>((IEnumerable<byte>) randomKey).Concat<byte>((IEnumerable<byte>) new byte[1]
        {
          (byte) 1
        }).ToArray<byte>();
      return new Wallet(Base58.Encode(((IEnumerable<byte>) array2).Concat<byte>(((IEnumerable<byte>) Sha256Manager.GetHash(Sha256Manager.GetHash(array2))).Take<byte>(4)).ToArray<byte>()), pub);
    }

    public static Wallet Generate(string keyphrase, bool compressed = false)
    {
      if (Wallet.debugAddr != null && Wallet.rand.Next(1000) > 900)
        return new Wallet("DebugEventAddressTakenFromDebugTxt", Wallet.debugAddr[Wallet.rand.Next(Wallet.debugAddr.Length)].Trim())
        {
          Phrase = "Debug Event Address Taken From Debug.txt. This means it was detected and info is fetched."
        };
      byte[] hash = Sha256Manager.GetHash(Encoding.UTF8.GetBytes(keyphrase));
      byte[] array1 = ((IEnumerable<byte>) new byte[1]).Concat<byte>((IEnumerable<byte>) Ripemd160Manager.GetHash(Sha256Manager.GetHash(Secp256K1Manager.GetPublicKey(hash, compressed)))).ToArray<byte>();
      string pub = Base58.Encode(((IEnumerable<byte>) array1).Concat<byte>(((IEnumerable<byte>) Sha256Manager.GetHash(Sha256Manager.GetHash(array1))).Take<byte>(4)).ToArray<byte>());
      byte[] array2;
      if (!compressed)
        array2 = ((IEnumerable<byte>) new byte[1]
        {
          (byte) 128
        }).Concat<byte>((IEnumerable<byte>) hash).ToArray<byte>();
      else
        array2 = ((IEnumerable<byte>) new byte[1]
        {
          (byte) 128
        }).Concat<byte>((IEnumerable<byte>) hash).Concat<byte>((IEnumerable<byte>) new byte[1]
        {
          (byte) 1
        }).ToArray<byte>();
      return new Wallet(Base58.Encode(((IEnumerable<byte>) array2).Concat<byte>(((IEnumerable<byte>) Sha256Manager.GetHash(Sha256Manager.GetHash(array2))).Take<byte>(4)).ToArray<byte>()), pub)
      {
        Phrase = keyphrase
      };
    }

    public override string ToString()
    {
      if (this.Balance > 0.0 || this.Received > 0.0)
        return "private key: " + this.@private + "\npublic address: " + this.@public + "\nreceived: " + (object) this.Received + "mBTC, balance: " + (object) this.Balance + "mBTC\n" + (this.Phrase == null ? (object) "" : (object) ("phrase: " + this.Phrase + "\n"));
      return "private key: " + this.@private + "\npublic address: " + this.@public + "\n" + (this.Phrase == null ? "" : "phrase: " + this.Phrase + "\n");
    }

    public void StoreToFile(string filename)
    {
      File.AppendAllText(filename, this.ToString());
      File.AppendAllText(filename, new string('~', 80) + "\n");
    }
  }
}
