// Decompiled with JetBrains decompiler
// Type: PenisWallet.JSONString
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System.Text;

namespace PenisWallet
{
  public class JSONString : JSONNode
  {
    private string m_Data;

    public override JSONNodeType Tag
    {
      get
      {
        return JSONNodeType.String;
      }
    }

    public override bool IsString
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
        return this.m_Data;
      }
      set
      {
        this.m_Data = value;
      }
    }

    public JSONString(string aData)
    {
      this.m_Data = aData;
    }

    internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
    {
      aSB.Append('"').Append(JSONNode.Escape(this.m_Data)).Append('"');
    }

    public override bool Equals(object obj)
    {
      if (base.Equals(obj))
        return true;
      string str = obj as string;
      if (str != null)
        return this.m_Data == str;
      JSONString jsonString = obj as JSONString;
      if ((JSONNode) jsonString != (object) null)
        return this.m_Data == jsonString.m_Data;
      return false;
    }

    public override int GetHashCode()
    {
      return this.m_Data.GetHashCode();
    }
  }
}
