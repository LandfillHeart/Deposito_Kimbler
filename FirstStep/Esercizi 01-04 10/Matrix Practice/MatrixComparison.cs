using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Matrix_Practice
{
	internal class MatrixComparison : IGenericExercise
	{
		const int ROWS = 4;
		const int COLUMNS = 4;
		string IGenericExercise.Name => "Confronto Matrici";

		private Random rng = new Random();

		int[,] matrixOne = new int[ROWS, COLUMNS];
		int[,] matrixTwo = new int[ROWS, COLUMNS];

		public void Execute()
		{
			GenerateMatrix(matrixOne);
			GenerateMatrix(matrixTwo);

			int[][,] matrices = [matrixOne, matrixTwo];
			PrintMatrices(matrices);

			int mOneWins = 0;
			int mTwoWins = 0;
			int mTies = 0;
			for (int i = 0; i < ROWS; i++)
			{
				int mOneSum = SumRow(matrixOne, i);
				int mTwoSum = SumRow(matrixTwo, i);

				if(mOneSum == mTwoSum)
				{
					mTies++;
					continue;
				} 

				if(mOneSum > mTwoSum)
				{
					mOneWins++;
					continue;
				}

				mTwoWins++;
			}

			Console.WriteLine($"Le matrici hanno pareggiato {mTies} volte");
			Console.WriteLine($"La matrice UNO ha vinto {mOneWins} volte");
			Console.WriteLine($"La matrice DUE ha vinto {mTwoWins} volte");


		}

		private void GenerateMatrix(int[,] matrix)
		{
			for (int row = 0; row < ROWS; row++) 
			{
				for (int col = 0; col < COLUMNS; col++)
				{
					matrix[row, col] = rng.Next(1, 51);
				}
			}
		}

		private void PrintMatrices(int[][,] matrixes)
		{
			/*
			|1|2|3|4 |1.1|2.1|3.1|4.1|
			*/

			for (int row = 0; row < ROWS; row++)
			{
				for(int m = 0; m < matrixes.Length; m++)
				{
					for (int col = 0; col < COLUMNS; col++)
					{
						Console.Write('|');
						Console.Write(matrixes[m][row, col]);
					}
					Console.Write('|');
					Console.Write("    ");
				}
				
				Console.WriteLine();
			}
		}

		private int SumRow(int[,] matrix, int row)
		{
			int sum = 0;
			for (int col = 0; col < matrix.GetLength(1); col++)
			{
				sum += matrix[row, col];
			}

			return sum;
		}
			
	}
}

