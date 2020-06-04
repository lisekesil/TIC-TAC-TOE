using System;
using System.Threading;

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

                if (endGame)
                    break;
                //...
            }
            //zakonczenie gry
            Console.Clear();
            DrawBoard(board);
            Console.Write("Koniec Gry! ");
            if (endGame)
            {
                Console.Write("Wygral: ");
                if (isPlayerAMove)
                    Console.WriteLine(pB.Name);
                else
                    Console.WriteLine(pA.Name);
            }
            else
                Console.WriteLine("Remis.");
            
            Console.ReadKey();
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

        public bool CheckIfGameOver(char[,] board)
        {
            int height = board.GetLength(0);
            int width = board.GetLength(1);
            if (width != height)
                throw new Exception("Plansza nie jest kwadratowa!");

            //sprawdz wiersze
            for(int i = 0; i<height; ++i)
            {
                int sumOfVerse = 0;
                for(int j =0; j<width; ++j)
                {
                    if (board[i, j] == Symbol)
                        ++sumOfVerse;
                }

                if (sumOfVerse == width)
                    return true;
            }

            //sprawdz kolumny
            for(int j = 0; j<width; ++j)
            {
                int sumOfColumn = 0;
                for(int i = 0; i <height; ++i)
                {
                    if (board[i, j] == Symbol)
                        ++sumOfColumn;
                }

                if (sumOfColumn == height)
                    return true;
            }

            //sprawdz przekatne
            int sumOfDiagonalA = 0;
            int sumOfDiagonalB = 0;
            for (int k =0; k<width; ++k)
            {
                if (board[k, k] == Symbol)
                    ++sumOfDiagonalA;
                if (board[k, width - 1 - k] == Symbol)
                    ++sumOfDiagonalB;
            }
            if (sumOfDiagonalA == width || sumOfDiagonalB == width)
                return true;

            //jesli zadna z opcji, nie ma konca gry
            return false;
        }

        public bool AddSymbol(char c, char[,] board, char[,] boardCopy)
        {
            int height = board.GetLength(0);
            int width = board.GetLength(1);
            if (height != boardCopy.GetLength(0) || width != boardCopy.GetLength(1))
                throw new Exception("rozmiary plansz nie zgadzaja sie");

            for(int i = 0; i < height; ++i)
                for(int j = 0; j <width; ++j)
                {
                    if ((board[i, j] == c) && (board[i, j] == boardCopy[i, j]))
                    {
                        board[i, j] = Symbol;
                        return true;
                    }
                }

            return false;
        }
    }

    class HumanPlayer : Player, IMove
    {
        public bool MakeMove(char[,] board, char[,] boardCopy)
        {
            char selectedField;
            do
            {
                Console.Write("Wybierz puste pole: ");
                selectedField = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            while (!AddSymbol(selectedField, board, boardCopy));


            return CheckIfGameOver(board);
        }
    }

    class ComputerPlayer : Player, IMove
    {
        public bool MakeMove(char[,] board, char[,] boardCopy)
        {
            Random rnd = new Random();
            char selectedField;
            do
            {
                int m = rnd.Next(1, board.Length + 1);
                selectedField = m.ToString()[0];
            }
            while (!AddSymbol(selectedField, board, boardCopy));
            Thread.Sleep(2000);
            
            return CheckIfGameOver(board);
        }
    }
}
