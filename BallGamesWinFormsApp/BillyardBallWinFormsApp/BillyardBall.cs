using BallLibrary;

namespace BillyardBallWinFormsApp
{
    public class BillyardBall : Ball
    {
        private Panel panel;

        public BillyardBall(Form form, Panel panel) : base(form)
        {
            this.panel = panel;
        }

        protected override void Go()
        {
            base.Go();

            if (CenterX - Radius <= panel.Left || CenterX + Radius >= panel.Right)
                Vx = -Vx;
            if (CenterY - Radius <= panel.Top || CenterY + Radius >= panel.Bottom)
                Vy = -Vy;
        }
    }
}