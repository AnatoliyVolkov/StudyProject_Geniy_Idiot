namespace DiffusionBallWinFormsApp
{
    partial class DiffusionBallMainForm
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
            leftLabel.BackColor = Color.Yellow;
            leftLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            leftLabel.ForeColor = Color.DarkGreen;
            leftLabel.Location = new Point(13, 380);
            leftLabel.Name = "leftLabel";
            leftLabel.Size = new Size(19, 21);
            leftLabel.TabIndex = 0;
            leftLabel.Text = "0";
            // 
            // rightLabel
            // 
            rightLabel.Anchor = AnchorStyles.Right;
            rightLabel.AutoSize = true;
            rightLabel.BackColor = Color.Yellow;
            rightLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            rightLabel.ForeColor = Color.DarkGreen;
            rightLabel.Location = new Point(1551, 380);
            rightLabel.Name = "rightLabel";
            rightLabel.Size = new Size(19, 21);
            rightLabel.TabIndex = 1;
            rightLabel.Text = "0";
            // 
            // topLabel
            // 
            topLabel.Anchor = AnchorStyles.Top;
            topLabel.AutoSize = true;
            topLabel.BackColor = Color.Yellow;
            topLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            topLabel.ForeColor = Color.DarkGreen;
            topLabel.Location = new Point(772, 9);
            topLabel.Name = "topLabel";
            topLabel.Size = new Size(19, 21);
            topLabel.TabIndex = 2;
            topLabel.Text = "0";
            // 
            // dawnLabel
            // 
            dawnLabel.Anchor = AnchorStyles.Bottom;
            dawnLabel.AutoSize = true;
            dawnLabel.BackColor = Color.Yellow;
            dawnLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            dawnLabel.ForeColor = Color.DarkGreen;
            dawnLabel.Location = new Point(772, 784);
            dawnLabel.Name = "dawnLabel";
            dawnLabel.Size = new Size(19, 21);
            dawnLabel.TabIndex = 3;
            dawnLabel.Text = "0";
            // 
            // DiffusionBallMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1601, 808);
            Controls.Add(dawnLabel);
            Controls.Add(topLabel);
            Controls.Add(rightLabel);
            Controls.Add(leftLabel);
            Name = "DiffusionBallMainForm";
            Text = "DiffusionBall";
            FormClosed += DiffusionBallMainForm_FormClosed;
            Load += DiffusionBallMainForm_Load;
            MouseDown += MouseKlickStartStopBall_MouseDown;
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
