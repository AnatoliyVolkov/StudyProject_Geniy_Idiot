namespace BallGamesWinFormsApp
{
    partial class BallButtonStopMainForm
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
            menuStrip1 = new MenuStrip();
            остановитьШарикиToolStripMenuItem = new ToolStripMenuItem();
            запуститьШарикиToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            toolStripTextBox = new ToolStripTextBox();
            ballPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.BackColor = Color.FromArgb(128, 255, 128);
            menuStrip1.Items.AddRange(new ToolStripItem[] { остановитьШарикиToolStripMenuItem, запуститьШарикиToolStripMenuItem, toolStripTextBox1, toolStripTextBox });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(841, 40);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // остановитьШарикиToolStripMenuItem
            // 
            остановитьШарикиToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            остановитьШарикиToolStripMenuItem.Name = "остановитьШарикиToolStripMenuItem";
            остановитьШарикиToolStripMenuItem.Size = new Size(170, 36);
            остановитьШарикиToolStripMenuItem.Text = "Остановить шарики ";
            остановитьШарикиToolStripMenuItem.Click += StopMoveBall_Click;
            // 
            // запуститьШарикиToolStripMenuItem
            // 
            запуститьШарикиToolStripMenuItem.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            запуститьШарикиToolStripMenuItem.Name = "запуститьШарикиToolStripMenuItem";
            запуститьШарикиToolStripMenuItem.Size = new Size(154, 36);
            запуститьШарикиToolStripMenuItem.Text = "Запустить шарики";
            запуститьШарикиToolStripMenuItem.Click += CreateRandomBull_Click;
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.AutoSize = false;
            toolStripTextBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(160, 40);
            toolStripTextBox1.Text = "Поймано шариков";
            toolStripTextBox1.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // toolStripTextBox
            // 
            toolStripTextBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            toolStripTextBox.ForeColor = Color.Red;
            toolStripTextBox.Name = "toolStripTextBox";
            toolStripTextBox.Size = new Size(100, 36);
            toolStripTextBox.Text = "0";
            toolStripTextBox.TextBoxTextAlign = HorizontalAlignment.Center;
            // 
            // ballPanel
            // 
            ballPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ballPanel.Location = new Point(0, 43);
            ballPanel.Name = "ballPanel";
            ballPanel.Size = new Size(841, 528);
            ballPanel.TabIndex = 6;
            ballPanel.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(841, 571);
            Controls.Add(ballPanel);
            Controls.Add(menuStrip1);
            Name = "MainForm";
            Text = "Игра Шарики";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem остановитьШарикиToolStripMenuItem;
        private ToolStripMenuItem запуститьШарикиToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripTextBox toolStripTextBox;
        private Panel ballPanel;
    }
}
