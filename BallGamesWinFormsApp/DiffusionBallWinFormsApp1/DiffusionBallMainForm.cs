using BallLibrary;
using System;
using System.Windows.Forms;
namespace DiffusionBallWinFormsApp;

public partial class DiffusionBallMainForm : Form
{
    List<BillyardBall> redBalls; 
    List<BillyardBall> blueBalls;
    Random random = new Random();
    public DiffusionBallMainForm()
    {
        InitializeComponent();
        redBalls = new List<BillyardBall>(); 
        blueBalls = new List<BillyardBall>();
        SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
    }

    private void DiffusionBallMainForm_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 7; i++)
        {
            var ball = new DiffusionBall(this, isRed: true);
            ball.OnHited += MaveRandomBall_OnHited;
            redBalls.Add(ball);
            ball.Start();
        }

        for (int i = 0; i < 7; i++)
        {
            var ball = new DiffusionBall(this, isRed: false);
            ball.OnHited += MaveRandomBall_OnHited;
            blueBalls.Add(ball);
            ball.Start();
        }
    }

    private void MaveRandomBall_OnHited(object? sender, HitEventArgs e)
    {
        switch (e.Side)
        {
            case Side.Left:
                leftLabel.Text = (int.Parse(leftLabel.Text) + 1).ToString();
                break;
            case Side.Right:
                rightLabel.Text = (int.Parse(rightLabel.Text) + 1).ToString();
                break;
            case Side.Top:
                topLabel.Text = (int.Parse(topLabel.Text) + 1).ToString();
                break;
            case Side.Down:
                dawnLabel.Text = (int.Parse(dawnLabel.Text) + 1).ToString();
                break;
        }
    }
}
