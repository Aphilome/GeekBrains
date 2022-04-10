using System;

namespace BankAccount
{
	class Program
	{
		static void Main(string[] args)
		{
			var nikolayAccount = new BankAccount(100);
			var kateAccount = new BankAccount(0, BankAccountTypeEnum.CorrespondentAccount);

			nikolayAccount.ToDeposit(1);
			
			Console.WriteLine(nikolayAccount);
			Console.WriteLine(kateAccount);

			kateAccount.MoneyTransactionToDeposit(nikolayAccount, 101);

			Console.WriteLine(nikolayAccount);
			Console.WriteLine(kateAccount);
		}
	}
}
