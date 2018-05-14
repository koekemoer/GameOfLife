using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static int w = Console.WindowWidth - 1;
        static int h = Console.WindowHeight - 4;
        public bool[,] board = new bool[w, h];
        int genCount = 0;
        public int aliveCells = 0;

        public void printBoard(bool[,] board)
        {
            this.aliveCells = 0;
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < h; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < w; x++)
                {
                    Console.Write(board[x, y] ? "▓" : "_");
                    //Console.Write(" ");
                    if (board[x, y])
                        aliveCells++;
                }
            }
            //Console.SetCursorPosition(0, h);
            Console.WriteLine();
            Console.Write("Generation: " + genCount);
            Console.WriteLine();
            Console.Write("Alive Cells: " + aliveCells);
            Console.WriteLine();
            Console.WriteLine("WINDOW WIDTH: " + (Console.WindowWidth - 1));
            Console.WriteLine("WINDOW HEIGHT: " + (Console.WindowHeight - 4));
        }

        public bool[,] seedBoard(bool[,] board)
        {
            Random random = new Random();
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    board[x, y] = Convert.ToBoolean(random.Next(1, 3) % 2);
                }
            }
            
            return board;
        }

        public int countNeighbours(int x, int y)
        {
            int count = 0;

            if ((x > 0 && y > 0) && board[x - 1, y - 1])
                count++;
            if (y > 0 && board[x, y - 1])
                count++;
            if ((y > 0 && x < w - 1) && board[x + 1, y - 1])
                count++;
            if (x > 0 && board[x - 1, y])
                count++;
            if (x < w - 1 && board[x + 1, y])
                count++;
            if ((x > 0 && y < h - 1) && board[x - 1, y + 1])
                count++;
            if (y < h - 1 && board[x, y + 1])
                count++;
            if ((x < w - 1 && y < h - 1) && board[x + 1, y + 1])
                count++;

            return count;
        }

        public bool[,] processBoard(bool[,] board)
        {
            bool[,] nextGen = new bool[w, h];
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    //int neighbours = 0;
                    int neighbours = countNeighbours(x, y);

                    if (board[x, y] && neighbours > 3)
                        nextGen[x, y] = !board[x, y];
                    else if (board[x, y] && neighbours < 2)
                        nextGen[x, y] = !board[x, y];
                    else if (!board[x, y] && neighbours == 3)
                        nextGen[x, y] = !board[x, y];
                    else
                        nextGen[x, y] = board[x, y];
                }
            }
            this.genCount++;

            return nextGen;
        }



        static void Main(string[] args)
        {
            Program sim = new Program();
            sim.seedBoard(sim.board);
            sim.printBoard(sim.board);
            Console.CursorVisible = false;

            while (sim.aliveCells > 0)
            {
                sim.board = sim.processBoard(sim.board);
                sim.printBoard(sim.board);
            }
            //int temp = sim.countNeighbours(10, 10);
            //Console.WriteLine("Count Neighbours: " + temp);
            Console.ReadLine();
        }
    }
}
