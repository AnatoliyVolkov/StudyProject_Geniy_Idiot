using System.Drawing;
using System.Windows.Forms;

namespace BallGamesWinFormsApp;

public class Ball
{
    private MainForm mainForm;
    protected int x = 150;
    protected int y = 150;
    protected int size = 70;
    public Ball(MainForm form)
    {
        this.mainForm = form;
    }

    public void Show()
    {
        var graphiscs = mainForm.CreateGraphics();
        var brush = Brushes.Aqua;
        var rectangle = new Rectangle(x, y, size, size);
        graphiscs.FillEllipse(brush, rectangle);
    }
}
