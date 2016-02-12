using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_RPG_thread_game
{
    internal class BuyMiner : BuyWorkerButton
    {

        public BuyMiner(Vector2 position, SizeF sizeF, object sender,WorkerType workerType) :
            base(position, sizeF, sender, workerType)
        {
            ButtonText = "Buy Miner";
        }


        protected override void SetEndStructure()
        {
            EndStructure = FindStructure<Goldmine>();
        }
    }
}