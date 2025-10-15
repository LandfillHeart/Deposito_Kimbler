using FirstStep._06_10;
using FirstStep._07_10;
using FirstStep._08_10;
using FirstStep._08_10.Esercizio_Officina;
using FirstStep._08_10.Esercizio_Soldato;
using FirstStep._09_10.Esercizio_Operatore;
using FirstStep.Choice_Menu;
using FirstStep.Collections_Practice;
using FirstStep.Esercizi_10_10.Es_Dispositivo_Elettronico;
using FirstStep.Esercizi_10_10.Es_Ente_Formativo;
using FirstStep.Esercizi_10_10.Es_Pagamento;
using FirstStep.Esercizi_13_10_Design_Pattern.Es_Singleton;
using FirstStep.Esercizi_14_10.Es_ConfigManager;
using FirstStep.Esercizi_15_10.Es_Bakery;
using FirstStep.Esercizi_15_10.Es_Bar;
using FirstStep.Esercizi_15_10.Es_News_Agency;
using FirstStep.Esercizi_15_10.Es_Observer_Display;
using FirstStep.Esercizi_15_10.Es_User_Manager;
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
			categories =
				new IChoiceMenu[] { 
				// classi commentate per ridurre dimensione del menu iniziale
				// considerata l'architettura con interfaccia IGenericExercise, questi esercizi sono ancora accessibili tramite ChoiceMenu, ma ora è preferibile usare ExerciseCollection come oggetto generico, piuttosto di creare una classe unica per ogni collezione
				// new ConditionalsPractice(), new SwitchPractice(), new WhilePractice(), new ForPractice(), new MethodsPracticeMenu(), new CollectionsPracticeMenu(), new MatrixPracticeMenu(), new GelateriaDolceGelo(), new PracticeOOP(), new PracticeOverride(),
				new ExerciseCollection(header: "Esercizi 08 Ottobre", new IGenericExercise[]{
					new Es_VoloAereo(),
					new Es_Soldato(),
					new Es_Officina(),
				}),
				new ExerciseCollection(header: "Esercizi 09 Ottobre", new IGenericExercise[]{
					new Es_Operatore()
				}),
				new ExerciseCollection(header: "Esercizi 10 Ottobre", new IGenericExercise[]{
					new Es_DispositivoElettronico(),
					new Es_Pagamento(),
					new Es_EnteFormativo(),
				}),
				new ExerciseCollection(header: "Esercizi 13 Ottobre - Design Pattern", new IGenericExercise[] {
					new Es_LogSingleton(),
					new Es_LogHistory()
				}),
				new ExerciseCollection(header: "Esercizi 14 Ottobre - Design Pattern", new IGenericExercise[] {
					new Es_ConfigurazioneSistema()
				}),
				new ExerciseCollection(header: "Esercizi 15 Ottobre - Observer", new IGenericExercise[]
				{
					new Es_ObserverDisplay(),
					new NewsAgencyPortal(),
					new UserCreationApp(),
					new BarApp(),
					new CakeApp(),
				})
			};

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

