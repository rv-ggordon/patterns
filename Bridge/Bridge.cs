using System;

namespace GangOfFour.Structural
{
    //Bridge Example
    public abstract class Switch
    {
        public Implementer _implementer; 

        public Implementer Implementer 
        {
            set 
            {
                _implementer = value;
            }
        } 
        public virtual void ON(){
            _implementer.ON();
        }
        public virtual void OFF(){
            _implementer.OFF();
        }
    }

    public class SwitchAbstraction : Switch
    {
        public SwitchAbstraction()
        {
            Console.WriteLine("Initalized SwitchAbstraction");
        }
        public override void ON()
        {
            _implementer.ON();
        }
        public override void OFF()
        {
            _implementer.OFF();
        }
    }

    public abstract class Implementer
    {
        public virtual void ON(){}
        public virtual void OFF(){}
    }

    public class ConcreteA : Implementer
    {
        public override void ON() 
        {
            Console.WriteLine("ConcreteA turned switch ON");
        }
        public override void OFF() 
        {
            Console.WriteLine("ConcreteA turned switch OFF");
        }
    }

    public class ConcreteB : Implementer
    {
        public override void ON()
        {
            Console.WriteLine("ConcreteB turned switch ON");
        }
    }

    class BridgePattern
    {
        static void Main()
        {

            Switch ba = new SwitchAbstraction();
            ba.Implementer = new ConcreteA();
            ba.ON();
            ba.OFF();

            //notice ConcreteB does not have OFF switch
            ba.Implementer = new ConcreteB();
            ba.ON();

            Console.ReadKey();
        }
    }
}
