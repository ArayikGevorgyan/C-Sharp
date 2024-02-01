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
