using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.DisplayBoard;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using Microsoft.Win32;

namespace BattleShip.UI
{

    class Program
    {
        public static void Main(string[] args)
        {
            bool keepPlaying;
            do
            {
                WorkFlow.InitialSetup();
                WorkFlow.PlayGame();
                keepPlaying = ConsoleIo.PlayAgain();
                Console.Clear();
            } while (keepPlaying);
        }
    }
}

