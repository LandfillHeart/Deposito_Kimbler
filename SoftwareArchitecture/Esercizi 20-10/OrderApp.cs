using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareArchitecture.Esercizi_20_10
{
	public class OrderApp
	{
	}

	public interface IAppConfig
	{
		public string AppName { get; }
		public string Currency { get; }
		public float Tax { get; }
	}

	public class OrderAppContext : IAppConfig
	{
		#region Singleton
		private static OrderAppContext instance;
		public static OrderAppContext Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new OrderAppContext();
				}
				return instance;
			}
		}
		private OrderAppContext() 
		{
			AppName = "App di Ordini di Ray!";
			Currency = "€";
			Tax = 22f;
		}
		#endregion
	
		public string AppName { get; private set; }
		public string Currency { get; private set; }
		public float Tax { get; private set; }
	}

	public interface ILogger
	{
		public void PrintMessage(string msg);
	}

	public class LoggerService : ILogger
	{
		#region Dependency Injection
		private IAppConfig config;

		// depending on how we want to build our service, we can override the app context with specific configs
		public LoggerService()
		{
			config = OrderAppContext.Instance;
		}
		
		public LoggerService(IAppConfig config)
		{
			this.config = config;
		}
		#endregion
		public void PrintMessage(string msg) 
		{
			Console.WriteLine($"Notifica da {config.AppName}: {msg}");
		}
	}

	public class OrderService
	{
		private List<string> ordersStatus = new List<string>();
		#region Dependency Injection
		private ILogger logger;
		public OrderService(ILogger logger, List<string> orders)
		{
			this.logger = logger;
			this.ordersStatus = orders;
		}
		#endregion

		public void GetOrderStatus()
		{
			foreach (string order in ordersStatus)
			{
				logger.PrintMessage(order);
			}
		}
	}

	#region Decorator 
	public abstract class ContextDecorator : IAppConfig
	{
		protected IAppConfig configComponent;
		public virtual string AppName => configComponent.AppName;

		public virtual string Currency => configComponent.Currency;

		public virtual float Tax => configComponent.Tax;

		public ContextDecorator(IAppConfig configComponent)
		{
			this.configComponent = configComponent;
		}
	}

	public class BetaContext : ContextDecorator
	{
		public override string AppName => $"{base.AppName} Versione Beta";
		public BetaContext(IAppConfig configComponent) : base(configComponent)
		{
		}
	}
	#endregion
}
