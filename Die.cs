using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingDie
{
    class Die
    {
        public event EventHandler<RollingDieSelectEventArgs> DieSelected;
        
        
        /// Number of sides that the die has
       
        private int sidesCount=6;
        private int value=1,count;
       
        /// Random number generator
       
        private Random random = new Random();

        private int[] history;

      

        public Die(int SidesCount)
        {
            if (SidesCount >= 1)
            {
                this.sidesCount = SidesCount;
            }
            history = new int[this.sidesCount];
            
        }
        
      

        public int getValue()
        {            
            return value;
        }
        // Tell us how many sides the die has

        public int GetSidesCount()
        {
            return sidesCount;
        }

        // Reset the history of this die

    public void resetHistory()
    {            
        history = new int[sidesCount];
    }


        // Implement a roll method to generate a number for the value

        public int[] Roll()
        //public void Roll()
        {
            //count = 0; 
            for (int i = 0; i <6 ; i++)
            {
                value = random.Next(1, sidesCount + 1);
                
                Console.Write($"{value},");
                history[i] = value;
               
            }
            

            return history;
        }

        public void Dierollcout(int [] history)
        {
            count = 0;
           
            for (int i = 0; i < 6; i++)
            {
               
                if (history[i] == 4)
                { count++; }

            }
            if (count == 2)
            {
                this.DieSelected?.Invoke(this, new RollingDieSelectEventArgs(count));
            }

            
            ////this.DieSelected?.Invoke(this, new RollingDieSelectEventArgs(history));
            //this.DieSelected?.Invoke(this, new RollingDieSelectEventArgs(count));
        }


        public void Diesecuent(int[] history)
        {
            int sum = 0;
            int first = history[0];
            int last = history[history.Length - 1];
            for (int i = 0; i < history.Length; i++)
            {
                sum += history[i];
            }

            if ((sum - first) >= 20 && (sum - last) >= 20)
            {
                //this.DieSelected?.Invoke(this, new RollingDieSelectEventArgs(history));
                this.DieSelected?.Invoke(this, new RollingDieSelectEventArgs(sum));
            }
        }
        public override string ToString()
        {
            return String.Format("Rolling a die with {0} sides", sidesCount);
        }

         



    }

}
