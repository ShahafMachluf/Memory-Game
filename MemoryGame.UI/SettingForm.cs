using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MemoryGame.Logic;

namespace MemoryGame.UI
{
    internal partial class SettingForm : Form
    {
        private readonly GameBoardForm r_MainFormReference;
        private readonly List<string> r_BoardSizeOptions;
        private int m_BoardSizeOptionsIndex;
        private bool m_XButtunClicked;

        internal SettingForm(GameBoardForm io_FormToInitiate)
        {
            m_BoardSizeOptionsIndex = 1;
            r_BoardSizeOptions = new List<string>();
            r_MainFormReference = io_FormToInitiate;
            FormClosing += settingForm_FormClosing;
            boardSizeOption();
            InitializeComponent();
        }

        private void settingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                m_XButtunClicked = true;
            }
        }

        internal bool XButtunClicked
        {
            get
            {
                return m_XButtunClicked;
            }
        }

        private void boardSizeOption()
        {
            r_BoardSizeOptions.Add("4x4");
            r_BoardSizeOptions.Add("4x5");
            r_BoardSizeOptions.Add("4x6");
            r_BoardSizeOptions.Add("5x4");
            r_BoardSizeOptions.Add("5x6");
            r_BoardSizeOptions.Add("6x4");
            r_BoardSizeOptions.Add("6x5");
            r_BoardSizeOptions.Add("6x6");
        }

        private void boardSizeButtom_Click(object sender, EventArgs e)
        {
            BoardSizeButton.Text = r_BoardSizeOptions[m_BoardSizeOptionsIndex];
            m_BoardSizeOptionsIndex++;
            if (m_BoardSizeOptionsIndex == 8)
            {
                m_BoardSizeOptionsIndex = 0;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (FirstPlayerNameTextBox.Text != string.Empty && (SecondPlayerNameLabel.Enabled == false || SecondPlayerNameTextBox.Text != string.Empty))
            {
                Player FirstPlayer = new Player(FirstPlayerNameTextBox.Text);
                Player SecondPlayer = new Player(SecondPlayerNameTextBox.Text);
                r_MainFormReference.UpdateGameSettings(BoardSizeButton.Text, FirstPlayer, SecondPlayer, !SecondPlayerNameTextBox.Enabled);
                this.Close();
            }
            else
            {
                MessageBox.Show("Player name cant be empty.", "ERROR", MessageBoxButtons.OK);
            }
        }

        private void againstButton_Click(object sender, EventArgs e)
        {
            if (SecondPlayerNameTextBox.Enabled == false)
            {
                SecondPlayerNameTextBox.Text = string.Empty;
                SecondPlayerNameTextBox.Enabled = true;
                AgainstButton.Text = "Against Computer";
            }
            else
            {
                SecondPlayerNameTextBox.Text = "Computer";
                SecondPlayerNameTextBox.Enabled = false;
                AgainstButton.Text = "Against a Player";
            }
        }

        internal string FirstPlayerName
        {
            get
            {
                return FirstPlayerNameTextBox.Text;
            }
        }

        internal string SecondPlayerName
        {
            get
            {
                return SecondPlayerNameTextBox.Text;
            }
        }
    }
}
