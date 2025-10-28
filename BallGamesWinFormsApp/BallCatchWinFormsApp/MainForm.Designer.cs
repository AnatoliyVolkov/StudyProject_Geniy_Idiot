namespace BallLibrary
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
            menuStrip1 = new MenuStrip();
            запуститьШарикиToolStripMenuItem = new ToolStripMenuItem();
            количествоПойманныхШариковToolStripMenuItem = new ToolStripMenuItem();
            cathBallToolStripTextBox = new ToolStripTextBox();
            ballPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { запуститьШарикиToolStripMenuItem, количествоПойманныхШариковToolStripMenuItem, cathBallToolStripTextBox });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 27);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // запуститьШарикиToolStripMenuItem
            // 
            запуститьШарикиToolStripMenuItem.Name = "запуститьШарикиToolStripMenuItem";
            запуститьШарикиToolStripMenuItem.Size = new Size(121, 23);
            запуститьШарикиToolStripMenuItem.Text = "Запустить шарики";
            запуститьШарикиToolStripMenuItem.Click += CreateRandomBull_Click;
            // 
            // количествоПойманныхШариковToolStripMenuItem
            // 
            количествоПойманныхШариковToolStripMenuItem.Name = "количествоПойманныхШариковToolStripMenuItem";
            количествоПойманныхШариковToolStripMenuItem.Size = new Size(204, 23);
            количествоПойманныхШариковToolStripMenuItem.Text = "Количество пойманных шариков";
            // 
            // cathBallToolStripTextBox
            // 
            cathBallToolStripTextBox.Name = "cathBallToolStripTextBox";
            cathBallToolStripTextBox.Size = new Size(100, 23);
            // 
            // ballPanel
            // 
            ballPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ballPanel.AutoSize = true;
            ballPanel.Location = new Point(0, 30);
            ballPanel.Name = "ballPanel";
            ballPanel.Size = new Size(800, 417);
            ballPanel.TabIndex = 1;
            ballPanel.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ballPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Поймаай Шарик";
            MouseDown += BallMousKlick_MouseDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem запуститьШарикиToolStripMenuItem;
        private ToolStripMenuItem количествоПойманныхШариковToolStripMenuItem;
        private ToolStripTextBox cathBallToolStripTextBox;
        private Panel ballPanel;
    }
}
