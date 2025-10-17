using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_17_10
{
	public class UserManager
	{
		#region Singleton
		private static UserManager instance;
		public static UserManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new UserManager();
				}
				return instance;
			}
		}

		private UserManager() { }
		#endregion

		#region Factory
		private int nextIdKey = 1;

		private User CreateNewUser(string name, string email)
		{
			return new User(name, email, GenerateID(email));
		}

		private ActionLog CreateNewLog(LogType type)
		{
			return type switch
			{
				LogType.LogIn => new ActionLog(type, "Utente ha fatto Log-In", DateTime.Now),
				LogType.LogOut => new ActionLog(type, "Utente ha fatto Log-Out", DateTime.Now),
				LogType.View => new ActionLog(type, "Account utente visionato", DateTime.Now),
				LogType.Create => new ActionLog(type, "Account creato", DateTime.Now),
				LogType.Delete => new ActionLog(type, "Account eliminato", DateTime.Now),
				LogType.Update => new ActionLog(type, "Account modificato", DateTime.Now)
			};
		}

		private int GenerateID(string email)
		{
			return HashCode.Combine(email);
		}
		#endregion

		private Dictionary<int, User> existingUsers = new Dictionary<int, User>();
		private Dictionary<int, List<ActionLog>> actionsByUsers = new Dictionary<int, List<ActionLog>>();

		#region CRUD
		public void AddUser(string name, string email)
		{
			if(existingUsers.ContainsKey(GenerateID(email)))
			{
				Console.WriteLine("Questa email è già registrata! Prova a fare il login");
				return;
			}
			int newId = GenerateID(email);
			existingUsers.Add(newId, CreateNewUser(name, email));
			if(!actionsByUsers.ContainsKey(newId))
			{
				actionsByUsers.Add(newId, new List<ActionLog>());
			}
			actionsByUsers[newId].Add(CreateNewLog(LogType.Create));
		}

		public void RemoveUser(int ID)
		{
			existingUsers.Remove(ID);
			actionsByUsers[ID].Add(CreateNewLog(LogType.Delete));
		}
		#endregion

		#region User Actions
		public void LogIn(int ID)
		{
			if (!existingUsers.ContainsKey(ID))
			{
				Console.WriteLine("Sembra che hai inserito un utente che non esiste!");
			}

			if (existingUsers[ID].IsActive)
			{
				Console.WriteLine("Impossibile fare il login, utente già online");
				return;
			}

			Console.WriteLine($"Bentornato, {existingUsers[ID].Name}");
			actionsByUsers[ID].Add(CreateNewLog(LogType.LogIn));
		}

		public void LogOut(int ID)
		{
			if(!existingUsers.ContainsKey(ID))
			{
				Console.WriteLine("Sembra che hai inserito un utente che non esiste!");
			}

			if(!existingUsers[ID].IsActive)
			{
				Console.WriteLine("Impossibile fare il logout, utente non online");
				return;
			}

			Console.WriteLine($"Arrivederci, {existingUsers[ID].Name}");
			actionsByUsers[ID].Add(CreateNewLog(LogType.LogIn));
		}

		public void ViewUser(int ID)
		{
			Console.WriteLine($"Benvenuto alla pagina di: {existingUsers[ID].Name} email: {existingUsers[ID].Email}");
			actionsByUsers[ID].Add(CreateNewLog(LogType.View));
		}

		public List<User> GetAllUsers()
		{
			return existingUsers.Values.ToList();
		}

		public List<ActionLog> ViewLogsByUser(int ID)
		{
			return actionsByUsers[ID];
		}
		#endregion

	}

	public class User
	{
		public readonly int ID;

		public string Name { get; private set; }
		public string Email { get; private set; }
		public bool IsActive { get; private set; }
		public DateTime CreatedAt { get; private set; }

		public User(string name, string email, int ID)
		{
			Name = name;
			Email = email;
			this.ID = ID;
			CreatedAt = DateTime.Now;
		}
	}

	public struct ActionLog
	{
		public readonly DateTime TimeStamp;
		public readonly LogType Type;
		public readonly string MetaData;
		public ActionLog(LogType type, string metaData, DateTime timeStamp)
		{
			TimeStamp = timeStamp;
			Type = type;
			MetaData = metaData;
		}
	}

	public enum LogType
	{
		LogIn,
		LogOut,
		View,
		Create,
		Update,
		Delete
	}
}
