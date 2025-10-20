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
            createBallButton = new Button();
            createRandomBullButton = new Button();
            SuspendLayout();
            // 
            // createBallButton
            // 
            createBallButton.Location = new Point(622, 43);
            createBallButton.Name = "createBallButton";
            createBallButton.Size = new Size(122, 41);
            createBallButton.TabIndex = 0;
            createBallButton.Text = "Рисивать шарик";
            createBallButton.UseVisualStyleBackColor = true;
            createBallButton.Click += CreateBallButton_Click;
            // 
            // createRandomBullButton
            // 
            createRandomBullButton.Location = new Point(622, 112);
            createRandomBullButton.Name = "createRandomBullButton";
            createRandomBullButton.Size = new Size(122, 41);
            createRandomBullButton.TabIndex = 1;
            createRandomBullButton.Text = "Случайный шарик";
            createRandomBullButton.UseVisualStyleBackColor = true;
            createRandomBullButton.Click += CreateRandomBullButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(createRandomBullButton);
            Controls.Add(createBallButton);
            Name = "MainForm";
            Text = "Игра Шарики";
            MouseDown += MainForm_MouseDown;
            ResumeLayout(false);
        }

        #endregion

        private Button createBallButton;
        private Button createRandomBullButton;
    }
}
