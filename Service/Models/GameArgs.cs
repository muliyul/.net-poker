using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class GameArgs : EventArgs
    {
        public Models.Player Player { get; set; }
        public int Amount { get; set; }
        public Card Card { get; set; }
    }
}