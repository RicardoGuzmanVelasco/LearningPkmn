using UnityEngine.Assertions;

namespace Pkmn.Overworld.Runtime.Domain
{
    public class Cooldown
    {
        readonly int period;
        public Cooldown(int period)
        {
            Assert.IsTrue(period > 0);
            this.period = period;
        }
         
        public bool IsUp => period == 0;

        public void Tick()
        {
            
        }
    }
}