namespace _2048WinFormsApp
{
    partial class Map
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
            label = new Label();
            label1 = new Label();
            scoreLabel = new Label();
            SuspendLayout();
            // 
            // label
            // 
            label.Location = new Point(0, 0);
            label.Name = "label";
            label.Size = new Size(100, 23);
            label.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(201, 28);
            label1.Name = "label1";
            label1.Size = new Size(211, 37);
            label1.TabIndex = 1;
            label1.Text = "Текущий счет :";
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            scoreLabel.Location = new Point(418, 28);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(96, 37);
            scoreLabel.TabIndex = 2;
            scoreLabel.Text = "label2";
            // 
            // Map
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 946);
            Controls.Add(scoreLabel);
            Controls.Add(label1);
            Controls.Add(label);
            Name = "Map";
            Text = "Form1";
            FormClosing += Map_FormClosing;
            Load += Map_Load;
            KeyDown += Map_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private Label label1;
        private Label scoreLabel;
    }
}
