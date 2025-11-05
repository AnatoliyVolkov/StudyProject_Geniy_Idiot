namespace BillyardBallWinFormsApp
{
    partial class MainFormBillyardBall
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
            leftLabel = new Label();
            rightLabel = new Label();
            topLabel = new Label();
            dawnLabel = new Label();
            SuspendLayout();
            // 
            // leftLabel
            // 
            leftLabel.Anchor = AnchorStyles.Left;
            leftLabel.AutoSize = true;
            leftLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            leftLabel.Location = new Point(12, 211);
            leftLabel.Name = "leftLabel";
            leftLabel.RightToLeft = RightToLeft.No;
            leftLabel.Size = new Size(19, 21);
            leftLabel.TabIndex = 0;
            leftLabel.Text = "0";
            // 
            // rightLabel
            // 
            rightLabel.Anchor = AnchorStyles.Right;
            rightLabel.AutoSize = true;
            rightLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            rightLabel.Location = new Point(769, 211);
            rightLabel.Name = "rightLabel";
            rightLabel.Size = new Size(19, 21);
            rightLabel.TabIndex = 1;
            rightLabel.Text = "0";
            // 
            // topLabel
            // 
            topLabel.Anchor = AnchorStyles.Top;
            topLabel.AutoSize = true;
            topLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            topLabel.Location = new Point(381, 9);
            topLabel.Name = "topLabel";
            topLabel.Size = new Size(19, 21);
            topLabel.TabIndex = 2;
            topLabel.Text = "0";
            // 
            // dawnLabel
            // 
            dawnLabel.Anchor = AnchorStyles.Bottom;
            dawnLabel.AutoSize = true;
            dawnLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dawnLabel.Location = new Point(381, 420);
            dawnLabel.Name = "dawnLabel";
            dawnLabel.Size = new Size(19, 21);
            dawnLabel.TabIndex = 3;
            dawnLabel.Text = "0";
            // 
            // MainFormBillyardBall
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dawnLabel);
            Controls.Add(topLabel);
            Controls.Add(rightLabel);
            Controls.Add(leftLabel);
            Name = "MainFormBillyardBall";
            Text = "BillyardBall";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label leftLabel;
        private Label rightLabel;
        private Label topLabel;
        private Label dawnLabel;
    }
}
