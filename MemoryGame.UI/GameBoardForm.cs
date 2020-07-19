using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Text;
using MemoryGame.Logic;

namespace MemoryGame.UI
{
    internal partial class GameBoardForm : Form
    {
        private static int m_NumberOfCardsRevealed = 0;
        private int m_NumberOfRows;
        private int m_NumberOfColumns;
        private Label m_FirstPlayerScoreLabel;
        private Label m_SecondPlayerScoreLabel;
        private Label m_CurrentPlayerTurnLabel;
        private MemoryGameBoard m_GameBoard;
        private MemoryGameCardButtuon[,] m_CardsButtons;
        private PlayMemoryGame m_GameManager;
        private MemoryGameCard m_LastCardRevealed;
        private Player m_CurrentPlayer;
        private Player m_FirstPlayer;
        private Player m_SecondPlayer;
        private bool m_IsAgainstComputer;
        private ComputerAI m_ComputerMemory;

        internal void UpdateGameSettings(string i_BoardSize, Player i_FirstPlayer, Player i_SecondPlayer, bool i_IsAgaintComputer)
        {
            m_NumberOfRows = i_BoardSize[0] - '0';
            m_NumberOfColumns = i_BoardSize[2] - '0';
            m_FirstPlayer = i_FirstPlayer;
            m_FirstPlayer.PlayerChanged += player_CurrentPlayerChanged;
            m_FirstPlayer.PlayerScoreChanged += player_PlayerScoreIncreased;
            m_SecondPlayer = i_SecondPlayer;
            m_SecondPlayer.PlayerChanged += player_CurrentPlayerChanged;
            m_SecondPlayer.PlayerScoreChanged += player_PlayerScoreIncreased;
            m_CurrentPlayer = i_FirstPlayer;
            m_GameManager = new PlayMemoryGame();
            m_GameBoard = new MemoryGameBoard(i_BoardSize[0] - '0', i_BoardSize[2] - '0');
            m_CardsButtons = new MemoryGameCardButtuon[i_BoardSize[0] - '0', i_BoardSize[2] - '0'];
            m_IsAgainstComputer = i_IsAgaintComputer;
            if (m_IsAgainstComputer == true)
            {
                m_ComputerMemory = new ComputerAI();
            }

            InitializeComponent();
            setDynamicControls();
        }

        private void player_PlayerScoreIncreased(Player i_Invoker)
        {
            if (i_Invoker == m_FirstPlayer)
            {
                m_FirstPlayerScoreLabel.Text = m_FirstPlayer.Name + "'s score: " + m_FirstPlayer.Score;
            }
            else
            {
                m_SecondPlayerScoreLabel.Text = m_SecondPlayer.Name + "'s score: " + m_SecondPlayer.Score;
            }
        }

        private void player_CurrentPlayerChanged()
        {
            if (m_CurrentPlayer == m_FirstPlayer)
            {
                m_CurrentPlayerTurnLabel.BackColor = m_SecondPlayerScoreLabel.BackColor;
                m_CurrentPlayerTurnLabel.Text = "Current Player: " + m_SecondPlayer.Name;
            }
            else
            {
                m_CurrentPlayerTurnLabel.BackColor = m_FirstPlayerScoreLabel.BackColor;
                m_CurrentPlayerTurnLabel.Text = "Current Player: " + m_FirstPlayer.Name;
            }
        }

        private void setDynamicControls()
        {
            m_FirstPlayerScoreLabel = new Label();
            m_FirstPlayerScoreLabel.Text = m_FirstPlayer.Name + "'s score: " + m_FirstPlayer.Score;
            m_FirstPlayerScoreLabel.Left = this.Left + 8;
            m_FirstPlayerScoreLabel.BackColor = Color.LightGreen;
            m_FirstPlayerScoreLabel.AutoSize = true;
            this.Controls.Add(m_FirstPlayerScoreLabel);
            m_SecondPlayerScoreLabel = new Label();
            m_SecondPlayerScoreLabel.Text = m_SecondPlayer.Name + "'s score: " + m_SecondPlayer.Score;
            m_SecondPlayerScoreLabel.Left = m_FirstPlayerScoreLabel.Left;
            m_SecondPlayerScoreLabel.BackColor = Color.MediumPurple;
            m_SecondPlayerScoreLabel.AutoSize = true;
            this.Controls.Add(m_SecondPlayerScoreLabel);
            m_CurrentPlayerTurnLabel = new Label();
            m_CurrentPlayerTurnLabel.Text = "Current Player: " + m_FirstPlayer.Name;
            m_CurrentPlayerTurnLabel.Left = this.Left + 8;
            m_CurrentPlayerTurnLabel.BackColor = m_FirstPlayerScoreLabel.BackColor;
            m_CurrentPlayerTurnLabel.AutoSize = true;
            this.Controls.Add(m_CurrentPlayerTurnLabel);
            m_GameBoard.FillBoard();
            setButtonsOnBoard();
            m_CurrentPlayerTurnLabel.Top = m_CardsButtons[m_NumberOfRows - 1, 0].Bottom + 30;
            m_FirstPlayerScoreLabel.Top = m_CurrentPlayerTurnLabel.Bottom + 8;
            m_SecondPlayerScoreLabel.Top = m_FirstPlayerScoreLabel.Bottom + 8;
            this.Height = m_SecondPlayerScoreLabel.Bottom + 50;
            foreach (MemoryGameCard card in m_GameBoard.BoardMatrix)
            {
                card.CardVisabilityChanged += card_CardVisabilityChanged;
            }
        }

        private void card_CardVisabilityChanged(MemoryGameCard i_Invoker)
        {
            foreach (MemoryGameCardButtuon button in m_CardsButtons)
            {
                if (button.LogicMemoryGameCardReference == i_Invoker)
                {
                    button.FlatAppearance.BorderColor = m_CurrentPlayerTurnLabel.BackColor;
                    button.ShowImage();
                    this.Update();
                    if (i_Invoker.IsVisable == false)
                    {
                        button.HideImage();
                        button.FlatAppearance.BorderColor = default;
                    }

                    break;
                }
            }
        }

        private void setButtonsOnBoard()
        {
            int leftLocation = this.Left;
            int BottomLocation = this.Top;

            for (int i = 0; i < m_NumberOfRows; i++)
            {
                for (int j = 0; j < m_NumberOfColumns; j++)
                {
                    m_CardsButtons[i, j] = new MemoryGameCardButtuon(m_GameBoard.BoardMatrix[i, j], i, j);
                    m_CardsButtons[i, j].Size = new System.Drawing.Size(100, 100);
                    m_CardsButtons[i, j].Left = leftLocation + 10;
                    m_CardsButtons[i, j].Top = BottomLocation + 10;
                    this.Controls.Add(m_CardsButtons[i, j]);
                    m_CardsButtons[i, j].Click += cardButton_Click;
                    leftLocation = m_CardsButtons[i, j].Right;
                }

                leftLocation = this.Left;
                BottomLocation = m_CardsButtons[i, m_NumberOfColumns - 1].Bottom;
            }

            this.Width = m_CardsButtons[m_NumberOfRows - 1, m_NumberOfColumns - 1].Right + 30;
        }

        private void cardButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            MemoryGameCard currentCardRevealed;

            MemoryGameCardButtuon memoryCardButton = i_Sender as MemoryGameCardButtuon;
            if (!memoryCardButton.ImageInCard.Visible)
            {
                m_NumberOfCardsRevealed++;
                currentCardRevealed = m_GameManager.RevealCardByPlayer(m_GameBoard, memoryCardButton.RowNumber, memoryCardButton.ColumnNumber, m_ComputerMemory);
                this.Update();
                if (m_NumberOfCardsRevealed % 2 == 0)
                {
                    m_NumberOfCardsRevealed = 0;
                    if (m_LastCardRevealed.CardValue == currentCardRevealed.CardValue)
                    {
                        runSeccessfulTurn(currentCardRevealed);
                    }
                    else
                    {
                        runUnSeccessfulTurn(currentCardRevealed, m_LastCardRevealed);
                    }

                    while (m_IsAgainstComputer && m_CurrentPlayer.Name == "Computer" && !m_GameBoard.IsBoardFull())
                    {
                        TwoPairsOfIndexes indexes;
                        m_GameManager.MakeAComputerMove(m_GameBoard, ref m_ComputerMemory, out indexes);
                        Thread.Sleep(1000);
                        if (m_GameBoard.BoardMatrix[(int)indexes.FirstRowIndex, (int)indexes.FirstColoumnIndex].CardValue == m_GameBoard.BoardMatrix[(int)indexes.SecondRowIndex, (int)indexes.SecondColoumnIndex].CardValue)
                        {
                            runSeccessfulTurn(m_GameBoard.BoardMatrix[(int)indexes.FirstRowIndex, (int)indexes.FirstColoumnIndex]);
                        }
                        else
                        {
                            runUnSeccessfulTurn(m_GameBoard.BoardMatrix[(int)indexes.FirstRowIndex, (int)indexes.FirstColoumnIndex], m_GameBoard.BoardMatrix[(int)indexes.SecondRowIndex, (int)indexes.SecondColoumnIndex]);
                        }
                    }
                }
                else
                {
                    m_LastCardRevealed = currentCardRevealed;
                }
            }
        }

        private void runUnSeccessfulTurn(MemoryGameCard i_CurrentCardRevealed, MemoryGameCard i_PreviousCardRevealed)
        {
            Thread.Sleep(1000);
            m_GameManager.PlayAnUnSeccessfulTurn(i_CurrentCardRevealed, i_PreviousCardRevealed);
            m_CurrentPlayer = m_CurrentPlayer.ChangePlayer(m_FirstPlayer, m_SecondPlayer);
        }

        private void announceWinner()
        {
            Player winner = null;
            StringBuilder winnerMessage = new StringBuilder();

            if (m_FirstPlayer.Score > m_SecondPlayer.Score)
            {
                winner = m_FirstPlayer;
            }
            else if (m_FirstPlayer.Score < m_SecondPlayer.Score)
            {
                winner = m_SecondPlayer;
            }
            else
            {
                winnerMessage.Append("There is a tie, both ");
                winnerMessage.Append(m_FirstPlayer.Name);
                winnerMessage.Append(" and ");
                winnerMessage.Append(m_SecondPlayer.Name);
                winnerMessage.Append(" got ");
                winnerMessage.Append(m_SecondPlayer.Score);
                winnerMessage.Append(" points");
            }

            if (winner != null)
            {
                winnerMessage.Append("The winner is ");
                winnerMessage.Append(winner.Name);
                winnerMessage.Append(" with ");
                winnerMessage.Append(winner.Score);
                winnerMessage.Append(" points");
            }

            MessageBox.Show(winnerMessage.ToString(), "Winner Announcment", MessageBoxButtons.OK);
        }

        private void runSeccessfulTurn(MemoryGameCard i_RevealedCard)
        {
            m_GameManager.PlayASuccessfulTurn(m_GameBoard, m_CurrentPlayer, i_RevealedCard, m_ComputerMemory);
            if (m_GameBoard.IsBoardFull() == true)
            {
                announceWinner();
                if (askForRematch() == true)
                {
                    resetBoardForRematch();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private bool askForRematch()
        {
            DialogResult result = MessageBox.Show("Do you want to play again?", "Rematch", MessageBoxButtons.YesNo);

            return result == DialogResult.Yes;
        }

        private void hideAllImages()
        {
            foreach (MemoryGameCardButtuon button in m_CardsButtons)
            {
                button.HideImage();
                button.FlatAppearance.BorderColor = default;
            }
        }

        private void resetBoardForRematch()
        {
            hideAllImages();
            m_FirstPlayer.ClearPoints();
            m_SecondPlayer.ClearPoints();
            m_CurrentPlayer = m_SecondPlayer;
            m_CurrentPlayer = m_CurrentPlayer.ChangePlayer(m_FirstPlayer, m_SecondPlayer);
            if (m_ComputerMemory != null)
            {
                m_ComputerMemory = new ComputerAI();
            }

            m_GameBoard = new MemoryGameBoard(m_NumberOfRows, m_NumberOfColumns);
            m_GameBoard.FillBoard();
            for (int i = 0; i < m_NumberOfRows; i++)
            {
                for (int j = 0; j < m_NumberOfColumns; j++)
                {
                    m_GameBoard.BoardMatrix[i, j].CardVisabilityChanged += card_CardVisabilityChanged;
                    m_CardsButtons[i, j].LogicMemoryGameCardReference = m_GameBoard.BoardMatrix[i, j];
                    m_CardsButtons[i, j].RowNumber = i;
                    m_CardsButtons[i, j].ColumnNumber = j;
                    m_CardsButtons[i, j].UpdateImageURL();
                }
            }

            this.Update();
        }
    }
}
