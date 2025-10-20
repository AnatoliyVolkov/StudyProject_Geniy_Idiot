namespace BallGamesWinFormsApp;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void CreateBallButton_Click(object sender, EventArgs e)
    {
        var ball = new Ball(this);
        ball.Show();
    }

    private void CreateRandomBullButton_Click(object sender, EventArgs e)
    {
        var randomBall = new RandomSizeAndPointBall(this);
        randomBall.Show();
    }

    private void MainForm_MouseDown(object sender, MouseEventArgs e)
    {
        var pointBall = new PiontBall(this, e.X, e.Y);
        pointBall.Show();
    }
}
