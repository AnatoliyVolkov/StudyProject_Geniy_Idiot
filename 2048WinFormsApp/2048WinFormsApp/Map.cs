using Newtonsoft.Json;

namespace _2048WinFormsApp
{
    public partial class Map : Form
    {
        private string userName;
        private Label[,] mapSaze;
        private int mapSize;
        private int count = 0;
        private static Random random = new Random();
        private Label userNameLabel;

        public Map(int size, string name)
        {
            InitializeComponent();
            mapSize = size;
            userName = name;
            CreateUserInfoControls();
        }

        private  void Map_Load(object sender, EventArgs e)
        {
            InitMap(mapSize);
            GenerationNumber();
            ShowScore();
            label2.Text = ShowBestPoint();
        }

        private string ShowBestPoint()
        {
            try
            {
                var results = DataStorage.ReadAll();
                var sortedResults = results.OrderByDescending(u => u.Score).ToList();
                var line = sortedResults[0].Score.ToString();
                return line;
            }
            catch { return "0"; }
        }

        private void CreateUserInfoControls()
        {
            userNameLabel = new Label();
            userNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            userNameLabel.ForeColor = Color.DarkBlue;
            userNameLabel.Location = new Point(20, 10);
            userNameLabel.AutoSize = true;
            userNameLabel.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            userNameLabel.Text = $"Игрок: {userName}";
            Controls.Add(userNameLabel);
        }

        private void ShowScore()
        {
            scoreLabel.Text = count.ToString();
        }

        private void InitMap(int size)
        {
            var panel = new TableLayoutPanel();
            panel.RowCount = size;
            panel.ColumnCount = size;
            panel.AutoSize = true;
            panel.Location = new Point(100, 100);
            for (int i = 0 ; i < size ; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 76));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            mapSaze = new Label[size, size];
            for (int i = 0 ; i < mapSize ; i++)
            {
                for (int j = 0 ; j < size ; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    panel.Controls.Add(newLabel, j, i);
                    mapSaze[i, j] = newLabel;
                }
            }
            Controls.Add(panel);
        }


        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label
            {
                Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204),
                BackColor = Color.Gray,
                ForeColor = Color.Black,
                Height = 70,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = string.Empty,
            };
            label.TextChanged += (sender, e) =>
            {
                UpdateCellColor(sender as Label);
            };
            return label;
        }

        private void GenerationNumber()
        {
            int labelEmpty = mapSize * mapSize;
            while (labelEmpty > 0)
            {
                var randomNumberLabel = random.Next(mapSize * mapSize);
                var indexRow = randomNumberLabel / mapSize;
                var indexColumn = randomNumberLabel % mapSize;
                var number = random.Next(100) < 25 ? "4" : "2";
                if (mapSaze[indexRow, indexColumn].Text == string.Empty)
                {
                    mapSaze[indexRow, indexColumn].Text = number;
                    UpdateCellColor(mapSaze[indexRow, indexColumn]);
                    break;
                }
                labelEmpty--;
            }
        }

        private void Map_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                for (int row = 0 ; row < mapSize ; row++)
                {
                    for (int column = 0 ; column < mapSize ; column++)
                    {
                        if (mapSaze[row, column].Text != string.Empty)
                        {
                            for (int k = column + 1 ; k < mapSize ; k++)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    if (mapSaze[row, column].Text == mapSaze[row, k].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, column].Text);
                                        mapSaze[row, column].Text = (number * 2).ToString();
                                        UpdateCellColor(mapSaze[row, column]);
                                        count += (number * 2);
                                        mapSaze[row, k].Text = string.Empty;
                                        UpdateCellColor(mapSaze[row, k]);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int row = 0 ; row < mapSize ; row++)
                {
                    for (int column = 0 ; column < mapSize ; column++)
                    {
                        if (mapSaze[row, column].Text == string.Empty)
                        {
                            for (int k = column + 1 ; k < mapSize ; k++)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    mapSaze[row, column].Text = mapSaze[row, k].Text;
                                    mapSaze[row, column].BackColor = mapSaze[row, k].BackColor;
                                    mapSaze[row, column].ForeColor = mapSaze[row, k].ForeColor;

                                    mapSaze[row, k].Text = string.Empty;
                                    UpdateCellColor(mapSaze[row, k]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                for (int row = 0 ; row < mapSize ; row++)
                {
                    for (int column = mapSize - 1 ; column >= 0 ; column--)
                    {
                        if (mapSaze[row, column].Text != string.Empty)
                        {
                            for (int k = column - 1 ; k >= 0 ; k--)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    if (mapSaze[row, column].Text == mapSaze[row, k].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, column].Text);
                                        mapSaze[row, column].Text = (number * 2).ToString();
                                        UpdateCellColor(mapSaze[row, column]);
                                        count += (number * 2);
                                        mapSaze[row, k].Text = string.Empty;
                                        UpdateCellColor(mapSaze[row, k]);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int row = 0 ; row < mapSize ; row++)
                {
                    for (int column = mapSize - 1 ; column >= 0 ; column--)
                    {
                        if (mapSaze[row, column].Text == string.Empty)
                        {
                            for (int k = column - 1 ; k >= 0 ; k--)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    mapSaze[row, column].Text = mapSaze[row, k].Text;
                                    mapSaze[row, column].BackColor = mapSaze[row, k].BackColor;
                                    mapSaze[row, column].ForeColor = mapSaze[row, k].ForeColor;

                                    mapSaze[row, k].Text = string.Empty;
                                    UpdateCellColor(mapSaze[row, k]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                for (int column = 0 ; column < mapSize ; column++)
                {
                    for (int row = 0 ; row < mapSize ; row++)
                    {
                        if (mapSaze[row, column].Text != string.Empty)
                        {
                            for (int k = row + 1 ; k < mapSize ; k++)
                            {
                                if (mapSaze[k, column].Text != string.Empty)
                                {
                                    if (mapSaze[row, column].Text == mapSaze[k, column].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, column].Text);
                                        mapSaze[row, column].Text = (number * 2).ToString();
                                        UpdateCellColor(mapSaze[row, column]);
                                        count += (number * 2);
                                        mapSaze[k, column].Text = string.Empty;
                                        UpdateCellColor(mapSaze[k, column]);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int column = 0 ; column < mapSize ; column++)
                {
                    for (int row = 0 ; row < mapSize ; row++)
                    {
                        if (mapSaze[row, column].Text == string.Empty)
                        {
                            for (int k = row + 1 ; k < mapSize ; k++)
                            {
                                if (mapSaze[k, column].Text != string.Empty)
                                {
                                    mapSaze[row, column].Text = mapSaze[k, column].Text;
                                    mapSaze[row, column].BackColor = mapSaze[k, column].BackColor;
                                    mapSaze[row, column].ForeColor = mapSaze[k, column].ForeColor;

                                    mapSaze[k, column].Text = string.Empty;
                                    UpdateCellColor(mapSaze[k, column]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                for (int column = 0 ; column < mapSize ; column++)
                {
                    for (int row = mapSize - 1 ; row >= 0 ; row--)
                    {
                        if (mapSaze[row, column].Text != string.Empty)
                        {
                            for (int k = row - 1 ; k >= 0 ; k--)
                            {
                                if (mapSaze[k, column].Text != string.Empty)
                                {
                                    if (mapSaze[row, column].Text == mapSaze[k, column].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, column].Text);
                                        mapSaze[row, column].Text = (number * 2).ToString();
                                        UpdateCellColor(mapSaze[row, column]);
                                        count += (number * 2);
                                        mapSaze[k, column].Text = string.Empty;
                                        UpdateCellColor(mapSaze[k, column]);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int column = 0 ; column < mapSize ; column++)
                {
                    for (int row = mapSize - 1 ; row >= 0 ; row--)
                    {
                        if (mapSaze[row, column].Text == string.Empty)
                        {
                            for (int k = row - 1 ; k >= 0 ; k--)
                            {
                                if (mapSaze[k, column].Text != string.Empty)
                                {
                                    mapSaze[row, column].Text = mapSaze[k, column].Text;
                                    mapSaze[row, column].BackColor = mapSaze[k, column].BackColor;
                                    mapSaze[row, column].ForeColor = mapSaze[k, column].ForeColor;

                                    mapSaze[k, column].Text = string.Empty;
                                    UpdateCellColor(mapSaze[k, column]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            GenerationNumber();
            ShowScore();
            CheckGameOver();
        }

        private void UpdateCellColor(Control cell)
        {
            if (cell.Text == string.Empty)
            {
                cell.BackColor = Color.Gray;
                cell.ForeColor = Color.Black;
                return;
            }

            switch (cell.Text)
            {
                case "2":
                    cell.BackColor = Color.AliceBlue;
                    cell.ForeColor = Color.Black;
                    break;
                case "4":
                    cell.BackColor = Color.Beige;
                    cell.ForeColor = Color.Black;
                    break;
                case "8":
                    cell.BackColor = Color.PapayaWhip;
                    cell.ForeColor = Color.Black;
                    break;
                case "16":
                    cell.BackColor = Color.PeachPuff;
                    cell.ForeColor = Color.Black;
                    break;
                case "32":
                    cell.BackColor = Color.Gold;
                    cell.ForeColor = Color.Black;
                    break;
                case "64":
                    cell.BackColor = Color.Tan;
                    cell.ForeColor = Color.Black;
                    break;
                case "128":
                    cell.BackColor = Color.Goldenrod;
                    cell.ForeColor = Color.White;
                    break;
                case "256":
                    cell.BackColor = Color.Chocolate;
                    cell.ForeColor = Color.White;
                    break;
                case "512":
                    cell.BackColor = Color.DimGray;
                    cell.ForeColor = Color.White;
                    break;
                case "1024":
                    cell.BackColor = Color.SlateGray;
                    cell.ForeColor = Color.White;
                    break;
                case "2048":
                    cell.BackColor = Color.DarkSlateGray;
                    cell.ForeColor = Color.White;
                    break;
                case "4096":
                    cell.BackColor = Color.Maroon;
                    cell.ForeColor = Color.White;
                    break;
                case "8192":
                    cell.BackColor = Color.Black;
                    cell.ForeColor = Color.White;
                    break;
                default:
                    cell.BackColor = Color.Gray;
                    cell.ForeColor = Color.Black;
                    break;
            }
        }

        private void Map_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                                                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else { e.Cancel = true; }
        }

        private bool IsGameOver()
        {
            for (int i = 0 ; i < mapSize ; i++)
            {
                for (int j = 0 ; j < mapSize ; j++)
                {
                    if (mapSaze[i, j].Text == string.Empty)
                        return false;
                }
            }
            for (int i = 0 ; i < mapSize ; i++)
            {
                for (int j = 0 ; j < mapSize ; j++)
                {
                    var current = mapSaze[i, j].Text;
                    if (current == string.Empty) continue;

                    if (j < mapSize - 1 && mapSaze[i, j + 1].Text == current)
                        return false;

                    if (i < mapSize - 1 && mapSaze[i + 1, j].Text == current)
                        return false;
                }
            }

            return true;
        }

        private void CheckGameOver()
        {
            if (IsGameOver())
            {
                var user = new User(userName, count);
                DataStorage.Save(user);

                MessageBox.Show($"Игра окончена!\nВаш счет: {count}", "Конец игры");
                var startMenu = new StartMenu();
                startMenu.Show();
                this.Hide();
            }
        }

        
    }
}