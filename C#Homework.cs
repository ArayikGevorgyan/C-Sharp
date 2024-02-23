// //Homework Task 1
/////////////////////         Show the horse strokes in the matrix [8,8]


// class Program
// {
//     static void Main()
//     {
//         int[,] chessboard = new int[8, 8];

//         int horseRow = 2;
//         int horseCol = 3;

//         MarkHorseMoves(chessboard, horseRow, horseCol);
//         PrintChessboard(chessboard);
//     }

//     static void MarkHorseMoves(int[,] chessboard, int row, int col)
//     {
//         int[] moveRow = { -2, -1, 1, 2, 2, 1, -1, -2 };
//         int[] moveCol = { 1, 2, 2, 1, -1, -2, -2, -1 };

//         for (int i = 0; i < 8; i++)
//         {
//             int newRow = row + moveRow[i];
//             int newCol = col + moveCol[i];

//             if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
//             {
//                 chessboard[newRow, newCol] = 1;
//             }
//         }
//     }

//     static void PrintChessboard(int[,] chessboard)
//     {
//         for (int i = 0; i < 8; i++)
//         {
//             for (int j = 0; j < 8; j++)
//             {
//                 Console.Write(chessboard[i, j] + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }

// ----------------------------------------------------------------------------------------------------------------------------------

// //Homework Task 2
/////////////////////////             Show the queen strokes in the matrix [8,8]
// class Program
// {
//     static void Main()
//     {
//         int[,] chessboard = new int[8, 8];

//         int queenRow = 3;
//         int queenCol = 4;

//         MarkQueenMoves(chessboard, queenRow, queenCol);

//         PrintChessboard(chessboard);
//     }

//     static void MarkQueenMoves(int[,] chessboard, int row, int col)
//     {

//         for (int i = 0; i < 8; i++)
//         {
//             chessboard[row, i] = 1;
//             chessboard[i, col] = 1;
//         }

//         for (int i = 1; i < 8; i++)
//         {
            
//             if (row + i < 8 && col + i < 8)
//                 chessboard[row + i, col + i] = 1;
            
//             if (row - i >= 0 && col + i < 8)
//                 chessboard[row - i, col + i] = 1;

//             if (row + i < 8 && col - i >= 0)
//                 chessboard[row + i, col - i] = 1;

//             if (row - i >= 0 && col - i >= 0)
//                 chessboard[row - i, col - i] = 1;
//         }
//     }

//     static void PrintChessboard(int[,] chessboard)
//     {
//         for (int i = 0; i < 8; i++)
//         {
//             for (int j = 0; j < 8; j++)
//             {
//                 Console.Write(chessboard[i, j] + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }



// ----------------------------------------------------------------------------------------------------------------------------------

// //Homework Task 3
///////////////////////             Randomly place queens on the chessboard so that they do not hit each other.
// class Program
// {
//     static Random random = new Random();

//     static void Main()
//     {
//         int boardSize = 8;
//         int[] queens = PlaceQueens(boardSize);

//         PrintChessboard(queens);
//     }

//     static int[] PlaceQueens(int boardSize)
//     {
//         int[] queens = new int[boardSize];

//         for (int i = 0; i < boardSize; i++)
//         {
//             queens[i] = random.Next(boardSize);
//         }

//         while (!IsValid(queens))
//         {
//             for (int i = 0; i < boardSize; i++)
//             {
//                 queens[i] = random.Next(boardSize);
//             }
//         }

//         return queens;
//     }

//     static bool IsValid(int[] queens)
//     {
//         for (int i = 0; i < queens.Length; i++)
//         {
//             for (int j = i + 1; j < queens.Length; j++)
//             {
//                 if (queens[i] == queens[j] || Math.Abs(queens[i] - queens[j]) == Math.Abs(i - j))
//                 {
//                     return false;
//                 }
//             }
//         }

//         return true;
//     }

//     static void PrintChessboard(int[] queens)
//     {
//         int boardSize = queens.Length;

//         for (int i = 0; i < boardSize; i++)
//         {
//             for (int j = 0; j < boardSize; j++)
//             {
//                 Console.Write(queens[i] == j ? "1 " : "0 ");
//             }
//             Console.WriteLine();
//         }
//     }
// }

// ----------------------------------------------------------------------------------------------------------------------------------

// //Hpmework Task 4
///////////////////////////      The horse (knight) will step from the mentioned field with random free fields once.

// class Program
// {
//     static Random random = new Random();

//     static void Main()
//     {
//         int boardSize = 8;
//         int[,] chessboard = new int[boardSize, boardSize];

//         int knightRow = 2;
//         int knightCol = 3;

//         chessboard[knightRow, knightCol] = 1;

//         var newPosition = PerformKnightMove(chessboard, knightRow, knightCol);
//         knightRow = newPosition.Item1;
//         knightCol = newPosition.Item2;

//         PrintChessboard(chessboard);
//     }

//     static Tuple<int, int> PerformKnightMove(int[,] chessboard, int row, int col)
//     {
//         int[] moveRow = { -2, -1, 1, 2, 2, 1, -1, -2 };
//         int[] moveCol = { 1, 2, 2, 1, -1, -2, -2, -1 };

//         var validMoves = GetValidMoves(chessboard, row, col, moveRow, moveCol);

//         if (validMoves.Count > 0)
//         {
//             var randomMove = validMoves[random.Next(validMoves.Count)];
//             var newRow = row + moveRow[randomMove];
//             var newCol = col + moveCol[randomMove];

//             chessboard[newRow, newCol] = 1;

//             return new Tuple<int, int>(newRow, newCol);
//         }

//         return new Tuple<int, int>(row, col);
//     }

//     static List<int> GetValidMoves(int[,] chessboard, int row, int col, int[] moveRow, int[] moveCol)
//     {
//         var validMoves = new List<int>();

//         for (int i = 0; i < 8; i++)
//         {
//             var newRow = row + moveRow[i];
//             var newCol = col + moveCol[i];

//             if (IsValidMove(chessboard, newRow, newCol))
//             {
//                 validMoves.Add(i);
//             }
//         }

//         return validMoves;
//     }

//     static bool IsValidMove(int[,] chessboard, int row, int col)
//     {
//         return row >= 0 && row < chessboard.GetLength(0) &&
//                col >= 0 && col < chessboard.GetLength(1) &&
//                chessboard[row, col] == 0;
//     }

//     static void PrintChessboard(int[,] chessboard)
//     {
//         for (int i = 0; i < chessboard.GetLength(0); i++)
//         {
//             for (int j = 0; j < chessboard.GetLength(1); j++)
//             {
//                 Console.Write(chessboard[i, j] + " ");
//             }
//             Console.WriteLine();
//         }
//     }
// }


// ----------------------------------------------------------------------------------------------------------------------------------


//Homework Task 5
                    /*Saddle point. Given an MxN integer size matrix.
                    Determine and find the matrix element that is largest in its row and smallest in its column.
                    If no such element exists, display the message "no".*/


// class SaddlePoint {

// 	static bool findSaddlePoint(int [,] mat, int n)
// 	{
		
// 		for (int i = 0; i < n; i++)
// 		{

// 			int min_row = mat[i, 0], col_ind = 0;
// 			for (int j = 1; j < n; j++)
// 			{
// 				if (min_row > mat[i, j])
// 				{
// 					min_row = mat[i, j];
// 					col_ind = j;
// 				}
// 			}

// 			int k;
// 			for (k = 0; k < n; k++)

// 				if (min_row < mat[k, col_ind])
// 					break;
	
// 			if (k == n)
// 			{
// 				Console.WriteLine("Value of Saddle Point is: " + min_row);
// 				return true;
// 			}
// 		}

// 		return false;
// 	}
	
// 	public static void Main() 
// 	{
// 		int [,] mat = {{1, 2, 3},
// 					   {4, 5, 6},
// 					   {7, 8, 9}};
		
// 		int n = 3;
// 		if (findSaddlePoint(mat, n) == false)
// 			Console.WriteLine("No Saddle Point ");
// 	}
// }


//----------------------------------------------------------------------------------------------------------------------------------


// // Homework Task 6
/////////////////////          Randomly fill non-repeating numbers in an NxM matrix.

// class RandomFill
// {
//     static void Main()
//     {
//         Console.Write("Enter the number of rows (N): ");
//         int n = int.Parse(Console.ReadLine());

//         Console.Write("Enter the number of columns (M): ");
//         int m = int.Parse(Console.ReadLine());

//         if (n <= 0 || m <= 0)
//         {
//             Console.WriteLine("Invalid matrix size. Please enter positive values for N and M.");
//             return;
//         }

//         int[,] matrix = new int[n, m];
//         List<int> availableNumbers = GenerateAvailableNumbers(n * m);

//         RandomlyFillMatrix(matrix, availableNumbers);

//         Console.WriteLine("Randomly filled matrix:");
//         PrintMatrix(matrix);
//     }

//     static List<int> GenerateAvailableNumbers(int count)
//     {
//         List<int> numbers = new List<int>();
//         for (int i = 1; i <= count; i++)
//         {
//             numbers.Add(i);
//         }
//         return numbers;
//     }

//     static void RandomlyFillMatrix(int[,] matrix, List<int> availableNumbers)
//     {
//         Random random = new Random();

//         for (int i = 0; i < matrix.GetLength(0); i++)
//         {
//             for (int j = 0; j < matrix.GetLength(1); j++)
//             {
//                 if (availableNumbers.Count == 0)
//                 {
//                     Console.WriteLine("Not enough unique numbers available.");
//                     return;
//                 }

//                 int randomIndex = random.Next(availableNumbers.Count);
//                 matrix[i, j] = availableNumbers[randomIndex];
//                 availableNumbers.RemoveAt(randomIndex);
//             }
//         }
//     }

//     static void PrintMatrix(int[,] matrix)
//     {
//         for (int i = 0; i < matrix.GetLength(0); i++)
//         {
//             for (int j = 0; j < matrix.GetLength(1); j++)
//             {
//                 Console.Write(matrix[i, j] + "\t");
//             }
//             Console.WriteLine();
//         }
//     }
// }


//----------------------------------------------------------------------------------------------------------------------------------

// // Homework Task 7
/* Queen placement in Matrix [8,8] with heuristic method. Place queens on a chessboard so that
they do not hit each other, using the heuristic of maximum free for queen fields. Display the current results
of the heuristic run.*/

// class Program
// {
//     static void Main()
//     {
//         char[,] matrix = new char[8, 8];
//         for (int i = 0; i < 8; i++)
//         {
//             for (int j = 0; j < 8; j++)
//             {
//                 matrix[i, j] = '1';
//             }
//         }

//         Console.WriteLine("Matrix 0:");
//         PrintMatrix(matrix);

//         int queenCount = 0; 
        
//         while (HasFP(matrix))
//         {
//             int randomX, randomY;
//             do
//             {
//                 Random random = new Random();
//                 randomX = random.Next(8);
//                 randomY = random.Next(8);
//             } while (matrix[randomX, randomY] != '1');

            
//             matrix[randomX, randomY] = '#';

            
//             MarkCells(matrix, randomX, randomY);

//             queenCount++;
//             Console.WriteLine($"Matrix {queenCount} ({randomX}, {randomY}):");
//             PrintMatrix(matrix);
//         }
//     }

//     static void PrintMatrix(char[,] matrix)
//     {
//         for (int i = 0; i < 8; i++)
//         {

//             for (int j = 0; j < 8; j++)
//             {
//                 Console.Write(matrix[i, j] + " ");
//             }
//             Console.WriteLine();
//         }
//         Console.WriteLine();
//     }

//     static void MarkCells(char[,] matrix, int queenX, int queenY)
//     {
    
//         for (int i = 0; i < 8; i++)
//         {
//             if (matrix[queenX, i] != '#') 
//                 matrix[queenX, i] = '0';

//             if (matrix[i, queenY] != '#')
//                 matrix[i, queenY] = '0';
//         }

        
//         for (int i = queenX - 1, j = queenY - 1; 
//         i >= 0 && j >= 0; i--, j--)
//         {
//             if (matrix[i, j] != '#') 
//                 matrix[i, j] = '0';
//         }
//         for (int i = queenX + 1, j = queenY + 1; 
//         i < 8 && j < 8; i++, j++)
//         {
//             if (matrix[i, j] != '#') 
//                 matrix[i, j] = '0';
//         }

        
//         for (int i = queenX - 1, j = queenY + 1;
//         i >= 0 && j < 8; i--, j++)
//         {
//             if (matrix[i, j] != '#')
//                 matrix[i, j] = '0';
//         }
//         for (int i = queenX + 1, j = queenY - 1;
//         i < 8 && j >= 0; i++, j--)
//         {
//             if (matrix[i, j] != '#')
//                 matrix[i, j] = '0';
//         }
//     }

//     static bool HasFP(char[,] matrix)
//     {
        
//         foreach (char cell in matrix)
//         {

//             if (cell == '1')
//                 return true;
//         }
//         return false;
//     }
// }

//----------------------------------------------------------------------------------------------------------------------------------

// // // Homework Task 8
/* Knight moving in Matrix [8,8] with heuristic method. Any next move of the knight in the free
field is selected by a special template with mninimum value. Template is the number of knight moves in the
initial chessboard. Display the current results of the heuristic run. Explanation in more detail in the
classroom.
*/


// class Program
// {
//     static int[] dx = { 2, 1, -1, -2, -2, -1, 1, 2 };
//     static int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

//     static void Main(string[] args)
//     {
//         int[,] chessboard = new int[8, 8];
//         int totalSteps = 0;

//         Console.WriteLine("Enter coordinates for the figure (x, y):");
//         int x = int.Parse(Console.ReadLine()) - 1;
//         int y = int.Parse(Console.ReadLine()) - 1;

//         if (x >= 0 && x < 8 && y >= 0 && y < 8)
//         {
//             FillChessboard(chessboard);

//             chessboard[x, y] = -1;

//             PrintChessboard(chessboard, x, y);

//             while (true)
//             {
//                 int minMoves = int.MaxValue;
//                 int newX = -1, newY = -1;
//                 for (int i = 0; i < 8; i++)
//                 {
//                     int nextX = x + dx[i];
//                     int nextY = y + dy[i];
//                     if (IsValidMove(nextX, nextY) && chessboard[nextX, nextY] > 0)
//                     {
//                         int moves = chessboard[nextX, nextY];
//                         if (moves < minMoves)
//                         {
//                             minMoves = moves;
//                             newX = nextX;
//                             newY = nextY;
//                         }
//                     }
//                 }

//                 if (newX == -1 && newY == -1)
//                     break;

//                 x = newX;
//                 y = newY;
//                 chessboard[x, y] = -1;
//                 totalSteps++;

//                 Console.WriteLine("\nThe knight has moved:");
//                 PrintChessboard(chessboard, x, y);
//             }

//             Console.WriteLine($"\nTotal steps is : {totalSteps + 1}");
//         }
//         else
//         {
//             Console.WriteLine("Coordinates are outside from the chessboard.");
//         }
//     }

//     static bool IsValidMove(int x, int y)
//     {
//         return x >= 0 && x < 8 && y >= 0 && y < 8;
//     }

//     static void FillChessboard(int[,] chessboard)
//     {
//         for (int i = 0; i < 8; i++)
//         {
//             for (int j = 0; j < 8; j++)
//             {
//                 chessboard[i, j] = CountPossibleMoves(i, j);
//             }
//         }
//     }

//     static int CountPossibleMoves(int x, int y)
//     {
//         int possibleMoves = 0;
//         for (int i = 0; i < 8; i++)
//         {
//             int newX = x + dx[i];
//             int newY = y + dy[i];
//             if (IsValidMove(newX, newY))
//                 possibleMoves++;
//         }

//         return possibleMoves;
//     }

//     static void PrintChessboard(int[,] chessboard, int knightX, int knightY)
//     {
//         for (int i = 0; i < 8; i++)
//         {
//             for (int j = 0; j < 8; j++)
//             {
//                 if (i == knightX && j == knightY)
//                 {
//                     Console.Write("  # ");
//                 }
//                 else
//                 {
//                     Console.Write(chessboard[i, j].ToString().PadLeft(3) + " ");
//                 }
//             }
//             Console.WriteLine();
//         }
//     }
// }





//----------------------------------------------------------------------------------------------------------------------------------




/* 
Task9. ax2 +bx +c=0. Solve the quadratic equation by methods and return x1, x2 . 
1.With ref parameters.
2. With Tuple 
3.With Array 
4.With Deconstructing in class.
*/

// class QarakusiHavasarum
// {
//     public static void Solve(double a, double b, double c, ref double x1, ref double x2)
//     {
//         double discriminant = b * b - 4 * a * c;

//         if (discriminant >= 0)
//         {
//             x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
//             x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
//         }
//         else
//         {
//             Console.WriteLine("No roots:");
//         }
//     }

//     static void Main()
//     {
//         double a = 1, b = -3, c = 2;
//         double x1 = 0, x2 = 0;

//         Solve(a, b, c, ref x1, ref x2);

//         Console.WriteLine($"Root 1: {x1}, Root 2: {x2}");
//     }
// }


//---------------------------


// class QarakusiHavasarum
// {
//     public static (double, double) Solve(double a, double b, double c)
//     {
//         double discriminant = b * b - 4 * a * c;

//         if (discriminant >= 0)
//         {
//             double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
//             double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
//             return (x1, x2);
//         }
//         else
//         {
//             Console.WriteLine("No roots:");
//             return (0, 0);
//         }
//     }

//     static void Main()
//     {
//         double a = 1, b = -3, c = 2;

//         var roots = Solve(a, b, c);

//         Console.WriteLine($"Root 1: {roots.Item1}, Root 2: {roots.Item2}");
//     }
// }

//-----------

// class QarakusiHavasarum
// {
//     public static double[] Solve(double a, double b, double c)
//     {
//         double[] roots = new double[2];
//         double discriminant = b * b - 4 * a * c;

//         if (discriminant >= 0)
//         {
//             roots[0] = (-b + Math.Sqrt(discriminant)) / (2 * a);
//             roots[1] = (-b - Math.Sqrt(discriminant)) / (2 * a);
//         }
//         else
//         {
//             Console.WriteLine("No roots: ");
//         }

//         return roots;
//     }

//     static void Main()
//     {
//         double a = 1, b = -3, c = 2;

//         double[] roots = Solve(a, b, c);

//         Console.WriteLine($"Root 1: {roots[0]}, Root 2: {roots[1]}");
//     }
// }
//---------


// using System;

// class QarakusiHavasarum
// {
//     public class Roots
//     {
//         public double X1 { get; }
//         public double X2 { get; }

//         public Roots(double x1, double x2)
//         {
//             X1 = x1;
//             X2 = x2;
//         }
//     }

//     public static Roots Solve(double a, double b, double c)
//     {
//         double discriminant = b * b - 4 * a * c;

//         if (discriminant >= 0)
//         {
//             double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
//             double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
//             return new Roots(x1, x2);
//         }
//         else
//         {
//             Console.WriteLine("No roots: ");
//             return new Roots(0, 0);
//         }
//     }

//     static void Main()
//     {
//         double a = 1, b = -3, c = 2;

//         var (root1, root2) = Solve(a, b, c);

//         Console.WriteLine($"Root 1: {root1}, Root 2: {root2}");
//     }
// }
