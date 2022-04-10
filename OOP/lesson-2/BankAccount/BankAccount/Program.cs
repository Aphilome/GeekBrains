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


			Console.WriteLine(
				$"Account number: {nikolayAccount.AccountNumber}, " +
				$"balance: {nikolayAccount.Balance}, " +
				$"account type: {nikolayAccount.BankAccountType}");
			
			Console.WriteLine(
							$"Account number: {kateAccount.AccountNumber}, " +
							$"balance: {kateAccount.Balance}, " +
							$"account type: {kateAccount.BankAccountType}");
		}
	}
}
