// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Secp256K1Manager
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using Cryptography.ECDSA.Internal.Secp256K1;
using System;
using System.Security.Cryptography;

namespace Cryptography.ECDSA
{
  public class Secp256K1Manager
  {
    private static readonly Context Ctx;

    public static event EventHandler<Callback> IllegalCallback;

    public static event EventHandler<Callback> ErrorCallback;

    static Secp256K1Manager()
    {
      Secp256K1Manager.IllegalCallback += new EventHandler<Callback>(Secp256K1Manager.OnIllegalCallback);
      Secp256K1Manager.ErrorCallback += new EventHandler<Callback>(Secp256K1Manager.OnErrorCallback);
      Secp256K1Manager.Ctx = new Context();
      Secp256K1Manager.Ctx = Secp256K1Manager.Secp256K1ContextCreate(Options.ContextVerify | Options.FlagsBitContextSign);
    }

    private static void OnErrorCallback(object sender, Callback secp256K1Callback)
    {
    }

    private static void OnIllegalCallback(object sender, Callback secp256K1Callback)
    {
    }

    private static Context Secp256K1ContextCreate(Options flags)
    {
      Context context1 = new Context();
      // ISSUE: reference to a compiler-generated field
      context1.IllegalCallback = Secp256K1Manager.IllegalCallback;
      // ISSUE: reference to a compiler-generated field
      context1.ErrorCallback = Secp256K1Manager.ErrorCallback;
      Context context2 = context1;
      if ((flags & Options.FlagsTypeMask) != Options.FlagsTypeContext)
      {
        EventHandler<Callback> illegalCallback = context2.IllegalCallback;
        if (illegalCallback != null)
          illegalCallback((object) null, new Callback("Invalid flags"));
        return (Context) null;
      }
      EcMult.secp256k1_ecmult_context_init(context2.EcMultCtx);
      EcMultGen.ContextInit(context2.EcMultGenCtx);
      if (flags.HasFlag((Enum) Options.FlagsBitContextSign))
        EcMultGen.ContextBuild(context2.EcMultGenCtx, context2.ErrorCallback);
      if (flags.HasFlag((Enum) Options.FlagsBitContextVerify))
        EcMult.secp256k1_ecmult_context_build(context2.EcMultCtx, context2.ErrorCallback);
      return context2;
    }

    private static int SignCompact(Context ctx, byte[] msg32, byte[] seckey, byte[] output64, out byte recid)
    {
      EcdsaRecoverableSignature recoverableSignature = new EcdsaRecoverableSignature();
      byte num = 0;
      int index = 0;
      byte[] noncedata = new byte[32];
      do
      {
        noncedata[index] = num;
        ++num;
        if (noncedata[index] == byte.MaxValue)
          ++index;
      }
      while (!Secp256K1Manager.Secp256K1EcdsaSignRecoverable(ctx, recoverableSignature, msg32, seckey, (NonceFunction) null, noncedata));
      Secp256K1Manager.Secp256K1EcdsaRecoverableSignatureSerializeCompact(ctx, output64, out recid, recoverableSignature);
      return (int) num;
    }

    private static bool Secp256K1EcdsaSignRecoverable(Context ctx, EcdsaRecoverableSignature signature, byte[] msg32, byte[] seckey, NonceFunction noncefp, byte[] noncedata)
    {
      if (ctx == null || msg32 == null || (signature == null || seckey == null))
        throw new NullReferenceException();
      if (!EcMultGen.ContextIsBuilt(ctx.EcMultGenCtx))
        throw new ArithmeticException();
      if (noncefp == null)
        noncefp = Secp256K1T.NonceFunctionDefault;
      byte recid = 1;
      bool flag = false;
      bool overflow = false;
      Scalar scalar1 = new Scalar();
      Scalar.SetB32(scalar1, seckey, ref overflow);
      Scalar scalar2 = new Scalar();
      Scalar scalar3 = new Scalar();
      if (!overflow && !Scalar.IsZero(scalar1))
      {
        byte[] numArray = new byte[32];
        uint attempt = 0;
        Scalar scalar4 = new Scalar();
        Scalar.SetB32(scalar4, msg32);
        Scalar scalar5 = new Scalar();
        while (true)
        {
          flag = noncefp(numArray, msg32, seckey, (byte[]) null, noncedata, attempt);
          if (flag)
          {
            Scalar.SetB32(scalar5, numArray, ref overflow);
            if (Scalar.IsZero(scalar5) || overflow || !Secp256K1Manager.Secp256K1EcdsaSigSign(ctx.EcMultGenCtx, scalar2, scalar3, scalar1, scalar4, scalar5, out recid))
              ++attempt;
            else
              break;
          }
          else
            break;
        }
        Util.MemSet(numArray, (byte) 0, 32);
        Scalar.Clear(scalar4);
        Scalar.Clear(scalar5);
        Scalar.Clear(scalar1);
      }
      if (flag)
        Secp256K1Manager.Secp256K1EcdsaRecoverableSignatureSave(signature, scalar2, scalar3, recid);
      else
        Util.MemSet(signature.Data, (byte) 0, 65);
      return flag;
    }

    private static void Secp256K1EcdsaRecoverableSignatureSave(EcdsaRecoverableSignature sig, Scalar r, Scalar s, byte recid)
    {
      Buffer.BlockCopy((Array) r.D, 0, (Array) sig.Data, 0, 32);
      Buffer.BlockCopy((Array) s.D, 0, (Array) sig.Data, 32, 32);
      sig.Data[64] = recid;
    }

    private static bool Secp256K1EcdsaSigSign(EcmultGenContext ctx, Scalar sigr, Scalar sigs, Scalar seckey, Scalar message, Scalar nonce, out byte recid)
    {
      byte[] numArray = new byte[32];
      Ge r1 = new Ge();
      Scalar scalar = new Scalar();
      bool overflow = false;
      GeJ r2;
      EcMultGen.secp256k1_ecmult_gen(ctx, out r2, nonce);
      Group.SetGeJ(r1, r2);
      Field.Normalize(r1.X);
      Field.Normalize(r1.Y);
      Field.GetB32(numArray, r1.X);
      Scalar.SetB32(sigr, numArray, ref overflow);
      recid = (byte) ((overflow ? 2 : 0) | (Field.IsOdd(r1.Y) ? 1 : 0));
      Scalar.Mul(scalar, sigr, seckey);
      Scalar.Add(scalar, scalar, message);
      Scalar.Inverse(sigs, nonce);
      Scalar.Mul(sigs, sigs, scalar);
      Scalar.Clear(scalar);
      Group.secp256k1_gej_clear(r2);
      Group.secp256k1_ge_clear(r1);
      if (Scalar.IsZero(sigs))
        return false;
      if (Scalar.IsHigh(sigs))
      {
        Scalar.Negate(sigs, sigs);
        recid ^= (byte) 1;
      }
      return true;
    }

    private static bool Secp256K1EcdsaRecoverableSignatureSerializeCompact(Context ctx, byte[] output64, out byte recid, EcdsaRecoverableSignature sig)
    {
      return Secp256K1Manager.Secp256K1EcdsaRecoverableSignatureSerializeCompact(ctx, output64, 0, out recid, sig);
    }

    private static bool Secp256K1EcdsaRecoverableSignatureSerializeCompact(Context ctx, byte[] outputxx, int skip, out byte recid, EcdsaRecoverableSignature sig)
    {
      Scalar scalar1 = new Scalar();
      Scalar scalar2 = new Scalar();
      recid = (byte) 0;
      if (outputxx == null)
      {
        EventHandler<Callback> illegalCallback = ctx.IllegalCallback;
        if (illegalCallback != null)
          illegalCallback((object) null, new Callback("(outputxx != null)"));
        return false;
      }
      if (sig == null)
      {
        EventHandler<Callback> illegalCallback = ctx.IllegalCallback;
        if (illegalCallback != null)
          illegalCallback((object) null, new Callback("(sig != null)"));
        return false;
      }
      Secp256K1Manager.Secp256K1EcdsaRecoverableSignatureLoad(scalar1, scalar2, out recid, sig);
      Scalar.GetB32(outputxx, skip, scalar1);
      Scalar.GetB32(outputxx, skip + 32, scalar2);
      return true;
    }

    private static void Secp256K1EcdsaRecoverableSignatureLoad(Scalar r, Scalar s, out byte recid, EcdsaRecoverableSignature sig)
    {
      Buffer.BlockCopy((Array) sig.Data, 0, (Array) r.D, 0, 32);
      Buffer.BlockCopy((Array) sig.Data, 32, (Array) s.D, 0, 32);
      recid = sig.Data[64];
    }

    private static byte[] SignCompact(byte[] data, byte[] seckey, out byte recoveryId)
    {
      EcdsaRecoverableSignature recoverableSignature = new EcdsaRecoverableSignature();
      byte num = 0;
      int index = 0;
      byte[] noncedata = new byte[32];
      do
      {
        noncedata[index] = num++;
        if (num == byte.MaxValue)
        {
          ++index;
          num = (byte) 0;
        }
      }
      while (!Secp256K1Manager.Secp256K1EcdsaSignRecoverable(Secp256K1Manager.Ctx, recoverableSignature, data, seckey, (NonceFunction) null, noncedata));
      byte[] output64 = new byte[64];
      Secp256K1Manager.Secp256K1EcdsaRecoverableSignatureSerializeCompact(Secp256K1Manager.Ctx, output64, out recoveryId, recoverableSignature);
      return output64;
    }

    public static byte[] SignCompact(byte[] data, byte[] seckey, out int recoveryId)
    {
      if (data == null)
        throw new ArgumentNullException(nameof (data));
      if (data.Length == 0)
        throw new ArgumentOutOfRangeException(nameof (data));
      if (seckey == null)
        throw new ArgumentNullException(nameof (seckey));
      if (seckey.Length != 32)
        throw new ArgumentOutOfRangeException(nameof (seckey));
      recoveryId = 0;
      EcdsaRecoverableSignature recoverableSignature = new EcdsaRecoverableSignature();
      if (!Secp256K1Manager.Secp256K1EcdsaSignRecoverable(Secp256K1Manager.Ctx, recoverableSignature, data, seckey, (NonceFunction) null, (byte[]) null))
        return (byte[]) null;
      byte[] output64 = new byte[64];
      byte recid;
      if (!Secp256K1Manager.Secp256K1EcdsaRecoverableSignatureSerializeCompact(Secp256K1Manager.Ctx, output64, out recid, recoverableSignature))
        return (byte[]) null;
      recoveryId = (int) recid;
      return output64;
    }

    public static byte[] SignCompressedCompact(byte[] data, byte[] seckey)
    {
      if (data == null)
        throw new ArgumentNullException(nameof (data));
      if (data.Length == 0)
        throw new ArgumentOutOfRangeException(nameof (data));
      if (seckey == null)
        throw new ArgumentNullException(nameof (seckey));
      if (seckey.Length != 32)
        throw new ArgumentOutOfRangeException(nameof (seckey));
      byte recid = 0;
      EcdsaRecoverableSignature recoverableSignature = new EcdsaRecoverableSignature();
      byte num1 = 0;
      int num2 = 0;
      byte[] numArray = (byte[]) null;
      RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
      do
      {
        if (num1 == byte.MaxValue)
        {
          ++num2;
          num1 = (byte) 0;
        }
        if (num1 > (byte) 0)
        {
          numArray = new byte[32];
          randomNumberGenerator.GetBytes(numArray);
        }
        ++num1;
      }
      while (!Secp256K1Manager.Secp256K1EcdsaSignRecoverable(Secp256K1Manager.Ctx, recoverableSignature, data, seckey, (NonceFunction) null, numArray) || !Secp256K1Manager.IsCanonical(recoverableSignature.Data));
      byte[] outputxx = new byte[65];
      Secp256K1Manager.Secp256K1EcdsaRecoverableSignatureSerializeCompact(Secp256K1Manager.Ctx, outputxx, 1, out recid, recoverableSignature);
      outputxx[0] = (byte) ((int) recid + 4 + 27);
      return outputxx;
    }

    public static bool IsCanonical(byte[] sig, int skip)
    {
      if (((int) sig[skip] & 128) > 0 || sig[skip] == (byte) 0 && ((int) sig[skip + 1] & 128) <= 0 || ((int) sig[skip + 32] & 128) > 0)
        return false;
      if (sig[skip + 32] == (byte) 0)
        return ((int) sig[skip + 33] & 128) > 0;
      return true;
    }

    private static bool IsCanonical(byte[] sig)
    {
      if (((int) sig[31] & 128) > 0 || sig[31] == (byte) 0 && ((int) sig[30] & 128) <= 0 || ((int) sig[63] & 128) > 0)
        return false;
      if (sig[63] == (byte) 0)
        return ((int) sig[62] & 128) > 0;
      return true;
    }

    public static byte[] GetPublicKey(byte[] privateKey, bool compressed)
    {
      if (privateKey == null)
        throw new ArgumentNullException(nameof (privateKey));
      if (privateKey.Length != 32)
        throw new ArgumentOutOfRangeException(nameof (privateKey));
      PubKey pubKey = new PubKey();
      if (!Secp256K1T.EcPubKeyCreate(Secp256K1Manager.Ctx, pubKey, privateKey))
        return (byte[]) null;
      return Secp256K1Manager.SerializePublicKey(pubKey, compressed);
    }

    private static byte[] SerializePublicKey(PubKey publicKey, bool compressed)
    {
      int outputlen = compressed ? 33 : 65;
      byte[] output = new byte[outputlen];
      if (!Secp256K1T.EcPubkeySerialize(output, ref outputlen, publicKey, compressed ? Options.EcCompressed : Options.FlagsTypeCompression))
        return (byte[]) null;
      if (outputlen == output.Length)
        return output;
      byte[] numArray = new byte[outputlen];
      Array.Copy((Array) output, 0, (Array) numArray, 0, outputlen);
      return numArray;
    }

    public static byte[] GenerateRandomKey()
    {
      RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
      byte[] numArray = new byte[32];
      byte[] data = numArray;
      randomNumberGenerator.GetBytes(data);
      return numArray;
    }
  }
}
