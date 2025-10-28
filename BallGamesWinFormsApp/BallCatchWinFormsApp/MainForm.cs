using System.Reflection.Metadata;
using System.Windows.Forms;

namespace BallLibrary;

public partial class MainForm : Form
{
    int count = 0;
    List<global::MoveBall> MoveBalls;
    public MainForm()
    {
        InitializeComponent();
        this.DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint |
                 ControlStyles.DoubleBuffer, true);

    }

    private void CreateRandomBull_Click(object sender, EventArgs e)
    {
        this.Invalidate();
        this.Update();
        count = 0;
        cathBallToolStripTextBox.Text = "0";
        MoveBalls = new List<global::MoveBall>();
        int i = 0;
        while (i < 20)
        {
            var maveRandomBall = new global::MoveBall(this);
            MoveBalls.Add(maveRandomBall);
            maveRandomBall.Start();
            i++;
        }
    }

    private void BallMousKlick_MouseDown(object sender, MouseEventArgs e)
    {
        for (int i = 0 ; i < MoveBalls.Count ; i++)
        {
            if (MoveBalls[i].IsStopped)
                continue;
            double distance = Math.Sqrt(Math.Pow(e.X - MoveBalls[i].CenterX, 2) +
                            Math.Pow(e.Y - MoveBalls[i].CenterY, 2));
            if (MoveBalls[i].IsForm(MoveBalls[i].CenterX, MoveBalls[i].CenterY, MoveBalls[i].Radius, ballPanel))
            {
                if (distance <= MoveBalls[i].Radius)
                {
                    count++;
                    MoveBalls[i].Stop();
                }
            }
        }
        cathBallToolStripTextBox.Text = count.ToString();
    }
}
