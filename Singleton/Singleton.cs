using System;

namespace GangOfFour.Creational
{

    //Singleton Example
    public class Election 
    {
        private static readonly Election _candidate = new Election();
        private static Election _lazyInitCandidate;

        public static Election Winner()
        {
            return _candidate;
        } 

        public static Election LazyWinner()
        {
          //lazy implementation
          return  _lazyInitCandidate =  (null == _lazyInitCandidate) ? new Election() : _lazyInitCandidate; 
        }
    }

    class Singleton
    {
        static void Main()
        {
            var w1 = Election.Winner(); 
            var w2 = Election.Winner();

            if(w1.Equals(w2)) {
               Console.WriteLine("Same Election Same Results");
            }

            //lazy winner
            var lw1 = Election.LazyWinner();
            var lw2 = Election.LazyWinner();

            if(lw1.Equals(lw2)) {
               Console.WriteLine("Lazy Election Winner");
            }

            Console.ReadKey();
        }
    }
}
