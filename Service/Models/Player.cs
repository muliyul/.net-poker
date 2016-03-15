using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Web;

namespace Service.Models
{
    [DataContract]
    public class Player
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public double Bank { get; set; }
        [DataMember]
        public DateTime MemberSince { get; set; }

        public IGameCallback Callback { get; set; }

        public Player(Service.Player p):this(p, false)
        {
        }

        public Player(Service.Player p, bool isAuthed)
        {
            Id = p.Id;
            Guid = p.Guid;
            Username = p.Username;
            Password = isAuthed? p.Password: null;
            Bank = p.Bank;
            MemberSince = p.MemberSince;
        }

        public Service.Player ToModel()
        {
            var p = new Service.Player();
            p.Id = Id;
            p.Guid = Guid ;
            p.Username = Username;
            p.Password = Password;
            p.Bank = Bank;
            p.MemberSince = MemberSince;
            return p;
        }
    }
}