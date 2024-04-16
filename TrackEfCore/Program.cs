/*
* Sami Alzoubi
* CPSC 23000
* April 16th, 2024
* Track database
*/



using System;
using System.Threading.Tasks;

namespace TrackEfCore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await TrackManager.Run();
        }
    }
}
