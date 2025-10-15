namespace _2048WinFormsApp
{
    partial class ResultsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            resultsDataGridView = new DataGridView();
            UserNameColumn = new DataGridViewTextBoxColumn();
            BestScoreColumn = new DataGridViewTextBoxColumn(); // Изменено с ScoreColumn на BestScoreColumn
            backButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // resultsDataGridView
            // 
            resultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsDataGridView.Columns.AddRange(new DataGridViewColumn[] { UserNameColumn, BestScoreColumn });
            resultsDataGridView.Location = new Point(50, 80);
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.Size = new Size(500, 300);
            resultsDataGridView.TabIndex = 0;
            // 
            // UserNameColumn
            // 
            UserNameColumn.HeaderText = "Имя игрока";
            UserNameColumn.Name = "UserNameColumn";
            UserNameColumn.Width = 250;
            // 
            // BestScoreColumn
            // 
            BestScoreColumn.HeaderText = "Лучший счет"; // Изменено заголовок
            BestScoreColumn.Name = "BestScoreColumn";
            BestScoreColumn.Width = 200;
            // 
            // backButton
            // 
            backButton.Location = new Point(250, 400);
            backButton.Name = "backButton";
            backButton.Size = new Size(100, 30);
            backButton.TabIndex = 1;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(200, 30);
            label1.Name = "label1";
            label1.Size = new Size(220, 32);
            label1.TabIndex = 2;
            label1.Text = "Таблица лидеров";
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 450);
            Controls.Add(label1);
            Controls.Add(backButton);
            Controls.Add(resultsDataGridView);
            Name = "ResultsForm";
            Text = "Результаты";
            FormClosing += ResultsForm_FormClosing;
            Load += ResultsForm_Load;
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView resultsDataGridView;
        private DataGridViewTextBoxColumn UserNameColumn;
        private DataGridViewTextBoxColumn BestScoreColumn; // Изменено объявление
        private Button backButton;
        private Label label1;
    }
}