using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_21_10
{
	public class FileUploader
	{
		// private get: non vogliamo dare accesso dall'esterno a StorageService, visto che potrebbero provare a leggere da un componente null
		// piuttosto, creiamo metodi di accesso alle proprietà di StorageService (come RetrieveFile)
		public IStorageService StorageService { private get; set; }
		public FileUploader() {  }

		public void UploadFile(string file)
		{
			if(StorageService == null)
			{
				Console.WriteLine("Non hai accesso al salvataggio dei file!");
				return;
			}

			StorageService.Store(file);
		}

		public string RetrieveFile()
		{
			if(StorageService == null)
			{
				return "Error: Nessun accesso a lettura dei file";
			}
			return StorageService.File;
		}
	}

	public class FileUploaderApp : IExecutable
	{
		public void Run()
		{
			FileUploader myUploader = new FileUploader();
			myUploader.UploadFile("C:/unaImmagine.png");
			Console.WriteLine(myUploader.RetrieveFile());

			myUploader.StorageService = new DiskStorage();
			myUploader.UploadFile("C:/unoScript.cs");
			Console.WriteLine(myUploader.RetrieveFile());

			myUploader.StorageService = new RAM_Storage();
			myUploader.UploadFile("C:/unaList.json");
			Console.WriteLine(myUploader.RetrieveFile());
			
			RAM_Storage storage = new RAM_Storage();
			Console.WriteLine($"File in RAM: {storage.File}");
		}
	}

	public interface IStorageService
	{
		public string File { get; }
		public void Store(string image);
	}

	public class DiskStorage : IStorageService
	{
		public string File { get; private set; }
		public void Store(string file)
		{
			File = file;
		}
	}

	public class RAM_Storage : IStorageService
	{
		private static string storedFile;
		public string File => storedFile;
		public void Store(string file)
		{
			storedFile = file;
		}
	}
}
