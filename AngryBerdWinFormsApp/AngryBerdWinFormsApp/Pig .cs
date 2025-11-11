namespace AngryBerdWinFormsApp;

public class Pig
{
    public float CenterX { get; set; }
    public float CenterY { get; set; }
    public int Radius { get; set; }
    private Random random;

    public Pig(float x, float y, int radius)
    {
        CenterX = x;
        CenterY = y;
        Radius = radius;
        random = new Random();
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

    public void Draw(Graphics g, Brush brush)
    {
        g.FillEllipse(brush, CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);

        g.FillEllipse(Brushes.DarkGreen, CenterX - Radius, CenterY - Radius, Radius / 2, Radius / 2);
        g.FillEllipse(Brushes.DarkGreen, CenterX + Radius / 2, CenterY - Radius, Radius / 2, Radius / 2);

        g.FillEllipse(Brushes.White, CenterX - Radius / 2, CenterY - Radius / 2, 4, 4);
        g.FillEllipse(Brushes.White, CenterX + Radius / 4, CenterY - Radius / 2, 4, 4);
        g.FillEllipse(Brushes.Black, CenterX - Radius / 2 + 1, CenterY - Radius / 2 + 1, 2, 2);
        g.FillEllipse(Brushes.Black, CenterX + Radius / 4 + 1, CenterY - Radius / 2 + 1, 2, 2);
    }
}