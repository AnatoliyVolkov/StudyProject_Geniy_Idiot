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
            textBox1 = new TextBox();
            label2 = new Label();
            userTextBoxMapSize = new TextBox();
            button1 = new Button();
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
            // textBox1
            // 
            textBox1.Location = new Point(225, 142);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(355, 23);
            textBox1.TabIndex = 1;
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
            // button1
            // 
            button1.Location = new Point(281, 384);
            button1.Name = "button1";
            button1.Size = new Size(236, 54);
            button1.TabIndex = 4;
            button1.Text = "СТАРТ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UserInput
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(userTextBoxMapSize);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "UserInput";
            Text = "UserInput";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox userTextBoxMapSize;
        private Button button1;
    }
}