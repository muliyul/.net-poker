using ConsoleClient.GameReferrence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static GameClient client = new GameClient();

        static void Main(string[] args)
        {
            client.ClientCredentials.UserName.UserName = "muli";
            client.ClientCredentials.UserName.Password = "1233";

            var p = client.GetMyInfo();
            Console.WriteLine(p?.Username + p?.Password);
        }
    }
}
