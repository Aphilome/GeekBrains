namespace BankAccount
{
	public class BankAccount
	{
		private static int _nextAccountNumber = 1;
		
		
		public int AccountNumber { get; }
		
		public int Balance { get; private set; }
		
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
		public int Withdraw(int neededSum)
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
		public void ToDeposit(uint putMoney)
		{
			checked
			{
				Balance += (int)putMoney;	
			}
		}
		
		private static void IncreaseAccountNumber()
		{
			_nextAccountNumber++;
		}
	}
}
