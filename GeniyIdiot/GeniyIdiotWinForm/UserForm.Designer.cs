namespace GeniyIdiotWinForm
{
    partial class UserForm
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
            infoUserLabel = new Label();
            infoUserInputLabel = new Label();
            userInputTextBox = new TextBox();
            nextButton = new Button();
            submitAnswerButton = new Button();
            questionLabel = new Label();
            restartAppButton = new Button();
            restartTestButton = new Button();
            exitButton = new Button();
            viewResultsButton = new Button();
            SuspendLayout();
            // 
            // infoUserLabel
            // 
            infoUserLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            infoUserLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            infoUserLabel.Location = new Point(12, 9);
            infoUserLabel.Name = "infoUserLabel";
            infoUserLabel.Size = new Size(776, 75);
            infoUserLabel.TabIndex = 0;
            infoUserLabel.Text = "Информационная надпись";
            infoUserLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // infoUserInputLabel
            // 
            infoUserInputLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            infoUserInputLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            infoUserInputLabel.Location = new Point(12, 167);
            infoUserInputLabel.Name = "infoUserInputLabel";
            infoUserInputLabel.Size = new Size(776, 25);
            infoUserInputLabel.TabIndex = 1;
            infoUserInputLabel.Text = "Информация для ввода";
            infoUserInputLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userInputTextBox
            // 
            userInputTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            userInputTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            userInputTextBox.Location = new Point(247, 276);
            userInputTextBox.Name = "userInputTextBox";
            userInputTextBox.Size = new Size(300, 29);
            userInputTextBox.TabIndex = 2;
            userInputTextBox.KeyPress += userInputTextBox_KeyPress;
            // 
            // nextButton
            // 
            nextButton.Anchor = AnchorStyles.Top;
            nextButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            nextButton.Location = new Point(350, 330);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(100, 35);
            nextButton.TabIndex = 3;
            nextButton.Text = "Далее";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // submitAnswerButton
            // 
            submitAnswerButton.Anchor = AnchorStyles.Top;
            submitAnswerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            submitAnswerButton.Location = new Point(350, 330);
            submitAnswerButton.Name = "submitAnswerButton";
            submitAnswerButton.Size = new Size(100, 35);
            submitAnswerButton.TabIndex = 4;
            submitAnswerButton.Text = "Ответить";
            submitAnswerButton.UseVisualStyleBackColor = true;
            submitAnswerButton.Visible = false;
            submitAnswerButton.Click += submitAnswerButton_Click;
            // 
            // questionLabel
            // 
            questionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            questionLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            questionLabel.Location = new Point(12, 205);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(776, 80);
            questionLabel.TabIndex = 5;
            questionLabel.Text = "Вопрос будет здесь";
            questionLabel.TextAlign = ContentAlignment.MiddleCenter;
            questionLabel.Visible = false;
            // 
            // restartAppButton
            // 
            restartAppButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            restartAppButton.Location = new Point(50, 380);
            restartAppButton.Name = "restartAppButton";
            restartAppButton.Size = new Size(140, 35);
            restartAppButton.TabIndex = 9;
            restartAppButton.Text = "Перезапустить приложение";
            restartAppButton.UseVisualStyleBackColor = true;
            restartAppButton.Visible = false;
            restartAppButton.Click += restartAppButton_Click;
            // 
            // restartTestButton
            // 
            restartTestButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            restartTestButton.Location = new Point(234, 380);
            restartTestButton.Name = "restartTestButton";
            restartTestButton.Size = new Size(140, 35);
            restartTestButton.TabIndex = 10;
            restartTestButton.Text = "Пройти сначала";
            restartTestButton.UseVisualStyleBackColor = true;
            restartTestButton.Visible = false;
            restartTestButton.Click += restartTestButton_Click;
            // 
            // exitButton
            // 
            exitButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            exitButton.Location = new Point(648, 380);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(140, 35);
            exitButton.TabIndex = 11;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Visible = false;
            exitButton.Click += exitButton_Click;
            // 
            // viewResultsButton
            // 
            viewResultsButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            viewResultsButton.Location = new Point(436, 380);
            viewResultsButton.Name = "viewResultsButton";
            viewResultsButton.Size = new Size(140, 35);
            viewResultsButton.TabIndex = 12;
            viewResultsButton.Text = "Показать результаты";
            viewResultsButton.UseVisualStyleBackColor = true;
            viewResultsButton.Visible = false;
            viewResultsButton.Click += viewResultsButton_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(viewResultsButton);
            Controls.Add(exitButton);
            Controls.Add(restartTestButton);
            Controls.Add(restartAppButton);
            Controls.Add(submitAnswerButton);
            Controls.Add(nextButton);
            Controls.Add(userInputTextBox);
            Controls.Add(questionLabel);
            Controls.Add(infoUserInputLabel);
            Controls.Add(infoUserLabel);
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Тестирование пользователя";
            Load += UserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label infoUserLabel;
        private Label infoUserInputLabel;
        private TextBox userInputTextBox;
        private Button nextButton;
        private Button submitAnswerButton;
        private Label questionLabel;
        private Button restartAppButton;
        private Button restartTestButton;
        private Button exitButton;
        private Button viewResultsButton;
    }
}