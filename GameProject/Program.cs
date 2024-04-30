using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Menu gameMenu = new Menu();
            while (true) // Loop to return to GameMenu after closing GameLobby
            {
                if (gameMenu.ShowDialog() == DialogResult.OK)
                {
                    GameLobby gameLobby = new GameLobby();
                    if (gameLobby.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            Application.Exit();
        }
    }
}
