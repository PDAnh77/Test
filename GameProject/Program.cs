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
                    GamePlay gamePlay = null;
                    while (true) // Loop to return to GameLobby after closing RoomForm
                    {
                        if (gameLobby.ShowDialog() == GameLobby.ContinueToGamePlay)
                        {
                            if (gamePlay == null) // Ensure only create it once
                            {
                                gamePlay = gameLobby.GetGamePlay(); // Retrieve the GamePlay instance from GameLobby
                            }
                            if (gamePlay.ShowDialog() != DialogResult.OK)
                            {
                                continue;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            // Test form

            /*RoomForm roomForm = new RoomForm();
            Application.Run(roomForm);*/

            Application.Exit();
        }
    }
}
