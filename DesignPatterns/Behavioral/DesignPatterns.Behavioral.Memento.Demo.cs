using static System.Console;

namespace DesignPatterns.Behavioral.Memento.Demo
{
    public class Memento
    {
        public int Balance { get; set; }
		public Memento(int balance)
        {
            Balance = balance;
        }
    }

	public class BankAccount
    {
        public int Balance { get; set; }
        public BankAccount(int balance) {
            Balance = balance;
        }

		public Memento Deposit(int value)
        {
            this.Balance += value;
            return new Memento(Balance);
        }
		public void Restore(Memento m)
        {
            this.Balance = m.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}: {Balance}";
        }
    }
    class MementoDemo
    {
        static void Main1(string[] args)
        {
            var ba = new BankAccount(100);
            var m1 = ba.Deposit(50); // 150
            var m2 = ba.Deposit(25); // 175
            WriteLine(ba);

            // restore to m1
            ba.Restore(m1);
            WriteLine(ba);

            ba.Restore(m2);
            WriteLine(ba);
        }
    }
}
