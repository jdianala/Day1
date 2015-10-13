using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Contrarian
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tell me something you like or dislike.");
            string usrStatement = Console.ReadLine().ToUpper();

            string newStatement = "";

            if (usrStatement.Contains("LIKE") && !(usrStatement.Contains("DISLIKE")))
            {
                newStatement = usrStatement.Replace("LIKE", "DISLIKE");
            }
            else if (usrStatement.Contains("DISLIKE"))
            {
                newStatement = usrStatement.Replace("DISLIKE", "LIKE");
            }
            else
                newStatement = "You need to say if you like it or not.";

            Console.WriteLine(newStatement);
            
            Console.ReadLine();
                

        }
    }
}
