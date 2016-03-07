using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Bank { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
