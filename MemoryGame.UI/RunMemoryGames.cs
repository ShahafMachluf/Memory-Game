using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame.UI
{
    internal class RunMemoryGames
    {
        public static void StartGame()
        {
            GameBoardForm mainForm = new GameBoardForm();
            SettingForm settingsForm = new SettingForm(mainForm);
            settingsForm.ShowDialog();
            while ((settingsForm.FirstPlayerName == string.Empty || settingsForm.SecondPlayerName == string.Empty) && !settingsForm.XButtunClicked)
            {
                settingsForm.ShowDialog();
            }

            if (settingsForm.DialogResult == DialogResult.OK)
            {
                mainForm.ShowDialog();
            }
        }   
    }
}
