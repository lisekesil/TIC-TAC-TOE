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
            char[,] boardCopy = board.Clone() as char[,];

            Console.Write("player A name: ");
            namePlayerA = Console.ReadLine();
            Console.Write("player B name: ");
            namePlayerB = Console.ReadLine();

            bool endGame = false;
            for(int round = 0; round < board.Length; ++round)
            {
                Console.Clear();
                DrawBoard(board);

                Console.ReadKey();
                //...
            }
        }

        static void DrawBoard(char[,] board)
        {
            int height = board.GetLength(0);
            int width = board.GetLength(1);

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
