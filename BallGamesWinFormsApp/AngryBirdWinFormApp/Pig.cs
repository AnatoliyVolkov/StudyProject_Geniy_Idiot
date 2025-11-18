using BallLibrary;

namespace AngryBirdWinFormApp;

public class Pig : RandomBall
{
    private Random random;

    public Pig(Form form, int radius) : base(form)
    {
        Radius = radius;
        random = new Random();
        Stop();
    }

    public void Respawn(int formWidth, int groundLevel)
    {
        int minX = 150;
        int maxX = formWidth - 150;
        int minY = 100;
        int maxY = groundLevel - 30;

        CenterX = random.Next(minX, maxX);
        CenterY = random.Next(minY, maxY);
    }

    public void Show(Graphics g)
    {
        g.FillEllipse(Brushes.Green, CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);

        g.FillEllipse(Brushes.DarkGreen, CenterX - Radius, CenterY - Radius, Radius / 2, Radius / 2);
        g.FillEllipse(Brushes.DarkGreen, CenterX + Radius / 2, CenterY - Radius, Radius / 2, Radius / 2);
        g.FillEllipse(Brushes.White, CenterX - Radius / 2, CenterY - Radius / 2, 4, 4);
        g.FillEllipse(Brushes.White, CenterX + Radius / 4, CenterY - Radius / 2, 4, 4);
        g.FillEllipse(Brushes.Black, CenterX - Radius / 2 + 1, CenterY - Radius / 2 + 1, 2, 2);
        g.FillEllipse(Brushes.Black, CenterX + Radius / 4 + 1, CenterY - Radius / 2 + 1, 2, 2);
    }
}