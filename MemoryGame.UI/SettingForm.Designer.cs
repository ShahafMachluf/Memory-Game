using System.Drawing;

namespace MemoryGame.UI
{
    internal partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.FirstPlayerNameLabel = new System.Windows.Forms.Label();
            this.SecondPlayerNameLabel = new System.Windows.Forms.Label();
            this.FirstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.SecondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.AgainstButton = new System.Windows.Forms.Button();
            this.BoardSize = new System.Windows.Forms.Label();
            this.BoardSizeButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // FirstPlayerNameLabel
            // 
            this.FirstPlayerNameLabel.AutoSize = true;
            this.FirstPlayerNameLabel.Location = new System.Drawing.Point(13, 18);
            this.FirstPlayerNameLabel.Name = "FirstPlayerNameLabel";
            this.FirstPlayerNameLabel.Size = new System.Drawing.Size(124, 17);
            this.FirstPlayerNameLabel.TabIndex = 0;
            this.FirstPlayerNameLabel.Text = "First Player Name:";
            // 
            // SecondPlayerNameLabel
            // 
            this.SecondPlayerNameLabel.AutoSize = true;
            this.SecondPlayerNameLabel.Location = new System.Drawing.Point(13, 50);
            this.SecondPlayerNameLabel.Name = "SecondPlayerNameLabel";
            this.SecondPlayerNameLabel.Size = new System.Drawing.Size(145, 17);
            this.SecondPlayerNameLabel.TabIndex = 2;
            this.SecondPlayerNameLabel.Text = "Second Player Name:";
            // 
            // FirstPlayerNameTextBox
            // 
            this.FirstPlayerNameTextBox.Location = new System.Drawing.Point(167, 18);
            this.FirstPlayerNameTextBox.Name = "FirstPlayerNameTextBox";
            this.FirstPlayerNameTextBox.Size = new System.Drawing.Size(137, 22);
            this.FirstPlayerNameTextBox.TabIndex = 1;
            // 
            // SecondPlayerNameTextBox
            // 
            this.SecondPlayerNameTextBox.Enabled = false;
            this.SecondPlayerNameTextBox.Location = new System.Drawing.Point(167, 50);
            this.SecondPlayerNameTextBox.Name = "SecondPlayerNameTextBox";
            this.SecondPlayerNameTextBox.Size = new System.Drawing.Size(137, 22);
            this.SecondPlayerNameTextBox.TabIndex = 3;
            this.SecondPlayerNameTextBox.Text = "Computer";
            // 
            // AgainstButton
            // 
            this.AgainstButton.Location = new System.Drawing.Point(320, 47);
            this.AgainstButton.Name = "AgainstButton";
            this.AgainstButton.Size = new System.Drawing.Size(147, 29);
            this.AgainstButton.TabIndex = 4;
            this.AgainstButton.Text = "Against a Player";
            this.AgainstButton.UseVisualStyleBackColor = true;
            this.AgainstButton.Click += new System.EventHandler(this.againstButton_Click);
            // 
            // BoardSize
            // 
            this.BoardSize.AutoSize = true;
            this.BoardSize.Location = new System.Drawing.Point(13, 90);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(81, 17);
            this.BoardSize.TabIndex = 5;
            this.BoardSize.Text = "Board Size:";
            // 
            // BoardSizeButton
            // 
            this.BoardSizeButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BoardSizeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BoardSizeButton.Location = new System.Drawing.Point(16, 120);
            this.BoardSizeButton.Name = "BoardSizeButton";
            this.BoardSizeButton.Size = new System.Drawing.Size(121, 75);
            this.BoardSizeButton.TabIndex = 6;
            this.BoardSizeButton.Text = "4x4";
            this.BoardSizeButton.UseVisualStyleBackColor = false;
            this.BoardSizeButton.Click += new System.EventHandler(this.boardSizeButtom_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.StartButton.Location = new System.Drawing.Point(367, 166);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 29);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // SettingForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 211);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.BoardSizeButton);
            this.Controls.Add(this.BoardSize);
            this.Controls.Add(this.AgainstButton);
            this.Controls.Add(this.SecondPlayerNameTextBox);
            this.Controls.Add(this.FirstPlayerNameTextBox);
            this.Controls.Add(this.SecondPlayerNameLabel);
            this.Controls.Add(this.FirstPlayerNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FirstPlayerNameLabel;
        private System.Windows.Forms.Label SecondPlayerNameLabel;
        private System.Windows.Forms.TextBox FirstPlayerNameTextBox;
        private System.Windows.Forms.TextBox SecondPlayerNameTextBox;
        private System.Windows.Forms.Button AgainstButton;
        private System.Windows.Forms.Label BoardSize;
        private System.Windows.Forms.Button BoardSizeButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
    }
}