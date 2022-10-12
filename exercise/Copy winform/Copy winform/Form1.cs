using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Input;
using OpenCvSharp;

namespace Copy_winform
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(100);
            timer.Elapsed += label2_Click;
            timer.Enabled = true;

            
        }

        public void Execute(string url)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd", "/c" + url);
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = psi;
            proc.Start();
        }

        string execute = "�����մϴ�.";
        string error = "������ �߻��Ͽ����ϴ�.";
        string nullpath = "��ΰ� �������� �ʾҽ��ϴ�.";

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "start Chrome.exe";
            /*string url = @"C:\Program Files\Google\Chrome\Application\chrome.exe";*/
            try
            {
                if (!url.Equals("") && url != null)
                {
                    Execute(url);
                    /*Process.Start(url);*/
                    label1.Text = "Chrome��" + execute;
                }
                else
                {
                    label1.Text = nullpath;
                }
            }
            catch
            {
                label1.Text = error;
            }
        }

        //���̹� ���� ��ŷ ũ�Ѹ�
        private void button2_Click(object sender, EventArgs e)
        {
            using (IWebDriver d = new ChromeDriver())
            {
                d.Url = "https://comic.naver.com/webtoon/weekday";
                d.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                var elements = d.FindElements(By.CssSelector("#realTimeRankFavorite li"));

                string result = "";
                foreach (var el in elements)
                {
                    result += el.FindElement(By.CssSelector("a")).Text.Trim() + "\n";
                }
                label1.Text = result;
            }
        }

        // ���û �������� ũ�Ѹ� �õ��Ͽ����� �����Ͱ� ����̾ȵ�.
        string today = DateTime.Now.ToString("yyyy-MM-dd");
        private void button3_Click(object sender, EventArgs e)
        {
            using (IWebDriver d = new ChromeDriver())
            {
                d.Url = "https://www.weather.go.kr/w/index.do";
                d.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

                var ul = d.FindElements(By.XPath("//ul[contains(@data-date, '" + today + "')]"));
                var li = ul[0].FindElements(By.CssSelector("li"));
                var span = li[2].FindElements(By.CssSelector("span[class$=feel]"));
                var result = "";
                foreach(var el in span)
                {
                    result += el.Text + "\n";
                }
                label1.Text = result;
            }
        }

        private void label2_Click(object sender, EventArgs e) 
        {
            MousePosition();
        }
        public void MousePosition()
        {

            label2.Text = String.Format("{0},{1}", Cursor.Position.X.ToString(), Cursor.Position.Y.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}