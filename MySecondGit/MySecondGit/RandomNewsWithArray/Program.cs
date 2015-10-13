using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RandomNewsWithArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //    var headlines = new String[] { "Martian Attacks!", "Cowboys win Superbowl", "John is so handsome" };
            //    Random rnd = new Random();

            //    int newIndex = rnd.Next(headlines.Length);
            //    Console.WriteLine(headlines[newIndex]);
            var i = 1;

            do
            {
                
                if (i % 7 == 0)
                {
                    Console.WriteLine(i);
                
                    
                }
                else
                {
                    
                }

                i++;
                
            } while (i < 100);

            Console.ReadLine();


        }
    }
}
