
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class GameArgs : EventArgs
    {
        public Table Table { get; set; }
        public PlayerData Player { get; set; }
        public PlayerData Dealer { get; set; }
        public decimal  Amount { get; set; }
        public Card Card { get; set; }
        public string Message { get; set; }
    }
}