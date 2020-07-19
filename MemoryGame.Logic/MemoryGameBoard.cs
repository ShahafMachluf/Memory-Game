using System;

namespace MemoryGame.Logic
{
    public class MemoryGameBoard
    {
        private readonly int r_BoardHight;
        private readonly int r_BoardWidth;
        private MemoryGameCard[,] m_BoardMatrix;
        private int m_numberOfRevealedCards;

        public MemoryGameBoard(int i_Hight, int i_Width)
        {
            if(i_Hight < 1)
            {
                throw new ArgumentException("ERROR. Board hight should be positive.");
            }

            if (i_Width < 1)
            {
                throw new ArgumentException("ERROR. Board width should be positive.");
            }

            if((i_Hight * i_Width) % 2 != 0)
            {
                throw new ArgumentException("ERROR. Board hight * width should be even.");
            }

            r_BoardHight = i_Hight;
            r_BoardWidth = i_Width;
            m_numberOfRevealedCards = 0;
            m_BoardMatrix = new MemoryGameCard[r_BoardHight, r_BoardWidth];
            for (int i = 0; i < r_BoardHight; i++)
            {
                for (int j = 0; j < r_BoardWidth; j++)
                {
                    m_BoardMatrix[i, j] = new MemoryGameCard();
                }
            }
        }

        internal int BoardHight
        {
            get
            {
                return r_BoardHight;
            }
        }

        internal int BoardWidth
        {
            get
            {
                return r_BoardWidth;
            }
        }

        internal int NumberOfRevealedCards
        {
            get
            {
                return m_numberOfRevealedCards;
            }

            set
            {
                m_numberOfRevealedCards = value;
            }
        }

        public ref MemoryGameCard[,] BoardMatrix
        {
            get
            {
                return ref m_BoardMatrix;
            }
        }

        public bool IsBoardFull()
        {
            return (r_BoardHight * r_BoardWidth) == m_numberOfRevealedCards;
        }

        public void FillBoard()
        {
            int[] alphabetArray = new int[PlayMemoryGame.k_NumberOfItemsToFillBoard];
            int maxNumberOfPairs = r_BoardHight * r_BoardWidth / 2;

            for (int i = 0; i < PlayMemoryGame.k_NumberOfItemsToFillBoard; i++)
            {
                alphabetArray[i] = 0;
            }

            Random random = new Random();
            for (int i = 0; i < maxNumberOfPairs; i++)
            {
                int randomNumber = random.Next(0, PlayMemoryGame.k_NumberOfItemsToFillBoard);
                while (alphabetArray[randomNumber] > 0)
                {
                    randomNumber = random.Next(0, PlayMemoryGame.k_NumberOfItemsToFillBoard);
                }

                alphabetArray[randomNumber]++;
                FillEmptyBoardCell(randomNumber, random);
                FillEmptyBoardCell(randomNumber, random);
            }
        }

        internal void FillEmptyBoardCell(int i_Value, Random i_Random)
        {
            int randomMatrixColIndex, randomMatrixRowIndex;

            randomMatrixColIndex = i_Random.Next(0, r_BoardWidth);
            randomMatrixRowIndex = i_Random.Next(0, r_BoardHight);
            while (m_BoardMatrix[randomMatrixRowIndex, randomMatrixColIndex].HasValue)
            {
                randomMatrixColIndex = i_Random.Next(0, r_BoardWidth);
                randomMatrixRowIndex = i_Random.Next(0, r_BoardHight);
            }

            m_BoardMatrix[randomMatrixRowIndex, randomMatrixColIndex].CardValue = i_Value;
        }
    }
}