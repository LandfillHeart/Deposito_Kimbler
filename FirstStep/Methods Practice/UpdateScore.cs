using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Methods_Practice
{
	internal class UpdateScore : IGenericExercise
	{
		string IGenericExercise.Name => "Aggiorna Punteggio";

		int sanitizedInput;
		int totScore = 0;
		float averageScore = 0;

		public void Execute()
		{
			Console.WriteLine("PS: dai 100 punti in poi, ricevi un bonus 2x");

			totScore = 0;
			averageScore = 0;

			for(int i = 1; i <= 3; i++)
			{
				Console.WriteLine($"Inserisci il punteggio del round {i}");
				Program.SanitizeInput(out sanitizedInput, mustBePositive: true);

				CalculateScore(ref sanitizedInput, sanitizedInput >= 100 ? 2 : 1, currentRound: i, ref totScore, out averageScore);
			}

			Console.WriteLine($"Punteggio finale: {totScore}");
			Console.WriteLine($"Punteggio medio: {averageScore}");

		}

		private void CalculateScore(ref int roundScore, int bonus, int currentRound, ref int totalScore, out float averageScore)
		{
			roundScore *= bonus;
			totalScore += roundScore * bonus;
			averageScore = totalScore / currentRound;
		}

	}
}
