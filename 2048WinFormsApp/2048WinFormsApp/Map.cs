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
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < size; j++)
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
            label.ForeColor = Color.Black;
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
                for (int row = 0; row < mapSize; row++)
                {
                    for (int colomn = 0; colomn < mapSize; colomn++)
                    {
                        if (mapSaze[row, colomn].Text != string.Empty)
                        {
                            for (int k = colomn + 1; k < mapSize; k++)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    if (mapSaze[row, colomn].Text == mapSaze[row, k].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, colomn].Text);
                                        mapSaze[row, colomn].Text = (number * 2).ToString();
                                        UpdateCellColor(mapSaze[row, colomn]);
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
                for (int row = 0; row < mapSize; row++)
                {
                    for (int colomn = 0; colomn < mapSize; colomn++)
                    {
                        if (mapSaze[row, colomn].Text == string.Empty)
                        {
                            for (int k = colomn + 1; k < mapSize; k++)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    mapSaze[row, colomn].Text = mapSaze[row, k].Text;
                                    mapSaze[row, colomn].BackColor = mapSaze[row, k].BackColor;
                                    mapSaze[row, colomn].ForeColor = mapSaze[row, k].ForeColor;

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
                for (int row = 0; row < mapSize; row++)
                {
                    for (int colomn = mapSize - 1; colomn >= 0; colomn--)
                    {
                        if (mapSaze[row, colomn].Text != string.Empty)
                        {
                            for (int k = colomn - 1; k >= 0; k--)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    if (mapSaze[row, colomn].Text == mapSaze[row, k].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, colomn].Text);
                                        mapSaze[row, colomn].Text = (number * 2).ToString();
                                        UpdateCellColor(mapSaze[row, colomn]);
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
                for (int row = 0; row < mapSize; row++)
                {
                    for (int colomn = mapSize - 1; colomn >= 0; colomn--)
                    {
                        if (mapSaze[row, colomn].Text == string.Empty)
                        {
                            for (int k = colomn - 1; k >= 0; k--)
                            {
                                if (mapSaze[row, k].Text != string.Empty)
                                {
                                    mapSaze[row, colomn].Text = mapSaze[row, k].Text;
                                    mapSaze[row, colomn].BackColor = mapSaze[row, k].BackColor;
                                    mapSaze[row, colomn].ForeColor = mapSaze[row, k].ForeColor;

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
                for (int colomn = 0; colomn < mapSize; colomn++)
                {
                    for (int row = 0; row < mapSize; row++)
                    {
                        if (mapSaze[row, colomn].Text != string.Empty)
                        {
                            for (int k = row + 1; k < mapSize; k++)
                            {
                                if (mapSaze[k, colomn].Text != string.Empty)
                                {
                                    if (mapSaze[row, colomn].Text == mapSaze[k, colomn].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, colomn].Text);
                                        mapSaze[row, colomn].Text = (number * 2).ToString();
                                        UpdateCellColor(mapSaze[row, colomn]);
                                        count += (number * 2);
                                        mapSaze[k, colomn].Text = string.Empty;
                                        UpdateCellColor(mapSaze[k, colomn]);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int colomn = 0; colomn < mapSize; colomn++)
                {
                    for (int row = 0; row < mapSize; row++)
                    {
                        if (mapSaze[row, colomn].Text == string.Empty)
                        {
                            for (int k = row + 1; k < mapSize; k++)
                            {
                                if (mapSaze[k, colomn].Text != string.Empty)
                                {
                                    mapSaze[row, colomn].Text = mapSaze[k, colomn].Text;
                                    mapSaze[row, colomn].BackColor = mapSaze[k, colomn].BackColor;
                                    mapSaze[row, colomn].ForeColor = mapSaze[k, colomn].ForeColor;

                                    mapSaze[k, colomn].Text = string.Empty;
                                    UpdateCellColor(mapSaze[k, colomn]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                for (int colomn = 0; colomn < mapSize; colomn++)
                {
                    for (int row = mapSize - 1; row >= 0; row--)
                    {
                        if (mapSaze[row, colomn].Text != string.Empty)
                        {
                            for (int k = row - 1; k >= 0; k--)
                            {
                                if (mapSaze[k, colomn].Text != string.Empty)
                                {
                                    if (mapSaze[row, colomn].Text == mapSaze[k, colomn].Text)
                                    {
                                        var number = int.Parse(mapSaze[row, colomn].Text);
                                        mapSaze[row, colomn].Text = (number * 2).ToString();
                                        UpdateCellColor(mapSaze[row, colomn]);
                                        count += (number * 2);
                                        mapSaze[k, colomn].Text = string.Empty;
                                        UpdateCellColor(mapSaze[k, colomn]);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (int colomn = 0; colomn < mapSize; colomn++)
                {
                    for (int row = mapSize - 1; row >= 0; row--)
                    {
                        if (mapSaze[row, colomn].Text == string.Empty)
                        {
                            for (int k = row - 1; k >= 0; k--)
                            {
                                if (mapSaze[k, colomn].Text != string.Empty)
                                {
                                    mapSaze[row, colomn].Text = mapSaze[k, colomn].Text;
                                    mapSaze[row, colomn].BackColor = mapSaze[k, colomn].BackColor;
                                    mapSaze[row, colomn].ForeColor = mapSaze[k, colomn].ForeColor;

                                    mapSaze[k, colomn].Text = string.Empty;
                                    UpdateCellColor(mapSaze[k, colomn]);
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
    }
}