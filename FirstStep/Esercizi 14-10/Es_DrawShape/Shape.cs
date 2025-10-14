using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_14_10.Es_DrawShape
{
	public interface IShape
	{
		public void Draw();
	}

	public abstract class Shape : IShape
	{
		public abstract void Draw();
	}

	public class Circle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine(" __ ");
			Console.WriteLine("/  \\");
			Console.WriteLine("\\__/");
		}
	}

	public class Square : Shape
	{
		public override void Draw()
		{
			Console.WriteLine(" __ ");
			Console.WriteLine("|__|");
		}
	}

	public interface IShapeFactory
	{
		public IShape CreateShape(string type);
	}

	public class ShapeFactory : IShapeFactory
	{
		public IShape CreateShape(string type)
		{
			IShape shape = null;
			switch(type)
			{
				case "quadrato":
					shape = new Square();
					break;
				case "cerchio":
					shape = new Circle();
					break;
			}
			return shape;
		}
	}
}
