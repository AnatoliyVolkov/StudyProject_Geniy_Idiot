using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048WinFormsApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            LoadResults();
        }

        private void LoadResults()
        {
            try
            {
                var results = DataStorage.ReadAll();
                resultsDataGridView.Rows.Clear();

                // Сортируем по счету (от большего к меньшему)
                var sortedResults = results.OrderByDescending(u => u.Score).ToList();

                foreach (var user in sortedResults)
                {
                    resultsDataGridView.Rows.Add(user.UserName, user.Score);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки результатов: {ex.Message}");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var startMenu = new StartMenu();
            startMenu.Show();
            this.Hide();
        }

        private void ResultsForm_FormClosing(object sender, FormClosingEventArgs e)
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