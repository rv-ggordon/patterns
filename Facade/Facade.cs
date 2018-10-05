using System;

namespace GangOfFour.Structural
{
    //Facade Pattern Example
    public class Order
    {
        public void MethodOne()
        {
            Console.WriteLine(" Order fufilled ");
        }
    }

    public class Billing
    {
        public void MethodTwo()
        {
            Console.WriteLine(" Bill Created ");
        }
    }

    public class Delivery
    {
        public void MethodThree()
        {
            Console.WriteLine(" Install Date Captured ");
        }
    }

    public class CustomerService
    {
        private Order _one;
        private Billing _two;
        private Delivery _three;

        public CustomerService() 
        {
            _one = new Order();
            _two = new Billing();
            _three = new Delivery();
        }

        public void MethodA()
        {
            Console.WriteLine("MethodA() --------");
            _one.MethodOne();
            _two.MethodTwo();
        }

        public void MethodB()
        {
            Console.WriteLine("MethodB() --------");
            _three.MethodThree();
        }
    }

    class FacadePattern
    {
        static void Main()
        {

            CustomerService customerServiceFacade = new CustomerService();
            customerServiceFacade.MethodA();
            customerServiceFacade.MethodB();

            Console.ReadKey();
        }
    }
}
