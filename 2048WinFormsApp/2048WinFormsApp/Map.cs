using System.Drawing;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2048WinFormsApp
{
    public partial class Map : Form
    {
        private Label[,] mapSaze;
        private int mapSize { get; }
        private int count = 0;
        private static Random random = new Random();


        public Map(int size)
        {
            InitializeComponent();
            mapSize = size;
        }

        private void Map_Load(object sender, EventArgs e)
        {
            InitMap(mapSize);
            GenerationNumber();
            ShowScore();
        }

        private void ShowScore()
        {
            scoreLabel.Text = count.ToString(); 
        }
        private void InitMap(int size)
        {
            mapSaze = new Label[size, size];
            for (int i = 0 ; i < mapSize ; i++)
            {
                for (int j = 0 ; j < size ; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    mapSaze[i, j] = newLabel;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label.BackColor = Color.Gray;
            int row = 40 + indexColumn * 86;
            int column = 70 + indexRow * 86;
            label.Location = new Point(row, column);
            label.Size = new Size(80, 80);
            label.TextAlign = ContentAlignment.MiddleCenter;
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
                    for (int colomn = 0 ; colomn < mapSize ; colomn++)
                    {
                        if (mapSaze[row, colomn].Text != string.Empty)
                        {
                            for (int k = colomn + 1 ; k < mapSize ; k++)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    if (mapSaze[row, colomn].Text == mapSaze[row, k].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, colomn].Text);
                                        mapSaze[row, colomn].Text = (number * 2).ToString();
                                        count += (number * 2);
                                        mapSaze[row, k].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int row = 0 ; row < mapSize ; row++)
                {
                    for (int colomn = 0 ; colomn < mapSize ; colomn++)
                    {
                        if (mapSaze[row, colomn].Text == string.Empty)
                        {
                            for (int k = colomn + 1 ; k < mapSize ; k++)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    mapSaze[row, colomn].Text = mapSaze[row, k].Text;
                                    mapSaze[row, k].Text = string.Empty;
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
                    for (int colomn = mapSize - 1 ; colomn >= 0 ; colomn--)
                    {
                        if (mapSaze[row, colomn].Text != string.Empty)
                        {
                            for (int k = colomn - 1 ; k >= 0 ; k--)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    if (mapSaze[row, colomn].Text == mapSaze[row, k].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, colomn].Text);
                                        mapSaze[row, colomn].Text = (number * 2).ToString();
                                        count += (number * 2);
                                        mapSaze[row, k].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int row = 0 ; row < mapSize ; row++)
                {
                    for (int colomn = mapSize - 1 ; colomn >= 0 ; colomn--)
                    {
                        if (mapSaze[row, colomn].Text == string.Empty)
                        {
                            for (int k = colomn - 1 ; k >= 0 ; k--)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    mapSaze[row, colomn].Text = mapSaze[row, k].Text;
                                    mapSaze[row, k].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            if (e.KeyCode == Keys.Up)
            {
                for (int colomn = 0 ; colomn < mapSize ; colomn++)
                {
                    for (int row = 0 ; row < mapSize ; row++)
                    {
                        if (mapSaze[row, colomn].Text != string.Empty)
                        {
                            for (int k = row + 1 ; k < mapSize ; k++)
                            {
                                if (mapSaze[row, colomn].Text != string.Empty)
                                {
                                    if (mapSaze[row, colomn].Text == mapSaze[k, colomn].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, colomn].Text);
                                        mapSaze[row, colomn].Text = (number * 2).ToString();
                                        count += (number * 2);
                                        mapSaze[k, colomn].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int colomn = 0 ; colomn < mapSize ; colomn++)
                {
                    for (int row = 0 ; row < mapSize ; row++)
                    {
                        if (mapSaze[row, colomn].Text == string.Empty)
                        {
                            for (int k = row + 1 ; k < mapSize ; k++)
                            {
                                if (mapSaze[k, colomn].Text != string.Empty)
                                {
                                    mapSaze[row, colomn].Text = mapSaze[k, colomn].Text;
                                    mapSaze[k, colomn].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            if (e.KeyCode == Keys.Down)
            {
                for (int colomn = 0 ; colomn < mapSize ; colomn++)
                {
                    for (int row = mapSize -1 ; row >= 0 ; row--)
                    {
                        if (mapSaze[row, colomn].Text != string.Empty)
                        {
                            for (int k = row - 1 ; k >= 0 ; k--)
                            {
                                if (mapSaze[row, colomn].Text != string.Empty)
                                {
                                    if (mapSaze[row, colomn].Text == mapSaze[k, colomn].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, colomn].Text);
                                        mapSaze[row, colomn].Text = (number * 2).ToString();
                                        count += (number * 2);
                                        mapSaze[k, colomn].Text = string.Empty;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int colomn = 0 ; colomn < mapSize ; colomn++)
                {
                    for (int row = mapSize - 1 ; row >= 0 ; row--)
                    {
                        if (mapSaze[row, colomn].Text == string.Empty)
                        {
                            for (int k = row - 1 ; k >= 0 ; k--)
                            {
                                if (mapSaze[k, colomn].Text != string.Empty)
                                {
                                    mapSaze[row, colomn].Text = mapSaze[k, colomn].Text;
                                    mapSaze[k, colomn].Text = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            GenerationNumber();
            ShowScore();
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
    }
}
