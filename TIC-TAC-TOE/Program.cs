using System;

namespace TIC_TAC_TOE
{
    class Program
    {
        static void Main(string[] args)
        {
         

            HumanPlayer pA = new HumanPlayer();
            ComputerPlayer pB = new ComputerPlayer();
            pA.Name = "Użytkownik";
            pA.Symbol = 'x';
            pB.Name = "Kommputer";
            pB.Symbol = 'o';


            char[,] board = new char[3, 3]
            {
                {'1','2', '3' },
                {'4','5', '6' },
                {'7','8', '9' }
            };
            char[,] boardCopy = board.Clone() as char[,];


            bool endGame = false;
            bool isPlayerAMove = true;
            for(int round = 0; round < board.Length; ++round)
            {
                Console.Clear();
                DrawBoard(board);
                if (isPlayerAMove)
                {
                    Console.WriteLine("Ruch wykonuje: " + pA.Name);
                    endGame = pA.MakeMove(board, boardCopy);
                    isPlayerAMove = false;
                }
                else
                {
                    Console.WriteLine("Ruch wykonuje: " + pB.Name);
                    endGame = pB.MakeMove(board, boardCopy);
                    isPlayerAMove = true;
                }
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

    interface IMove
    {
        bool MakeMove(char[,] board, char[,] boardCopy);
    }

    abstract class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }
    }

    class HumanPlayer : Player, IMove
    {
        public bool MakeMove(char[,] board, char[,] boardCopy)
        {
            //tu bedzie wykonany ruch
            return false;
        }
    }

    class ComputerPlayer : Player, IMove
    {
        public bool MakeMove(char[,] board, char[,] boardCopy)
        {
            //tu bedzie ruch 
            return false;
        }
    }
}
