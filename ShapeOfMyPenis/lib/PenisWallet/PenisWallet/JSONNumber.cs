// Decompiled with JetBrains decompiler
// Type: PenisWallet.JSONNumber
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;
using System.Globalization;
using System.Text;

namespace PenisWallet
{
  public class JSONNumber : JSONNode
  {
    private double m_Data;

    public override JSONNodeType Tag
    {
      get
      {
        return JSONNodeType.Number;
      }
    }

    public override bool IsNumber
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
        return this.m_Data.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      set
      {
        double result;
        if (!double.TryParse(value, NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture, out result))
          return;
        this.m_Data = result;
      }
    }

    public override double AsDouble
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

    public override long AsLong
    {
      get
      {
        return (long) this.m_Data;
      }
      set
      {
        this.m_Data = (double) value;
      }
    }

    public JSONNumber(double aData)
    {
      this.m_Data = aData;
    }

    public JSONNumber(string aData)
    {
      this.Value = aData;
    }

    internal override void WriteToStringBuilder(StringBuilder aSB, int aIndent, int aIndentInc, JSONTextMode aMode)
    {
      aSB.Append(this.Value);
    }

    private static bool IsNumeric(object value)
    {
      if (!(value is int) && !(value is uint) && (!(value is float) && !(value is double)) && (!(value is Decimal) && !(value is long) && (!(value is ulong) && !(value is short))) && (!(value is ushort) && !(value is sbyte)))
        return value is byte;
      return true;
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (base.Equals(obj))
        return true;
      JSONNumber jsonNumber = obj as JSONNumber;
      if ((JSONNode) jsonNumber != (object) null)
        return this.m_Data == jsonNumber.m_Data;
      if (JSONNumber.IsNumeric(obj))
        return Convert.ToDouble(obj) == this.m_Data;
      return false;
    }

    public override int GetHashCode()
    {
      return this.m_Data.GetHashCode();
    }
  }
}
