using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCore
{
    class clsBacktrack
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/the-knights-tour-problem-backtracking-1/
        /// Visit each square once on chess board
        /// </summary>
        /// <param name="N">N*N Size of the board</param>
        public void Tour(int x, int y, int N)
        {
            Console.WriteLine(x + "," + y);
            board[x, y] = step++;
            
            //Print Board
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(", " + board[i, j]);
                }
                Console.WriteLine("");
            }

            //Define moves for knight
            int[] move_x = new int[] { 2, 2, 1, 1, -2, -2, -1, -1 };
            int[] move_y = new int[] { 1, -1, 2, -2, -1, 1, -2, 2 };
            
            for(int k = 0; k < N; k++)
            {
                int nextX = x + move_x[k];
                int nextY = y + move_y[k];

                if (isSafe(nextX, nextY, N))
                {                    
                    Tour(nextX, nextY, N);
                }
            }
        }
        int step = 0;
        private int[,] board = new int[8, 8];                //Declare chess board
        private bool isSafe(int x,int y,int N)
        {
            if(x >=0 && x < N && y >= 0 && y < N && board[x,y] == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Find path from source to destination
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public bool SolveMaze(int[][] maze, int x , int y) {
            //Print Maze  
            for (int i = 0; i < maze.Length; i++)
            {
                maze[i] = new int[4];
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if((i == 0 && j == 0) || (i == 0 && j == 1) || 
                        (i == 1 && j == 0) || (i == 1 && j == 3) || (i == 1 && j == 2) ||
                        (i == 2 && j == 0) || (i == 0 && j == 2) || (i == 3 && j == 0) || //|| (i == 1 && j == 1) 
                        (i == 2 && j == 3) || (i == 0 && j == 3) || (i == 3 && j == 3)  )
                    {
                        maze[i][j] = 1;
                    }
                    Console.Write(", " + maze[i][j]);
                }
                Console.WriteLine("");
            }

            int sourceX = 0;
            int sourceY = 0;

            this.x = x;
            this.y = y;

            return  solveMaze(sourceX, sourceY, maze);
        }
        int x; 
        int y;
        private bool solveMaze(int sourceX, int sourceY,int[][] maze)
        {
            //Console.WriteLine("x:" + sourceX + ", y:" + sourceY +"," + maze[sourceX][sourceY]);
            if (sourceX == x && sourceY == y) { return true; }          //Path Found

            if (mazeIsSafe(sourceX+1, sourceY, maze))                   //Check if pathis valid
            {
                if(solveMaze(++sourceX, sourceY, maze)) { return true; }
                else { sourceX--; }
                //Console.WriteLine("x1:" + sourceX + "," + sourceY);
            }
            if (mazeIsSafe(sourceX, sourceY+1, maze))
            {
                if (solveMaze(sourceX, ++sourceY, maze)) { return true; }
                else { sourceY--; }
                //Console.WriteLine("y1:" + sourceX + "," + sourceY);
            }

            return false;
        }

        private bool mazeIsSafe(int x, int y, int[][] maze)
        {
            if (x >= 0 && x < maze.Length && y >= 0 && y < maze[0].Length && maze[x][y] == 1)
            {
                return true;
            }
            return false;
        }
    }
}
