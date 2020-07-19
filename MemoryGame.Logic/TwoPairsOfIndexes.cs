namespace MemoryGame.Logic
{
    public class TwoPairsOfIndexes
    {
        private int? m_FirstRowIndex = null;
        private int? m_FirstColoumnIndex = null;
        private int? m_SecondRowIndex = null;
        private int? m_SecondColoumnIndex = null;
        private bool m_IndexesAreAvalbale = true;

        public int? FirstRowIndex
        {
            get
            {
                return m_FirstRowIndex;
            }

            set
            {
                m_FirstRowIndex = value;
            }
        }

        public int? FirstColoumnIndex
        {
            get
            {
                return m_FirstColoumnIndex;
            }

            set
            {
                m_FirstColoumnIndex = value;
            }
        }

        public int? SecondRowIndex
        {
            get
            {
                return m_SecondRowIndex;
            }

            set
            {
                m_SecondRowIndex = value;
            }
        }

        public int? SecondColoumnIndex
        {
            get
            {
                return m_SecondColoumnIndex;
            }

            set
            {
                m_SecondColoumnIndex = value;
            }
        }

        internal bool IsTwoPairsHaveValue()
        {
            return m_FirstRowIndex != null && m_FirstColoumnIndex != null && m_SecondRowIndex != null && m_SecondColoumnIndex != null && m_IndexesAreAvalbale;
        }

        internal void MarkTwoPairsAsUnAvalabale()
        {
            m_IndexesAreAvalbale = false;
        }
    }
}
