namespace BallGamesWinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            stopMoveBallButton = new Button();
            createRandomBullButton = new Button();
            label1 = new Label();
            countBallLabel = new Label();
            SuspendLayout();
            // 
            // stopMoveBallButton
            // 
            stopMoveBallButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stopMoveBallButton.Location = new Point(666, 43);
            stopMoveBallButton.Name = "stopMoveBallButton";
            stopMoveBallButton.Size = new Size(122, 41);
            stopMoveBallButton.TabIndex = 0;
            stopMoveBallButton.Text = "Остановить шарики";
            stopMoveBallButton.UseVisualStyleBackColor = true;
            stopMoveBallButton.Click += StopMoveBallButton_Click;
            // 
            // createRandomBullButton
            // 
            createRandomBullButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createRandomBullButton.Location = new Point(666, 115);
            createRandomBullButton.Name = "createRandomBullButton";
            createRandomBullButton.Size = new Size(122, 41);
            createRandomBullButton.TabIndex = 1;
            createRandomBullButton.Text = "Случайный шарик";
            createRandomBullButton.UseVisualStyleBackColor = true;
            createRandomBullButton.Click += CreateRandomBullButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(16, 12);
            label1.Name = "label1";
            label1.Size = new Size(144, 21);
            label1.TabIndex = 2;
            label1.Text = "Поймано шариков";
            // 
            // countBallLabel
            // 
            countBallLabel.AutoSize = true;
            countBallLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            countBallLabel.Location = new Point(43, 43);
            countBallLabel.Name = "countBallLabel";
            countBallLabel.Size = new Size(64, 25);
            countBallLabel.TabIndex = 3;
            countBallLabel.Text = "label2";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(countBallLabel);
            Controls.Add(label1);
            Controls.Add(createRandomBullButton);
            Controls.Add(stopMoveBallButton);
            Name = "MainForm";
            Text = "Игра Шарики";
            MouseDown += MainForm_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button stopMoveBallButton;
        private Button createRandomBullButton;
        private Label label1;
        private Label countBallLabel;
    }
}
