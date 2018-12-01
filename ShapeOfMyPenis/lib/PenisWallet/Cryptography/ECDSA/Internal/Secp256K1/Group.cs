// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.Group
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class Group
  {
    public static Ge Secp256K1GeConstG = new Ge(new uint[10]
    {
      49813400U,
      10507973U,
      42833311U,
      57456440U,
      50502652U,
      60932801U,
      33958236U,
      49197398U,
      41875932U,
      1994649U
    }, new uint[10]
    {
      51434680U,
      32777214U,
      21076420U,
      19044885U,
      16586676U,
      58999338U,
      38780864U,
      51484022U,
      41363107U,
      1183414U
    });
    private const int CurveB = 7;

    public static void SetXY(Ge r, Fe x, Fe y)
    {
      r.Infinity = false;
      r.X = x;
      r.Y = y;
    }

    public static bool secp256k1_ge_is_infinity(Ge a)
    {
      return a.Infinity;
    }

    public static void GeJAddGe(GeJ r, GeJ a, Ge b)
    {
      uint[] arr = new uint[10];
      arr[0] = 1U;
      Fe a1 = new Fe(arr);
      if (b.Infinity)
        throw new ArithmeticException();
      Fe fe1 = new Fe();
      Field.Sqr(fe1, a.Z);
      Fe fe2 = a.X.Clone();
      Field.NormalizeWeak(fe2);
      Fe fe3 = new Fe();
      Field.Mul(fe3, b.X, fe1);
      Fe r1 = a.Y.Clone();
      Field.NormalizeWeak(r1);
      Fe fe4 = new Fe();
      Field.Mul(fe4, b.Y, fe1);
      Field.Mul(fe4, fe4, a.Z);
      Fe fe5 = fe2.Clone();
      Field.Add(fe5, fe3);
      Fe fe6 = r1.Clone();
      Field.Add(fe6, fe4);
      Fe fe7 = new Fe();
      Field.Sqr(fe7, fe5);
      Fe fe8 = new Fe();
      Field.Negate(fe8, fe3, 1U);
      Fe fe9 = new Fe();
      Field.Mul(fe9, fe2, fe8);
      Field.Add(fe7, fe9);
      bool flag1 = Field.NormalizesToZero(fe6) && Field.NormalizesToZero(fe7);
      Fe fe10 = r1.Clone();
      Field.MulInt(fe10, 2U);
      Field.Add(fe8, fe2);
      Field.Cmov(fe10, fe7, !flag1);
      Field.Cmov(fe8, fe6, !flag1);
      Fe fe11 = new Fe();
      Field.Sqr(fe11, fe8);
      Fe fe12 = new Fe();
      Field.Mul(fe12, fe11, fe5);
      Field.Sqr(fe11, fe11);
      Field.Cmov(fe11, fe6, flag1);
      Field.Sqr(fe5, fe10);
      Field.Mul(r.Z, a.Z, fe8);
      bool flag2 = !a.Infinity && Field.NormalizesToZero(r.Z);
      Field.MulInt(r.Z, 2U);
      Field.Negate(fe12, fe12, 1U);
      Field.Add(fe5, fe12);
      Field.NormalizeWeak(fe5);
      r.X = fe5.Clone();
      Field.MulInt(fe5, 2U);
      Field.Add(fe5, fe12);
      Field.Mul(fe5, fe5, fe10);
      Field.Add(fe5, fe11);
      Field.Negate(r.Y, fe5, 3U);
      Field.NormalizeWeak(r.Y);
      Field.MulInt(r.X, 4U);
      Field.MulInt(r.Y, 4U);
      Field.Cmov(r.X, b.X, a.Infinity);
      Field.Cmov(r.Y, b.Y, a.Infinity);
      Field.Cmov(r.Z, a1, a.Infinity);
      r.Infinity = flag2;
    }

    public static void FromStorage(Ge r, GeStorage a)
    {
      Field.FromStorage(r.X, a.X);
      Field.FromStorage(r.Y, a.Y);
      r.Infinity = false;
    }

    public static void StorageCmov(GeStorage r, GeStorage a, bool flag)
    {
      Field.StorageCmov(r.X, a.X, flag);
      Field.StorageCmov(r.Y, a.Y, flag);
    }

    public static void secp256k1_ge_set_gej_zinv(Ge r, GeJ a, Fe zi)
    {
      Fe fe1 = new Fe();
      Fe fe2 = new Fe();
      Field.Sqr(fe1, zi);
      Field.Mul(fe2, fe1, zi);
      Field.Mul(r.X, a.X, fe1);
      Field.Mul(r.Y, a.Y, fe2);
      r.Infinity = a.Infinity;
    }

    public static void SetGeJ(Ge r, GeJ a)
    {
      Fe fe1 = new Fe();
      Fe fe2 = new Fe();
      r.Infinity = a.Infinity;
      Field.Inv(a.Z, a.Z);
      Field.Sqr(fe1, a.Z);
      Field.Mul(fe2, a.Z, fe1);
      Field.Mul(a.X, a.X, fe1);
      Field.Mul(a.Y, a.Y, fe2);
      Field.SetInt(a.Z, 1U);
      r.X = a.X.Clone();
      r.Y = a.Y.Clone();
    }

    public static void secp256k1_ge_set_all_gej_var(Ge[] r, GeJ[] a, int len, EventHandler<Callback> cb)
    {
      Fe[] a1 = new Fe[len];
      int len1 = 0;
      for (int index = 0; index < len; ++index)
      {
        if (!a[index].Infinity)
          a1[len1++] = a[index].Z.Clone();
      }
      Fe[] r1 = new Fe[len1];
      Field.InvAllVar(r1, a1, len1);
      int num = 0;
      for (int index = 0; index < len; ++index)
      {
        r[index].Infinity = a[index].Infinity;
        if (!a[index].Infinity)
          Group.secp256k1_ge_set_gej_zinv(r[index], a[index], r1[num++]);
      }
    }

    public static void secp256k1_ge_set_table_gej_var(Ge[] r, GeJ[] a, Fe[] zr, int len)
    {
      int index = len - 1;
      Fe fe = new Fe();
      if (len <= 0)
        return;
      Field.Inv(fe, a[index].Z);
      Group.secp256k1_ge_set_gej_zinv(r[index], a[index], fe);
      while (index > 0)
      {
        Field.Mul(fe, fe, zr[index]);
        --index;
        Group.secp256k1_ge_set_gej_zinv(r[index], a[index], fe);
      }
    }

    public static void secp256k1_gej_clear(GeJ r)
    {
      r.Infinity = false;
      Field.Clear(r.X);
      Field.Clear(r.Y);
      Field.Clear(r.Z);
    }

    public static void secp256k1_ge_clear(Ge r)
    {
      r.Infinity = false;
      Field.Clear(r.X);
      Field.Clear(r.Y);
    }

    public static bool secp256k1_ge_set_xquad(Ge r, Fe x)
    {
      r.X = x.Clone();
      Fe fe1 = new Fe();
      Field.Sqr(fe1, x);
      Fe fe2 = new Fe();
      Field.Mul(fe2, x, fe1);
      r.Infinity = false;
      Fe fe3 = new Fe();
      Field.SetInt(fe3, 7U);
      Field.Add(fe3, fe2);
      return Field.Sqrt(r.Y, fe3);
    }

    public static bool secp256k1_ge_set_xo_var(Ge r, Fe x, bool odd)
    {
      if (!Group.secp256k1_ge_set_xquad(r, x))
        return false;
      Field.NormalizeVar(r.Y);
      if (Field.IsOdd(r.Y) != odd)
        Field.Negate(r.Y, r.Y, 1U);
      return true;
    }

    public static void secp256k1_gej_set_ge(GeJ r, Ge a)
    {
      r.Infinity = a.Infinity;
      r.X = a.X.Clone();
      r.Y = a.Y.Clone();
      Field.SetInt(r.Z, 1U);
    }

    public static void secp256k1_gej_neg(GeJ r, GeJ a)
    {
      r.Infinity = a.Infinity;
      r.X = a.X.Clone();
      r.Y = a.Y.Clone();
      r.Z = a.Z.Clone();
      Field.NormalizeWeak(r.Y);
      Field.Negate(r.Y, r.Y, 1U);
    }

    public static void secp256k1_gej_double_var(GeJ r, GeJ a, Fe rzr)
    {
      r.Infinity = a.Infinity;
      if (r.Infinity)
      {
        if (rzr == null)
          return;
        Field.SetInt(rzr, 1U);
      }
      else
      {
        if (rzr != null)
        {
          rzr = a.Y.Clone();
          Field.NormalizeWeak(rzr);
          Field.MulInt(rzr, 2U);
        }
        Field.Mul(r.Z, a.Z, a.Y);
        Field.MulInt(r.Z, 2U);
        Fe fe1 = new Fe();
        Field.Sqr(fe1, a.X);
        Field.MulInt(fe1, 3U);
        Fe fe2 = new Fe();
        Field.Sqr(fe2, fe1);
        Fe fe3 = new Fe();
        Field.Sqr(fe3, a.Y);
        Field.MulInt(fe3, 2U);
        Fe fe4 = new Fe();
        Field.Sqr(fe4, fe3);
        Field.MulInt(fe4, 2U);
        Field.Mul(fe3, fe3, a.X);
        r.X = fe3.Clone();
        Field.MulInt(r.X, 4U);
        Field.Negate(r.X, r.X, 4U);
        Field.Add(r.X, fe2);
        Field.Negate(fe2, fe2, 1U);
        Field.MulInt(fe3, 6U);
        Field.Add(fe3, fe2);
        Field.Mul(r.Y, fe1, fe3);
        Field.Negate(fe2, fe4, 2U);
        Field.Add(r.Y, fe2);
      }
    }

    public static void secp256k1_gej_add_var(GeJ r, GeJ a, GeJ b, Fe rzr)
    {
      if (a.Infinity)
        r = b.Clone();
      else if (b.Infinity)
      {
        if (rzr != null)
          Field.SetInt(rzr, 1U);
        r = a.Clone();
      }
      else
      {
        r.Infinity = false;
        Fe fe1 = new Fe();
        Field.Sqr(fe1, b.Z);
        Fe fe2 = new Fe();
        Field.Sqr(fe2, a.Z);
        Fe fe3 = new Fe();
        Field.Mul(fe3, a.X, fe1);
        Fe fe4 = new Fe();
        Field.Mul(fe4, b.X, fe2);
        Fe fe5 = new Fe();
        Field.Mul(fe5, a.Y, fe1);
        Field.Mul(fe5, fe5, b.Z);
        Fe fe6 = new Fe();
        Field.Mul(fe6, b.Y, fe2);
        Field.Mul(fe6, fe6, a.Z);
        Fe fe7 = new Fe();
        Field.Negate(fe7, fe3, 1U);
        Field.Add(fe7, fe4);
        Fe fe8 = new Fe();
        Field.Negate(fe8, fe5, 1U);
        Field.Add(fe8, fe6);
        if (Field.NormalizesToZeroVar(fe7))
        {
          if (Field.NormalizesToZeroVar(fe8))
          {
            Group.secp256k1_gej_double_var(r, a, rzr);
          }
          else
          {
            if (rzr != null)
              Field.SetInt(rzr, 0U);
            r.Infinity = true;
          }
        }
        else
        {
          Fe fe9 = new Fe();
          Field.Sqr(fe9, fe8);
          Fe fe10 = new Fe();
          Field.Sqr(fe10, fe7);
          Fe fe11 = new Fe();
          Field.Mul(fe11, fe7, fe10);
          Field.Mul(fe7, fe7, b.Z);
          if (rzr != null)
            rzr = fe7.Clone();
          Field.Mul(r.Z, a.Z, fe7);
          Fe fe12 = new Fe();
          Field.Mul(fe12, fe3, fe10);
          r.X = fe12.Clone();
          Field.MulInt(r.X, 2U);
          Field.Add(r.X, fe11);
          Field.Negate(r.X, r.X, 3U);
          Field.Add(r.X, fe9);
          Field.Negate(r.Y, r.X, 5U);
          Field.Add(r.Y, fe12);
          Field.Mul(r.Y, r.Y, fe8);
          Field.Mul(fe11, fe11, fe5);
          Field.Negate(fe11, fe11, 1U);
          Field.Add(r.Y, fe11);
        }
      }
    }

    public static void secp256k1_gej_add_ge_var(GeJ r, GeJ a, Ge b, Fe rzr)
    {
      if (a.Infinity)
        Group.secp256k1_gej_set_ge(r, b);
      else if (b.Infinity)
      {
        if (rzr != null)
          Field.SetInt(rzr, 1U);
        r = a.Clone();
      }
      else
      {
        r.Infinity = false;
        Fe fe1 = new Fe();
        Field.Sqr(fe1, a.Z);
        Fe fe2 = a.X.Clone();
        Field.NormalizeWeak(fe2);
        Fe fe3 = new Fe();
        Field.Mul(fe3, b.X, fe1);
        Fe fe4 = a.Y.Clone();
        Field.NormalizeWeak(fe4);
        Fe fe5 = new Fe();
        Field.Mul(fe5, b.Y, fe1);
        Field.Mul(fe5, fe5, a.Z);
        Fe fe6 = new Fe();
        Field.Negate(fe6, fe2, 1U);
        Field.Add(fe6, fe3);
        Fe fe7 = new Fe();
        Field.Negate(fe7, fe4, 1U);
        Field.Add(fe7, fe5);
        if (Field.NormalizesToZeroVar(fe6))
        {
          if (Field.NormalizesToZeroVar(fe7))
          {
            Group.secp256k1_gej_double_var(r, a, rzr);
          }
          else
          {
            if (rzr != null)
              Field.SetInt(rzr, 0U);
            r.Infinity = true;
          }
        }
        else
        {
          Fe fe8 = new Fe();
          Field.Sqr(fe8, fe7);
          Fe fe9 = new Fe();
          Field.Sqr(fe9, fe6);
          Fe fe10 = new Fe();
          Field.Mul(fe10, fe6, fe9);
          if (rzr != null)
            rzr = fe6.Clone();
          Field.Mul(r.Z, a.Z, fe6);
          Fe fe11 = new Fe();
          Field.Mul(fe11, fe2, fe9);
          r.X = fe11.Clone();
          Field.MulInt(r.X, 2U);
          Field.Add(r.X, fe10);
          Field.Negate(r.X, r.X, 3U);
          Field.Add(r.X, fe8);
          Field.Negate(r.Y, r.X, 5U);
          Field.Add(r.Y, fe11);
          Field.Mul(r.Y, r.Y, fe7);
          Field.Mul(fe10, fe10, fe4);
          Field.Negate(fe10, fe10, 1U);
          Field.Add(r.Y, fe10);
        }
      }
    }

    public static void secp256k1_gej_rescale(GeJ r, Fe s)
    {
      Fe fe = new Fe();
      Field.Sqr(fe, s);
      Field.Mul(r.X, r.X, fe);
      Field.Mul(r.Y, r.Y, fe);
      Field.Mul(r.Y, r.Y, s);
      Field.Mul(r.Z, r.Z, s);
    }

    public static void ToStorage(GeStorage r, Ge a)
    {
      Fe fe1 = a.X.Clone();
      Field.Normalize(fe1);
      Fe fe2 = a.Y.Clone();
      Field.Normalize(fe2);
      Field.ToStorage(r.X, fe1);
      Field.ToStorage(r.Y, fe2);
    }
  }
}
