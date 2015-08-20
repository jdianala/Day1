using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string one = "cat";
            string two = "dog";
            string three = "bird";
            var message = String.Format("The {0} that chasing the {2} was eaten by the {1}", one, two, three);
            Console.WriteLine(message);
          
            Console.ReadLine();
        }
    }
}
