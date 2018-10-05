using System;
using System.Collections.Generic;

namespace GangOfFour.Structural
{
    //Proxy Pattern Example
    public abstract class Subject
    {
        public abstract void Deposit();
    }

    public class Proxy : Subject
    {
        private static readonly Lazy<RealBankAccount> _bankAccount = new Lazy<RealBankAccount>();

        public override void Deposit()
        {
            Console.WriteLine("Proxy is performing a deposit of 100k on the Real BankAccount");
            _bankAccount.Value.Deposit(); 
        }
    }

    public class RealBankAccount : Subject
    {
        public override void Deposit()
        {
            Console.WriteLine("Real Deposit account updated with 100k");
        }
    }

    class ProxyPattern
    {
        static void Main()
        {
            Proxy proxy = new Proxy();
            proxy.Deposit();

            Console.ReadKey();
        }
    }
}