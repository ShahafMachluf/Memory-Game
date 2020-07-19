using System;

namespace MemoryGame.Logic
{
    public class MemoryGameCard
    {
        private int m_CardValue;
        private bool m_IsVisable;
        private bool m_HasValue;

        public event Action<MemoryGameCard> CardVisabilityChanged;

        internal bool HasValue
        {
            get
            {
                return m_HasValue;
            }
        }

        public int CardValue
        {
            get
            {
                return m_CardValue;
            }

            set
            {
                m_CardValue = value;
                m_HasValue = true;
            }
        }

        public bool IsVisable
        {
            get
            {
                return m_IsVisable;
            }

            set
            {
                m_IsVisable = value;
                if (CardVisabilityChanged != null)
                {
                    CardVisabilityChanged.Invoke(this);
                }
            }
        }
    }
}
