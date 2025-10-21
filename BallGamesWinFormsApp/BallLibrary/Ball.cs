using System.Drawing;
using System;
using System.Windows.Forms;

namespace BallLibrary;

public class Ball
{
    private Form mainForm;
    protected int vx = 3;
    protected int vy = 4;
    public int X { get; protected set; } = 150;
    public int Y { get; protected set; } = 150;
    protected int size = 70;

    public Ball(Form form)
    {
        this.mainForm = form;
    }

    public void Show()
    {
        var graphiscs = mainForm.CreateGraphics();
        var brush = Brushes.Orange;
        var rectangle = new Rectangle(X, Y, size, size);
        graphiscs.FillEllipse(brush, rectangle);
    }
    public void Move()
    {
        Clear();
        Go();
        Show();
    }

    private void Go()
    {
        X += vx;
        Y += vy;
    }

    private void Clear()
    {
        var graphiscs = mainForm.CreateGraphics();
        var brush = SystemBrushes.Control;
        var rectangle = new Rectangle(X, Y, size, size);
        graphiscs.FillEllipse(brush, rectangle);
    }


}
