using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10.Esercizi_Semplici
{
	public class DataExporterApp : IExecutable
	{
		public void Run()
		{
			DataExporter myExporter = new DataExporter();
			byte[] fileToExport = new byte[8];

			myExporter.Export(fileToExport, ExportContext.GetStrategy("xml"));

			myExporter.Export(fileToExport, ExportContext.GetStrategy("json"));
		}
	}

	public class DataExporter
	{
		public void Export(byte[] originalFile, IExportStrategy exportStrategy)
		{
			exportStrategy.Export(originalFile);
		}
	}

	public interface IExportStrategy
	{
		public void Export(byte[] file);
	}

	public class JsonExporter : IExportStrategy
	{
		public void Export(byte[] file)
		{
			Console.WriteLine("Esportando il tuo file a json...");
		}
	}

	public class XMLExporter : IExportStrategy
	{
		public void Export(byte[] file)
		{
			Console.WriteLine("Esportando il tuo file a xml...");
		}
	}

	public class FileExporter : IExportStrategy
	{
		public void Export(byte[] file)
		{
			Console.WriteLine("Esportando il tuo file in raw file...");
		}
	}

	public static class ExportContext
	{
		public static IExportStrategy GetStrategy(string fileExtension)
		{
			if(fileExtension.Contains("xml"))
			{
				return new XMLExporter();
			}

			if(fileExtension.Contains("json"))
			{
				return new JsonExporter();
			}

			return new FileExporter();
		}
	}
}
