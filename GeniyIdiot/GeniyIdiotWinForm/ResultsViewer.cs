using GeniyIdiotClassLibrary;
using System.IO;

namespace GeniyIdiotWinForm
{
    public static class ResultsViewer
    {
        public static void ShowResultsTable()
        {
            try
            {
                string resultsPath = "test_results.txt";

                if (!File.Exists(resultsPath))
                {
                    MessageBox.Show("Файл с результатами не найден.", "Результаты",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var results = UserResultStorage.LoadFromFile(resultsPath);

                if (results.Count == 0)
                {
                    MessageBox.Show("Результатов тестирования пока нет.", "Результаты",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var tableForm = CreateResultsForm(results);
                tableForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке результатов: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Form CreateResultsForm(List<User> results)
        {
            var form = new Form()
            {
                Text = "Результаты тестирования",
                Size = new Size(700, 400),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            var dataGridView = new DataGridView()
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                BackgroundColor = SystemColors.Window
            };

            dataGridView.Columns.Add("FullName", "ФИО");
            dataGridView.Columns.Add("Score", "Правильные ответы");
            dataGridView.Columns.Add("Diagnosis", "Диагноз");

            foreach (var result in results)
            {
                dataGridView.Rows.Add(result.FullName, result.Score, result.Diagnosis);
            }

            var closeButton = new Button()
            {
                Text = "Закрыть",
                Size = new Size(100, 30),
                Anchor = AnchorStyles.Bottom
            };
            closeButton.Click += (s, e) => form.Close();

            var panel = new Panel() { Dock = DockStyle.Fill };
            panel.Controls.Add(dataGridView);

            var buttonPanel = new Panel()
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                Padding = new Padding(10)
            };
            buttonPanel.Controls.Add(closeButton);

            form.Controls.Add(panel);
            form.Controls.Add(buttonPanel);

            return form;
        }
    }
}