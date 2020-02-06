using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.CodeExercise
{
    public class Game
    {
        public event EventHandler RatEnter, RatDies;
       
        public event EventHandler<Rat> NotifyRat;
     

        public void FireNotifyRat(object sender, Rat whichRat)
        {
            NotifyRat?.Invoke(sender, whichRat);
        }

        public void FireRatEnter(object sender)
        {
            RatEnter?.Invoke(sender, EventArgs.Empty);
        }

        public void FireRatDies(object sender)
        {
            RatDies?.Invoke(sender, EventArgs.Empty);
        }
    }

    public class Rat : IDisposable
    {
        public int Attack = 1;
        private readonly Game game;
        public Rat(Game game)
        {
            this.game = game;
            game.RatEnter += (sender, args) => {

                if (sender != this)
                {
                    ++Attack;
                    game.FireNotifyRat(this, (Rat)sender);
                }
            };
            game.NotifyRat += (sender, rat) => {
                if (rat == this)
                {
                    ++Attack;
                }
            };
            game.RatDies += (sender, args) => --Attack;
            game.FireRatEnter(this);

        }
        public void Dispose()
        {
            game.RatDies += (sender, args) => {
                game.FireRatDies(this);
            };
        }


    }


    class DesignPatterns
    {
    }
}
