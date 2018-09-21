using System;
using System.Collections.Generic;

namespace GangOfFour.Creational
{

    public abstract class Builder {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract MealItem ProductGetResult();
    }

    public class Cashier 
    {
        public void Orders(Builder builder) {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    public class MealItem 
    {
        private List<String> _mealItems = new List<string>();
        public void Add(string part) {
            _mealItems.Add(part);
        }

        public void show() {
            foreach(string mealItem in _mealItems) {
                Console.WriteLine(mealItem);
            }
        }
    }

    public class Entree : Builder
    {

        private MealItem _mealItems = new MealItem();

        public override void BuildPartA()
        {
            _mealItems.Add("Cheese Burger");


        }

        public override void BuildPartB()
        {
            _mealItems.Add("2x Apple Pecan Salad");
        }

        public override MealItem ProductGetResult()
        {
            return _mealItems;
        }
    }

    public class Drink : Builder
    {

        private MealItem _meals = new MealItem();
        public override void BuildPartA()
        {
            _meals.Add("Welch Sparkling Water");
        }

        public override void BuildPartB()
        {
            _meals.Add("MilkShake");
        }

        public override MealItem ProductGetResult()
        {
            return _meals;
        }
    }

    //Builder Design Pattern example
    class BuilderPattern
    {
        static void Main()
        {
            Cashier cashier = new Cashier();
            Builder meal = new Entree();
            Builder drink = new Drink();

            Console.WriteLine("\nAt The Jive FastFood Joint -----");
            Console.WriteLine("Your order was");
            Console.WriteLine("---------------");

            cashier.Orders(meal);
            MealItem order1 = meal.ProductGetResult();
            order1.show();

            cashier.Orders(drink);
            MealItem order2 = drink.ProductGetResult();
            order2.show();

            Console.ReadKey();
        }
    }
}
