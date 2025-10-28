using BallLibrary;

namespace BallGamesWinFormsApp;

public partial class BallButtonStopMainForm : Form
{
    List<Ball> balls;
    public BallButtonStopMainForm()
    {
        InitializeComponent();
        this.DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint |
                 ControlStyles.DoubleBuffer, true);
    }

    private void StopMoveBall_Click(object sender, EventArgs e)
    {
        try
        {
            if (balls == null)
            {
                toolStripTextBox.Text = "0";
                MessageBox.Show("Прежде чем останавливать, запусти шарики!");
                return;
            }
            int count = 0;
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Stop();
                if (balls[i].IsForm(balls[i].CenterX, balls[i].CenterY, balls[i].Radius,ballPanel))
               {
                    count++;
                }
            }
            toolStripTextBox.Text = count.ToString();
        }
        catch (Exception ex) { MessageBox.Show($"Ошибка: {ex.Message}"); }
    }

    private void CreateRandomBull_Click(object sender, EventArgs e)
    {
        this.Invalidate();
        this.Update();
        toolStripTextBox.Text = "0";
        balls = new List<Ball>();
        int i = 0;
        while (i < 20)
        {
            var moveRandomBall = new MoveBall(this);
            balls.Add(moveRandomBall);
            moveRandomBall.Start();
            i++;
        }
    }
}
