
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class GameArgs : EventArgs
    {
        public Models.Table Table { get; set; }
        public Models.PlayerData Player { get; set; }
        public decimal  Amount { get; set; }
        public Card Card { get; set; }
    }
}