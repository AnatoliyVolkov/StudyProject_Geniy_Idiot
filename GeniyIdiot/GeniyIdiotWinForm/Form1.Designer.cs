namespace GeniyIdiotWinForm
{
    partial class Form1
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
            userHelloLabel = new Label();
            userStartButton = new Button();
            adminStartButton = new Button();
            userChooseLabel = new Label();
            SuspendLayout();
            // 
            // userHelloLabel
            // 
            userHelloLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userHelloLabel.AutoSize = true;
            userHelloLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            userHelloLabel.Location = new Point(135, 20);
            userHelloLabel.Name = "userHelloLabel";
            userHelloLabel.Size = new Size(220, 25);
            userHelloLabel.TabIndex = 0;
            userHelloLabel.Text = "Приветсвие при входе";
            userHelloLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userStartButton
            // 
            userStartButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            userStartButton.Location = new Point(54, 292);
            userStartButton.Name = "userStartButton";
            userStartButton.Size = new Size(198, 130);
            userStartButton.TabIndex = 1;
            userStartButton.Text = "ДА  - Войти как пользователь";
            userStartButton.UseVisualStyleBackColor = true;
            userStartButton.Click += userStartButton_Click;
            // 
            // adminStartButton
            // 
            adminStartButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            adminStartButton.Location = new Point(537, 292);
            adminStartButton.Name = "adminStartButton";
            adminStartButton.Size = new Size(198, 130);
            adminStartButton.TabIndex = 2;
            adminStartButton.Text = "НЕТ - Войти как администратор";
            adminStartButton.UseVisualStyleBackColor = true;
            adminStartButton.Click += adminStartButton_Click;
            // 
            // userChooseLabel
            // 
            userChooseLabel.AutoSize = true;
            userChooseLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            userChooseLabel.Location = new Point(139, 51);
            userChooseLabel.Name = "userChooseLabel";
            userChooseLabel.Size = new Size(209, 25);
            userChooseLabel.TabIndex = 3;
            userChooseLabel.Text = "Предложение выбора";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(userChooseLabel);
            Controls.Add(adminStartButton);
            Controls.Add(userStartButton);
            Controls.Add(userHelloLabel);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userHelloLabel;
        private Button userStartButton;
        private Button adminStartButton;
        private Label userChooseLabel;
    }
}
