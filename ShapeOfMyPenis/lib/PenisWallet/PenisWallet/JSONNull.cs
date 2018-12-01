// Decompiled with JetBrains decompiler
// Type: PenisWallet.JSONNull
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System.Text;

namespace PenisWallet
{
  public class JSONNull : JSONNode
  {
    private static JSONNull m_StaticInstance = new JSONNull();
    public static bool reuseSameInstance = true;

    public static JSONNull CreateOrGet()
    {
      if (JSONNull.reuseSameInstance)
        return JSONNull.m_StaticInstance;
      return new JSONNull();
    }

    private JSONNull()
    {
    }

    public override JSONNodeType Tag
    {
      get
      {
        return JSONNodeType.NullValue;
      }
    }

    public override bool IsNull
    {
      get
      {
        return true;
      }
    }

    public override JSONNode.Enumerator GetEnumerator()
    {
      return new JSONNode.Enumerator();
    }

    public override string Value
    {
      get
      {
        return "null";
      }
      set
      {
      }
    }

    public override bool AsBool
    {
      get
      {
        return false;
      }
      set
      {
      }
    }

    public override bool Equals(object obj)
    {
      if (this == obj)
        return true;
      return obj is JSONNull;
    }

    public override int GetHashCode()
    {
      return 0;
    }

    internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
    {
      aSB.Append("null");
    }
  }
}
