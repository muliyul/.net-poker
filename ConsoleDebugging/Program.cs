using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDebugging.GameReference;
using System.ServiceModel;
using System.Threading;

namespace ConsoleDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Program();
            x.MyFunc();

            Thread.Sleep(600000);
        }

        private async void MyFunc()
        {
            var callback = new CallBacks();
            var instanceContax = new InstanceContext(callback);
            using (var gr = new GameReference.GameClient(instanceContax))
            {
                 gr.CreateTable("l");
              
            }
        }
    }

   

    class CallBacks : GameReference.IGameCallback
    {
        public void OnBet(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnDeal(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnFold(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnHit(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnJoin(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnLeave(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnNewTableCreated(object sender, GameArgs e)
        {
            Console.WriteLine("yay");
        }

        public void OnNextTurn(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
