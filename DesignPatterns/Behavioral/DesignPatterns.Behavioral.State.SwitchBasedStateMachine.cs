using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.State.SwitchBasedStateMachine
{
    public enum State
    {
        Locked,
        Failed,
        Unlocked
    }
    class SwitchBasedStateMachine
    {
        static void Main123(string[] args)
        {
            string code = "1234";
            var state = State.Locked;
            var entry = new StringBuilder();
            while (true)
            {
                switch (state)
                {
                    case State.Locked:
                        entry.Append(Console.ReadKey().KeyChar);
                        if (entry.ToString() == code)
                        {
                            state = State.Unlocked;
                            break;
                        }
                        if (!code.StartsWith(entry.ToString()))
                        {
                            state = State.Failed;
                        }
                        break;
                    case State.Failed:
                        Console.CursorLeft = 0;
                        Console.WriteLine("FAILED");
                        entry.Clear();
                        state = State.Locked;
                        break;
                    case State.Unlocked:
                        Console.CursorLeft = 0;
                        Console.WriteLine("UNLOCKED");
                        return;
                        
                }
            }
        }
    }
}
