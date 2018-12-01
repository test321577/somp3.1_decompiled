// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Secp256K1.NonceFunction
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

namespace Cryptography.ECDSA.Internal.Secp256K1
{
  internal delegate bool NonceFunction(byte[] nonce32, byte[] msg32, byte[] key32, byte[] algo16, byte[] data, uint attempt);
}
