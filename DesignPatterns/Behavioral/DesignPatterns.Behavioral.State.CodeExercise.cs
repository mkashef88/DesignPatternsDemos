using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.State.CodeExercise
{
    public class CombinationLock
    {
        private string code;
        private StringBuilder entry = new StringBuilder();
        public CombinationLock(int[] combination)
        {
            code = string.Join("", combination);
            this.Status = "LOCKED";
        }

        // you need to be changing this on user input
        public string Status;

        public void EnterDigit(int digit)
        {
            if (Status == "LOCKED")
                Status = string.Empty;

            Status += digit.ToString();
            if (Status == code)
            {
                Status = "OPEN";
                return;
            }
            if (!code.StartsWith(Status))
            {
                Status = "ERROR";
                return;
            }
            

            entry.Append(digit.ToString());


        }
    }
    class CodeExercise
    {
    }
}
