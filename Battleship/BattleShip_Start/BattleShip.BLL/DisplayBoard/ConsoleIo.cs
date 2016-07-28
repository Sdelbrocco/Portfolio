using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.BLL.DisplayBoard
{
    public class ConsoleIo
    {

        public static void ShowBattleShipMenu()
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                      WELCOME TO BATTLESHIP!                    |");
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                     SINK ALL THE ENEMY SHIPS!                  |");
            Console.WriteLine("|                     First arrange your ships,                  |");
            Console.WriteLine("|                  then take turns with each other               |");
            Console.WriteLine("|                     to bomb each others ships                  |");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                            GOOD LUCK!                          |");
        }
        
        
        public static void PlaceShipBoard(Board board)
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                            BATTLESHIP                          |");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|     A     B     C     D     E     F     G     H     I     J    |");
            Console.WriteLine("+----------------------------------------------------------------+");

            string strA = " ";

            string strB = "S";

            for (int i = 0; i < 10; i++)
            {
                Console.Write("\n {0, -5}", i + 1);

                for (int j = 0; j < 10; j++)
                {
                    bool exists = false;
                    foreach (var ship in board.GetShips())
                    {
                        if (ship != null)
                            if (ship.BoardPositions.Any(b => b != null && b.XCoordinate == j+1 && b.YCoordinate == i+1))
                            {
                                exists = true;
                            }
                        if (exists)
                            break;
                    }

                    Console.Write("{0, -6}", exists ? strB : strA);
                }
            }
            Console.WriteLine("\n+----------------------------------------------------------------+");
        }
    

        public static void DisplayBoard(Board board)
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                            BATTLESHIP                          |");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|     A     B     C     D     E     F     G     H     I     J    |");
            Console.WriteLine("+----------------------------------------------------------------+");

            string strA = " ";

            string strB = " ";

            for (int i = 1; i < 11; i++)
            {
                Console.Write("\n {0, -5}", i);

                for (int j = 1; j < 11; j++)
                {
                    ShotHistory shotHistory;
                    if (board.ShotHistory.ContainsKey(new Coordinate(j, i)))
                    {
                        board.ShotHistory.TryGetValue(new Coordinate(j, i), out shotHistory);
                        switch (shotHistory)
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("{0, -6}", "H");
                                Console.ResetColor();
                                break;
                            case ShotHistory.Unknown:
                                Console.Write("{0, -6}", strB);
                                break;
                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("{0, -6}", "M");
                                Console.ResetColor();
                                break;
                            default:
                                Console.Write("{0, -6}", strB);
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("{0, -6}", strB);

                    }
                }
            }
            Console.WriteLine("\n+----------------------------------------------------------------+");
        }


        public static string GetPlayerOneName()
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                            PLAYER ONE                          |");
            Console.WriteLine("|                      Please enter your name:                   |");
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.Write(" ");
            return Console.ReadLine();
        }


        public static string GetPlayerTwoName()
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                            PLAYER TWO                          |");
            Console.WriteLine("|                      Please enter your name:                   |");
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.Write(" ");
            return Console.ReadLine();
        }


        public static void DisplayPlayerName(string playerName)
        {
            Console.WriteLine("                                                                  ");
            Console.WriteLine($"                              {playerName.ToUpper()}                           ");
        }


        public static  void ShowWinner(string playerName)
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine($"                               {playerName.ToUpper()} WINS!                    ");
        }


        public static bool PlayAgain()
        {
            string PlayAgain;

            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                              GREAT JOB!                        |");
            Console.WriteLine("|                    Would You like to play again?               |");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                             (Y)es/(N)o:                        |");
            Console.WriteLine("+----------------------------------------------------------------+");
            PlayAgain = Console.ReadLine();

            if (PlayAgain.ToUpper() != "N")
            {
                return true;
            }
            return false;
        }


        public static void PlayerContinue()
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                    Press any key to continue...                |");
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.Write(" ");
            Console.ReadKey();
        }


        public static string PromptCoordinate()
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                   PLEASE ENTER VALID COORDINATE                |");
            Console.WriteLine("|                             ex. 'A1'                           |");
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.Write(" ");
            return Console.ReadLine().ToUpper();
        }


        public static void PromptPlaceShip()
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                      PLEASE PLACE YOUR SHIPS                   |");
            Console.WriteLine("|                                                                |");
        }
        
        
        public static void PromptFireShot()
        {
            Console.WriteLine("+----------------------------------------------------------------+");
            Console.WriteLine("|                            TAKE A SHOT                         |");
        }


        public static string PromptString(string message)
        {
            Display(message);
            return Console.ReadLine();
        }


        public static void Display(string message)
        {
            Console.WriteLine(message);
        }


        public static int PromptInt(string message)
        {
            bool isValid;
            int result;
            
            do
            {
                string userInput = PromptString(message);
                isValid = int.TryParse(userInput, out result);
                if (!isValid)
                {
                    Display("I said a number!");
                }
            } while (!isValid);
            return result;
        }

    }
}

