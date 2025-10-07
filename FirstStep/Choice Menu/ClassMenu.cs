using FirstStep._06_10;
using FirstStep._07_10;
using FirstStep.Collections_Practice;
using FirstStep.Methods_Practice;
using FirstStep.While_Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep
{
	internal class ClassMenu
	{
		private int sanitizedInput;

		private IChoiceMenu[] categories;

		public static bool ReturnWithoutDialogue = false;

		public ClassMenu()
		{
			categories = new IChoiceMenu[] { new ConditionalsPractice(), new SwitchPractice(), new WhilePractice(), new ForPractice(), new MethodsPracticeMenu(), new CollectionsPracticeMenu(), new MatrixPracticeMenu(), new GelateriaDolceGelo(), new PracticeOOP(), new PracticeOverride()};

		}

		public void OptionsMenu()
		{
			while (true)
			{
				Console.WriteLine("Scegli un opzione");
				Console.WriteLine("ENTER - Chiudi il programma");


				for (int i = 0; i < categories.Length; i++)
				{
					Console.WriteLine($"{i + 1} - {categories[i].Name}");
				}

				Program.SanitizeInput(out sanitizedInput);

				if (sanitizedInput == 0)
				{
					Console.Clear();
					return;
				}

				sanitizedInput--;


				if (sanitizedInput > categories.Length - 1 || sanitizedInput < 0)
				{
					Console.WriteLine("Esercizio non riconosciuto");
					continue;
				}

				Console.Clear();
				categories[sanitizedInput].OptionsMenu();

				if(ReturnWithoutDialogue)
				{
					Console.Clear();
					ReturnWithoutDialogue = false;
					continue;
				}
				Console.WriteLine("Premi qualsiasi tasto per tornare al menu");
				Console.ReadKey(true);
				Console.Clear();

			}

		}
	}
}
