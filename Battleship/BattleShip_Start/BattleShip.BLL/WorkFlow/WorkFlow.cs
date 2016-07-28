using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.DisplayBoard;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.BLL
{
    public class WorkFlow
    {
        static readonly Player player1 = new Player();
        static readonly Player player2 = new Player();

        public static ShipDirection GetDirection(Player name)
        {
            int userInput;
            userInput = ConsoleIo.PromptInt("Input: 1 = up, 2 = down, 3 = left, 4 = right");

            while (userInput < 1 || userInput > 4)
            {
                ConsoleIo.Display("Invalid input, please enter 1 - 4");
                userInput = ConsoleIo.PromptInt("Input: 1 = up, 2 = down, 3 = left, 4 = right");
            }
            switch (userInput)
            {
                case 1:
                    return ShipDirection.Up;
                case 2:
                    return ShipDirection.Down;
                case 3:
                    return ShipDirection.Left;
                case 4:
                    return ShipDirection.Right;
                default:
                    ConsoleIo.Display("Something terrible happened");
                    return ShipDirection.Right;
            }
        }
        
        public static Coordinate GetCoordinate(string playerName)
        {
            int x = 0;
            int y = 0;
            if (playerName != null)
            {
                bool isValid = false;
                do
                {
                    ConsoleIo.DisplayPlayerName(playerName);
                    string newCoord = ConsoleIo.PromptCoordinate();
                    if (newCoord.Length < 1 || newCoord.Length > 4)
                    {
                        ConsoleIo.Display("That's not a coordinate...Try again.");
                        continue;
                    }
                    int.TryParse(newCoord.Substring(1), out y);
                    x = Convert.ToInt32(newCoord[0]) - 64;
                    if (y < 1 || y > 10)
                    {
                        ConsoleIo.Display("You're a bad bad person! 1 - 10 ONLY!!!");
                        Thread.Sleep(2000);
                    }
                    else if (x < 0 || x > 10)
                    {
                        ConsoleIo.Display($"CHILLLLLLL {playerName.ToUpper()}! Lets try again...A-J only this time!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        isValid = true;
                    }
                    x = Convert.ToInt32(newCoord[0]) - 64;
                    
                } while (!isValid);

                return new Coordinate(x, y);
            }
            return null;
        }

        public static void InitialSetup()
        {
            List<Player> players = new List<Player>();
            
            ConsoleIo.ShowBattleShipMenu();

            player1.Name = ConsoleIo.GetPlayerOneName();
            players.Add(player1);

            Console.Clear();
            ConsoleIo.ShowBattleShipMenu();
            player2.Name = ConsoleIo.GetPlayerTwoName();
            players.Add(player2);


            Console.Clear();
            ConsoleIo.DisplayPlayerName(player1.Name);
            ConsoleIo.PlayerContinue();
            Console.Clear();

            foreach (Player player in players)
            {
                for (int i = 0; i < 5; i++)
                {
                    bool isValid = false;
                    do
                    {
                        ConsoleIo.PromptPlaceShip();
                        ConsoleIo.PlaceShipBoard(player.Board);
                        PlaceShipRequest placeShip = new PlaceShipRequest();
                        placeShip.Coordinate = GetCoordinate(player.Name);
                        placeShip.Direction = GetDirection(player1);
                        placeShip.ShipType = (ShipType)i;
                        ShipPlacement response = player.Board.PlaceShip(placeShip);

                        switch (response)
                        {
                            case ShipPlacement.NotEnoughSpace:
                                Console.Clear();
                                ConsoleIo.Display("Not enough space, try again...");
                                break;
                            case ShipPlacement.Overlap:
                                Console.Clear();
                                ConsoleIo.Display("Looks like theres already a ship there, try again...");
                                break;
                            case ShipPlacement.Ok:
                                Console.Clear();
                                isValid = true;
                                break;
                            default:
                                Console.Clear();
                                ConsoleIo.Display("Try again");
                                break;
                        }
                    } while (!isValid);
                }
                ConsoleIo.Display("Good Work, your ships were placed!");
                ConsoleIo.DisplayPlayerName(player2.Name);
            }
            ConsoleIo.PlayerContinue();
        }

        public static void PlayGame()
        {
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            bool isWinner = false;
            do
            {
                for (int i = 1; i <= players.Count; i++)
                {
                    Player player = players[i - 1];
                    Player enemy = players[i % 2];

                    Console.Clear();
                    bool isValid = false;
                    do
                    {
                        ConsoleIo.PromptFireShot();
                        ConsoleIo.DisplayBoard(enemy.Board);
                        var coord = GetCoordinate(player.Name);
                        FireShotResponse response = enemy.Board.FireShot(coord);
                        switch (response.ShotStatus)
                        {
                            case ShotStatus.Invalid:
                                Console.Clear();
                                ConsoleIo.Display("Please pick a coordinate within the gird...");
                                break;
                            case ShotStatus.Duplicate:
                                Console.Clear();
                                ConsoleIo.Display("Looks like you've already tried that spot...");
                                break;
                            case ShotStatus.Miss:
                                Console.Clear();
                                ConsoleIo.Display("MISS!");
                                isValid = true;
                                break;
                            case ShotStatus.Hit:
                                Console.Clear();
                                ConsoleIo.Display($"You've hit {enemy.Name}'s ship!");
                                isValid = true;
                                break;
                            case ShotStatus.HitAndSunk:
                                Console.Clear();
                                ConsoleIo.Display($"You've sunk {enemy.Name}'s {response.ShipImpacted}");
                                isValid = true;
                                break;
                            case ShotStatus.Victory:
                                Console.Clear();
                                ConsoleIo.ShowWinner(player.Name);
                                isValid = true;
                                isWinner = true;
                                break;
                            default:
                                Console.WriteLine("Something really went wrong! GIT fetch Victor!");
                                break;
                        }
                    } while (!isValid);

                    if (isWinner)
                    {
                        break;
                    }
                    ConsoleIo.DisplayBoard(enemy.Board);
                    ConsoleIo.PlayerContinue();
                }
            } while (!isWinner);
        }
    }
}
