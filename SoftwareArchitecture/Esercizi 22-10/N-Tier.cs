using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_22_10
{
	// Tier separati: Presentation -> Service -> Repository (dati).
	using System;
	using System.Collections.Generic;

	interface IProdottoRepository { IEnumerable<string> All(); void Add(string nome); }
	class ProdottoRepositoryMem : IProdottoRepository
	{
		private readonly List<string> _db = new() { "Pane", "Latte" };
		public IEnumerable<string> All() => _db;
		public void Add(string nome) => _db.Add(nome);
	}

	class ProdottoService
	{
		private readonly IProdottoRepository _repo;
		public ProdottoService(IProdottoRepository repo) => _repo = repo;

		public IEnumerable<string> Elenca() => _repo.All();
		public void Crea(string nome)
		{
			if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome vuoto");
			_repo.Add(nome);
		}
	}

	class ConsoleUI
	{
		private readonly ProdottoService _svc;
		public ConsoleUI(ProdottoService svc) => _svc = svc;

		public void Run()
		{
			foreach (var p in _svc.Elenca()) Console.WriteLine($"- {p}");
			_svc.Crea("Uova");
		}
	}

}
