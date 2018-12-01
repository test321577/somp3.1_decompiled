// Decompiled with JetBrains decompiler
// Type: ShapeOfMyPenis.EmptyClass
// Assembly: ShapeOfMyPenis, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21A59ED2-F9B1-44BA-B5E7-59F320D41A1B
// Assembly location: C:\Users\1\Desktop\somp3\ShapeOfMyPenis.exe

using PenisWallet;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace ShapeOfMyPenis
{
  public class EmptyClass : Form
  {
    private AbstractKeyProvider provider = (AbstractKeyProvider) new SoMPKeyProvider();
    private AbstractKeyProvider altProvider = (AbstractKeyProvider) new PhraseProvider();
    private string[] wisdom_list = new string[30]
    {
      "ПРОСТО ПОВЕРЬ В СЕБЯ!",
      "СВОЙ СЛОВАРЬ НАЗОВИ altdict.txt",
      "ПЕРЕЗАПУСТИ, ВЫБЕРИ AltDict РЕЖИМ",
      "Limited СНИЖАЕТ НАГРУЗКУ НА СЕТЬ",
      "А ТАКЖЕ ПОВЫШАЕТ СКОРОСТЬ И...",
      "ВЕСЬ ПОИСК КОНЦЕНТРИРУЕТСЯ НА...",
      "16 МЛН.+ КОШЕЛЬКОВ С ДЕНЬГАМИ",
      "В debug.txt ПОЛОЖИ СПИСОК АДРЕСОВ",
      "ЧТОБЫ ПРОВЕРИТЬ РЕАКЦИЮ SoMP",
      "И УБЕДИТЬСЯ ЧТО SoMP РАБОТАЕТ",
      "ТЕБЕ НУЖЕН ЛИШЬ ОДИН ШАНС",
      "ЭТО МОЖЕТ СЛУЧИТЬСЯ ПРЯМО СЕЙЧАС",
      "ТЫ СТАНЕШЬ СКАЗОЧНО БОГАТ",
      "ВЕРЬ В СВОЮ УДАЧУ!",
      "СОРВИ КУШ! БЕСПЛАТНО!",
      "НАСТРОЙСЯ НА ПОЗИТИВНЫЕ МЫСЛИ",
      "МЫСЛЬ МАТЕРИАЛЬНА",
      "НАШ РАНДОМ — НЕ РАНДОМЕН",
      "ПОПРОБУЙ НЕСКОЛЬКО THREADS",
      "ДАЖЕ НА БОТАХ МОЖНО ПОЖИВИТЬСЯ",
      "НАБЛЮДАЙ ЗА ЖЕЛТЫМИ КОШЕЛЬКАМИ",
      "НЕ УПУСТИ СВОЙ ШАНС",
      "ОЖИДАНИЕ ВОЗНАГРАДИТ ТЕБЯ",
      "СЛУЧАЙНОСТЕЙ НЕ БЫВАЕТ",
      "ВСЁ ЗАКОНОМЕРНО",
      "ВСЁ ПОДЧИНЯЕТСЯ ТЕБЕ",
      "СТОИТ ЛИШЬ ЗАХОТЕТЬ",
      "И ВЕСЬ МИР БУДЕТ У ТВОИХ НОГ",
      "НЕТ НИЧЕГО НЕВОЗМОЖНОГО",
      "НИКТО НЕ ЗНАЕТ КАК СЛОЖИТСЯ СУДЬБА"
    };
    private System.Timers.Timer aTimer;
    private Searcher searcher;
    private Label searches;
    private Label speed;
    private Label bots;
    private Label green;
    private Label yellow;
    private Label wisdom;
    private Label tcountl;
    private Label keys;
    private Label last;
    private NumericUpDown tcount;
    private Button button1;
    private Button button2;
    private Button config;
    private Button offline;
    private bool hasAltDict;
    private int frame;
    private Image image1;
    private Image image2;
    private int wisdomIndex;
    private bool running;

    public EmptyClass()
    {
      if (File.Exists("altdict.txt"))
      {
        (this.altProvider as PhraseProvider).AddWords(File.ReadAllLines("altdict.txt"));
        this.hasAltDict = true;
      }
      this.Text = "Shape Of My Penis v3.1 Windows (.NET 4.6)";
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.DoubleBuffered = true;
      this.image1 = Image.FromFile("004.dat");
      this.image2 = Image.FromFile("006.dat");
      this.BackgroundImage = this.image1;
      this.searcher = new Searcher();
      this.Size = new Size(670, 497);
      this.ResizeEnd += (EventHandler) ((sender, e) => this.Size = new Size(670, 497));
      this.searches = new Label();
      this.searches.Size = new Size(200, 40);
      this.searches.Location = new Point(10, 10);
      this.searches.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.searches);
      this.keys = new Label();
      this.keys.Size = new Size(600, 280);
      this.keys.Location = new Point(325, 10);
      this.keys.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.keys);
      this.speed = new Label();
      this.speed.Size = new Size(200, 40);
      this.speed.Location = new Point(10, 50);
      this.speed.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.speed);
      this.button1 = new Button();
      this.button1.Size = new Size(100, 20);
      this.button1.Location = new Point(10, 90);
      this.button1.Text = "Start search";
      this.Controls.Add((Control) this.button1);
      this.button1.Click += new EventHandler(this.button1_Click);
      this.tcount = new NumericUpDown();
      this.tcount.Size = new Size(40, 20);
      this.tcount.Location = new Point(110, 90);
      this.tcount.Value = Decimal.One;
      this.tcount.Minimum = Decimal.One;
      this.tcount.Maximum = new Decimal(64);
      this.Controls.Add((Control) this.tcount);
      this.tcountl = new Label();
      this.tcountl.Size = new Size(60, 20);
      this.tcountl.Location = new Point(150, 90);
      this.tcountl.Text = " (threads)";
      this.tcountl.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.tcountl);
      this.button2 = new Button();
      this.button2.Size = new Size(80, 20);
      this.button2.Location = new Point(10, 130);
      this.button2.Text = "Stop search";
      this.Controls.Add((Control) this.button2);
      this.button2.Click += new EventHandler(this.button2_Click);
      this.button2.Enabled = false;
      this.bots = new Label();
      this.bots.Size = new Size(200, 40);
      this.bots.Location = new Point(10, 170);
      this.bots.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.bots);
      this.green = new Label();
      this.green.Size = new Size(200, 40);
      this.green.Location = new Point(10, 250);
      this.green.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.green);
      this.yellow = new Label();
      this.yellow.Size = new Size(200, 40);
      this.yellow.Location = new Point(10, 210);
      this.yellow.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.yellow);
      this.last = new Label();
      this.last.Size = new Size(400, 100);
      this.last.Location = new Point(10, 390);
      this.last.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.last);
      this.wisdom = new Label();
      this.wisdom.Text = "ПРОСТО ПОВЕРЬ В СЕБЯ";
      this.wisdom.Size = new Size(400, 20);
      this.wisdom.Font = new Font(FontFamily.GenericSerif, 13f, FontStyle.Bold);
      this.wisdom.Location = new Point(280, 360);
      this.wisdom.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.wisdom);
      this.offline = new Button();
      this.offline.Text = "Full Search";
      this.offline.Size = new Size(100, 20);
      this.offline.Location = new Point(100, 120);
      this.Controls.Add((Control) this.offline);
      this.offline.Click += new EventHandler(this.button3_Click);
      this.config = new Button();
      this.config.Size = new Size(90, 30);
      this.config.Location = new Point(470, 390);
      this.config.Text = PassPhraseGen.config.ToString();
      this.config.Click += (EventHandler) ((sender, e) =>
      {
        PassPhraseGen.Config result;
        Enum.TryParse<PassPhraseGen.Config>(this.config.Text, out result);
        switch (result)
        {
          case PassPhraseGen.Config.AllBots:
            result = PassPhraseGen.Config.Classic;
            break;
          case PassPhraseGen.Config.Classic:
            result = PassPhraseGen.Config.UniquePhrases;
            break;
          case PassPhraseGen.Config.UniquePhrases:
            result = PassPhraseGen.Config.TrueRandom;
            break;
          case PassPhraseGen.Config.TrueRandom:
            result = this.hasAltDict ? PassPhraseGen.Config.AltDict : PassPhraseGen.Config.AllBots;
            break;
          case PassPhraseGen.Config.AltDict:
            result = PassPhraseGen.Config.AllBots;
            break;
        }
        PassPhraseGen.config = result;
        this.config.Text = result.ToString();
      });
      this.Controls.Add((Control) this.config);
      this.SetTimer();
    }

    private void SetTimer()
    {
      this.aTimer = new System.Timers.Timer(1000.0);
      this.aTimer.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
      this.aTimer.AutoReset = true;
      this.aTimer.Enabled = true;
    }

    private void InvokeLabelText(Label label, string text)
    {
      label.BeginInvoke((Delegate) (() => label.Text = text));
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
      ++this.frame;
      if (this.frame == 5)
      {
        Image image2 = this.image2;
        this.image2 = this.image1;
        this.image1 = image2;
        this.BackgroundImage = this.image1;
        this.frame = 0;
      }
      string time = this.searcher.Time;
      if (time.Contains("."))
        time = time.Split(new char[1]{ '.' }, 2)[0];
      this.InvokeLabelText(this.searches, "Searched: " + this.searcher.Searches + ", elapsed: " + time);
      this.InvokeLabelText(this.speed, "Speed: " + this.searcher.Speed);
      this.InvokeLabelText(this.bots, "Bots (empty): " + (object) this.searcher.bots + "\n (see bots.txt)");
      this.InvokeLabelText(this.yellow, "Real but empty: " + (object) this.searcher.found + "\n (see yellow.txt)");
      this.InvokeLabelText(this.green, "With balance: " + (object) this.searcher.green + "\n (see green.txt)");
      this.InvokeLabelText(this.wisdom, this.wisdom_list[this.wisdomIndex++ / 4]);
      if (this.wisdomIndex / 4 >= this.wisdom_list.Length)
        this.wisdomIndex = 0;
      if (this.searcher.Last != null)
        this.InvokeLabelText(this.last, "Last (not bot):\n" + (object) this.searcher.Last);
      lock (this.searcher)
      {
        string text = "SOME keys and passpharses some shown below:\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
        for (int index = 0; index < this.searcher.SearchList.Length; ++index)
        {
          Wallet search = this.searcher.SearchList[this.searcher.SearchList.Length - 1 - index];
          if (search != null)
            text = search.Phrase == null ? text + search.@private + "\n" : text + search.Phrase + "\n";
        }
        this.InvokeLabelText(this.keys, text);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.button2.Enabled = true;
      this.button1.Enabled = false;
      this.InvokeLabelText(this.tcountl, "(" + (object) this.tcount.Value + " threads)");
      this.tcountl.Location = new Point(110, 90);
      if (this.tcount.Visible)
      {
        if (this.tcount.Value % new Decimal(10) == Decimal.One && this.tcount.Value % new Decimal(100) != new Decimal(11))
          this.InvokeLabelText(this.tcountl, this.tcountl.Text.Replace("s", ""));
        this.tcount.Hide();
      }
      this.running = true;
      for (int index = 0; (Decimal) index < this.tcount.Value; ++index)
        ThreadPool.QueueUserWorkItem((WaitCallback) (state =>
        {
          while (true)
          {
            lock (this)
            {
              if (!this.running)
                break;
            }
            this.searcher.Search(!this.hasAltDict || PassPhraseGen.config != PassPhraseGen.Config.AltDict ? this.provider : this.altProvider);
          }
        }));
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.button1.Enabled = true;
      this.button2.Enabled = false;
      lock (this)
        this.running = false;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (this.offline.Text == "Full Search")
      {
        this.offline.Text = "Limit to top-16M";
        this.searcher.offline = true;
      }
      else
      {
        this.offline.Text = "Full Search";
        this.searcher.offline = false;
      }
    }

    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.Run((Form) new EmptyClass());
    }
  }
}
