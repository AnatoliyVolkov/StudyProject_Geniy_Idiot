namespace BallGamesWinFormsApp;

public partial class MainForm : Form
{
    List<MoveBall> MoveBalls;
    public MainForm()
    {
        InitializeComponent();
    }

    private void StopMoveBallButton_Click(object sender, EventArgs e)
    {
        for (int i = 0 ; i < MoveBalls.Count ; i++)
        {
            MoveBalls[i].Stop();
        }
    }

    private void CreateRandomBullButton_Click(object sender, EventArgs e)
    {
        MoveBalls = new List<MoveBall>();
        int i = 0;
        while ( i  < 20 )
        {
            var maveRandomBall = new MoveBall(this);
            MoveBalls.Add(maveRandomBall);
            maveRandomBall.Start();
            i++;
        }
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
        var pointBall = new PiontBall(this, e.X, e.Y);
        pointBall.Show();
    }

    private void ShowBallDisplay() { countBallLabel.Text = MoveBalls.Count.ToString(); }
    
      
    
}
