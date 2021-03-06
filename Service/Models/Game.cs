//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.Winnings = 0m;
            this.Blackjacks = 0;
            this.WonHands = 0;
            this.LostHands = 0;
        }
    
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public decimal Winnings { get; set; }
        public int Blackjacks { get; set; }
        public System.DateTime PlayedOn { get; set; }
        public System.Guid GameId { get; set; }
        public int WonHands { get; set; }
        public int LostHands { get; set; }
        public int TotalHands { get; set; }
    
        public virtual Player Player { get; set; }
    }
}
