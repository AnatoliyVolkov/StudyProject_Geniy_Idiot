using BallLibrary;

namespace BallGamesWinFormsApp;

public partial class MainForm : Form
{
    List<MoveBall> MoveBalls;
    public MainForm()
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
            if (MoveBalls == null)
            {
                toolStripTextBox.Text = "0";
                MessageBox.Show("Прежде чем останавливать, запусти шарики!");
                return;
            }
            int count = 0;
            for (int i = 0; i < MoveBalls.Count; i++)
            {
                MoveBalls[i].Stop();
                if (MoveBalls[i].IsForm(MoveBalls[i].X, MoveBalls[i].Y, MoveBalls[i].size, this))
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
        MoveBalls = new List<MoveBall>();
        int i = 0;
        while (i < 20)
        {
            var moveRandomBall = new MoveBall(this);
            MoveBalls.Add(moveRandomBall);
            moveRandomBall.Start();
            i++;
        }
    }
}
