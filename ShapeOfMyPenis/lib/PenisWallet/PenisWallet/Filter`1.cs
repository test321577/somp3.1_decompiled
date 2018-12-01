// Decompiled with JetBrains decompiler
// Type: PenisWallet.Filter`1
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PenisWallet
{
  public class Filter<T>
  {
    private readonly int _hashFunctionCount;
    private BitArray _hashBits;
    private readonly Filter<T>.HashFunction _getHashSecondary;

    public Filter(int capacity)
      : this(capacity, (Filter<T>.HashFunction) null)
    {
    }

    public Filter(int capacity, float errorRate)
      : this(capacity, errorRate, (Filter<T>.HashFunction) null)
    {
    }

    public Filter(int capacity, Filter<T>.HashFunction hashFunction)
      : this(capacity, Filter<T>.BestErrorRate(capacity), hashFunction)
    {
    }

    public Filter(int capacity, float errorRate, Filter<T>.HashFunction hashFunction)
      : this(capacity, errorRate, hashFunction, Filter<T>.BestM(capacity, errorRate), Filter<T>.BestK(capacity, errorRate))
    {
    }

    public Filter(int capacity, float errorRate, Filter<T>.HashFunction hashFunction, int m, int k)
    {
      if (capacity < 1)
        throw new ArgumentOutOfRangeException(nameof (capacity), (object) capacity, "capacity must be > 0");
      if ((double) errorRate >= 1.0 || (double) errorRate <= 0.0)
        throw new ArgumentOutOfRangeException(nameof (errorRate), (object) errorRate, string.Format("errorRate must be between 0 and 1, exclusive. Was {0}", (object) errorRate));
      if (m < 1)
        throw new ArgumentOutOfRangeException(string.Format("The provided capacity and errorRate values would result in an array of length > int.MaxValue. Please reduce either of these values. Capacity: {0}, Error rate: {1}", (object) capacity, (object) errorRate));
      if (hashFunction == null)
      {
        if (typeof (T) == typeof (string))
        {
          this._getHashSecondary = new Filter<T>.HashFunction(Filter<T>.HashString);
        }
        else
        {
          if (!(typeof (T) == typeof (int)))
            throw new ArgumentNullException(nameof (hashFunction), "Please provide a hash function for your type T, when T is not a string or int.");
          this._getHashSecondary = new Filter<T>.HashFunction(Filter<T>.HashInt32);
        }
      }
      else
        this._getHashSecondary = hashFunction;
      this._hashFunctionCount = k;
      this._hashBits = new BitArray(m);
    }

    public double Truthiness
    {
      get
      {
        return (double) this.TrueBits() / (double) this._hashBits.Count;
      }
    }

    public void Add(T item)
    {
      int hashCode = item.GetHashCode();
      int secondaryHash = this._getHashSecondary(item);
      for (int i = 0; i < this._hashFunctionCount; ++i)
        this._hashBits[this.ComputeHash(hashCode, secondaryHash, i)] = true;
    }

    public bool Contains(T item)
    {
      int hashCode = item.GetHashCode();
      int secondaryHash = this._getHashSecondary(item);
      for (int i = 0; i < this._hashFunctionCount; ++i)
      {
        if (!this._hashBits[this.ComputeHash(hashCode, secondaryHash, i)])
          return false;
      }
      return true;
    }

    private static int BestK(int capacity, float errorRate)
    {
      return (int) Math.Round(Math.Log(2.0) * (double) Filter<T>.BestM(capacity, errorRate) / (double) capacity);
    }

    private static int BestM(int capacity, float errorRate)
    {
      return (int) Math.Ceiling((double) capacity * Math.Log((double) errorRate, 1.0 / Math.Pow(2.0, Math.Log(2.0))));
    }

    private static float BestErrorRate(int capacity)
    {
      float num = 1f / (float) capacity;
      if ((double) num != 0.0)
        return num;
      return (float) Math.Pow(0.6185, (double) (int.MaxValue / capacity));
    }

    private static int HashInt32(T input)
    {
      uint? nullable1 = (object) input as uint?;
      uint? nullable2 = nullable1;
      uint? nullable3 = nullable2.HasValue ? new uint?(~nullable2.GetValueOrDefault()) : new uint?();
      nullable2 = nullable1;
      uint? nullable4 = nullable2.HasValue ? new uint?(nullable2.GetValueOrDefault() << 15) : new uint?();
      uint? nullable5;
      if (!(nullable3.HasValue & nullable4.HasValue))
      {
        nullable2 = new uint?();
        nullable5 = nullable2;
      }
      else
        nullable5 = new uint?(nullable3.GetValueOrDefault() + nullable4.GetValueOrDefault());
      uint? nullable6 = nullable5;
      uint? nullable7 = nullable6;
      nullable2 = nullable6;
      uint? nullable8 = nullable2.HasValue ? new uint?(nullable2.GetValueOrDefault() >> 12) : new uint?();
      uint? nullable9;
      if (!(nullable7.HasValue & nullable8.HasValue))
      {
        nullable2 = new uint?();
        nullable9 = nullable2;
      }
      else
        nullable9 = new uint?(nullable7.GetValueOrDefault() ^ nullable8.GetValueOrDefault());
      uint? nullable10 = nullable9;
      uint? nullable11 = nullable10;
      nullable2 = nullable10;
      uint? nullable12 = nullable2.HasValue ? new uint?(nullable2.GetValueOrDefault() << 2) : new uint?();
      uint? nullable13;
      if (!(nullable11.HasValue & nullable12.HasValue))
      {
        nullable2 = new uint?();
        nullable13 = nullable2;
      }
      else
        nullable13 = new uint?(nullable11.GetValueOrDefault() + nullable12.GetValueOrDefault());
      uint? nullable14 = nullable13;
      uint? nullable15 = nullable14;
      nullable2 = nullable14;
      uint? nullable16 = nullable2.HasValue ? new uint?(nullable2.GetValueOrDefault() >> 4) : new uint?();
      uint? nullable17;
      if (!(nullable15.HasValue & nullable16.HasValue))
      {
        nullable2 = new uint?();
        nullable17 = nullable2;
      }
      else
        nullable17 = new uint?(nullable15.GetValueOrDefault() ^ nullable16.GetValueOrDefault());
      uint? nullable18 = nullable17;
      uint num = 2057;
      uint? nullable19 = nullable18.HasValue ? new uint?(nullable18.GetValueOrDefault() * num) : new uint?();
      uint? nullable20 = nullable19;
      nullable2 = nullable19;
      uint? nullable21 = nullable2.HasValue ? new uint?(nullable2.GetValueOrDefault() >> 16) : new uint?();
      uint? nullable22;
      if (!(nullable20.HasValue & nullable21.HasValue))
      {
        nullable2 = new uint?();
        nullable22 = nullable2;
      }
      else
        nullable22 = new uint?(nullable20.GetValueOrDefault() ^ nullable21.GetValueOrDefault());
      return (int) nullable22.Value;
    }

    private static int HashString(T input)
    {
      string str = (object) input as string;
      int num1 = 0;
      for (int index = 0; index < str.Length; ++index)
      {
        int num2 = num1 + (int) str[index];
        int num3 = num2 + (num2 << 10);
        num1 = num3 ^ num3 >> 6;
      }
      int num4 = num1 + (num1 << 3);
      int num5 = num4 ^ num4 >> 11;
      return num5 + (num5 << 15);
    }

    private int TrueBits()
    {
      int num = 0;
      foreach (bool hashBit in this._hashBits)
      {
        if (hashBit)
          ++num;
      }
      return num;
    }

    private int ComputeHash(int primaryHash, int secondaryHash, int i)
    {
      return Math.Abs((primaryHash + i * secondaryHash) % this._hashBits.Count);
    }

    public IEnumerable<byte> Serialize()
    {
      BitArray hashBits = this._hashBits;
      int length = hashBits.Count / 8;
      if (hashBits.Count % 8 != 0)
        ++length;
      byte[] bytes = new byte[length];
      byte[] bytes1 = BitConverter.GetBytes(hashBits.Count);
      hashBits.CopyTo((Array) bytes, 0);
      byte[] numArray = bytes1;
      int index;
      for (index = 0; index < numArray.Length; ++index)
        yield return numArray[index];
      numArray = (byte[]) null;
      numArray = bytes;
      for (index = 0; index < numArray.Length; ++index)
        yield return numArray[index];
      numArray = (byte[]) null;
    }

    public void Deserialize(IEnumerable<byte> bytes)
    {
      int int32 = BitConverter.ToInt32(bytes.Take<byte>(4).ToArray<byte>(), 0);
      this._hashBits = new BitArray(bytes.Skip<byte>(4).ToArray<byte>())
      {
        Length = int32
      };
    }

    public delegate int HashFunction(T input);
  }
}
