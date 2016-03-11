﻿using System;
using System.Runtime.Serialization;

namespace Shared
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
        [DataMember]
        public Hand Hand { get; set; }
    }
}
