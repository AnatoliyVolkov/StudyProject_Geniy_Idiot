namespace AngryBerdWinFormsApp;

public class GameManager
{
    public int Score { get; private set; }
    public int PigsCount { get; private set; }
    public List<Pig> Pigs { get; private set; }
    public int Level { get; private set; }
    public bool IsLevelComplete { get; set; }

    public GameManager()
    {
        Score = 0;
        Level = 1;
        PigsCount = 1;
        Pigs = new List<Pig>();
        IsLevelComplete = false;
    }

    public void IncreaseScore()
    {
        Score++;
    }

    public void NextLevel()
    {
        Level++;
        PigsCount = 1 + (Level - 1);
        if (PigsCount > 5) PigsCount = 5; 
        IsLevelComplete = false;
    }

    public void InitializePigs(int formWidth, int groundLevel, int pigRadius)
    {
        Pigs.Clear();
        var random = new Random();

        for (int i = 0 ; i < PigsCount ; i++)
        {
            var pig = new Pig(0, 0, pigRadius);
            int attempts = 0;
            bool positionFound = false;

            while (attempts < 50 && !positionFound)
            {
                pig.Respawn(formWidth, groundLevel);
                positionFound = true;

                foreach (var existingPig in Pigs)
                {
                    float dx = pig.CenterX - existingPig.CenterX;
                    float dy = pig.CenterY - existingPig.CenterY;
                    float distance = (float)Math.Sqrt(dx * dx + dy * dy);

                    if (distance < (pig.Radius + existingPig.Radius + 30)) 
                    {
                        positionFound = false;
                        break;
                    }
                }

                attempts++;
            }

            Pigs.Add(pig);
        }
    }

    public void RemovePig(Pig pig)
    {
        Pigs.Remove(pig);
        IncreaseScore();

        if (Pigs.Count == 0)
        {
            IsLevelComplete = true;
        }
    }
}