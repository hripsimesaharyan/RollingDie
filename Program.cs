using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingDie
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Die sixSided = new Die(6);
          
            Die tenSided = new Die(10);

            Console.WriteLine(sixSided.GetSidesCount());
            Console.WriteLine(tenSided.GetSidesCount());


            Twotimesfourtosses(sixSided);
           
            //Die sixSided1 = new Die(6);

            Setofdie(sixSided);


            Console.ReadKey();
        }

        public static void Twotimesfourtosses(Die sixsided)
        {

            sixsided.DieSelected += TwotimesDieselected;
          
            for (int i = 0; i < 50; i++)
            {

                int[] dies = sixsided.Roll();
                sixsided.Dierollcout(dies);
             
                Console.WriteLine(" ");
               
            }
           

        }
        public static void Setofdie(Die sixsided)
        {
            sixsided.DieSelected -= TwotimesDieselected;
            sixsided.DieSelected += Dietosses;

            for (int i = 0; i < 50; i++)
            {
                int [] dies =sixsided.Roll();
                sixsided.Diesecuent(dies);

                Console.WriteLine(" ");
                
            }

        }

        private static void Dietosses(object sender, RollingDieSelectEventArgs args)
        {
            Console.WriteLine($"Consequent 5 tosses sum  >=20 --{args.count}");

           
        }
        private static void TwotimesDieselected(object sender, RollingDieSelectEventArgs args)
        {
            Console.WriteLine($"Die roll 4 two times- {args.count}");

           
        }
    }
}
