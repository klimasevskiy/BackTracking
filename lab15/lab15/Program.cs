using System;

class BackTrack
{
    int[,] CreateBoard(int n)
    {
        int[,] board = new int[n, n];
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                board[i, j] = 0;
            }
        }
        return board;
    }
    void printSolution(int[,] board, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(" " + board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    bool isSafe(int[,] board, int row, int col, int n)
    {
        int i, j;

        for (i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;

        for (i = row, j = col; i >= 0 &&
             j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;

        for (i = row, j = col; j >= 0 &&
                      i < n; i++, j--)
            if (board[i, j] == 1)
                return false;

        return true;
    }

    bool solveNQUtil(int[,] board, int col, int n)
    {
        if (col >= n)
            return true;

        for (int i = 0; i < n; i++)
        {
            if (isSafe(board, i, col, n))
            {
                board[i, col] = 1;

                if (solveNQUtil(board, col + 1, n) == true)
                    return true;

                board[i, col] = 0; // BACKTRACK
            }
        }

        return false;
    }

    bool solveNQ(int n)
    {
        int[,] board = CreateBoard(n);

        if (solveNQUtil(board, 0, n) == false)
        {
            Console.Write("Solution does not exist");
            return false;
        }

        printSolution(board, n);
        return true;
    }

    public static void Main(String[] args)
    {
        Console.Write("n = "); int n = Convert.ToInt32(Console.ReadLine());
        BackTrack Queen = new BackTrack();
        Queen.solveNQ(n);
    }
}