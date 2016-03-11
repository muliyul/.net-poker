using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service.Models
{
    [DataContract]
    public class PlayerData
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
        [DataMember]
        public Hand Hand { get; set; }
    }
}