using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Memento.Exercise
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class Memento
    {
        public List<Token> Tokens = new List<Token>();
		public Memento(List<Token> tokens)
        {
            Tokens = tokens.Select(t => new Token(t.Value)).ToList();
           
           
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            Tokens.Add(new Token(value));  
            return new Memento(Tokens);
        }

        public Memento AddToken(Token token)
        {
            return AddToken(token.Value);
        }

        public void Revert(Memento m)
        {
            this.Tokens = m.Tokens.Select(t => new Token(t.Value)).ToList();
            
        }
    }
    class Exercise
    {
        static void Main12(string[] args)
        {
            
                var tm = new TokenMachine();
                var m = tm.AddToken(123);
                tm.AddToken(456);
                tm.Revert(m);
            
        }
    }
}
