using BallLibrary;
using System.Drawing;

namespace DiffusionBallWinFormsApp;

internal class DiffusionBall : BillyardBall
{

    public DiffusionBall(Form form) : base(form)    
    {
        
    }

    public void CreateRedBall()
    {
        this.CenterX = random.Next(this.Radius, form.ClientSize.Width / 2 - this.Radius);
        this.CenterY = random.Next(this.Radius, form.ClientSize.Height - this.Radius);
        this.Brush = Brushes.Red;
    }

    public void CreateBlueBall()
    {
        this.CenterX = random.Next(form.ClientSize.Width / 2 + this.Radius, form.ClientSize.Width - this.Radius);
        this.CenterY = random.Next(this.Radius, form.ClientSize.Height - this.Radius);
        this.Brush = Brushes.Blue;
    }
}
