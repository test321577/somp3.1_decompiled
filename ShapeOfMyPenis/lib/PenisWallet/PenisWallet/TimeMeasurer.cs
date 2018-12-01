// Decompiled with JetBrains decompiler
// Type: PenisWallet.TimeMeasurer
// Assembly: PenisWallet, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3646752A-0D99-4B0A-A992-CA4468257D9B
// Assembly location: C:\Users\1\Desktop\somp3\PenisWallet.dll

using System;

namespace PenisWallet
{
  public class TimeMeasurer
  {
    private TimeSpan span = new TimeSpan(0L);
    private DateTime timeStart1;

    public string GetElapsed()
    {
      return string.Concat((object) this.span);
    }

    public double GetSeconds()
    {
      return this.span.TotalSeconds;
    }

    public void Play()
    {
      this.timeStart1 = DateTime.UtcNow;
    }

    public void Pause()
    {
      this.span += DateTime.UtcNow - this.timeStart1;
    }

    public void Reset()
    {
      this.span = new TimeSpan(0L);
      this.timeStart1 = DateTime.UtcNow;
    }
  }
}
