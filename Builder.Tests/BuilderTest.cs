using System;
using Xunit;
using Moq;
using GangOfFour.Creational;

namespace Builders.Tests
{
    public class BuilderTests 
    {
        [Fact]
        public void CashierWasAbleToBuildEntree_WithoutException()
        {
            var builderMockEntree = new Mock<Entree>();

            Cashier cashier = new Cashier();
            cashier.Orders(builderMockEntree.Object);
            MealItem entreeOrder = builderMockEntree.Object.ProductGetResult();

            builderMockEntree.VerifyAll();
        }

        [Fact]
        public void CashierWasAbleToOrderDrink_WithoutException()
        {
            var builderMockDrink = new Mock<Drink>();

            Cashier cashier = new Cashier();
            cashier.Orders(builderMockDrink.Object);
            MealItem drinkOrder = builderMockDrink.Object.ProductGetResult();

            builderMockDrink.VerifyAll();
        }
    }
}
