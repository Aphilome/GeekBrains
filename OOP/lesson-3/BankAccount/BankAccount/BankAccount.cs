namespace BankAccount
{
	public class BankAccount
	{
		private static ulong _nextAccountNumber = 1;
		
		public ulong AccountNumber { get; }
		
		public decimal Balance { get; private set; }
		
		public BankAccountTypeEnum BankAccountType { get; }

		#region Constructors
		
		public BankAccount()
		{
			AccountNumber = _nextAccountNumber;
			IncreaseAccountNumber();
		}
		
		public BankAccount(int balance) : this(balance,
			BankAccountTypeEnum.BudgetAccount)
		{
		}
		
		public BankAccount(BankAccountTypeEnum type) : this(0, type)
		{
		}

		public BankAccount(int balance, BankAccountTypeEnum type) : this()
		{
			Balance = balance;
			BankAccountType = type;
		}
		
		#endregion

		/// <summary>
		/// Попытаться снять указанное количество денег
		/// </summary>
		/// <param name="neededSum">сколько попытаться снять</param>
		/// <returns>реальное количество денег, которое удалось снять</returns>
		public decimal Withdraw(decimal neededSum)
		{
			if (neededSum < 0 || neededSum > Balance)
				return Balance;
			Balance -= neededSum;
			return neededSum;
		}

		/// <summary>
		/// Увеличить баланс на уазанную сумму, в случае перепонения случится exception
		/// </summary>
		/// <param name="putMoney">деньги, которые кладем на счет</param>
		public void ToDeposit(decimal putMoney)
		{
			Balance += putMoney;
		}
		
		public bool MoneyTransactionToDeposit(BankAccount fromBankAccount, decimal sum)
		{
			decimal resSum = fromBankAccount.Withdraw(sum);
			if (resSum != sum)
			{
				fromBankAccount.ToDeposit(resSum);
				return false;
			}
			this.ToDeposit(sum);
			return true;
		}

		public override string ToString() => $"Account number: {AccountNumber},\nbalance: {Balance},\naccount type: {BankAccountType}";

		private static void IncreaseAccountNumber()
		{
			_nextAccountNumber++;
		}
	}
}
