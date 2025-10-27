namespace _2048WinFormsApp
{
    partial class StartMenu
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
            label1 = new Label();
            buttonForStartGame = new Button();
            infoGameButton = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label1.Location = new Point(-2, 0);
            label1.Name = "label1";
            label1.Size = new Size(805, 76);
            label1.TabIndex = 0;
            label1.Text = "Приветствие";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonForStartGame
            // 
            buttonForStartGame.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonForStartGame.Location = new Point(310, 243);
            buttonForStartGame.Name = "buttonForStartGame";
            buttonForStartGame.Size = new Size(188, 75);
            buttonForStartGame.TabIndex = 1;
            buttonForStartGame.Text = "Начать игру";
            buttonForStartGame.UseVisualStyleBackColor = true;
            buttonForStartGame.Click += ButtonForStartGame_Click;
            // 
            // infoGameButton
            // 
            infoGameButton.Location = new Point(43, 324);
            infoGameButton.Name = "infoGameButton";
            infoGameButton.Size = new Size(153, 51);
            infoGameButton.TabIndex = 2;
            infoGameButton.Text = "Правила игры";
            infoGameButton.UseVisualStyleBackColor = true;
            infoGameButton.Click += InfoGameButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(599, 324);
            button3.Name = "button3";
            button3.Size = new Size(153, 51);
            button3.TabIndex = 3;
            button3.Text = "Выход";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ButtonForExit_Click;
            // 
            // button4
            // 
            button4.Location = new Point(310, 387);
            button4.Name = "button4";
            button4.Size = new Size(188, 51);
            button4.TabIndex = 4;
            button4.Text = "Таблица лидеров";
            button4.UseVisualStyleBackColor = true;
            button4.Click += ButtonShowResult_Click;
            // 
            // StartMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(infoGameButton);
            Controls.Add(buttonForStartGame);
            Controls.Add(label1);
            Name = "StartMenu";
            Text = "Form1";
            FormClosing += StartMenu_FormClosing_1;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button buttonForStartGame;
        private Button infoGameButton;
        private Button button3;
        private Button button4;
    }
}
