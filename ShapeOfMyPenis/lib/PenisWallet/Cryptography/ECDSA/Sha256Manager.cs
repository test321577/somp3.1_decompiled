// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Sha256Manager
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using Cryptography.ECDSA.Internal.Sha256;

namespace Cryptography.ECDSA
{
  public class Sha256Manager
  {
    private readonly Sha256T _sha;

    public Sha256Manager()
    {
      this._sha = new Sha256T();
      Hash.Initialize(this._sha);
    }

    public void Write(byte[] data)
    {
      Hash.Write(this._sha, data, (uint) data.Length);
    }

    public void Write(byte[] data, int len)
    {
      Hash.Write(this._sha, data, (uint) len);
    }

    public byte[] FinalizeAndGetResult()
    {
      byte[] out32 = new byte[32];
      Hash.Finalize(this._sha, out32);
      return out32;
    }

    public static byte[] GetHash(byte[] data)
    {
      Sha256T hash = new Sha256T();
      Hash.Initialize(hash);
      Hash.Write(hash, data, (uint) data.Length);
      byte[] out32 = new byte[32];
      Hash.Finalize(hash, out32);
      return out32;
    }
  }
}
