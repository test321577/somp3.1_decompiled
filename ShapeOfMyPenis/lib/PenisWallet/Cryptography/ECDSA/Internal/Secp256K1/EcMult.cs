// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.EcMult
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class EcMult
  {
    private static void secp256k1_ecmult_odd_multiples_table(int n, GeJ[] prej, Fe[] zr, GeJ a)
    {
      GeJ r1 = new GeJ();
      Group.secp256k1_gej_double_var(r1, a, (Fe) null);
      Ge b = new Ge();
      b.X = r1.X.Clone();
      b.Y = r1.Y.Clone();
      b.Infinity = false;
      Ge r2 = new Ge();
      Group.secp256k1_ge_set_gej_zinv(r2, a, r1.Z);
      prej[0].X = r2.X.Clone();
      prej[0].Y = r2.Y.Clone();
      prej[0].Z = a.Z.Clone();
      prej[0].Infinity = false;
      zr[0] = r1.Z.Clone();
      for (int index = 1; index < n; ++index)
        Group.secp256k1_gej_add_ge_var(prej[index], prej[index - 1], b, zr[index]);
      Field.Mul(prej[n - 1].Z, prej[n - 1].Z, r1.Z);
    }

    public static void secp256k1_ecmult_odd_multiples_table_storage_var(int n, GeStorage[] pre, GeJ a, EventHandler<Callback> cb)
    {
      GeJ[] geJArray = new GeJ[n];
      Ge[] r = new Ge[n];
      Fe[] zr = new Fe[n];
      for (int index = 0; index < n; ++index)
      {
        geJArray[index] = new GeJ();
        r[index] = new Ge();
        zr[index] = new Fe();
      }
      EcMult.secp256k1_ecmult_odd_multiples_table(n, geJArray, zr, a);
      Group.secp256k1_ge_set_table_gej_var(r, geJArray, zr, n);
      for (int index = 0; index < n; ++index)
        Group.ToStorage(pre[index], r[index]);
    }

    public static void secp256k1_ecmult_context_init(EcMultContext ctx)
    {
      ctx.PreG = (GeStorage[]) null;
    }

    public static void secp256k1_ecmult_context_build(EcMultContext ctx, EventHandler<Callback> cb)
    {
      if (ctx.PreG != null)
        return;
      GeJ geJ = new GeJ();
      Group.secp256k1_gej_set_ge(geJ, Group.Secp256K1GeConstG);
      int n = 1 << 16 - 2;
      ctx.PreG = new GeStorage[n];
      for (int index = 0; index < n; ++index)
        ctx.PreG[index] = new GeStorage();
      EcMult.secp256k1_ecmult_odd_multiples_table_storage_var(n, ctx.PreG, geJ, cb);
    }
  }
}
