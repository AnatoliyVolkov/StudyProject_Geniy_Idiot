using System;
using System.Windows.Forms;


namespace BallLibrary;

public class Ball
{
    private Form mainForm;
    public int vx { get; protected set; } = 3;
    public int vy { get; protected set; } = 4;
    public int X { get; protected set; } = 150;
    public int Y { get; protected set; } = 150;
    public int size { get; protected set; } = 70;
    


    public Ball(Form form)
    {
        this.mainForm = form;
    }

    public void Show()
    {
        var graphiscs = mainForm.CreateGraphics();
        var brush = Brushes.Orange;
        var rectangle = new Rectangle(X - size / 2, Y - size / 2, size, size);
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
        var rectangle = new Rectangle(X - size / 2, Y - size / 2, size, size);
        graphiscs.FillEllipse(brush, rectangle);
    }


}
