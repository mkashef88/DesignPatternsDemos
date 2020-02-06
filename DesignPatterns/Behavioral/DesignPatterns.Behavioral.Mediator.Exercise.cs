using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behvioral.Mediator.Exercise
{
    public class Participant
    {
        public int Value { get; set; } = 0;
       
        private readonly Mediator mediator;
        public Participant(Mediator mediator)
        {
            this.mediator = mediator;

            mediator.Alert += MediatorAlert;

        }

        public void MediatorAlert(object sender, int e)
        {
            if (sender != this)
                this.Value += e;
        }
        public void Say(int n)
        {
            
            mediator.BroadCast(this,n);
        }

        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}";
        }
    }

    public class Mediator
    {
        
        


        public void BroadCast(object sender,int n)
        {
            Alert?.Invoke(sender, n);
        }
        public event EventHandler<int> Alert;

    }
    class Program
    {

        static void Main2(string[] args)
        {
            var mediator = new Mediator();
            var participant1 = new Participant(mediator);
           
            var participant2 = new Participant(mediator);
           
            //var participant3 = new Participant(mediator, "Participant 3");
            Console.WriteLine(participant1);
            Console.WriteLine(participant2);

            participant1.Say(3);
            Console.WriteLine(participant1);
            Console.WriteLine(participant2);

            participant2.Say(2);

            Console.WriteLine(participant1);
            Console.WriteLine(participant2);
        }
    }
}
