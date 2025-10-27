namespace _2048WinFormsApp
{
    partial class UserInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            userTextBox = new TextBox();
            label2 = new Label();
            userTextBoxMapSize = new TextBox();
            buttonStartGame = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 73);
            label1.Name = "label1";
            label1.Size = new Size(776, 54);
            label1.TabIndex = 0;
            label1.Text = "Введите свое имя";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(225, 142);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(355, 23);
            userTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(12, 252);
            label2.Name = "label2";
            label2.Size = new Size(776, 50);
            label2.TabIndex = 2;
            label2.Text = "Введите размер поля\r\n";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userTextBoxMapSize
            // 
            userTextBoxMapSize.Location = new Point(225, 315);
            userTextBoxMapSize.Name = "userTextBoxMapSize";
            userTextBoxMapSize.Size = new Size(355, 23);
            userTextBoxMapSize.TabIndex = 3;
            // 
            // buttonStartGame
            // 
            buttonStartGame.Location = new Point(281, 384);
            buttonStartGame.Name = "buttonStartGame";
            buttonStartGame.Size = new Size(236, 54);
            buttonStartGame.TabIndex = 4;
            buttonStartGame.Text = "СТАРТ";
            buttonStartGame.UseVisualStyleBackColor = true;
            buttonStartGame.Click += ButtonStartGame_Click;
            // 
            // UserInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonStartGame);
            Controls.Add(userTextBoxMapSize);
            Controls.Add(label2);
            Controls.Add(userTextBox);
            Controls.Add(label1);
            Name = "UserInput";
            Text = "UserInput";
            FormClosing += UserInput_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox userTextBoxMapSize;
        private Button buttonStartGame;
        private TextBox userTextBox;
    }
}