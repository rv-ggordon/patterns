using System;
using System.Collections.Generic;

namespace GangOfFour.Behavorial
{
    //ChainOfResponsbility Pattern Example
    public abstract class CoinSorter
    {
        protected CoinSorter successor;

        public void SetSuccessor(CoinSorter successor)
        {
                 this.successor = successor;
        }

        public abstract void HandleRequest(double request);
    }

    public class SortQuaters : CoinSorter
    {
        public override void HandleRequest(double request)
        {
            if(request == 0.25 )
            {
                Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
            }
            else if (null != successor)
            {
                successor.HandleRequest(request);
            }
        }
    }

    public class SortNickles : CoinSorter
    {
        public override void HandleRequest(double request)
        {
            if(request == 0.05)
            {
                Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
            }
            else if (null != successor)
            {
                successor.HandleRequest(request);
            }
        }
    }

    public class SortDimes : CoinSorter
    {
        public override void HandleRequest(double request)
        {
            if(request == 0.10)
            {
                Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
            }
            else if (null != successor)
            {
                successor.HandleRequest(request);
            }
        }
    }
    public class NoSort : CoinSorter
    {
        public override void HandleRequest(double request)
        {
             Console.WriteLine("{0} sorry unable to sort this coin {1:F2}", this.GetType().Name, request);
        }
    }

    class ChainOfResponsbilityPattern
    {
        static void Main()
        {
            CoinSorter c1 = new SortQuaters();
            CoinSorter c2 = new SortDimes();
            CoinSorter c3 = new SortNickles();
            CoinSorter cn = new NoSort();

            c1.SetSuccessor(c2);
            c2.SetSuccessor(c3);
            c3.SetSuccessor(cn);

            //Generate and process request
            double [] requests = {0.05, 0.10, 1.00, 0.25, 0.10, 0.05, 1.00, 2.00};
            foreach (double request in requests)
            {
                c1.HandleRequest(request);
            }

            Console.ReadKey();
        }
    }
}
