// Decompiled with JetBrains decompiler
// Type: PenisWallet.JSONBool
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System.Text;

namespace PenisWallet
{
  public class JSONBool : JSONNode
  {
    private bool m_Data;

    public override JSONNodeType Tag
    {
      get
      {
        return JSONNodeType.Boolean;
      }
    }

    public override bool IsBoolean
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
        return this.m_Data.ToString();
      }
      set
      {
        bool result;
        if (!bool.TryParse(value, out result))
          return;
        this.m_Data = result;
      }
    }

    public override bool AsBool
    {
      get
      {
        return this.m_Data;
      }
      set
      {
        this.m_Data = value;
      }
    }

    public JSONBool(bool aData)
    {
      this.m_Data = aData;
    }

    public JSONBool(string aData)
    {
      this.Value = aData;
    }

    internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
    {
      aSB.Append(this.m_Data ? "true" : "false");
    }

    public override bool Equals(object obj)
    {
      if (obj == null || !(obj is bool))
        return false;
      return this.m_Data == (bool) obj;
    }

    public override int GetHashCode()
    {
      return this.m_Data.GetHashCode();
    }
  }
}
