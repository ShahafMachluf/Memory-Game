using System;

namespace MemoryGame.Logic
{
    public class Player
    {
        private readonly string r_Name;
        private int m_Score;

        public event Action PlayerChanged;

        public event Action<Player> PlayerScoreChanged;

        public Player(string i_PlayerName)
        {
            if(i_PlayerName == string.Empty)
            {
                throw new ArgumentException("ERROR. Player name cant be empty.");
            }

            r_Name = i_PlayerName;
            m_Score = 0;
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        internal void IncreaseScore()
        {
            m_Score++;
            if (PlayerScoreChanged != null)
            {
                PlayerScoreChanged.Invoke(this);
            }
        }

        public Player ChangePlayer(Player i_FirstPlayer, Player i_SecondPlayer)
        {
            Player nextTurnPlayer;

            if (this == i_FirstPlayer)
            {
                nextTurnPlayer = i_SecondPlayer;
            }
            else
            {
                nextTurnPlayer = i_FirstPlayer;
            }

            if (PlayerChanged != null)
            {
                PlayerChanged.Invoke();
            }

            return nextTurnPlayer;
        }

        public void ClearPoints()
        {
            m_Score = 0;
            if (PlayerScoreChanged != null)
            {
                PlayerScoreChanged.Invoke(this);
            }
        }
    }
}
