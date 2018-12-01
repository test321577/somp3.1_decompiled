// Decompiled with JetBrains decompiler
// Type: Cryptography.ECDSA.Internal.Sha256.Hash
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using Cryptography.ECDSA.Internal.Secp256K1;
using System;

namespace Cryptography.ECDSA.Internal.Sha256
{
  internal class Hash
  {
    public static void Initialize(Sha256T hash)
    {
      hash.S[0] = 1779033703U;
      hash.S[1] = 3144134277U;
      hash.S[2] = 1013904242U;
      hash.S[3] = 2773480762U;
      hash.S[4] = 1359893119U;
      hash.S[5] = 2600822924U;
      hash.S[6] = 528734635U;
      hash.S[7] = 1541459225U;
      hash.Bytes = 0U;
    }

    public static void Write(Sha256T hash, uint[] data, uint len)
    {
      byte[] data1 = new byte[data.Length * 4];
      Util.Memcpy((Array) data, 0, (Array) data1, 0, data1.Length);
      Hash.Write(hash, data1, len);
    }

    public static void Write(Sha256T hash, byte[] data, uint len)
    {
      uint dstOffset = hash.Bytes & 63U;
      hash.Bytes += len;
      uint srcOffset = 0;
      for (; dstOffset + len >= 64U; dstOffset = 0U)
      {
        Util.Memcpy((Array) data, srcOffset, (Array) hash.Buf, dstOffset, 64U - dstOffset);
        srcOffset += 64U - dstOffset;
        len -= 64U - dstOffset;
        Hash.Transform(hash.S, hash.Buf);
      }
      if (len <= 0U)
        return;
      Util.Memcpy((Array) data, srcOffset, (Array) hash.Buf, dstOffset, len);
    }

    public static void Transform(uint[] s, uint[] chunk)
    {
      uint num1 = s[0];
      uint num2 = s[1];
      uint num3 = s[2];
      uint num4 = s[3];
      uint num5 = s[4];
      uint num6 = s[5];
      uint num7 = s[6];
      uint num8;
      uint num9 = (uint) ((int) s[7] + (((int) (num5 >> 6) | (int) num5 << 26) ^ ((int) (num5 >> 11) | (int) num5 << 21) ^ ((int) (num5 >> 25) | (int) num5 << 7)) + ((int) num7 ^ (int) num5 & ((int) num6 ^ (int) num7)) + 1116352408) + (num8 = (uint) (((int) chunk[0] & (int) byte.MaxValue) << 24 | ((int) chunk[0] & 65280) << 8) | (chunk[0] & 16711680U) >> 8 | (chunk[0] & 4278190080U) >> 24);
      uint num10 = (uint) ((((int) (num1 >> 2) | (int) num1 << 30) ^ ((int) (num1 >> 13) | (int) num1 << 19) ^ ((int) (num1 >> 22) | (int) num1 << 10)) + ((int) num1 & (int) num2 | (int) num3 & ((int) num1 | (int) num2)));
      uint num11 = num4 + num9;
      uint num12 = num9 + num10;
      uint num13;
      uint num14 = (uint) ((int) num7 + (((int) (num11 >> 6) | (int) num11 << 26) ^ ((int) (num11 >> 11) | (int) num11 << 21) ^ ((int) (num11 >> 25) | (int) num11 << 7)) + ((int) num6 ^ (int) num11 & ((int) num5 ^ (int) num6)) + 1899447441) + (num13 = (uint) (((int) chunk[1] & (int) byte.MaxValue) << 24 | ((int) chunk[1] & 65280) << 8) | (chunk[1] & 16711680U) >> 8 | (chunk[1] & 4278190080U) >> 24);
      uint num15 = (uint) ((((int) (num12 >> 2) | (int) num12 << 30) ^ ((int) (num12 >> 13) | (int) num12 << 19) ^ ((int) (num12 >> 22) | (int) num12 << 10)) + ((int) num12 & (int) num1 | (int) num2 & ((int) num12 | (int) num1)));
      uint num16 = num3 + num14;
      uint num17 = num14 + num15;
      uint num18;
      uint num19 = (uint) ((int) num6 + (((int) (num16 >> 6) | (int) num16 << 26) ^ ((int) (num16 >> 11) | (int) num16 << 21) ^ ((int) (num16 >> 25) | (int) num16 << 7)) + ((int) num5 ^ (int) num16 & ((int) num11 ^ (int) num5)) - 1245643825) + (num18 = (uint) (((int) chunk[2] & (int) byte.MaxValue) << 24 | ((int) chunk[2] & 65280) << 8) | (chunk[2] & 16711680U) >> 8 | (chunk[2] & 4278190080U) >> 24);
      uint num20 = (uint) ((((int) (num17 >> 2) | (int) num17 << 30) ^ ((int) (num17 >> 13) | (int) num17 << 19) ^ ((int) (num17 >> 22) | (int) num17 << 10)) + ((int) num17 & (int) num12 | (int) num1 & ((int) num17 | (int) num12)));
      uint num21 = num2 + num19;
      uint num22 = num19 + num20;
      uint num23;
      uint num24 = (uint) ((int) num5 + (((int) (num21 >> 6) | (int) num21 << 26) ^ ((int) (num21 >> 11) | (int) num21 << 21) ^ ((int) (num21 >> 25) | (int) num21 << 7)) + ((int) num11 ^ (int) num21 & ((int) num16 ^ (int) num11)) - 373957723) + (num23 = (uint) (((int) chunk[3] & (int) byte.MaxValue) << 24 | ((int) chunk[3] & 65280) << 8) | (chunk[3] & 16711680U) >> 8 | (chunk[3] & 4278190080U) >> 24);
      uint num25 = (uint) ((((int) (num22 >> 2) | (int) num22 << 30) ^ ((int) (num22 >> 13) | (int) num22 << 19) ^ ((int) (num22 >> 22) | (int) num22 << 10)) + ((int) num22 & (int) num17 | (int) num12 & ((int) num22 | (int) num17)));
      uint num26 = num1 + num24;
      uint num27 = num24 + num25;
      uint num28;
      uint num29 = (uint) ((int) num11 + (((int) (num26 >> 6) | (int) num26 << 26) ^ ((int) (num26 >> 11) | (int) num26 << 21) ^ ((int) (num26 >> 25) | (int) num26 << 7)) + ((int) num16 ^ (int) num26 & ((int) num21 ^ (int) num16)) + 961987163) + (num28 = (uint) (((int) chunk[4] & (int) byte.MaxValue) << 24 | ((int) chunk[4] & 65280) << 8) | (chunk[4] & 16711680U) >> 8 | (chunk[4] & 4278190080U) >> 24);
      uint num30 = (uint) ((((int) (num27 >> 2) | (int) num27 << 30) ^ ((int) (num27 >> 13) | (int) num27 << 19) ^ ((int) (num27 >> 22) | (int) num27 << 10)) + ((int) num27 & (int) num22 | (int) num17 & ((int) num27 | (int) num22)));
      uint num31 = num12 + num29;
      uint num32 = num29 + num30;
      uint num33;
      uint num34 = (uint) ((int) num16 + (((int) (num31 >> 6) | (int) num31 << 26) ^ ((int) (num31 >> 11) | (int) num31 << 21) ^ ((int) (num31 >> 25) | (int) num31 << 7)) + ((int) num21 ^ (int) num31 & ((int) num26 ^ (int) num21)) + 1508970993) + (num33 = (uint) (((int) chunk[5] & (int) byte.MaxValue) << 24 | ((int) chunk[5] & 65280) << 8) | (chunk[5] & 16711680U) >> 8 | (chunk[5] & 4278190080U) >> 24);
      uint num35 = (uint) ((((int) (num32 >> 2) | (int) num32 << 30) ^ ((int) (num32 >> 13) | (int) num32 << 19) ^ ((int) (num32 >> 22) | (int) num32 << 10)) + ((int) num32 & (int) num27 | (int) num22 & ((int) num32 | (int) num27)));
      uint num36 = num17 + num34;
      uint num37 = num34 + num35;
      uint num38;
      uint num39 = (uint) ((int) num21 + (((int) (num36 >> 6) | (int) num36 << 26) ^ ((int) (num36 >> 11) | (int) num36 << 21) ^ ((int) (num36 >> 25) | (int) num36 << 7)) + ((int) num26 ^ (int) num36 & ((int) num31 ^ (int) num26)) - 1841331548) + (num38 = (uint) (((int) chunk[6] & (int) byte.MaxValue) << 24 | ((int) chunk[6] & 65280) << 8) | (chunk[6] & 16711680U) >> 8 | (chunk[6] & 4278190080U) >> 24);
      uint num40 = (uint) ((((int) (num37 >> 2) | (int) num37 << 30) ^ ((int) (num37 >> 13) | (int) num37 << 19) ^ ((int) (num37 >> 22) | (int) num37 << 10)) + ((int) num37 & (int) num32 | (int) num27 & ((int) num37 | (int) num32)));
      uint num41 = num22 + num39;
      uint num42 = num39 + num40;
      uint num43;
      uint num44 = (uint) ((int) num26 + (((int) (num41 >> 6) | (int) num41 << 26) ^ ((int) (num41 >> 11) | (int) num41 << 21) ^ ((int) (num41 >> 25) | (int) num41 << 7)) + ((int) num31 ^ (int) num41 & ((int) num36 ^ (int) num31)) - 1424204075) + (num43 = (uint) (((int) chunk[7] & (int) byte.MaxValue) << 24 | ((int) chunk[7] & 65280) << 8) | (chunk[7] & 16711680U) >> 8 | (chunk[7] & 4278190080U) >> 24);
      uint num45 = (uint) ((((int) (num42 >> 2) | (int) num42 << 30) ^ ((int) (num42 >> 13) | (int) num42 << 19) ^ ((int) (num42 >> 22) | (int) num42 << 10)) + ((int) num42 & (int) num37 | (int) num32 & ((int) num42 | (int) num37)));
      uint num46 = num27 + num44;
      uint num47 = num44 + num45;
      uint num48;
      uint num49 = (uint) ((int) num31 + (((int) (num46 >> 6) | (int) num46 << 26) ^ ((int) (num46 >> 11) | (int) num46 << 21) ^ ((int) (num46 >> 25) | (int) num46 << 7)) + ((int) num36 ^ (int) num46 & ((int) num41 ^ (int) num36)) - 670586216) + (num48 = (uint) (((int) chunk[8] & (int) byte.MaxValue) << 24 | ((int) chunk[8] & 65280) << 8) | (chunk[8] & 16711680U) >> 8 | (chunk[8] & 4278190080U) >> 24);
      uint num50 = (uint) ((((int) (num47 >> 2) | (int) num47 << 30) ^ ((int) (num47 >> 13) | (int) num47 << 19) ^ ((int) (num47 >> 22) | (int) num47 << 10)) + ((int) num47 & (int) num42 | (int) num37 & ((int) num47 | (int) num42)));
      uint num51 = num32 + num49;
      uint num52 = num49 + num50;
      uint num53;
      uint num54 = (uint) ((int) num36 + (((int) (num51 >> 6) | (int) num51 << 26) ^ ((int) (num51 >> 11) | (int) num51 << 21) ^ ((int) (num51 >> 25) | (int) num51 << 7)) + ((int) num41 ^ (int) num51 & ((int) num46 ^ (int) num41)) + 310598401) + (num53 = (uint) (((int) chunk[9] & (int) byte.MaxValue) << 24 | ((int) chunk[9] & 65280) << 8) | (chunk[9] & 16711680U) >> 8 | (chunk[9] & 4278190080U) >> 24);
      uint num55 = (uint) ((((int) (num52 >> 2) | (int) num52 << 30) ^ ((int) (num52 >> 13) | (int) num52 << 19) ^ ((int) (num52 >> 22) | (int) num52 << 10)) + ((int) num52 & (int) num47 | (int) num42 & ((int) num52 | (int) num47)));
      uint num56 = num37 + num54;
      uint num57 = num54 + num55;
      uint num58;
      uint num59 = (uint) ((int) num41 + (((int) (num56 >> 6) | (int) num56 << 26) ^ ((int) (num56 >> 11) | (int) num56 << 21) ^ ((int) (num56 >> 25) | (int) num56 << 7)) + ((int) num46 ^ (int) num56 & ((int) num51 ^ (int) num46)) + 607225278) + (num58 = (uint) (((int) chunk[10] & (int) byte.MaxValue) << 24 | ((int) chunk[10] & 65280) << 8) | (chunk[10] & 16711680U) >> 8 | (chunk[10] & 4278190080U) >> 24);
      uint num60 = (uint) ((((int) (num57 >> 2) | (int) num57 << 30) ^ ((int) (num57 >> 13) | (int) num57 << 19) ^ ((int) (num57 >> 22) | (int) num57 << 10)) + ((int) num57 & (int) num52 | (int) num47 & ((int) num57 | (int) num52)));
      uint num61 = num42 + num59;
      uint num62 = num59 + num60;
      uint num63;
      uint num64 = (uint) ((int) num46 + (((int) (num61 >> 6) | (int) num61 << 26) ^ ((int) (num61 >> 11) | (int) num61 << 21) ^ ((int) (num61 >> 25) | (int) num61 << 7)) + ((int) num51 ^ (int) num61 & ((int) num56 ^ (int) num51)) + 1426881987) + (num63 = (uint) (((int) chunk[11] & (int) byte.MaxValue) << 24 | ((int) chunk[11] & 65280) << 8) | (chunk[11] & 16711680U) >> 8 | (chunk[11] & 4278190080U) >> 24);
      uint num65 = (uint) ((((int) (num62 >> 2) | (int) num62 << 30) ^ ((int) (num62 >> 13) | (int) num62 << 19) ^ ((int) (num62 >> 22) | (int) num62 << 10)) + ((int) num62 & (int) num57 | (int) num52 & ((int) num62 | (int) num57)));
      uint num66 = num47 + num64;
      uint num67 = num64 + num65;
      uint num68;
      uint num69 = (uint) ((int) num51 + (((int) (num66 >> 6) | (int) num66 << 26) ^ ((int) (num66 >> 11) | (int) num66 << 21) ^ ((int) (num66 >> 25) | (int) num66 << 7)) + ((int) num56 ^ (int) num66 & ((int) num61 ^ (int) num56)) + 1925078388) + (num68 = (uint) (((int) chunk[12] & (int) byte.MaxValue) << 24 | ((int) chunk[12] & 65280) << 8) | (chunk[12] & 16711680U) >> 8 | (chunk[12] & 4278190080U) >> 24);
      uint num70 = (uint) ((((int) (num67 >> 2) | (int) num67 << 30) ^ ((int) (num67 >> 13) | (int) num67 << 19) ^ ((int) (num67 >> 22) | (int) num67 << 10)) + ((int) num67 & (int) num62 | (int) num57 & ((int) num67 | (int) num62)));
      uint num71 = num52 + num69;
      uint num72 = num69 + num70;
      uint num73;
      uint num74 = (uint) ((int) num56 + (((int) (num71 >> 6) | (int) num71 << 26) ^ ((int) (num71 >> 11) | (int) num71 << 21) ^ ((int) (num71 >> 25) | (int) num71 << 7)) + ((int) num61 ^ (int) num71 & ((int) num66 ^ (int) num61)) - 2132889090) + (num73 = (uint) (((int) chunk[13] & (int) byte.MaxValue) << 24 | ((int) chunk[13] & 65280) << 8) | (chunk[13] & 16711680U) >> 8 | (chunk[13] & 4278190080U) >> 24);
      uint num75 = (uint) ((((int) (num72 >> 2) | (int) num72 << 30) ^ ((int) (num72 >> 13) | (int) num72 << 19) ^ ((int) (num72 >> 22) | (int) num72 << 10)) + ((int) num72 & (int) num67 | (int) num62 & ((int) num72 | (int) num67)));
      uint num76 = num57 + num74;
      uint num77 = num74 + num75;
      uint num78;
      uint num79 = (uint) ((int) num61 + (((int) (num76 >> 6) | (int) num76 << 26) ^ ((int) (num76 >> 11) | (int) num76 << 21) ^ ((int) (num76 >> 25) | (int) num76 << 7)) + ((int) num66 ^ (int) num76 & ((int) num71 ^ (int) num66)) - 1680079193) + (num78 = (uint) (((int) chunk[14] & (int) byte.MaxValue) << 24 | ((int) chunk[14] & 65280) << 8) | (chunk[14] & 16711680U) >> 8 | (chunk[14] & 4278190080U) >> 24);
      uint num80 = (uint) ((((int) (num77 >> 2) | (int) num77 << 30) ^ ((int) (num77 >> 13) | (int) num77 << 19) ^ ((int) (num77 >> 22) | (int) num77 << 10)) + ((int) num77 & (int) num72 | (int) num67 & ((int) num77 | (int) num72)));
      uint num81 = num62 + num79;
      uint num82 = num79 + num80;
      uint num83;
      uint num84 = (uint) ((int) num66 + (((int) (num81 >> 6) | (int) num81 << 26) ^ ((int) (num81 >> 11) | (int) num81 << 21) ^ ((int) (num81 >> 25) | (int) num81 << 7)) + ((int) num71 ^ (int) num81 & ((int) num76 ^ (int) num71)) - 1046744716) + (num83 = (uint) (((int) chunk[15] & (int) byte.MaxValue) << 24 | ((int) chunk[15] & 65280) << 8) | (chunk[15] & 16711680U) >> 8 | (chunk[15] & 4278190080U) >> 24);
      uint num85 = (uint) ((((int) (num82 >> 2) | (int) num82 << 30) ^ ((int) (num82 >> 13) | (int) num82 << 19) ^ ((int) (num82 >> 22) | (int) num82 << 10)) + ((int) num82 & (int) num77 | (int) num72 & ((int) num82 | (int) num77)));
      uint num86 = num67 + num84;
      uint num87 = num84 + num85;
      uint num88;
      uint num89 = (uint) ((int) num71 + (((int) (num86 >> 6) | (int) num86 << 26) ^ ((int) (num86 >> 11) | (int) num86 << 21) ^ ((int) (num86 >> 25) | (int) num86 << 7)) + ((int) num76 ^ (int) num86 & ((int) num81 ^ (int) num76)) - 459576895) + (num88 = num8 + (uint) ((((int) (num78 >> 17) | (int) num78 << 15) ^ ((int) (num78 >> 19) | (int) num78 << 13) ^ (int) (num78 >> 10)) + (int) num53 + (((int) (num13 >> 7) | (int) num13 << 25) ^ ((int) (num13 >> 18) | (int) num13 << 14) ^ (int) (num13 >> 3))));
      uint num90 = (uint) ((((int) (num87 >> 2) | (int) num87 << 30) ^ ((int) (num87 >> 13) | (int) num87 << 19) ^ ((int) (num87 >> 22) | (int) num87 << 10)) + ((int) num87 & (int) num82 | (int) num77 & ((int) num87 | (int) num82)));
      uint num91 = num72 + num89;
      uint num92 = num89 + num90;
      uint num93;
      uint num94 = (uint) ((int) num76 + (((int) (num91 >> 6) | (int) num91 << 26) ^ ((int) (num91 >> 11) | (int) num91 << 21) ^ ((int) (num91 >> 25) | (int) num91 << 7)) + ((int) num81 ^ (int) num91 & ((int) num86 ^ (int) num81)) - 272742522) + (num93 = num13 + (uint) ((((int) (num83 >> 17) | (int) num83 << 15) ^ ((int) (num83 >> 19) | (int) num83 << 13) ^ (int) (num83 >> 10)) + (int) num58 + (((int) (num18 >> 7) | (int) num18 << 25) ^ ((int) (num18 >> 18) | (int) num18 << 14) ^ (int) (num18 >> 3))));
      uint num95 = (uint) ((((int) (num92 >> 2) | (int) num92 << 30) ^ ((int) (num92 >> 13) | (int) num92 << 19) ^ ((int) (num92 >> 22) | (int) num92 << 10)) + ((int) num92 & (int) num87 | (int) num82 & ((int) num92 | (int) num87)));
      uint num96 = num77 + num94;
      uint num97 = num94 + num95;
      uint num98;
      uint num99 = (uint) ((int) num81 + (((int) (num96 >> 6) | (int) num96 << 26) ^ ((int) (num96 >> 11) | (int) num96 << 21) ^ ((int) (num96 >> 25) | (int) num96 << 7)) + ((int) num86 ^ (int) num96 & ((int) num91 ^ (int) num86)) + 264347078) + (num98 = num18 + (uint) ((((int) (num88 >> 17) | (int) num88 << 15) ^ ((int) (num88 >> 19) | (int) num88 << 13) ^ (int) (num88 >> 10)) + (int) num63 + (((int) (num23 >> 7) | (int) num23 << 25) ^ ((int) (num23 >> 18) | (int) num23 << 14) ^ (int) (num23 >> 3))));
      uint num100 = (uint) ((((int) (num97 >> 2) | (int) num97 << 30) ^ ((int) (num97 >> 13) | (int) num97 << 19) ^ ((int) (num97 >> 22) | (int) num97 << 10)) + ((int) num97 & (int) num92 | (int) num87 & ((int) num97 | (int) num92)));
      uint num101 = num82 + num99;
      uint num102 = num99 + num100;
      uint num103;
      uint num104 = (uint) ((int) num86 + (((int) (num101 >> 6) | (int) num101 << 26) ^ ((int) (num101 >> 11) | (int) num101 << 21) ^ ((int) (num101 >> 25) | (int) num101 << 7)) + ((int) num91 ^ (int) num101 & ((int) num96 ^ (int) num91)) + 604807628) + (num103 = num23 + (uint) ((((int) (num93 >> 17) | (int) num93 << 15) ^ ((int) (num93 >> 19) | (int) num93 << 13) ^ (int) (num93 >> 10)) + (int) num68 + (((int) (num28 >> 7) | (int) num28 << 25) ^ ((int) (num28 >> 18) | (int) num28 << 14) ^ (int) (num28 >> 3))));
      uint num105 = (uint) ((((int) (num102 >> 2) | (int) num102 << 30) ^ ((int) (num102 >> 13) | (int) num102 << 19) ^ ((int) (num102 >> 22) | (int) num102 << 10)) + ((int) num102 & (int) num97 | (int) num92 & ((int) num102 | (int) num97)));
      uint num106 = num87 + num104;
      uint num107 = num104 + num105;
      uint num108;
      uint num109 = (uint) ((int) num91 + (((int) (num106 >> 6) | (int) num106 << 26) ^ ((int) (num106 >> 11) | (int) num106 << 21) ^ ((int) (num106 >> 25) | (int) num106 << 7)) + ((int) num96 ^ (int) num106 & ((int) num101 ^ (int) num96)) + 770255983) + (num108 = num28 + (uint) ((((int) (num98 >> 17) | (int) num98 << 15) ^ ((int) (num98 >> 19) | (int) num98 << 13) ^ (int) (num98 >> 10)) + (int) num73 + (((int) (num33 >> 7) | (int) num33 << 25) ^ ((int) (num33 >> 18) | (int) num33 << 14) ^ (int) (num33 >> 3))));
      uint num110 = (uint) ((((int) (num107 >> 2) | (int) num107 << 30) ^ ((int) (num107 >> 13) | (int) num107 << 19) ^ ((int) (num107 >> 22) | (int) num107 << 10)) + ((int) num107 & (int) num102 | (int) num97 & ((int) num107 | (int) num102)));
      uint num111 = num92 + num109;
      uint num112 = num109 + num110;
      uint num113;
      uint num114 = (uint) ((int) num96 + (((int) (num111 >> 6) | (int) num111 << 26) ^ ((int) (num111 >> 11) | (int) num111 << 21) ^ ((int) (num111 >> 25) | (int) num111 << 7)) + ((int) num101 ^ (int) num111 & ((int) num106 ^ (int) num101)) + 1249150122) + (num113 = num33 + (uint) ((((int) (num103 >> 17) | (int) num103 << 15) ^ ((int) (num103 >> 19) | (int) num103 << 13) ^ (int) (num103 >> 10)) + (int) num78 + (((int) (num38 >> 7) | (int) num38 << 25) ^ ((int) (num38 >> 18) | (int) num38 << 14) ^ (int) (num38 >> 3))));
      uint num115 = (uint) ((((int) (num112 >> 2) | (int) num112 << 30) ^ ((int) (num112 >> 13) | (int) num112 << 19) ^ ((int) (num112 >> 22) | (int) num112 << 10)) + ((int) num112 & (int) num107 | (int) num102 & ((int) num112 | (int) num107)));
      uint num116 = num97 + num114;
      uint num117 = num114 + num115;
      uint num118;
      uint num119 = (uint) ((int) num101 + (((int) (num116 >> 6) | (int) num116 << 26) ^ ((int) (num116 >> 11) | (int) num116 << 21) ^ ((int) (num116 >> 25) | (int) num116 << 7)) + ((int) num106 ^ (int) num116 & ((int) num111 ^ (int) num106)) + 1555081692) + (num118 = num38 + (uint) ((((int) (num108 >> 17) | (int) num108 << 15) ^ ((int) (num108 >> 19) | (int) num108 << 13) ^ (int) (num108 >> 10)) + (int) num83 + (((int) (num43 >> 7) | (int) num43 << 25) ^ ((int) (num43 >> 18) | (int) num43 << 14) ^ (int) (num43 >> 3))));
      uint num120 = (uint) ((((int) (num117 >> 2) | (int) num117 << 30) ^ ((int) (num117 >> 13) | (int) num117 << 19) ^ ((int) (num117 >> 22) | (int) num117 << 10)) + ((int) num117 & (int) num112 | (int) num107 & ((int) num117 | (int) num112)));
      uint num121 = num102 + num119;
      uint num122 = num119 + num120;
      uint num123;
      uint num124 = (uint) ((int) num106 + (((int) (num121 >> 6) | (int) num121 << 26) ^ ((int) (num121 >> 11) | (int) num121 << 21) ^ ((int) (num121 >> 25) | (int) num121 << 7)) + ((int) num111 ^ (int) num121 & ((int) num116 ^ (int) num111)) + 1996064986) + (num123 = num43 + (uint) ((((int) (num113 >> 17) | (int) num113 << 15) ^ ((int) (num113 >> 19) | (int) num113 << 13) ^ (int) (num113 >> 10)) + (int) num88 + (((int) (num48 >> 7) | (int) num48 << 25) ^ ((int) (num48 >> 18) | (int) num48 << 14) ^ (int) (num48 >> 3))));
      uint num125 = (uint) ((((int) (num122 >> 2) | (int) num122 << 30) ^ ((int) (num122 >> 13) | (int) num122 << 19) ^ ((int) (num122 >> 22) | (int) num122 << 10)) + ((int) num122 & (int) num117 | (int) num112 & ((int) num122 | (int) num117)));
      uint num126 = num107 + num124;
      uint num127 = num124 + num125;
      uint num128;
      uint num129 = (uint) ((int) num111 + (((int) (num126 >> 6) | (int) num126 << 26) ^ ((int) (num126 >> 11) | (int) num126 << 21) ^ ((int) (num126 >> 25) | (int) num126 << 7)) + ((int) num116 ^ (int) num126 & ((int) num121 ^ (int) num116)) - 1740746414) + (num128 = num48 + (uint) ((((int) (num118 >> 17) | (int) num118 << 15) ^ ((int) (num118 >> 19) | (int) num118 << 13) ^ (int) (num118 >> 10)) + (int) num93 + (((int) (num53 >> 7) | (int) num53 << 25) ^ ((int) (num53 >> 18) | (int) num53 << 14) ^ (int) (num53 >> 3))));
      uint num130 = (uint) ((((int) (num127 >> 2) | (int) num127 << 30) ^ ((int) (num127 >> 13) | (int) num127 << 19) ^ ((int) (num127 >> 22) | (int) num127 << 10)) + ((int) num127 & (int) num122 | (int) num117 & ((int) num127 | (int) num122)));
      uint num131 = num112 + num129;
      uint num132 = num129 + num130;
      uint num133;
      uint num134 = (uint) ((int) num116 + (((int) (num131 >> 6) | (int) num131 << 26) ^ ((int) (num131 >> 11) | (int) num131 << 21) ^ ((int) (num131 >> 25) | (int) num131 << 7)) + ((int) num121 ^ (int) num131 & ((int) num126 ^ (int) num121)) - 1473132947) + (num133 = num53 + (uint) ((((int) (num123 >> 17) | (int) num123 << 15) ^ ((int) (num123 >> 19) | (int) num123 << 13) ^ (int) (num123 >> 10)) + (int) num98 + (((int) (num58 >> 7) | (int) num58 << 25) ^ ((int) (num58 >> 18) | (int) num58 << 14) ^ (int) (num58 >> 3))));
      uint num135 = (uint) ((((int) (num132 >> 2) | (int) num132 << 30) ^ ((int) (num132 >> 13) | (int) num132 << 19) ^ ((int) (num132 >> 22) | (int) num132 << 10)) + ((int) num132 & (int) num127 | (int) num122 & ((int) num132 | (int) num127)));
      uint num136 = num117 + num134;
      uint num137 = num134 + num135;
      uint num138;
      uint num139 = (uint) ((int) num121 + (((int) (num136 >> 6) | (int) num136 << 26) ^ ((int) (num136 >> 11) | (int) num136 << 21) ^ ((int) (num136 >> 25) | (int) num136 << 7)) + ((int) num126 ^ (int) num136 & ((int) num131 ^ (int) num126)) - 1341970488) + (num138 = num58 + (uint) ((((int) (num128 >> 17) | (int) num128 << 15) ^ ((int) (num128 >> 19) | (int) num128 << 13) ^ (int) (num128 >> 10)) + (int) num103 + (((int) (num63 >> 7) | (int) num63 << 25) ^ ((int) (num63 >> 18) | (int) num63 << 14) ^ (int) (num63 >> 3))));
      uint num140 = (uint) ((((int) (num137 >> 2) | (int) num137 << 30) ^ ((int) (num137 >> 13) | (int) num137 << 19) ^ ((int) (num137 >> 22) | (int) num137 << 10)) + ((int) num137 & (int) num132 | (int) num127 & ((int) num137 | (int) num132)));
      uint num141 = num122 + num139;
      uint num142 = num139 + num140;
      uint num143;
      uint num144 = (uint) ((int) num126 + (((int) (num141 >> 6) | (int) num141 << 26) ^ ((int) (num141 >> 11) | (int) num141 << 21) ^ ((int) (num141 >> 25) | (int) num141 << 7)) + ((int) num131 ^ (int) num141 & ((int) num136 ^ (int) num131)) - 1084653625) + (num143 = num63 + (uint) ((((int) (num133 >> 17) | (int) num133 << 15) ^ ((int) (num133 >> 19) | (int) num133 << 13) ^ (int) (num133 >> 10)) + (int) num108 + (((int) (num68 >> 7) | (int) num68 << 25) ^ ((int) (num68 >> 18) | (int) num68 << 14) ^ (int) (num68 >> 3))));
      uint num145 = (uint) ((((int) (num142 >> 2) | (int) num142 << 30) ^ ((int) (num142 >> 13) | (int) num142 << 19) ^ ((int) (num142 >> 22) | (int) num142 << 10)) + ((int) num142 & (int) num137 | (int) num132 & ((int) num142 | (int) num137)));
      uint num146 = num127 + num144;
      uint num147 = num144 + num145;
      uint num148;
      uint num149 = (uint) ((int) num131 + (((int) (num146 >> 6) | (int) num146 << 26) ^ ((int) (num146 >> 11) | (int) num146 << 21) ^ ((int) (num146 >> 25) | (int) num146 << 7)) + ((int) num136 ^ (int) num146 & ((int) num141 ^ (int) num136)) - 958395405) + (num148 = num68 + (uint) ((((int) (num138 >> 17) | (int) num138 << 15) ^ ((int) (num138 >> 19) | (int) num138 << 13) ^ (int) (num138 >> 10)) + (int) num113 + (((int) (num73 >> 7) | (int) num73 << 25) ^ ((int) (num73 >> 18) | (int) num73 << 14) ^ (int) (num73 >> 3))));
      uint num150 = (uint) ((((int) (num147 >> 2) | (int) num147 << 30) ^ ((int) (num147 >> 13) | (int) num147 << 19) ^ ((int) (num147 >> 22) | (int) num147 << 10)) + ((int) num147 & (int) num142 | (int) num137 & ((int) num147 | (int) num142)));
      uint num151 = num132 + num149;
      uint num152 = num149 + num150;
      uint num153;
      uint num154 = (uint) ((int) num136 + (((int) (num151 >> 6) | (int) num151 << 26) ^ ((int) (num151 >> 11) | (int) num151 << 21) ^ ((int) (num151 >> 25) | (int) num151 << 7)) + ((int) num141 ^ (int) num151 & ((int) num146 ^ (int) num141)) - 710438585) + (num153 = num73 + (uint) ((((int) (num143 >> 17) | (int) num143 << 15) ^ ((int) (num143 >> 19) | (int) num143 << 13) ^ (int) (num143 >> 10)) + (int) num118 + (((int) (num78 >> 7) | (int) num78 << 25) ^ ((int) (num78 >> 18) | (int) num78 << 14) ^ (int) (num78 >> 3))));
      uint num155 = (uint) ((((int) (num152 >> 2) | (int) num152 << 30) ^ ((int) (num152 >> 13) | (int) num152 << 19) ^ ((int) (num152 >> 22) | (int) num152 << 10)) + ((int) num152 & (int) num147 | (int) num142 & ((int) num152 | (int) num147)));
      uint num156 = num137 + num154;
      uint num157 = num154 + num155;
      uint num158;
      uint num159 = (uint) ((int) num141 + (((int) (num156 >> 6) | (int) num156 << 26) ^ ((int) (num156 >> 11) | (int) num156 << 21) ^ ((int) (num156 >> 25) | (int) num156 << 7)) + ((int) num146 ^ (int) num156 & ((int) num151 ^ (int) num146)) + 113926993) + (num158 = num78 + (uint) ((((int) (num148 >> 17) | (int) num148 << 15) ^ ((int) (num148 >> 19) | (int) num148 << 13) ^ (int) (num148 >> 10)) + (int) num123 + (((int) (num83 >> 7) | (int) num83 << 25) ^ ((int) (num83 >> 18) | (int) num83 << 14) ^ (int) (num83 >> 3))));
      uint num160 = (uint) ((((int) (num157 >> 2) | (int) num157 << 30) ^ ((int) (num157 >> 13) | (int) num157 << 19) ^ ((int) (num157 >> 22) | (int) num157 << 10)) + ((int) num157 & (int) num152 | (int) num147 & ((int) num157 | (int) num152)));
      uint num161 = num142 + num159;
      uint num162 = num159 + num160;
      uint num163;
      uint num164 = (uint) ((int) num146 + (((int) (num161 >> 6) | (int) num161 << 26) ^ ((int) (num161 >> 11) | (int) num161 << 21) ^ ((int) (num161 >> 25) | (int) num161 << 7)) + ((int) num151 ^ (int) num161 & ((int) num156 ^ (int) num151)) + 338241895) + (num163 = num83 + (uint) ((((int) (num153 >> 17) | (int) num153 << 15) ^ ((int) (num153 >> 19) | (int) num153 << 13) ^ (int) (num153 >> 10)) + (int) num128 + (((int) (num88 >> 7) | (int) num88 << 25) ^ ((int) (num88 >> 18) | (int) num88 << 14) ^ (int) (num88 >> 3))));
      uint num165 = (uint) ((((int) (num162 >> 2) | (int) num162 << 30) ^ ((int) (num162 >> 13) | (int) num162 << 19) ^ ((int) (num162 >> 22) | (int) num162 << 10)) + ((int) num162 & (int) num157 | (int) num152 & ((int) num162 | (int) num157)));
      uint num166 = num147 + num164;
      uint num167 = num164 + num165;
      uint num168;
      uint num169 = (uint) ((int) num151 + (((int) (num166 >> 6) | (int) num166 << 26) ^ ((int) (num166 >> 11) | (int) num166 << 21) ^ ((int) (num166 >> 25) | (int) num166 << 7)) + ((int) num156 ^ (int) num166 & ((int) num161 ^ (int) num156)) + 666307205) + (num168 = num88 + (uint) ((((int) (num158 >> 17) | (int) num158 << 15) ^ ((int) (num158 >> 19) | (int) num158 << 13) ^ (int) (num158 >> 10)) + (int) num133 + (((int) (num93 >> 7) | (int) num93 << 25) ^ ((int) (num93 >> 18) | (int) num93 << 14) ^ (int) (num93 >> 3))));
      uint num170 = (uint) ((((int) (num167 >> 2) | (int) num167 << 30) ^ ((int) (num167 >> 13) | (int) num167 << 19) ^ ((int) (num167 >> 22) | (int) num167 << 10)) + ((int) num167 & (int) num162 | (int) num157 & ((int) num167 | (int) num162)));
      uint num171 = num152 + num169;
      uint num172 = num169 + num170;
      uint num173;
      uint num174 = (uint) ((int) num156 + (((int) (num171 >> 6) | (int) num171 << 26) ^ ((int) (num171 >> 11) | (int) num171 << 21) ^ ((int) (num171 >> 25) | (int) num171 << 7)) + ((int) num161 ^ (int) num171 & ((int) num166 ^ (int) num161)) + 773529912) + (num173 = num93 + (uint) ((((int) (num163 >> 17) | (int) num163 << 15) ^ ((int) (num163 >> 19) | (int) num163 << 13) ^ (int) (num163 >> 10)) + (int) num138 + (((int) (num98 >> 7) | (int) num98 << 25) ^ ((int) (num98 >> 18) | (int) num98 << 14) ^ (int) (num98 >> 3))));
      uint num175 = (uint) ((((int) (num172 >> 2) | (int) num172 << 30) ^ ((int) (num172 >> 13) | (int) num172 << 19) ^ ((int) (num172 >> 22) | (int) num172 << 10)) + ((int) num172 & (int) num167 | (int) num162 & ((int) num172 | (int) num167)));
      uint num176 = num157 + num174;
      uint num177 = num174 + num175;
      uint num178;
      uint num179 = (uint) ((int) num161 + (((int) (num176 >> 6) | (int) num176 << 26) ^ ((int) (num176 >> 11) | (int) num176 << 21) ^ ((int) (num176 >> 25) | (int) num176 << 7)) + ((int) num166 ^ (int) num176 & ((int) num171 ^ (int) num166)) + 1294757372) + (num178 = num98 + (uint) ((((int) (num168 >> 17) | (int) num168 << 15) ^ ((int) (num168 >> 19) | (int) num168 << 13) ^ (int) (num168 >> 10)) + (int) num143 + (((int) (num103 >> 7) | (int) num103 << 25) ^ ((int) (num103 >> 18) | (int) num103 << 14) ^ (int) (num103 >> 3))));
      uint num180 = (uint) ((((int) (num177 >> 2) | (int) num177 << 30) ^ ((int) (num177 >> 13) | (int) num177 << 19) ^ ((int) (num177 >> 22) | (int) num177 << 10)) + ((int) num177 & (int) num172 | (int) num167 & ((int) num177 | (int) num172)));
      uint num181 = num162 + num179;
      uint num182 = num179 + num180;
      uint num183;
      uint num184 = (uint) ((int) num166 + (((int) (num181 >> 6) | (int) num181 << 26) ^ ((int) (num181 >> 11) | (int) num181 << 21) ^ ((int) (num181 >> 25) | (int) num181 << 7)) + ((int) num171 ^ (int) num181 & ((int) num176 ^ (int) num171)) + 1396182291) + (num183 = num103 + (uint) ((((int) (num173 >> 17) | (int) num173 << 15) ^ ((int) (num173 >> 19) | (int) num173 << 13) ^ (int) (num173 >> 10)) + (int) num148 + (((int) (num108 >> 7) | (int) num108 << 25) ^ ((int) (num108 >> 18) | (int) num108 << 14) ^ (int) (num108 >> 3))));
      uint num185 = (uint) ((((int) (num182 >> 2) | (int) num182 << 30) ^ ((int) (num182 >> 13) | (int) num182 << 19) ^ ((int) (num182 >> 22) | (int) num182 << 10)) + ((int) num182 & (int) num177 | (int) num172 & ((int) num182 | (int) num177)));
      uint num186 = num167 + num184;
      uint num187 = num184 + num185;
      uint num188;
      uint num189 = (uint) ((int) num171 + (((int) (num186 >> 6) | (int) num186 << 26) ^ ((int) (num186 >> 11) | (int) num186 << 21) ^ ((int) (num186 >> 25) | (int) num186 << 7)) + ((int) num176 ^ (int) num186 & ((int) num181 ^ (int) num176)) + 1695183700) + (num188 = num108 + (uint) ((((int) (num178 >> 17) | (int) num178 << 15) ^ ((int) (num178 >> 19) | (int) num178 << 13) ^ (int) (num178 >> 10)) + (int) num153 + (((int) (num113 >> 7) | (int) num113 << 25) ^ ((int) (num113 >> 18) | (int) num113 << 14) ^ (int) (num113 >> 3))));
      uint num190 = (uint) ((((int) (num187 >> 2) | (int) num187 << 30) ^ ((int) (num187 >> 13) | (int) num187 << 19) ^ ((int) (num187 >> 22) | (int) num187 << 10)) + ((int) num187 & (int) num182 | (int) num177 & ((int) num187 | (int) num182)));
      uint num191 = num172 + num189;
      uint num192 = num189 + num190;
      uint num193;
      uint num194 = (uint) ((int) num176 + (((int) (num191 >> 6) | (int) num191 << 26) ^ ((int) (num191 >> 11) | (int) num191 << 21) ^ ((int) (num191 >> 25) | (int) num191 << 7)) + ((int) num181 ^ (int) num191 & ((int) num186 ^ (int) num181)) + 1986661051) + (num193 = num113 + (uint) ((((int) (num183 >> 17) | (int) num183 << 15) ^ ((int) (num183 >> 19) | (int) num183 << 13) ^ (int) (num183 >> 10)) + (int) num158 + (((int) (num118 >> 7) | (int) num118 << 25) ^ ((int) (num118 >> 18) | (int) num118 << 14) ^ (int) (num118 >> 3))));
      uint num195 = (uint) ((((int) (num192 >> 2) | (int) num192 << 30) ^ ((int) (num192 >> 13) | (int) num192 << 19) ^ ((int) (num192 >> 22) | (int) num192 << 10)) + ((int) num192 & (int) num187 | (int) num182 & ((int) num192 | (int) num187)));
      uint num196 = num177 + num194;
      uint num197 = num194 + num195;
      uint num198;
      uint num199 = (uint) ((int) num181 + (((int) (num196 >> 6) | (int) num196 << 26) ^ ((int) (num196 >> 11) | (int) num196 << 21) ^ ((int) (num196 >> 25) | (int) num196 << 7)) + ((int) num186 ^ (int) num196 & ((int) num191 ^ (int) num186)) - 2117940946) + (num198 = num118 + (uint) ((((int) (num188 >> 17) | (int) num188 << 15) ^ ((int) (num188 >> 19) | (int) num188 << 13) ^ (int) (num188 >> 10)) + (int) num163 + (((int) (num123 >> 7) | (int) num123 << 25) ^ ((int) (num123 >> 18) | (int) num123 << 14) ^ (int) (num123 >> 3))));
      uint num200 = (uint) ((((int) (num197 >> 2) | (int) num197 << 30) ^ ((int) (num197 >> 13) | (int) num197 << 19) ^ ((int) (num197 >> 22) | (int) num197 << 10)) + ((int) num197 & (int) num192 | (int) num187 & ((int) num197 | (int) num192)));
      uint num201 = num182 + num199;
      uint num202 = num199 + num200;
      uint num203;
      uint num204 = (uint) ((int) num186 + (((int) (num201 >> 6) | (int) num201 << 26) ^ ((int) (num201 >> 11) | (int) num201 << 21) ^ ((int) (num201 >> 25) | (int) num201 << 7)) + ((int) num191 ^ (int) num201 & ((int) num196 ^ (int) num191)) - 1838011259) + (num203 = num123 + (uint) ((((int) (num193 >> 17) | (int) num193 << 15) ^ ((int) (num193 >> 19) | (int) num193 << 13) ^ (int) (num193 >> 10)) + (int) num168 + (((int) (num128 >> 7) | (int) num128 << 25) ^ ((int) (num128 >> 18) | (int) num128 << 14) ^ (int) (num128 >> 3))));
      uint num205 = (uint) ((((int) (num202 >> 2) | (int) num202 << 30) ^ ((int) (num202 >> 13) | (int) num202 << 19) ^ ((int) (num202 >> 22) | (int) num202 << 10)) + ((int) num202 & (int) num197 | (int) num192 & ((int) num202 | (int) num197)));
      uint num206 = num187 + num204;
      uint num207 = num204 + num205;
      uint num208;
      uint num209 = (uint) ((int) num191 + (((int) (num206 >> 6) | (int) num206 << 26) ^ ((int) (num206 >> 11) | (int) num206 << 21) ^ ((int) (num206 >> 25) | (int) num206 << 7)) + ((int) num196 ^ (int) num206 & ((int) num201 ^ (int) num196)) - 1564481375) + (num208 = num128 + (uint) ((((int) (num198 >> 17) | (int) num198 << 15) ^ ((int) (num198 >> 19) | (int) num198 << 13) ^ (int) (num198 >> 10)) + (int) num173 + (((int) (num133 >> 7) | (int) num133 << 25) ^ ((int) (num133 >> 18) | (int) num133 << 14) ^ (int) (num133 >> 3))));
      uint num210 = (uint) ((((int) (num207 >> 2) | (int) num207 << 30) ^ ((int) (num207 >> 13) | (int) num207 << 19) ^ ((int) (num207 >> 22) | (int) num207 << 10)) + ((int) num207 & (int) num202 | (int) num197 & ((int) num207 | (int) num202)));
      uint num211 = num192 + num209;
      uint num212 = num209 + num210;
      uint num213;
      uint num214 = (uint) ((int) num196 + (((int) (num211 >> 6) | (int) num211 << 26) ^ ((int) (num211 >> 11) | (int) num211 << 21) ^ ((int) (num211 >> 25) | (int) num211 << 7)) + ((int) num201 ^ (int) num211 & ((int) num206 ^ (int) num201)) - 1474664885) + (num213 = num133 + (uint) ((((int) (num203 >> 17) | (int) num203 << 15) ^ ((int) (num203 >> 19) | (int) num203 << 13) ^ (int) (num203 >> 10)) + (int) num178 + (((int) (num138 >> 7) | (int) num138 << 25) ^ ((int) (num138 >> 18) | (int) num138 << 14) ^ (int) (num138 >> 3))));
      uint num215 = (uint) ((((int) (num212 >> 2) | (int) num212 << 30) ^ ((int) (num212 >> 13) | (int) num212 << 19) ^ ((int) (num212 >> 22) | (int) num212 << 10)) + ((int) num212 & (int) num207 | (int) num202 & ((int) num212 | (int) num207)));
      uint num216 = num197 + num214;
      uint num217 = num214 + num215;
      uint num218;
      uint num219 = (uint) ((int) num201 + (((int) (num216 >> 6) | (int) num216 << 26) ^ ((int) (num216 >> 11) | (int) num216 << 21) ^ ((int) (num216 >> 25) | (int) num216 << 7)) + ((int) num206 ^ (int) num216 & ((int) num211 ^ (int) num206)) - 1035236496) + (num218 = num138 + (uint) ((((int) (num208 >> 17) | (int) num208 << 15) ^ ((int) (num208 >> 19) | (int) num208 << 13) ^ (int) (num208 >> 10)) + (int) num183 + (((int) (num143 >> 7) | (int) num143 << 25) ^ ((int) (num143 >> 18) | (int) num143 << 14) ^ (int) (num143 >> 3))));
      uint num220 = (uint) ((((int) (num217 >> 2) | (int) num217 << 30) ^ ((int) (num217 >> 13) | (int) num217 << 19) ^ ((int) (num217 >> 22) | (int) num217 << 10)) + ((int) num217 & (int) num212 | (int) num207 & ((int) num217 | (int) num212)));
      uint num221 = num202 + num219;
      uint num222 = num219 + num220;
      uint num223;
      uint num224 = (uint) ((int) num206 + (((int) (num221 >> 6) | (int) num221 << 26) ^ ((int) (num221 >> 11) | (int) num221 << 21) ^ ((int) (num221 >> 25) | (int) num221 << 7)) + ((int) num211 ^ (int) num221 & ((int) num216 ^ (int) num211)) - 949202525) + (num223 = num143 + (uint) ((((int) (num213 >> 17) | (int) num213 << 15) ^ ((int) (num213 >> 19) | (int) num213 << 13) ^ (int) (num213 >> 10)) + (int) num188 + (((int) (num148 >> 7) | (int) num148 << 25) ^ ((int) (num148 >> 18) | (int) num148 << 14) ^ (int) (num148 >> 3))));
      uint num225 = (uint) ((((int) (num222 >> 2) | (int) num222 << 30) ^ ((int) (num222 >> 13) | (int) num222 << 19) ^ ((int) (num222 >> 22) | (int) num222 << 10)) + ((int) num222 & (int) num217 | (int) num212 & ((int) num222 | (int) num217)));
      uint num226 = num207 + num224;
      uint num227 = num224 + num225;
      uint num228;
      uint num229 = (uint) ((int) num211 + (((int) (num226 >> 6) | (int) num226 << 26) ^ ((int) (num226 >> 11) | (int) num226 << 21) ^ ((int) (num226 >> 25) | (int) num226 << 7)) + ((int) num216 ^ (int) num226 & ((int) num221 ^ (int) num216)) - 778901479) + (num228 = num148 + (uint) ((((int) (num218 >> 17) | (int) num218 << 15) ^ ((int) (num218 >> 19) | (int) num218 << 13) ^ (int) (num218 >> 10)) + (int) num193 + (((int) (num153 >> 7) | (int) num153 << 25) ^ ((int) (num153 >> 18) | (int) num153 << 14) ^ (int) (num153 >> 3))));
      uint num230 = (uint) ((((int) (num227 >> 2) | (int) num227 << 30) ^ ((int) (num227 >> 13) | (int) num227 << 19) ^ ((int) (num227 >> 22) | (int) num227 << 10)) + ((int) num227 & (int) num222 | (int) num217 & ((int) num227 | (int) num222)));
      uint num231 = num212 + num229;
      uint num232 = num229 + num230;
      uint num233;
      uint num234 = (uint) ((int) num216 + (((int) (num231 >> 6) | (int) num231 << 26) ^ ((int) (num231 >> 11) | (int) num231 << 21) ^ ((int) (num231 >> 25) | (int) num231 << 7)) + ((int) num221 ^ (int) num231 & ((int) num226 ^ (int) num221)) - 694614492) + (num233 = num153 + (uint) ((((int) (num223 >> 17) | (int) num223 << 15) ^ ((int) (num223 >> 19) | (int) num223 << 13) ^ (int) (num223 >> 10)) + (int) num198 + (((int) (num158 >> 7) | (int) num158 << 25) ^ ((int) (num158 >> 18) | (int) num158 << 14) ^ (int) (num158 >> 3))));
      uint num235 = (uint) ((((int) (num232 >> 2) | (int) num232 << 30) ^ ((int) (num232 >> 13) | (int) num232 << 19) ^ ((int) (num232 >> 22) | (int) num232 << 10)) + ((int) num232 & (int) num227 | (int) num222 & ((int) num232 | (int) num227)));
      uint num236 = num217 + num234;
      uint num237 = num234 + num235;
      uint num238;
      uint num239 = (uint) ((int) num221 + (((int) (num236 >> 6) | (int) num236 << 26) ^ ((int) (num236 >> 11) | (int) num236 << 21) ^ ((int) (num236 >> 25) | (int) num236 << 7)) + ((int) num226 ^ (int) num236 & ((int) num231 ^ (int) num226)) - 200395387) + (num238 = num158 + (uint) ((((int) (num228 >> 17) | (int) num228 << 15) ^ ((int) (num228 >> 19) | (int) num228 << 13) ^ (int) (num228 >> 10)) + (int) num203 + (((int) (num163 >> 7) | (int) num163 << 25) ^ ((int) (num163 >> 18) | (int) num163 << 14) ^ (int) (num163 >> 3))));
      uint num240 = (uint) ((((int) (num237 >> 2) | (int) num237 << 30) ^ ((int) (num237 >> 13) | (int) num237 << 19) ^ ((int) (num237 >> 22) | (int) num237 << 10)) + ((int) num237 & (int) num232 | (int) num227 & ((int) num237 | (int) num232)));
      uint num241 = num222 + num239;
      uint num242 = num239 + num240;
      uint num243;
      uint num244 = (uint) ((int) num226 + (((int) (num241 >> 6) | (int) num241 << 26) ^ ((int) (num241 >> 11) | (int) num241 << 21) ^ ((int) (num241 >> 25) | (int) num241 << 7)) + ((int) num231 ^ (int) num241 & ((int) num236 ^ (int) num231)) + 275423344) + (num243 = num163 + (uint) ((((int) (num233 >> 17) | (int) num233 << 15) ^ ((int) (num233 >> 19) | (int) num233 << 13) ^ (int) (num233 >> 10)) + (int) num208 + (((int) (num168 >> 7) | (int) num168 << 25) ^ ((int) (num168 >> 18) | (int) num168 << 14) ^ (int) (num168 >> 3))));
      uint num245 = (uint) ((((int) (num242 >> 2) | (int) num242 << 30) ^ ((int) (num242 >> 13) | (int) num242 << 19) ^ ((int) (num242 >> 22) | (int) num242 << 10)) + ((int) num242 & (int) num237 | (int) num232 & ((int) num242 | (int) num237)));
      uint num246 = num227 + num244;
      uint num247 = num244 + num245;
      uint num248;
      uint num249 = (uint) ((int) num231 + (((int) (num246 >> 6) | (int) num246 << 26) ^ ((int) (num246 >> 11) | (int) num246 << 21) ^ ((int) (num246 >> 25) | (int) num246 << 7)) + ((int) num236 ^ (int) num246 & ((int) num241 ^ (int) num236)) + 430227734) + (num248 = num168 + (uint) ((((int) (num238 >> 17) | (int) num238 << 15) ^ ((int) (num238 >> 19) | (int) num238 << 13) ^ (int) (num238 >> 10)) + (int) num213 + (((int) (num173 >> 7) | (int) num173 << 25) ^ ((int) (num173 >> 18) | (int) num173 << 14) ^ (int) (num173 >> 3))));
      uint num250 = (uint) ((((int) (num247 >> 2) | (int) num247 << 30) ^ ((int) (num247 >> 13) | (int) num247 << 19) ^ ((int) (num247 >> 22) | (int) num247 << 10)) + ((int) num247 & (int) num242 | (int) num237 & ((int) num247 | (int) num242)));
      uint num251 = num232 + num249;
      uint num252 = num249 + num250;
      uint num253;
      uint num254 = (uint) ((int) num236 + (((int) (num251 >> 6) | (int) num251 << 26) ^ ((int) (num251 >> 11) | (int) num251 << 21) ^ ((int) (num251 >> 25) | (int) num251 << 7)) + ((int) num241 ^ (int) num251 & ((int) num246 ^ (int) num241)) + 506948616) + (num253 = num173 + (uint) ((((int) (num243 >> 17) | (int) num243 << 15) ^ ((int) (num243 >> 19) | (int) num243 << 13) ^ (int) (num243 >> 10)) + (int) num218 + (((int) (num178 >> 7) | (int) num178 << 25) ^ ((int) (num178 >> 18) | (int) num178 << 14) ^ (int) (num178 >> 3))));
      uint num255 = (uint) ((((int) (num252 >> 2) | (int) num252 << 30) ^ ((int) (num252 >> 13) | (int) num252 << 19) ^ ((int) (num252 >> 22) | (int) num252 << 10)) + ((int) num252 & (int) num247 | (int) num242 & ((int) num252 | (int) num247)));
      uint num256 = num237 + num254;
      uint num257 = num254 + num255;
      uint num258;
      uint num259 = (uint) ((int) num241 + (((int) (num256 >> 6) | (int) num256 << 26) ^ ((int) (num256 >> 11) | (int) num256 << 21) ^ ((int) (num256 >> 25) | (int) num256 << 7)) + ((int) num246 ^ (int) num256 & ((int) num251 ^ (int) num246)) + 659060556) + (num258 = num178 + (uint) ((((int) (num248 >> 17) | (int) num248 << 15) ^ ((int) (num248 >> 19) | (int) num248 << 13) ^ (int) (num248 >> 10)) + (int) num223 + (((int) (num183 >> 7) | (int) num183 << 25) ^ ((int) (num183 >> 18) | (int) num183 << 14) ^ (int) (num183 >> 3))));
      uint num260 = (uint) ((((int) (num257 >> 2) | (int) num257 << 30) ^ ((int) (num257 >> 13) | (int) num257 << 19) ^ ((int) (num257 >> 22) | (int) num257 << 10)) + ((int) num257 & (int) num252 | (int) num247 & ((int) num257 | (int) num252)));
      uint num261 = num242 + num259;
      uint num262 = num259 + num260;
      uint num263;
      uint num264 = (uint) ((int) num246 + (((int) (num261 >> 6) | (int) num261 << 26) ^ ((int) (num261 >> 11) | (int) num261 << 21) ^ ((int) (num261 >> 25) | (int) num261 << 7)) + ((int) num251 ^ (int) num261 & ((int) num256 ^ (int) num251)) + 883997877) + (num263 = num183 + (uint) ((((int) (num253 >> 17) | (int) num253 << 15) ^ ((int) (num253 >> 19) | (int) num253 << 13) ^ (int) (num253 >> 10)) + (int) num228 + (((int) (num188 >> 7) | (int) num188 << 25) ^ ((int) (num188 >> 18) | (int) num188 << 14) ^ (int) (num188 >> 3))));
      uint num265 = (uint) ((((int) (num262 >> 2) | (int) num262 << 30) ^ ((int) (num262 >> 13) | (int) num262 << 19) ^ ((int) (num262 >> 22) | (int) num262 << 10)) + ((int) num262 & (int) num257 | (int) num252 & ((int) num262 | (int) num257)));
      uint num266 = num247 + num264;
      uint num267 = num264 + num265;
      uint num268;
      uint num269 = (uint) ((int) num251 + (((int) (num266 >> 6) | (int) num266 << 26) ^ ((int) (num266 >> 11) | (int) num266 << 21) ^ ((int) (num266 >> 25) | (int) num266 << 7)) + ((int) num256 ^ (int) num266 & ((int) num261 ^ (int) num256)) + 958139571) + (num268 = num188 + (uint) ((((int) (num258 >> 17) | (int) num258 << 15) ^ ((int) (num258 >> 19) | (int) num258 << 13) ^ (int) (num258 >> 10)) + (int) num233 + (((int) (num193 >> 7) | (int) num193 << 25) ^ ((int) (num193 >> 18) | (int) num193 << 14) ^ (int) (num193 >> 3))));
      uint num270 = (uint) ((((int) (num267 >> 2) | (int) num267 << 30) ^ ((int) (num267 >> 13) | (int) num267 << 19) ^ ((int) (num267 >> 22) | (int) num267 << 10)) + ((int) num267 & (int) num262 | (int) num257 & ((int) num267 | (int) num262)));
      uint num271 = num252 + num269;
      uint num272 = num269 + num270;
      uint num273;
      uint num274 = (uint) ((int) num256 + (((int) (num271 >> 6) | (int) num271 << 26) ^ ((int) (num271 >> 11) | (int) num271 << 21) ^ ((int) (num271 >> 25) | (int) num271 << 7)) + ((int) num261 ^ (int) num271 & ((int) num266 ^ (int) num261)) + 1322822218) + (num273 = num193 + (uint) ((((int) (num263 >> 17) | (int) num263 << 15) ^ ((int) (num263 >> 19) | (int) num263 << 13) ^ (int) (num263 >> 10)) + (int) num238 + (((int) (num198 >> 7) | (int) num198 << 25) ^ ((int) (num198 >> 18) | (int) num198 << 14) ^ (int) (num198 >> 3))));
      uint num275 = (uint) ((((int) (num272 >> 2) | (int) num272 << 30) ^ ((int) (num272 >> 13) | (int) num272 << 19) ^ ((int) (num272 >> 22) | (int) num272 << 10)) + ((int) num272 & (int) num267 | (int) num262 & ((int) num272 | (int) num267)));
      uint num276 = num257 + num274;
      uint num277 = num274 + num275;
      uint num278;
      uint num279 = (uint) ((int) num261 + (((int) (num276 >> 6) | (int) num276 << 26) ^ ((int) (num276 >> 11) | (int) num276 << 21) ^ ((int) (num276 >> 25) | (int) num276 << 7)) + ((int) num266 ^ (int) num276 & ((int) num271 ^ (int) num266)) + 1537002063) + (num278 = num198 + (uint) ((((int) (num268 >> 17) | (int) num268 << 15) ^ ((int) (num268 >> 19) | (int) num268 << 13) ^ (int) (num268 >> 10)) + (int) num243 + (((int) (num203 >> 7) | (int) num203 << 25) ^ ((int) (num203 >> 18) | (int) num203 << 14) ^ (int) (num203 >> 3))));
      uint num280 = (uint) ((((int) (num277 >> 2) | (int) num277 << 30) ^ ((int) (num277 >> 13) | (int) num277 << 19) ^ ((int) (num277 >> 22) | (int) num277 << 10)) + ((int) num277 & (int) num272 | (int) num267 & ((int) num277 | (int) num272)));
      uint num281 = num262 + num279;
      uint num282 = num279 + num280;
      uint num283;
      uint num284 = (uint) ((int) num266 + (((int) (num281 >> 6) | (int) num281 << 26) ^ ((int) (num281 >> 11) | (int) num281 << 21) ^ ((int) (num281 >> 25) | (int) num281 << 7)) + ((int) num271 ^ (int) num281 & ((int) num276 ^ (int) num271)) + 1747873779) + (num283 = num203 + (uint) ((((int) (num273 >> 17) | (int) num273 << 15) ^ ((int) (num273 >> 19) | (int) num273 << 13) ^ (int) (num273 >> 10)) + (int) num248 + (((int) (num208 >> 7) | (int) num208 << 25) ^ ((int) (num208 >> 18) | (int) num208 << 14) ^ (int) (num208 >> 3))));
      uint num285 = (uint) ((((int) (num282 >> 2) | (int) num282 << 30) ^ ((int) (num282 >> 13) | (int) num282 << 19) ^ ((int) (num282 >> 22) | (int) num282 << 10)) + ((int) num282 & (int) num277 | (int) num272 & ((int) num282 | (int) num277)));
      uint num286 = num267 + num284;
      uint num287 = num284 + num285;
      uint num288;
      uint num289 = (uint) ((int) num271 + (((int) (num286 >> 6) | (int) num286 << 26) ^ ((int) (num286 >> 11) | (int) num286 << 21) ^ ((int) (num286 >> 25) | (int) num286 << 7)) + ((int) num276 ^ (int) num286 & ((int) num281 ^ (int) num276)) + 1955562222) + (num288 = num208 + (uint) ((((int) (num278 >> 17) | (int) num278 << 15) ^ ((int) (num278 >> 19) | (int) num278 << 13) ^ (int) (num278 >> 10)) + (int) num253 + (((int) (num213 >> 7) | (int) num213 << 25) ^ ((int) (num213 >> 18) | (int) num213 << 14) ^ (int) (num213 >> 3))));
      uint num290 = (uint) ((((int) (num287 >> 2) | (int) num287 << 30) ^ ((int) (num287 >> 13) | (int) num287 << 19) ^ ((int) (num287 >> 22) | (int) num287 << 10)) + ((int) num287 & (int) num282 | (int) num277 & ((int) num287 | (int) num282)));
      uint num291 = num272 + num289;
      uint num292 = num289 + num290;
      uint num293;
      uint num294 = (uint) ((int) num276 + (((int) (num291 >> 6) | (int) num291 << 26) ^ ((int) (num291 >> 11) | (int) num291 << 21) ^ ((int) (num291 >> 25) | (int) num291 << 7)) + ((int) num281 ^ (int) num291 & ((int) num286 ^ (int) num281)) + 2024104815) + (num293 = num213 + (uint) ((((int) (num283 >> 17) | (int) num283 << 15) ^ ((int) (num283 >> 19) | (int) num283 << 13) ^ (int) (num283 >> 10)) + (int) num258 + (((int) (num218 >> 7) | (int) num218 << 25) ^ ((int) (num218 >> 18) | (int) num218 << 14) ^ (int) (num218 >> 3))));
      uint num295 = (uint) ((((int) (num292 >> 2) | (int) num292 << 30) ^ ((int) (num292 >> 13) | (int) num292 << 19) ^ ((int) (num292 >> 22) | (int) num292 << 10)) + ((int) num292 & (int) num287 | (int) num282 & ((int) num292 | (int) num287)));
      uint num296 = num277 + num294;
      uint num297 = num294 + num295;
      uint num298;
      uint num299 = (uint) ((int) num281 + (((int) (num296 >> 6) | (int) num296 << 26) ^ ((int) (num296 >> 11) | (int) num296 << 21) ^ ((int) (num296 >> 25) | (int) num296 << 7)) + ((int) num286 ^ (int) num296 & ((int) num291 ^ (int) num286)) - 2067236844) + (num298 = num218 + (uint) ((((int) (num288 >> 17) | (int) num288 << 15) ^ ((int) (num288 >> 19) | (int) num288 << 13) ^ (int) (num288 >> 10)) + (int) num263 + (((int) (num223 >> 7) | (int) num223 << 25) ^ ((int) (num223 >> 18) | (int) num223 << 14) ^ (int) (num223 >> 3))));
      uint num300 = (uint) ((((int) (num297 >> 2) | (int) num297 << 30) ^ ((int) (num297 >> 13) | (int) num297 << 19) ^ ((int) (num297 >> 22) | (int) num297 << 10)) + ((int) num297 & (int) num292 | (int) num287 & ((int) num297 | (int) num292)));
      uint num301 = num282 + num299;
      uint num302 = num299 + num300;
      uint num303;
      uint num304 = (uint) ((int) num286 + (((int) (num301 >> 6) | (int) num301 << 26) ^ ((int) (num301 >> 11) | (int) num301 << 21) ^ ((int) (num301 >> 25) | (int) num301 << 7)) + ((int) num291 ^ (int) num301 & ((int) num296 ^ (int) num291)) - 1933114872) + (num303 = num223 + (uint) ((((int) (num293 >> 17) | (int) num293 << 15) ^ ((int) (num293 >> 19) | (int) num293 << 13) ^ (int) (num293 >> 10)) + (int) num268 + (((int) (num228 >> 7) | (int) num228 << 25) ^ ((int) (num228 >> 18) | (int) num228 << 14) ^ (int) (num228 >> 3))));
      uint num305 = (uint) ((((int) (num302 >> 2) | (int) num302 << 30) ^ ((int) (num302 >> 13) | (int) num302 << 19) ^ ((int) (num302 >> 22) | (int) num302 << 10)) + ((int) num302 & (int) num297 | (int) num292 & ((int) num302 | (int) num297)));
      uint num306 = num287 + num304;
      uint num307 = num304 + num305;
      uint num308;
      uint num309 = (uint) ((int) num291 + (((int) (num306 >> 6) | (int) num306 << 26) ^ ((int) (num306 >> 11) | (int) num306 << 21) ^ ((int) (num306 >> 25) | (int) num306 << 7)) + ((int) num296 ^ (int) num306 & ((int) num301 ^ (int) num296)) - 1866530822) + (num308 = num228 + (uint) ((((int) (num298 >> 17) | (int) num298 << 15) ^ ((int) (num298 >> 19) | (int) num298 << 13) ^ (int) (num298 >> 10)) + (int) num273 + (((int) (num233 >> 7) | (int) num233 << 25) ^ ((int) (num233 >> 18) | (int) num233 << 14) ^ (int) (num233 >> 3))));
      uint num310 = (uint) ((((int) (num307 >> 2) | (int) num307 << 30) ^ ((int) (num307 >> 13) | (int) num307 << 19) ^ ((int) (num307 >> 22) | (int) num307 << 10)) + ((int) num307 & (int) num302 | (int) num297 & ((int) num307 | (int) num302)));
      uint num311 = num292 + num309;
      uint num312 = num309 + num310;
      uint num313;
      uint num314 = (uint) ((int) num296 + (((int) (num311 >> 6) | (int) num311 << 26) ^ ((int) (num311 >> 11) | (int) num311 << 21) ^ ((int) (num311 >> 25) | (int) num311 << 7)) + ((int) num301 ^ (int) num311 & ((int) num306 ^ (int) num301)) - 1538233109) + (num313 = num233 + (uint) ((((int) (num303 >> 17) | (int) num303 << 15) ^ ((int) (num303 >> 19) | (int) num303 << 13) ^ (int) (num303 >> 10)) + (int) num278 + (((int) (num238 >> 7) | (int) num238 << 25) ^ ((int) (num238 >> 18) | (int) num238 << 14) ^ (int) (num238 >> 3))));
      uint num315 = (uint) ((((int) (num312 >> 2) | (int) num312 << 30) ^ ((int) (num312 >> 13) | (int) num312 << 19) ^ ((int) (num312 >> 22) | (int) num312 << 10)) + ((int) num312 & (int) num307 | (int) num302 & ((int) num312 | (int) num307)));
      uint num316 = num297 + num314;
      uint num317 = num314 + num315;
      uint num318 = (uint) ((int) num301 + (((int) (num316 >> 6) | (int) num316 << 26) ^ ((int) (num316 >> 11) | (int) num316 << 21) ^ ((int) (num316 >> 25) | (int) num316 << 7)) + ((int) num306 ^ (int) num316 & ((int) num311 ^ (int) num306)) - 1090935817 + ((int) num238 + (((int) (num308 >> 17) | (int) num308 << 15) ^ ((int) (num308 >> 19) | (int) num308 << 13) ^ (int) (num308 >> 10)) + (int) num283 + (((int) (num243 >> 7) | (int) num243 << 25) ^ ((int) (num243 >> 18) | (int) num243 << 14) ^ (int) (num243 >> 3))));
      uint num319 = (uint) ((((int) (num317 >> 2) | (int) num317 << 30) ^ ((int) (num317 >> 13) | (int) num317 << 19) ^ ((int) (num317 >> 22) | (int) num317 << 10)) + ((int) num317 & (int) num312 | (int) num307 & ((int) num317 | (int) num312)));
      uint num320 = num302 + num318;
      uint num321 = num318 + num319;
      uint num322 = (uint) ((int) num306 + (((int) (num320 >> 6) | (int) num320 << 26) ^ ((int) (num320 >> 11) | (int) num320 << 21) ^ ((int) (num320 >> 25) | (int) num320 << 7)) + ((int) num311 ^ (int) num320 & ((int) num316 ^ (int) num311)) - 965641998 + ((int) num243 + (((int) (num313 >> 17) | (int) num313 << 15) ^ ((int) (num313 >> 19) | (int) num313 << 13) ^ (int) (num313 >> 10)) + (int) num288 + (((int) (num248 >> 7) | (int) num248 << 25) ^ ((int) (num248 >> 18) | (int) num248 << 14) ^ (int) (num248 >> 3))));
      uint num323 = (uint) ((((int) (num321 >> 2) | (int) num321 << 30) ^ ((int) (num321 >> 13) | (int) num321 << 19) ^ ((int) (num321 >> 22) | (int) num321 << 10)) + ((int) num321 & (int) num317 | (int) num312 & ((int) num321 | (int) num317)));
      uint num324 = num307 + num322;
      uint num325 = num322 + num323;
      s[0] += num325;
      s[1] += num321;
      s[2] += num317;
      s[3] += num312;
      s[4] += num324;
      s[5] += num320;
      s[6] += num316;
      s[7] += num311;
    }

    public static void Finalize(Sha256T hash, byte[] out32)
    {
      byte[] numArray1 = new byte[64];
      numArray1[0] = (byte) 128;
      byte[] data1 = numArray1;
      uint[] data2 = new uint[2];
      uint[] numArray2 = new uint[8];
      data2[0] = (uint) (((int) (hash.Bytes >> 29) & (int) byte.MaxValue) << 24 | ((int) (hash.Bytes >> 29) & 65280) << 8) | (hash.Bytes >> 29 & 16711680U) >> 8 | (hash.Bytes >> 29 & 4278190080U) >> 24;
      data2[1] = (uint) (((int) hash.Bytes << 3 & (int) byte.MaxValue) << 24 | ((int) hash.Bytes << 3 & 65280) << 8) | (uint) ((int) hash.Bytes << 3 & 16711680) >> 8 | (uint) ((int) hash.Bytes << 3 & -16777216) >> 24;
      Hash.Write(hash, data1, 1U + (119U - hash.Bytes % 64U) % 64U);
      Hash.Write(hash, data2, 8U);
      for (int index = 0; index < 8; ++index)
      {
        numArray2[index] = (uint) (((int) hash.S[index] & (int) byte.MaxValue) << 24 | ((int) hash.S[index] & 65280) << 8) | (hash.S[index] & 16711680U) >> 8 | (hash.S[index] & 4278190080U) >> 24;
        hash.S[index] = 0U;
      }
      Util.Memcpy((Array) numArray2, 0, (Array) out32, 0, 32);
    }

    private static void HmacSha256Initialize(HmacSha256T hash, byte[] key, uint keylen)
    {
      byte[] numArray = new byte[64];
      if (keylen <= 64U)
      {
        Util.Memcpy((Array) key, 0U, (Array) numArray, 0U, keylen);
        Util.MemSet(numArray, keylen, (byte) 0, 64U - keylen);
      }
      else
      {
        Sha256T hash1 = new Sha256T();
        Hash.Initialize(hash1);
        Hash.Write(hash1, key, keylen);
        Hash.Finalize(hash1, numArray);
        Util.MemSet(numArray, 32U, (byte) 0, 32U);
      }
      Hash.Initialize(hash.Outer);
      for (int index = 0; index < 64; ++index)
        numArray[index] ^= (byte) 92;
      Hash.Write(hash.Outer, numArray, 64U);
      Hash.Initialize(hash.Inner);
      for (int index = 0; index < 64; ++index)
        numArray[index] ^= (byte) 106;
      Hash.Write(hash.Inner, numArray, 64U);
      Util.MemSet(numArray, (byte) 0, 64);
    }

    private static void HmacSha256Write(HmacSha256T hash, byte[] data, uint size)
    {
      Hash.Write(hash.Inner, data, size);
    }

    private static void HmacSha256Finalize(HmacSha256T hash, byte[] out32)
    {
      byte[] numArray = new byte[32];
      Hash.Finalize(hash.Inner, numArray);
      Hash.Write(hash.Outer, numArray, 32U);
      Util.MemSet(numArray, (byte) 0, 32);
      Hash.Finalize(hash.Outer, out32);
    }

    public static void Rfc6979HmacSha256Initialize(Rfc6979HmacSha256T rng, byte[] key, uint keylen)
    {
      HmacSha256T hash = new HmacSha256T();
      byte[] data1 = new byte[1];
      byte[] data2 = new byte[1]{ (byte) 1 };
      Util.MemSet(rng.V, (byte) 1, 32);
      Util.MemSet(rng.K, (byte) 0, 32);
      Hash.HmacSha256Initialize(hash, rng.K, 32U);
      Hash.HmacSha256Write(hash, rng.V, 32U);
      Hash.HmacSha256Write(hash, data1, 1U);
      Hash.HmacSha256Write(hash, key, keylen);
      Hash.HmacSha256Finalize(hash, rng.K);
      Hash.HmacSha256Initialize(hash, rng.K, 32U);
      Hash.HmacSha256Write(hash, rng.V, 32U);
      Hash.HmacSha256Finalize(hash, rng.V);
      Hash.HmacSha256Initialize(hash, rng.K, 32U);
      Hash.HmacSha256Write(hash, rng.V, 32U);
      Hash.HmacSha256Write(hash, data2, 1U);
      Hash.HmacSha256Write(hash, key, keylen);
      Hash.HmacSha256Finalize(hash, rng.K);
      Hash.HmacSha256Initialize(hash, rng.K, 32U);
      Hash.HmacSha256Write(hash, rng.V, 32U);
      Hash.HmacSha256Finalize(hash, rng.V);
      rng.Retry = false;
    }

    public static void Rfc6979HmacSha256Generate(Rfc6979HmacSha256T rng, byte[] outdata, int outlen)
    {
      byte[] data = new byte[1];
      if (rng.Retry)
      {
        HmacSha256T hash = new HmacSha256T();
        Hash.HmacSha256Initialize(hash, rng.K, 32U);
        Hash.HmacSha256Write(hash, rng.V, 32U);
        Hash.HmacSha256Write(hash, data, 1U);
        Hash.HmacSha256Finalize(hash, rng.K);
        Hash.HmacSha256Initialize(hash, rng.K, 32U);
        Hash.HmacSha256Write(hash, rng.V, 32U);
        Hash.HmacSha256Finalize(hash, rng.V);
      }
      int dstOffset = 0;
      while (outlen > 0)
      {
        HmacSha256T hash = new HmacSha256T();
        int count = outlen;
        Hash.HmacSha256Initialize(hash, rng.K, 32U);
        Hash.HmacSha256Write(hash, rng.V, 32U);
        Hash.HmacSha256Finalize(hash, rng.V);
        if (count > 32)
          count = 32;
        Util.Memcpy((Array) rng.V, 0, (Array) outdata, dstOffset, count);
        dstOffset += count;
        outlen -= count;
      }
      rng.Retry = true;
    }

    public static void Rfc6979HmacSha256Finalize(Rfc6979HmacSha256T rng)
    {
      Util.MemSet(rng.K, (byte) 0, 32);
      Util.MemSet(rng.V, (byte) 0, 32);
      rng.Retry = false;
    }
  }
}
