using DiffusionBallWinFormsApp;

namespace DiffusionBallWinFormsApp1
{
    public partial class StartDiffusionform : Form
    {
        public StartDiffusionform()
        {
            InitializeComponent();
        }

        private void StartDiffusion_Click(object sender, EventArgs e)
        {
            var message = ValidHelp.ValidInput(countBallTextBox.Text);
            try
            {
                var ball = int.Parse(countBallTextBox.Text);
                if (ball < 2 || ball > 100) { MessageBox.Show($"{message}"); }
                else
                {
                    Form map = new DiffusionBallMainForm(ball);
                    map.Show();
                    this.Hide();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"{message}");
            }
            
        }
    }
}
