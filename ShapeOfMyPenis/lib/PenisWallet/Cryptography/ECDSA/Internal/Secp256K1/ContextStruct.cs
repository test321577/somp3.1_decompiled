// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.ContextStruct
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal class ContextStruct
  {
    public EcMultContext EcMultCtx;
    public EcmultGenContext EcMultGenCtx;
    public EventHandler<Callback> IllegalCallback;
    public EventHandler<Callback> ErrorCallback;

    public ContextStruct()
    {
      this.EcMultCtx = new EcMultContext();
      this.EcMultGenCtx = new EcmultGenContext();
    }
  }
}
