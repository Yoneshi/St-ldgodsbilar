using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Car
    {
        public int passengers; 
        public int contrabandAmount;
        public bool alreadyChecked; // Ja/ nej om bilen har blivit visiterad
        public static Random generator;


        public bool Examine()
        {
            this.alreadyChecked = true;
            return ((this.contrabandAmount != 0) && (generator.Next(6) <= this.contrabandAmount));
        }

        static Car()
        {
            generator = new Random();
        }

        public Car()
        {

        }

        class CleanCar
        {
            public CleanCar()
            {
                base.passengers = Car.generator.Next(1, 4); //Risken att missa stöldgods ska helst bero på hur mycket som finns – om man har 1 så ska det vara större chans att komma undan än om man har 4.

                base.contrabandAmount = 0;
            }
        }
    }
    //katt


    class Program
    {







    {
        static void Main(string[] args) // oh shit tiden rinner ut hinner inte göra klart.
        {
            Console.WriteLine("Hur många bildar vill ni skapa?"); // Basic som frågar hur många bilar man vill skapa 

            int result = -1; // 

            while (result <= 0)
            {
                if (int.TryParse(Console.ReadLine(), out result) && (result > 0))
                {

                    continue;

                }


                Console.WriteLine("ogiltigt svar testa igen tack.");

            }

            List<Car> list = new List<Car>();
            Random random = new Random();
            for (int i = 0; i < result; i++)
            {
                if (random.Next(2) == 0)
                {
                    list.Add(new Cleancar());

                }
                else
                {
                    list.Add(new Contrabandcar());
                }


            }
            while (true)
            {
                Console.WriteLine("Vilken bil vill ni se på?" + (list.Count - 1).ToString());
                result = -1;


                while (true)
                {
                    if ((result > 0) && (result <= (list.Count - 1)))
                    {
                        if (list[result].alreadyChecked)
                        {
                            Console.WriteLine("Ni har redan udnersökt denna bil");

                        }
                        else
                        {
                            Console.WriteLine("Undersöker bilen...");
                            if (list[result].Examine())
                            {
                                Console.WriteLine("Hittade" + list[result].contrabandAmount.ToString() + "stöldgods");
                            }
                            else
                            {
                                Console.WriteLine("Hittade inget.");


                            }
                        }
                        break;

                    }
                    if (!int.TryParse(Console.ReadLine(), out result) || ((result < 0) || (result > (list.Count - 1))))
                    {

                        Console.WriteLine("ogiltig inmatning försök igen tack.");
                    }

                }

            }


        }
    }
}
}
