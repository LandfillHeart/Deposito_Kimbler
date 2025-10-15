using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstStep.Esercizi_15_10.Es_News_Agency
{
	public interface INewsSubscriber
	{
		public ClientType Type { get; }
		public void Update(string msg);
	}

	public enum ClientType
	{
		Mobile,
		Email
	}
}
