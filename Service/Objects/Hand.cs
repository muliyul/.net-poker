using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Blackjack
{
    [CollectionDataContract]
    public class Hand : List<Card>
    {
        [DataMember]
        public int Value
        {
            get
            {
                int sum = this.Sum(card => card.Value);
                int aces = this.Count(card => card.Face == Face.Ace);

                while (sum > 21 && aces-- > 0) sum -= 10;
                return sum;
            }
        }
    }
}