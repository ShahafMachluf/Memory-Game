using System;

namespace MemoryGame.Logic
{
    public class ComputerAI
    {
        private readonly TwoPairsOfIndexes[] r_ComputerMemory;

        public ComputerAI()
        {
            r_ComputerMemory = new TwoPairsOfIndexes[PlayMemoryGame.k_NumberOfItemsToFillBoard];
            for (int i = 0; i < PlayMemoryGame.k_NumberOfItemsToFillBoard; i++)
            {
                r_ComputerMemory[i] = new TwoPairsOfIndexes();
            }
        }

        internal TwoPairsOfIndexes[] ComputerMemory
        {
            get
            {
                return r_ComputerMemory;
            }
        }

        internal void UpdateComputerMemory(int i_RowIndex, int i_ColoumnIndex, int i_Value)
        {
            if(i_Value > PlayMemoryGame.k_NumberOfItemsToFillBoard - 1)
            {
                throw new IndexOutOfRangeException("ERROR. Computer memory index should be between 0 - " + (PlayMemoryGame.k_NumberOfItemsToFillBoard - 1).ToString());
            }

            if (r_ComputerMemory[i_Value].FirstRowIndex == null && r_ComputerMemory[i_Value].FirstColoumnIndex == null)
            {
                r_ComputerMemory[i_Value].FirstRowIndex = i_RowIndex;
                r_ComputerMemory[i_Value].FirstColoumnIndex = i_ColoumnIndex;
            }
            else if ((r_ComputerMemory[i_Value].FirstRowIndex != i_RowIndex || r_ComputerMemory[i_Value].FirstColoumnIndex != i_ColoumnIndex) && r_ComputerMemory[i_Value].SecondRowIndex == null && r_ComputerMemory[i_Value].SecondColoumnIndex == null)
            {
                r_ComputerMemory[i_Value].SecondRowIndex = i_RowIndex;
                r_ComputerMemory[i_Value].SecondColoumnIndex = i_ColoumnIndex;
            }
        }
    }
}
