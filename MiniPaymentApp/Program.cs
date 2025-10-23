using static Program;

public class Program
{
	public delegate void PaymentCompleteHandler(string id, float total);

	public static void Main()
	{
		// choose payment type
		Console.WriteLine("Inserisci un tipo di pagamento: paypall/carta/bonifico");
		string choice = Console.ReadLine();
		PaymentType chosenPaymentType = 0;
		
		choice = choice.ToLower();
		if ("paypal".Contains(choice)) chosenPaymentType = PaymentType.PayPal;
		if ("carta".Contains(choice)) chosenPaymentType = PaymentType.Card;
		if ("bonifico".Contains(choice)) chosenPaymentType = PaymentType.Transfer;


		// insert amount
		Console.WriteLine("Inserisci l'importo da pagare: ");
		string inputAmount = Console.ReadLine();
		float amount = float.Parse(inputAmount);
		// apply a discount
		IDiscountPolicy discountPolicy = null;
		if(Random.Shared.Next(0, 10) >= 5)
		{
			discountPolicy = new SimpleDiscount(Random.Shared.Next(10, 50));
		}

		// Pay() -> invoke event
		PaymentService paymentService = new PaymentService(PaymentFactory.CreatePayment(chosenPaymentType), new ConsoleLog(), discountPolicy);
		paymentService.Pay(amount);
	}
}

public class PaymentService
{
	public event Action<string, float> OnPaymentCompleted;

	private IPayment payment;
	private ILogger logger;
	private IDiscountPolicy? discount;

	public PaymentService(IPayment payment, ILogger logger, IDiscountPolicy? discount = null)
	{
		this.payment = payment;
		this.logger = logger;
		this.discount = discount;
		OnPaymentCompleted += logger.Log;
	}

	public void Pay(float amount)
	{
		if (discount != null)
		{
			amount = discount.DiscountedCost(amount);
			Console.WriteLine($"Applicato uno sconto del: {discount.Discount}");
		}

		OnPaymentCompleted?.Invoke(payment.PaymentType.ToString(), amount);
	}
}

public enum PaymentType
{
	PayPal,
	Card,
	Transfer
}

public interface IPayment
{
	public PaymentType PaymentType { get; }
}

public interface ILogger
{
	public void Log(string id, float amount);
}

public interface IDiscountPolicy
{
	public float Discount { get; }
	public float DiscountedCost(float originalAmount);
}

public static class PaymentFactory
{
	public static IPayment CreatePayment(PaymentType type)
	{
		return new SimplePayment(type);
	}
}

public class SimplePayment : IPayment
{
	public PaymentType PaymentType { get; private set; }
	public SimplePayment(PaymentType paymentType)
	{
		this.PaymentType = paymentType;
	}
}

public class ConsoleLog : ILogger
{
	public void Log(string id, float amount)
	{
		Console.WriteLine($"Messaggio di Console: {id} - {amount}");
	}
}

public class EmailLog : ILogger 
{
	public void Log(string id, float amount)
	{
		Console.WriteLine($"Nuova Email: {id} - {amount}");	
	}
}

public class SimpleDiscount : IDiscountPolicy
{
	public float Discount { get; private set; }
	public float DiscountedCost(float originalAmount)
	{
		return originalAmount - ((originalAmount * Discount) / 100);
	}

	public SimpleDiscount(float discount)
	{
		Discount = discount;
	}
}