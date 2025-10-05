namespace GeniyIdiotWinForm
{
    partial class AdminForm
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
            adminInfoLabel = new Label();
            adminInputTextBox = new TextBox();
            adminActionButton = new Button();
            adminBackButton = new Button();
            adminListBox = new ListBox();
            adminPromptLabel = new Label();
            SuspendLayout();
            // 
            // adminInfoLabel
            // 
            adminInfoLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            adminInfoLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            adminInfoLabel.Location = new Point(12, 9);
            adminInfoLabel.Name = "adminInfoLabel";
            adminInfoLabel.Size = new Size(776, 75);
            adminInfoLabel.TabIndex = 0;
            adminInfoLabel.Text = "РЕЖИМ АДМИНИСТРАТОРА";
            adminInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adminInputTextBox
            // 
            adminInputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            adminInputTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            adminInputTextBox.Location = new Point(250, 280);
            adminInputTextBox.Name = "adminInputTextBox";
            adminInputTextBox.Size = new Size(300, 29);
            adminInputTextBox.TabIndex = 3;
            adminInputTextBox.Visible = false;
            adminInputTextBox.KeyPress += adminInputTextBox_KeyPress;
            // 
            // adminActionButton
            // 
            adminActionButton.Anchor = AnchorStyles.Top;
            adminActionButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            adminActionButton.Location = new Point(250, 330);
            adminActionButton.Name = "adminActionButton";
            adminActionButton.Size = new Size(300, 70);
            adminActionButton.TabIndex = 4;
            adminActionButton.Text = "Выполнить";
            adminActionButton.UseVisualStyleBackColor = true;
            adminActionButton.Click += adminActionButton_Click;
            // 
            // adminBackButton
            // 
            adminBackButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            adminBackButton.Location = new Point(29, 403);
            adminBackButton.Name = "adminBackButton";
            adminBackButton.Size = new Size(140, 35);
            adminBackButton.TabIndex = 5;
            adminBackButton.Text = "Назад";
            adminBackButton.UseVisualStyleBackColor = true;
            adminBackButton.Click += adminBackButton_Click;
            // 
            // adminListBox
            // 
            adminListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            adminListBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            adminListBox.FormattingEnabled = true;
            adminListBox.Location = new Point(50, 120);
            adminListBox.Name = "adminListBox";
            adminListBox.Size = new Size(700, 144);
            adminListBox.TabIndex = 2;
            // 
            // adminPromptLabel
            // 
            adminPromptLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            adminPromptLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            adminPromptLabel.Location = new Point(12, 80);
            adminPromptLabel.Name = "adminPromptLabel";
            adminPromptLabel.Size = new Size(776, 30);
            adminPromptLabel.TabIndex = 1;
            adminPromptLabel.Text = "Выберите действие:";
            adminPromptLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(adminBackButton);
            Controls.Add(adminActionButton);
            Controls.Add(adminInputTextBox);
            Controls.Add(adminListBox);
            Controls.Add(adminPromptLabel);
            Controls.Add(adminInfoLabel);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Режим администратора";
            FormClosing += AdminForm_FormClosing;
            Load += AdminForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Label adminInfoLabel;
        private TextBox adminInputTextBox;
        private Button adminActionButton;
        private Button adminBackButton;
        private ListBox adminListBox;
        private Label adminPromptLabel;
    }
}
#endregion