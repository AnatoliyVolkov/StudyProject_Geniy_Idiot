namespace _2048WinFormsApp
{
    partial class Map
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
            scoreLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // scoreLabel
            // 
            scoreLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            scoreLabel.Location = new Point(631, 9);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(25, 30);
            scoreLabel.TabIndex = 0;
            scoreLabel.Text = "0";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(448, 9);
            label1.Name = "label1";
            label1.Size = new Size(164, 30);
            label1.TabIndex = 1;
            label1.Text = "Текущий счет: ";
            // 
            // Map
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 643);
            Controls.Add(label1);
            Controls.Add(scoreLabel);
            Name = "Map";
            Text = "2048";
            FormClosing += Map_FormClosing;
            Load += Map_Load;
            KeyDown += Map_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label scoreLabel;
        private Label label1;
    }
}