using System.Runtime.Serialization;
using System.Security.Principal;

namespace Blackjack.Objects
{
    public partial class Game
    {
    }

    public partial class Player
    {
        public IIdentity Identity { get; internal set; }
        [DataMember]
        public Hand Hand { get; internal set; }
    }
}
