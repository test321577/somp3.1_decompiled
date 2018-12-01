// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Callback
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace Cryptography.ECDSA
{
  public class Callback : EventArgs
  {
    public string Message;

    public Callback()
    {
    }

    public Callback(string message)
    {
      this.Message = message;
    }
  }
}
