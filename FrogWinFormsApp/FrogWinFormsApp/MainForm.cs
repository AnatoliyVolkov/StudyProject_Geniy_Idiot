namespace FrogWinFormsApp;

public partial class MainForm : Form
{
    private int moveCount = 0;
    private const int optimalMoves = 24;
    private const int pictureBoxWidth = 110;
    private const int startY = 24;
    private const int totalPositions = 9;
    private bool gameWon = false;
    const int winFormWidth = 400;
    const int winFormHeight = 450;
    const int imageSize = 200;
    const int imageTop = 0;
    const int labelHeight = 80;
    const int labelTop = 250;
    const int buttonWidth = 120;
    const int buttonHeight = 35;
    const int buttonTop = 340;
    private PictureBox[] allFrogs;
    private readonly List<PictureBox> leftFrogs = new();
    private readonly List<PictureBox> rightFrogs = new();

    public MainForm()
    {
        InitializeComponent();
        InitializeFrogArray();
        UpdateMoveCount();
    }

    private void InitializeFrogArray()
    {
        allFrogs = new PictureBox[]
        {
            leftPictureBox1, leftPictureBox2, leftPictureBox3, leftPictureBox4,
            emptyPictureBox,
            rightPictureBox1, rightPictureBox2, rightPictureBox3, rightPictureBox4
        };

        leftFrogs.AddRange(new[] { leftPictureBox1, leftPictureBox2, leftPictureBox3, leftPictureBox4 });
        rightFrogs.AddRange(new[] { rightPictureBox1, rightPictureBox2, rightPictureBox3, rightPictureBox4 });
    }

    private void PictureBox_Click(object sender, EventArgs e)
    {
        if (gameWon) return;
        Swap((PictureBox)sender);
    }

    private void Swap(PictureBox clickedPicture)
    {
        if (clickedPicture == emptyPictureBox) return;

        var clickedX = clickedPicture.Location.X;
        var emptyX = emptyPictureBox.Location.X;
        var step = pictureBoxWidth;

        var distance = Math.Abs(clickedX - emptyX) / step;
        if (distance > 2)
        {
            MessageBox.Show("Вам нужно прыгать на соседнюю клетку или через одну лягушку.");
            return;
        }

        int middleX = (clickedX + emptyX) / 2;
        bool hasFrogBetween = Controls.OfType<PictureBox>()
            .Any(pb => pb != clickedPicture &&
                      pb != emptyPictureBox &&
                      pb.Location.X == middleX);

        moveCount++;
        UpdateMoveCount();

        var location = clickedPicture.Location;
        clickedPicture.Location = emptyPictureBox.Location;
        emptyPictureBox.Location = location;

        CheckWinCondition();
    }

    private void UpdateMoveCount()
    {
        moveCountLabel.Text = $"Ходы: {moveCount}";
    }

    private void CheckWinCondition()
    {
        if (gameWon) return;

        var leftWin = true;
        var rightWin = true;

        for (int i = 0 ; i < 4 ; i++)
        {
            var currentX = i * pictureBoxWidth;
            var frogAtPosition = GetFrogAtPosition(currentX);

            if (frogAtPosition == null || !rightFrogs.Contains(frogAtPosition))
            {
                rightWin = false;
                break;
            }
        }


        for (int i = 5 ; i < totalPositions ; i++)
        {
            var currentX = i * pictureBoxWidth;
            var frogAtPosition = GetFrogAtPosition(currentX);

            if (frogAtPosition == null || !leftFrogs.Contains(frogAtPosition))
            {
                leftWin = false;
                break;
            }
        }

        var centerEmpty = emptyPictureBox.Location.X == 4 * pictureBoxWidth;

        if (leftWin && rightWin && centerEmpty)
        {
            gameWon = true;

            var performance = moveCount == optimalMoves ?
                "Отлично! Вы достигли оптимального результата!" :
                $"Можно было решить за {optimalMoves} ходов!";

            var message = $"Поздравляем! Вы победили!\n\nСделано ходов: {moveCount}\n\n{performance}";

            ShowWinMessage(message, moveCount == optimalMoves);
        }
    }

    private PictureBox GetFrogAtPosition(int xPosition)
    {
        return Controls.OfType<PictureBox>()
            .FirstOrDefault(pb => pb.Location.X == xPosition && pb != emptyPictureBox);
    }

    private void ShowWinMessage(string message, bool isOptimal)
    {
        Form winForm = new Form()
        {
            Text = "Победа!",
            Size = new Size(winFormWidth, winFormHeight),
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            MaximizeBox = false,
            MinimizeBox = false
        };

        var centerX = (winFormWidth - imageSize) / 2;

        Control winImageControl = CreateWinImage(imageSize, centerX, imageTop);
        Label messageLabel = CreateMessageLabel(message, winFormWidth, labelHeight, 10, labelTop);

        if (isOptimal)
        {
            Button exitButton = CreateExitButton(buttonWidth, buttonHeight, (winFormWidth - buttonWidth) / 2, buttonTop, winForm);
            winForm.Controls.Add(exitButton);
        }
        else
        {
            int buttonSpacing = 10;
            int startX = (winFormWidth - (buttonWidth * 2 + buttonSpacing)) / 2;

            Button newGameButton = CreateNewGameButton(buttonWidth, buttonHeight, startX, buttonTop, winForm);
            Button exitButton = CreateExitButton(buttonWidth, buttonHeight, startX + buttonWidth + buttonSpacing, buttonTop, winForm);

            winForm.Controls.Add(newGameButton);
            winForm.Controls.Add(exitButton);
        }

        winForm.Controls.Add(winImageControl);
        winForm.Controls.Add(messageLabel);
        winForm.ShowDialog(this);
    }

    private Control CreateWinImage(int size, int x, int y)
    {
        return new PictureBox()
        {
            Image = Properties.Resources._115450386_80e5d380_a224_11eb_8ea8_5d0187aafd06,
            SizeMode = PictureBoxSizeMode.Zoom,
            Size = new Size(size, size),
            Location = new Point(x, y)
        };
    }

    private Label CreateMessageLabel(string text, int width, int height, int x, int y)
    {
        return new Label()
        {
            Text = text,
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = false,
            Size = new Size(width, height),
            Location = new Point(x, y),
            Font = new Font("Arial", 10)
        };
    }

    private Button CreateNewGameButton(int width, int height, int x, int y, Form parentForm)
    {
        Button button = new Button()
        {
            Text = "Новая игра",
            Size = new Size(width, height),
            Location = new Point(x, y)
        };

        button.Click += (s, e) =>
        {
            parentForm.Close();
            StartNewGame();
        };

        return button;
    }

    private Button CreateExitButton(int width, int height, int x, int y, Form parentForm)
    {
        Button button = new Button()
        {
            Text = "Выход",
            Size = new Size(width, height),
            Location = new Point(x, y)
        };

        button.Click += (s, e) =>
        {
            parentForm.Close();
            Application.Exit();
        };

        return button;
    }

    private void StartNewGame()
    {
        for (int i = 0 ; i < allFrogs.Length ; i++)
        {
            allFrogs[i].Location = new Point(i * pictureBoxWidth, startY);
        }

        moveCount = 0;
        gameWon = false;
        UpdateMoveCount();
    }

    private void ShowRules()
    {
        var rules = @"Правила игры 'Лягушки':

Цель: поменять левую группу лягушек с правой группой.

Правила хода:
• Можно передвинуть на свободное место рядом
• Можно перепрыгнуть через одну лягушку
• Прыгать назад нельзя, только вперед

Оптимальное решение: 24 хода";

        MessageBox.Show(rules, "Правила игры", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        StartNewGame();
    }

    private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowRules();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}