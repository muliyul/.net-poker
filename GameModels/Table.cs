
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Collections.Specialized;

namespace Shared
{
    [DataContract]
    public class Table
    {
        IList<Player> players = new List<Player>();

        [DataMember]
        public IList<Player> Players { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int Pot { get; set; }
    }
}