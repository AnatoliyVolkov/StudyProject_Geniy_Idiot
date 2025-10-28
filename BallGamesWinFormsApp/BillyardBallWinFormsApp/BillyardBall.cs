using BallLibrary;

namespace BillyardBallWinFormsApp
{

    public class BillyardBall : RandomBall
    {
        public event EventHandler<HitEventArgs> OnHited;

        public BillyardBall(Form form) : base(form)
        {

        }

        protected override void Go()
        {
            base.Go();

            if (CenterX - Radius <= 0)
            { Vx = -Vx; OnHited.Invoke(this, new HitEventArgs(Side.Left)); }

            if (CenterX + Radius >= form.ClientSize.Width)
            {  Vx = -Vx; OnHited.Invoke(this, new HitEventArgs(Side.Right)); }

            if (CenterY - Radius <= 0)
               { Vy = -Vy; OnHited.Invoke(this, new HitEventArgs(Side.Top));}

            if (CenterY + Radius >= form.ClientSize.Height)
               { Vy = -Vy; OnHited.Invoke(this, new HitEventArgs(Side.Down));}
        }
    }
}