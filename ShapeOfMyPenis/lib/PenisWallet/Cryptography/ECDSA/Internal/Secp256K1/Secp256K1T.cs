// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.Secp256K1T
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using Cryptography.ECDSA.Internal.Sha256;
using System;

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class Secp256K1T
  {
    public static NonceFunction NonceFunctionRfc6979 = new NonceFunction(Secp256K1T.nonce_function_rfc6979);
    public static NonceFunction NonceFunctionDefault = new NonceFunction(Secp256K1T.nonce_function_rfc6979);

    public static bool nonce_function_rfc6979(byte[] nonce32, byte[] msg32, byte[] key32, byte[] algo16, byte[] data, uint counter)
    {
      int size = 112;
      byte[] numArray = new byte[size];
      Rfc6979HmacSha256T rng = new Rfc6979HmacSha256T();
      uint dstOffset1 = 0;
      Util.Memcpy((Array) key32, 0U, (Array) numArray, dstOffset1, 32U);
      uint dstOffset2 = dstOffset1 + 32U;
      Util.Memcpy((Array) msg32, 0U, (Array) numArray, dstOffset2, 32U);
      uint num = dstOffset2 + 32U;
      if (data != null)
      {
        Util.Memcpy((Array) data, 0, (Array) numArray, 64, 32);
        num = 96U;
      }
      if (algo16 != null)
      {
        Util.Memcpy((Array) algo16, 0U, (Array) numArray, num, 16U);
        num += 16U;
      }
      Hash.Rfc6979HmacSha256Initialize(rng, numArray, num);
      Util.MemSet(numArray, (byte) 0, size);
      for (uint index = 0; index <= counter; ++index)
        Hash.Rfc6979HmacSha256Generate(rng, nonce32, 32);
      Hash.Rfc6979HmacSha256Finalize(rng);
      return true;
    }

    public static bool EcPubKeyCreate(Context ctx, PubKey pubkey, byte[] seckey)
    {
      GeJ r = new GeJ();
      Ge ge = new Ge();
      Scalar scalar = new Scalar();
      int num = !Scalar.SetB32(scalar, seckey) & !Scalar.IsZero(scalar) ? 1 : 0;
      if (num != 0)
      {
        EcMultGen.secp256k1_ecmult_gen(ctx.EcMultGenCtx, out r, scalar);
        Group.SetGeJ(ge, r);
        Secp256K1T.SavePubKey(pubkey, ge);
      }
      Scalar.Clear(scalar);
      return num != 0;
    }

    private static void SavePubKey(PubKey pubkey, Ge ge)
    {
      Field.NormalizeVar(ge.X);
      Field.NormalizeVar(ge.Y);
      Field.GetB32(pubkey.Data, ge.X);
      Field.GetB32(pubkey.Data, 32, ge.Y);
    }

    public static bool EcPubkeySerialize(byte[] output, ref int outputlen, PubKey pubkey, Options flags)
    {
      Ge ge = new Ge();
      bool flag = false;
      int size = outputlen;
      outputlen = 0;
      if (Secp256K1T.LoadPubKey(ge, pubkey))
      {
        flag = ECKey.PubkeySerialize(ge, output, ref size, flags.HasFlag((Enum) Options.FlagsBitContextVerify));
        if (flag)
          outputlen = size;
      }
      return flag;
    }

    private static bool LoadPubKey(Ge ge, PubKey pubkey)
    {
      Fe fe1 = new Fe();
      Field.SetB32(fe1, pubkey.Data);
      Fe fe2 = new Fe();
      Field.SetB32(fe2, pubkey.Data, 32);
      Group.SetXY(ge, fe1, fe2);
      return true;
    }
  }
}
