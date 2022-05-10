using System.Diagnostics;

namespace GUI_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Execute(string url)
        {
            ProcessStartInfo psi = new ProcessStartInfo(url);
            psi.RedirectStandardOutput = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process proc = new Process();
            proc.StartInfo = psi;
            proc.Start();
        }
        //New World
        private void button1_Click(object sender, EventArgs e)
        {
            string url = @"";
            if (!url.Equals("") && url != null)
            {
                label1.Text = "New World를 실행합니다.";
                Execute(url);
            }
        }
        
        //Discord
        private void button2_Click(object sender, EventArgs e)
        {
            string url = @"";
            if(!url.Equals("") && url != null)
            {
                label1.Text = "Discord를 실행합니다.";
                Execute(url);
            }
            
        }

        //Steam
        private void button3_Click(object sender, EventArgs e)
        {
            string url = @"";
            if (!url.Equals("") && url != null)
            {
                label1.Text = "Steam를 실행합니다.";
                Execute(url);
            }
        }

        //EpicGames
        private void button4_Click(object sender, EventArgs e)
        {
            string url = @"";
            if (!url.Equals("") && url != null)
            {
                label1.Text = "EpicGames를 실행합니다.";
                Execute(url);
            }
        }

        //VScode
        private void button5_Click(object sender, EventArgs e)
        {
            string url = @"D:\tool\Microsoft VS Code\Code.exe";
            if (!url.Equals("") && url != null)
            {
                label2.Text = "VScode를 실행합니다.";
                Execute(url);
            }
        }

        //Git_Bash
        private void button6_Click(object sender, EventArgs e)
        {
            string url = @"D:\tool\Git\git-bash.exe";
            if (!url.Equals("") && url != null)
            {
                label2.Text = "Git_Bash를 실행합니다.";
                Execute(url);
            }
        }

        //Unity Hup
        private void button8_Click(object sender, EventArgs e)
        {
            string url = @"D:\tool\Unity Hub\Unity Hub.exe";
            if (!url.Equals("") && url != null)
            {
                label2.Text = "Unity Hup를 실행합니다.";
                Execute(url);
            }
        }
    }
}