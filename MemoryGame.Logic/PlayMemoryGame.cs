using System;

namespace MemoryGame.Logic
{
    public class PlayMemoryGame
    {
        public const int k_NumberOfItemsToFillBoard = 26;
        private static readonly Random sr_Random = new Random();

        private static MemoryGameCard revealRandomCardByComputer(MemoryGameBoard i_GameBoard, out int o_RowIndex, out int o_ColoumnIndex, ComputerAI i_ComputerMemory)
        {
            int randomRowIndex = sr_Random.Next(0, i_GameBoard.BoardHight);
            int randomColumnIndex = sr_Random.Next(0, i_GameBoard.BoardWidth);

            while (i_GameBoard.BoardMatrix[randomRowIndex, randomColumnIndex].IsVisable)
            {
                randomRowIndex = sr_Random.Next(0, i_GameBoard.BoardHight);
                randomColumnIndex = sr_Random.Next(0, i_GameBoard.BoardWidth);
            }

            i_ComputerMemory.UpdateComputerMemory(randomRowIndex, randomColumnIndex, i_GameBoard.BoardMatrix[randomRowIndex, randomColumnIndex].CardValue);
            i_GameBoard.BoardMatrix[randomRowIndex, randomColumnIndex].IsVisable = true;
            o_RowIndex = randomRowIndex;
            o_ColoumnIndex = randomColumnIndex;

            return i_GameBoard.BoardMatrix[randomRowIndex, randomColumnIndex];
        }

        public void PlayAnUnSeccessfulTurn(MemoryGameCard io_FirstCardRevealed, MemoryGameCard io_SecondCardRevealed)
        {
            io_FirstCardRevealed.IsVisable = false;
            io_SecondCardRevealed.IsVisable = false;
        }

        public void PlayASuccessfulTurn(MemoryGameBoard i_GameBoard, Player i_CurrentPlayer, MemoryGameCard i_CardRevealed, ComputerAI i_ComputerMemory)
        {
            if (i_ComputerMemory != null)
            {
                i_ComputerMemory.ComputerMemory[i_CardRevealed.CardValue].MarkTwoPairsAsUnAvalabale();
            }

            i_CurrentPlayer.IncreaseScore();
            i_GameBoard.NumberOfRevealedCards += 2;
        }

        public void MakeAComputerMove(MemoryGameBoard i_GameBoard, ref ComputerAI i_ComputerMemory, out TwoPairsOfIndexes o_Indexes)
        {
            if (!isPairAvailableInMemory(i_GameBoard, ref i_ComputerMemory, out o_Indexes))
            {
                int getRowIndex, getColoumnIndex;
                MemoryGameCard firstCardRevealed = revealRandomCardByComputer(i_GameBoard, out getRowIndex, out getColoumnIndex, i_ComputerMemory);
                o_Indexes.FirstRowIndex = getRowIndex;
                o_Indexes.FirstColoumnIndex = getColoumnIndex;
                o_Indexes.SecondRowIndex = (int)i_ComputerMemory.ComputerMemory[firstCardRevealed.CardValue].FirstRowIndex;
                o_Indexes.SecondColoumnIndex = (int)i_ComputerMemory.ComputerMemory[firstCardRevealed.CardValue].FirstColoumnIndex;
                if (o_Indexes.SecondRowIndex != getRowIndex || o_Indexes.SecondColoumnIndex != getColoumnIndex)
                {
                    MemoryGameCard pairOfRandomCard = i_GameBoard.BoardMatrix[(int)o_Indexes.SecondRowIndex, (int)o_Indexes.SecondColoumnIndex];
                    pairOfRandomCard.IsVisable = true;
                }
                else
                {
                    revealRandomCardByComputer(i_GameBoard, out getRowIndex, out getColoumnIndex, i_ComputerMemory);
                    o_Indexes.SecondRowIndex = getRowIndex;
                    o_Indexes.SecondColoumnIndex = getColoumnIndex;
                }
            }
        }

        private bool isPairAvailableInMemory(MemoryGameBoard i_GameBoard, ref ComputerAI i_ComputerMemory, out TwoPairsOfIndexes o_Indexes)
        {
            bool isPairFound = false;

            o_Indexes = new TwoPairsOfIndexes();
            for (int i = 0; i < k_NumberOfItemsToFillBoard; i++)
            {
                if (i_ComputerMemory.ComputerMemory[i].IsTwoPairsHaveValue())
                {
                    o_Indexes.FirstRowIndex = i_ComputerMemory.ComputerMemory[i].FirstRowIndex;
                    o_Indexes.FirstColoumnIndex = i_ComputerMemory.ComputerMemory[i].FirstColoumnIndex;
                    o_Indexes.SecondRowIndex = i_ComputerMemory.ComputerMemory[i].SecondRowIndex;
                    o_Indexes.SecondColoumnIndex = i_ComputerMemory.ComputerMemory[i].SecondColoumnIndex;
                    MemoryGameCard firstCardRevealedFromMemory = i_GameBoard.BoardMatrix[(int)o_Indexes.FirstRowIndex, (int)o_Indexes.FirstColoumnIndex];
                    firstCardRevealedFromMemory.IsVisable = true;
                    MemoryGameCard secondCardRevealedFromMemory = i_GameBoard.BoardMatrix[(int)o_Indexes.SecondRowIndex, (int)o_Indexes.SecondColoumnIndex];
                    secondCardRevealedFromMemory.IsVisable = true;
                    i_ComputerMemory.ComputerMemory[i].MarkTwoPairsAsUnAvalabale();
                    isPairFound = true;
                    break;
                }
            }

            return isPairFound;
        }

        public MemoryGameCard RevealCardByPlayer(MemoryGameBoard i_GameBoard, int? i_CellRowIndex,
            int? i_CellColoumnIndex, ComputerAI i_ComputerMemory)
        {
            if (i_ComputerMemory != null)
            {
                i_ComputerMemory.UpdateComputerMemory((int)i_CellRowIndex, (int)i_CellColoumnIndex, i_GameBoard.BoardMatrix[(int)i_CellRowIndex, (int)i_CellColoumnIndex].CardValue);
            }

            i_GameBoard.BoardMatrix[(int)i_CellRowIndex, (int)i_CellColoumnIndex].IsVisable = true;

            return i_GameBoard.BoardMatrix[(int)i_CellRowIndex, (int)i_CellColoumnIndex];
        }
    }
}
