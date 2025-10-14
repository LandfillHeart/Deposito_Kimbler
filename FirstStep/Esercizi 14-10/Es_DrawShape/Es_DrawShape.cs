using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_14_10.Es_DrawShape
{
	public class Es_DrawShape : IGenericExercise
	{
		string IGenericExercise.Name => "Disegna Forma";
		public void Execute()
		{
			IShapeFactory factory = new ShapeFactory();
			Console.WriteLine("Quale forma vuoi disegnare? quadrato/cerchio");
			Program.SanitizeInput(out string sanitizedInput);

			IShape shape = factory.CreateShape(sanitizedInput);
			shape.Draw();
		}
	}
}
