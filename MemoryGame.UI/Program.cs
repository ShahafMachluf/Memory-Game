using System;
using System.Windows.Forms;

namespace MemoryGame.UI
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            RunMemoryGames.StartGame();
        }
    }
}
