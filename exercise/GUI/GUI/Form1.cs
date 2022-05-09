namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int cnt = 0;
        string[] ARRAY = { "first", "second", "third" };

        private void button1_Click(object sender, EventArgs e)
        {
            if(cnt == 2)
            {
                progressBar1.Value = 100;
                label1.Text = ARRAY[cnt];
                cnt = 0;
            }
            else
            {
                progressBar1.Value = (cnt+1) * 33;
                label1.Text = ARRAY[cnt];
                cnt += 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar2.Value == 100)
            {
                progressBar2.Value = 0;
            }
            else
            {
                progressBar2.Value += 1;
            }
        }
    }
}