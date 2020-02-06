using System.Collections.Generic;
using static System.Console;

namespace DesignPatterns.Behavioral.Memento.UndoRedo
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
        private List<Memento> changes = new List<Memento>();
        private int current = 0;
        public int Balance { get; set; }
        public BankAccount(int balance)
        {
            Balance = balance;
            changes.Add(new Memento(balance));
        }

        public Memento Deposit(int value)
        {
            this.Balance += value;
            var m = new Memento(Balance);
            changes.Add(m);
            current++;
            return m;
        }
        public void Restore(Memento m)
        {
            if (m != null)
            {
                this.Balance = m.Balance;
                changes.Add(m);
                current = changes.Count - 1;
            }
            
        }

        public Memento Undo()
        {
            if (current > 0)
            {
                var m = changes[--current];
                Balance = m.Balance;
                return m;
            }
            return null;
        }

        public Memento Redo()
        {
            if (current < changes.Count - 1)
            {
                var m = changes[++current];
                Balance = m.Balance;
                return m;
            }
            return null;
        }

        public override string ToString()
        {
            return $"{nameof(Balance)}: {Balance}";
        }
    }
    class UndoRedoDemo
    {
        static void Main3(string[] args)
        {
            var ba = new BankAccount(100);
            ba.Deposit(50);
            ba.Deposit(25);
            WriteLine(ba);

            ba.Undo();
            WriteLine($"Undo 1: {ba}");
            ba.Undo();
            WriteLine($"Undo 2: {ba}");
            ba.Redo();
            WriteLine($"Redo 2: {ba}");
        }
    }
}
