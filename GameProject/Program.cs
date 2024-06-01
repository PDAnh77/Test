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
                    while (true) // Loop to return to GameLobby after closing RoomForm
                    {
                        if (gameLobby.ShowDialog() == GameLobby.ContinueToRoomForm)
                        {
                            RoomForm room = new RoomForm();
                            if (room.ShowDialog() != DialogResult.OK)
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

            /*UserProfile userProfile = new UserProfile();
            Application.Run(userProfile);*/

            Application.Exit();
        }
    }
}
