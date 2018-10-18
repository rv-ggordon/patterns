using System;
using System.Collections.Generic;

namespace GangOfFour.Behaviorial
{
    //Command Pattern Example
    public abstract class Order
    {
        protected Cook cook; 
        public Order(Cook cook)
        {
            this.cook = cook;
        }

        public abstract void PlaceOrder();
    }

    public class Waitress  
    {
        protected Order order; 
        public void Build(Order order)
        {
           this.order = order;
        }

        public void PlaceOrder()
        {
            order.PlaceOrder();
        }
    }

    public class Cook
    {
        public void CookFood()
        {
            Console.WriteLine("Cooks the food");
        }
    }

    public class MakeOrder : Order
    {

        public MakeOrder(Cook cook) :
           base(cook)
        {
        }

        public override void PlaceOrder()
        {
               cook.CookFood();
        }
    }

    class CommandPattern
    {
        static void Main()
        {
            Cook cook = new Cook();
            Order order = new MakeOrder(cook);
            Waitress waitress = new Waitress();

            waitress.Build(order);
            waitress.PlaceOrder();

            Console.ReadKey();
        }
    }
}
