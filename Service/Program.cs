using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Blackjack
{
    public class Program
    {
        public static void main()
        {
            using (var sh = new ServiceHost(typeof(Game)))
            {
                sh.Open();
                Console.WriteLine("Server listening");
                Console.ReadKey();
            }
        }
    }
}