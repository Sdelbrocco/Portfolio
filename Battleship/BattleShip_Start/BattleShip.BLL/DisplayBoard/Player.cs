using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.BLL.DisplayBoard
{
    public class Player
    {
        public string Name { get; set; }
        public Board Board { get; set; }
        public List<Ship> Ships { get; set; }

        public Player()
        {
            this.Board = new Board();
        }
    }
}
