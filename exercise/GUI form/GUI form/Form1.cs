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
            try
            {
                if (!url.Equals("") && url != null)
                {
                    label1.Text = "New World를 실행합니다.";
                    Execute(url);
                }
                else
                {
                    label1.Text = "New World 경로가 설정되지 않았습니다.";
                }
            }
            catch
            {
                label1.Text = "New World 경로가 잘못되었습니다.";
            }
            
        }
        
        //Discord
        private void button2_Click(object sender, EventArgs e)
        {
            string url = @"";
            try
            {
                if(!url.Equals("") && url != null)
                {
                    label1.Text = "Discord를 실행합니다.";
                    Execute(url);
                }
                else
                {
                    label1.Text = "Discord 경로가 설정되지 않았습니다.";
                }
            }
            catch
            {
                label1.Text = "Discord 경로가 잘못되었습니다..";
            }
            
        }

        //Steam
        private void button3_Click(object sender, EventArgs e)
        {
            string url = @"";
            try
            {
                if (!url.Equals("") && url != null)
                {
                    label1.Text = "Steam를 실행합니다.";
                    Execute(url);
                }
                else
                {
                    label1.Text = "Steam 경로가 설정되지 않았습니다.";
                }
            }
            catch
            {
                label1.Text = "Steam 경로가 잘못되었습니다.";
            }
            
        }

        //EpicGames
        private void button4_Click(object sender, EventArgs e)
        {
            string url = @"D:\game\Epic Games\Launcher\Portal\Binaries\Win32\EpicGamesLauncher.exe";
            try
            {
                if (!url.Equals("") && url != null)
                {
                    label1.Text = "EpicGames를 실행합니다.";
                    Execute(url);
                }
                else
                {
                    label1.Text = "EpicGames 경로가 설정되지 않았습니다.";
                }
            }
            catch
            {
                label1.Text = "EpicGames 경로가 잘못되었습니다.";
            }
            
        }

        //VScode
        private void button5_Click(object sender, EventArgs e)
        {
            string url = @"D:\tool\Microsoft VS Code\Code.exe";
            try
            {
                if (!url.Equals("") && url != null)
                {
                    label2.Text = "VScode를 실행합니다.";
                    Execute(url);
                }
                else
                {
                    label2.Text = "VScode 경로가 설정되지 않았습니다.";
                }
            }
            catch
            {
                label2.Text = "VScode 경로가 잘못되었습니다.";
            }
            
        }

        //Git_Bash
        private void button6_Click(object sender, EventArgs e)
        {
            string url = @"D:\tool\Git\git-bash.exe";
            try
            {
                if (!url.Equals("") && url != null)
                {
                    label2.Text = "Git_Bash를 실행합니다.";
                    Execute(url);
                }
                else
                {
                    label2.Text = "Git_Bash 경로가 설정되지 않았습니다.";
                }
            }
            catch
            {
                label2.Text = "Git_Bash 경로가 잘못되었습니다.";
            }
            
        }

        //Unity Hup
        private void button8_Click(object sender, EventArgs e)
        {
            string url = @"D:\tool\Unity Hub\Unity Hub.exe";
            try
            {
                if (!url.Equals("") && url != null)
                {
                    label2.Text = "Unity Hup를 실행합니다.";
                    Execute(url);
                }
                else
                {
                    label2.Text = "Unity Hup 경로가 설정되지 않았습니다.";
                }
            }
            catch
            {
                label2.Text = "Unity Hup 경로가 잘못되었습니다.";
            }
            
        }
    }
}