using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace MySecondGit
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter day: ");
            int day = int.Parse(Console.ReadLine());

            DateTime newDate = new DateTime(year, month, day);

            Console.WriteLine(newDate.ToString("D", CultureInfo.CreateSpecificCulture("en-US")));       





            /*
            int x = 1, y = 3, sum = x + y;
            x = 2;
            y = 5;
         
            Console.WriteLine(DateTime.Now);
            Debug.Assert(true);
            Console.ReadLine();
            */

        }



    }
}
