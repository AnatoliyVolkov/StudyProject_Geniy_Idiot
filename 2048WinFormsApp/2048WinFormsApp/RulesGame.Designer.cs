namespace _2048WinFormsApp
{
    partial class RulesGame
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
            button1 = new Button();
            infoLabel = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(310, 351);
            button1.Name = "button1";
            button1.Size = new Size(160, 58);
            button1.TabIndex = 0;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonBackMenu_Click;
            // 
            // infoLabel
            // 
            infoLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            infoLabel.Location = new Point(2, 9);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(794, 324);
            infoLabel.TabIndex = 1;
            infoLabel.Text = "label1";
            // 
            // RulesGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(infoLabel);
            Controls.Add(button1);
            Name = "RulesGame";
            Text = "Правила Игры";
            FormClosing += RulesGame_FormClosing;
            Load += RulesGame_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label infoLabel;
    }
}