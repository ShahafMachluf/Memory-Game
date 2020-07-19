using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MemoryGame.Logic;

namespace MemoryGame.UI
{
    internal class MemoryGameCardButtuon : Button
    {
        private readonly PictureBox r_ImageInCard;
        private int m_RowNumber;
        private int m_ColumnNumber;
        private MemoryGameCard m_LogicMemoryGameCardReference;

        internal MemoryGameCardButtuon(MemoryGameCard i_GameCard, int i_RownNumber, int i_ColumnNumber)
        {
            StringBuilder imageURL = new StringBuilder();
            
            m_RowNumber = i_RownNumber;
            m_ColumnNumber = i_ColumnNumber;
            m_LogicMemoryGameCardReference = i_GameCard;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 1;
            r_ImageInCard = new PictureBox();
            r_ImageInCard.Top = this.Top + 3;
            r_ImageInCard.Left = this.Left + 3;
            r_ImageInCard.Size = new Size(94,94);
            r_ImageInCard.SizeMode = PictureBoxSizeMode.StretchImage;
            imageURL.Append(@"https://picsum.photos/id/");
            imageURL.Append(m_LogicMemoryGameCardReference.CardValue);
            imageURL.Append(@"/80");
            r_ImageInCard.LoadAsync(imageURL.ToString());
            r_ImageInCard.Visible = false;
            this.Controls.Add(r_ImageInCard);
        }

        internal void UpdateImageURL()
        {
            StringBuilder imageURL = new StringBuilder();
            imageURL.Append(@"https://picsum.photos/id/");
            imageURL.Append(m_LogicMemoryGameCardReference.CardValue);
            imageURL.Append(@"/80");
            r_ImageInCard.LoadAsync(imageURL.ToString());
        }

        internal MemoryGameCard LogicMemoryGameCardReference
        {
            get
            {
                return m_LogicMemoryGameCardReference;
            }

            set
            {
                m_LogicMemoryGameCardReference = value;
            }
        }

        internal int RowNumber
        {
            get
            {
                return m_RowNumber;
            }

            set
            {
                m_RowNumber = value;
            }
        }

        internal int ColumnNumber
        {
            get
            {
                return m_ColumnNumber;
            }

            set
            {
                m_ColumnNumber = value;
            }
        }

        public PictureBox ImageInCard
        {
            get
            {
                return r_ImageInCard;
            }
        }

        internal void HideImage() 
        {
            r_ImageInCard.Visible = false;
        }

        internal void ShowImage() 
        {
            r_ImageInCard.Visible = true;
        }
    }
}
