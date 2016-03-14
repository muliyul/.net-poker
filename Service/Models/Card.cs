using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Service.Models
{

    public enum Suit { Spades, Hearts, Clubs, Diamonds }
    public enum Face:int { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack = 10, Queen = 10, King = 10, Ace = 11 }


    [DataContract]
    public class Card
    {
        [DataMember]
        public Suit Suit { get; set; }
        [DataMember]
        public Face Face { get; set; }
        [DataMember]
        public int Value { get { return (int)Face; } }
    }
}
