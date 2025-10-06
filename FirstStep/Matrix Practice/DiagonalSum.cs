using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Matrix_Practice
{
	internal class DiagonalSum : IGenericExercise
	{
		const int ROWS = 5;
		const int COLUMNS = 5;

		string IGenericExercise.Name => "Somma delle diagonali";
		private Random rng = new Random();
		int[,] matrix = new int[ROWS, COLUMNS];
		public void Execute()
		{
			GenerateMatrix(matrix);
			PrintMatrix(matrix);

			int diagOne = SumDiagonalLeft();
			int diagTwo = SumDiagonalRight();

			Console.WriteLine($"Somma diagonale sinistra->destra: {diagOne}");
			Console.WriteLine($"Somma diagonale destra->sinistra: {diagTwo}");
			if (diagOne == diagTwo) { Console.WriteLine("Le diagonali hanno la stessa somma!"); return; }
			Console.WriteLine("La diagonale con la somma maggiore è: " + (diagOne > diagTwo ? "sinistra->destra" : "destra->sinistra"));
		}

		private void GenerateMatrix(int[,] matrix)
		{
			for (int row = 0; row < ROWS; row++)
			{
				for (int col = 0; col < COLUMNS; col++)
				{
					matrix[row, col] = rng.Next(1, 21);
				}
			}
		}

		private void PrintMatrix(int[,] matrix)
		{
			/*
			|1|2|3|4 |1.1|2.1|3.1|4.1|
			*/

			for (int row = 0; row < ROWS; row++)
			{
				for (int col = 0; col < COLUMNS; col++)
				{
					Console.Write('|');
					Console.Write(matrix[row, col]);
				}
				Console.WriteLine();
			}

			Console.WriteLine();
		}

		private int SumDiagonalLeft()
		{
			int sum = 0;

			for(int i = 0; i < COLUMNS; i++)
			{
				sum += matrix[i, i];
			}

			return sum;
		}

		private int SumDiagonalRight()
		{
			int sum = 0;

			for(int i = COLUMNS -1; i >= 0; i--)
			{
				sum += matrix[COLUMNS - 1 - i, i];
			}

			return sum;
		}

	}

}

