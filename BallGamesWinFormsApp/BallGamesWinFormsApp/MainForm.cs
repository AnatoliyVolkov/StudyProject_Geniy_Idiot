namespace BallGamesWinFormsApp;

public partial class MainForm : Form
{
    List<MoveBall> MoveBalls;
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
        var pointBall = new PiontBall(this, e.X, e.Y);
        pointBall.Show();
    }

    private void StopMoveBallToolStripMenuItem_Click(object sender, EventArgs e)
    {
        int count = 0;
        for (int i = 0; i < MoveBalls.Count; i++)
        {
            MoveBalls[i].Stop();
            if (MoveBalls[i].X - MoveBalls[i].radius >= ClientRectangle.Left &&
                MoveBalls[i].X + MoveBalls[i].radius <= ClientRectangle.Right &&
                MoveBalls[i].Y - MoveBalls[i].radius >= ClientRectangle.Top &&
                MoveBalls[i].Y + MoveBalls[i].radius <= ClientRectangle.Bottom)
            {
                count++;
            }
        }
        toolStripTextBox.Text = count.ToString();
    }

    private void CreateRandomBullToolStripMenuItem_Click(object sender, EventArgs e)
    {

        MoveBalls = new List<MoveBall>();
        int i = 0;
        while (i < 20)
        {
            var maveRandomBall = new MoveBall(this);
            MoveBalls.Add(maveRandomBall);
            maveRandomBall.Start();
            i++;
        }
    }
}
