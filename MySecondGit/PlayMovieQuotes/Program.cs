using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;

namespace PlayMovieQuotes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Sound Player Objects
            var movie1 = new SoundPlayer(@"http://www.wavsource.com/snds_2015-08-16_6897529750891327/movies/12_angry_men/answer.wav");
            var movie2 = new SoundPlayer(@"http://www.wavsource.com/snds_2015-08-16_6897529750891327/movies/terminator/t1_be_back.wav");
            var movie3 = new SoundPlayer(@"http://www.wavsource.com/snds_2015-08-16_6897529750891327/movies/forrest_gump/stupid_is.wav");

            //Create an array of SoundPlayer Objects aka  An array of movie sound clips
            var soundClips = new SoundPlayer[] { movie1, movie2, movie3};

            //Create a new instance of the Random() class
            Random rnd = new Random();

            //Select a random number using the length of the soundClips array as the max length
            int newIndex = rnd.Next(soundClips.Length);

            //Selects the SoundPlayer object with the index number that matches newIndex 
            soundClips[newIndex].Play();
            Console.ReadLine();

        }
    }
}


