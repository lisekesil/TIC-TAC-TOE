using System;

namespace TIC_TAC_TOE
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePlayerA = "";
            string namePlayerB = "";
            char symbolPlayerA = 'x';
            char symbolPlayerB = 'o';

            char[,] board = new char[3, 3]
            {
                {'1','2', '3' },
                {'4','5', '6' },
                {'7','8', '9' }
            };

            Console.Write("player A name: ");
            namePlayerA = Console.ReadLine();
            Console.Write("player B name: ");
            namePlayerB = Console.ReadLine();
        }
    }
}
