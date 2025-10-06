using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Matrix_Practice
{
	internal class SumOfMatrixContent : IGenericExercise
	{
		string IGenericExercise.Name => "Somma di tutto, righe, e colonne";
		private int[,] matrix;
		private int sanitizedInput;

		public void Execute()
		{
			Console.WriteLine("Inserire numero righe");
			Program.SanitizeInput(out sanitizedInput);
			int rows = sanitizedInput;

			Console.WriteLine("Inserire numero colonne");
			Program.SanitizeInput(out sanitizedInput);
			int columns = sanitizedInput;

			matrix = new int[rows, columns];

			SetMatrix();

			int total = 0;
			int cache = 0;
			for (int i = 0; i < rows; i++) 
			{
				cache = SumRow(i);
				total += cache;
				Console.WriteLine($"Somma Riga {i}: {cache}");
			}

			for (int i = 0; i < rows; i++)
			{
				cache = SumColumn(i);
				total += cache;
				Console.WriteLine($"Somma Colonna {i}: {cache}");
			}

			Console.WriteLine($"Somma di tutta la matrice {total}");
			
		}

		private void SetMatrix()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					Console.WriteLine($"Riga: {row} Colonna: {col}");
					Program.SanitizeInput(out sanitizedInput);
					matrix[row, col] = sanitizedInput;
				}
			}
		}

		private int SumColumn(int col) 
		{
			int sum = 0;
			for(int row = 0; row < matrix.GetLength(0); row++)
			{
				sum += matrix[row, col];
			}

			return sum;
		}

		private int SumRow(int row)
		{
			int sum = 0;
			for(int col = 0; col < matrix.GetLength(1); col++)
			{
				sum += matrix[row, col];
			}

			return sum;
		}

	}
}
