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

        public void spawnStillLifes()
        {
            //block
            board[5, 5] = true;
            board[5, 6] = true;
            board[6, 5] = true;
            board[6, 6] = true;

            //beehive
            board[10, 10] = true;
            board[11, 10] = true;
            board[9, 11] = true;
            board[12, 11] = true;
            board[10, 12] = true;
            board[11, 12] = true;

            //loaf
            board[20, 10] = true;
            board[21, 10] = true;
            board[19, 11] = true;
            board[22, 11] = true;
            board[20, 12] = true;
            board[22, 12] = true;
            board[21, 13] = true;

            //Boat
            board[10, 5] = true;
            board[11, 5] = true;
            board[10, 6] = true;
            board[12, 6] = true;
            board[11, 7] = true;

            //tub
            board[20, 5] = true;
            board[19, 6] = true;
            board[21, 6] = true;
            board[20, 7] = true;
        }

        public void spawnOscillators()
        {
            //blinker
            board[3, 15] = true;
            board[3, 16] = true;
            board[3, 17] = true;

            //toad
            board[8, 17] = true;
            board[9, 17] = true;
            board[10, 17] = true;
            board[9, 16] = true;
            board[10, 16] = true;
            board[11, 16] = true;

            //beacon
            board[15, 15] = true;
            board[16, 15] = true;
            board[15, 16] = true;
            //board[16, 16] = true;
            //board[17, 17] = true;
            board[18, 17] = true;
            board[17, 18] = true;
            board[18, 18] = true;

            //pulsar
            board[30, 8] = true;
            board[30, 9] = true;
            board[30, 10] = true;
            board[32, 6] = true;
            board[33, 6] = true;
            board[34, 6] = true;

            board[32, 11] = true;
            board[33, 11] = true;
            board[34, 11] = true;
            board[35, 8] = true;
            board[35, 9] = true;
            board[35, 10] = true;

            board[30, 8] = true;
            board[30, 9] = true;
            board[30, 10] = true;
            board[32, 6] = true;
            board[33, 6] = true;
            board[34, 6] = true;

            board[38, 11] = true;
            board[39, 11] = true;
            board[40, 11] = true;
            board[37, 8] = true;
            board[37, 9] = true;
            board[37, 10] = true;

            board[42, 8] = true;
            board[42, 9] = true;
            board[42, 10] = true;
            board[38, 6] = true;
            board[39, 6] = true;
            board[40, 6] = true;

            board[37, 14] = true;
            board[37, 15] = true;
            board[37, 16] = true;
            board[35, 14] = true;
            board[35, 15] = true;
            board[35, 16] = true;
            
            board[38, 13] = true;
            board[39, 13] = true;
            board[40, 13] = true;
            board[32, 13] = true;
            board[33, 13] = true;
            board[34, 13] = true;

            board[38, 13] = true;
            board[39, 13] = true;
            board[40, 13] = true;
            board[32, 13] = true;
            board[33, 13] = true;
            board[34, 13] = true;

            board[42, 14] = true;
            board[42, 15] = true;
            board[42, 16] = true;
            board[32, 18] = true;
            board[33, 18] = true;
            board[34, 18] = true;

            board[38, 18] = true;
            board[39, 18] = true;
            board[40, 18] = true;
            board[30, 14] = true;
            board[30, 15] = true;
            board[30, 16] = true;

            //Pentadecathlon
            board[55, 7] = true;
            board[55, 8] = true;
            board[54, 9] = true;
            board[56, 9] = true;
            board[55, 10] = true;
            board[55, 11] = true;
            board[55, 12] = true;
            board[55, 13] = true;
            board[54, 14] = true;
            board[56, 14] = true;
            board[55, 15] = true;
            board[55, 16] = true;

        }

        public void spawnPresets()
        {
            this.spawnStillLifes();
            this.spawnOscillators();
        }



        static void Main(string[] args)
        {
            Program sim = new Program();
            sim.seedBoard(sim.board);
            //sim.spawnPresets();
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
