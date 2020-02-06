using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Abserver.Demo
{
	public class FallsIllEventArgs
    {
        public string Address;
    }
	public class Person
    {
		public void CatchACold()
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs { Address = "6785 Al Jabri" });
        }
        public event EventHandler<FallsIllEventArgs> FallsIll;
    }
    class AbserverDemo
    {
        static void Main23()
        {
            var person = new Person();

            person.FallsIll += CallDoctor;

            person.CatchACold();
        }

        private static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
        }
    }
}
