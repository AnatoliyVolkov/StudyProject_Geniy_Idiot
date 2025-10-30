namespace DiffusionBallWinFormsApp1
{
    partial class StartDiffusionform
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
            label2 = new Label();
            countBallTextBox = new TextBox();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(98, 51);
            label1.Name = "label1";
            label1.Size = new Size(633, 47);
            label1.TabIndex = 0;
            label1.Text = "Добро пожаловать, исследователь!";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(23, 142);
            label2.Name = "label2";
            label2.Size = new Size(756, 32);
            label2.TabIndex = 1;
            label2.Text = "Введи количество молекул газа для имитации процесса диффузии";
            // 
            // countBallTextBox
            // 
            countBallTextBox.AllowDrop = true;
            countBallTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            countBallTextBox.Location = new Point(242, 248);
            countBallTextBox.Name = "countBallTextBox";
            countBallTextBox.Size = new Size(366, 23);
            countBallTextBox.TabIndex = 2;
            countBallTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.AutoEllipsis = true;
            button1.Location = new Point(242, 306);
            button1.Name = "button1";
            button1.Size = new Size(357, 53);
            button1.TabIndex = 3;
            button1.Text = "Запустить процесс";
            button1.UseVisualStyleBackColor = true;
            button1.Click += StartDiffusion_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(344, 194);
            label3.Name = "label3";
            label3.Size = new Size(138, 32);
            label3.TabIndex = 4;
            label3.Text = "от 2 до 100";
            // 
            // StartDiffusionform
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 598);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(countBallTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "StartDiffusionform";
            Text = "StartDiffusionform";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox countBallTextBox;
        private Button button1;
        private Label label3;
    }
}