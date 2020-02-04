using System.Collections.Generic;
using NUnit.Framework;

namespace CheckOutSystemTest.Test
{
    [TestFixture]
    public class WhenIHaveNothingInTheList
    {
        [Test]
        public void ThenTheTotalCostIsZero()
        {
            //Arrange
            var checkOutSystem = new CheckOutSystem();
            const decimal expectedResult = 0.00m;
            var listOfItems = new List<Item>();

            //Action
            var actualResult = checkOutSystem.CheckOut(listOfItems);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    [TestFixture]
    public class WhenIHaveOnlyOneItemInTheList
    {
        //Arrange
        private static readonly object[] SourceList =
        {
            new object[] {new List<Item> {new Item(ProductName.ChickenWings)}, 4.40m}, // Only one Starter in the list
            new object[] {new List<Item> {new Item(ProductName.Lasagna)}, 7.00m} // Only one Main in the list
        };

        [TestCaseSource(nameof(SourceList))]
        public void ThenTheTotalCostIsTheCostOfThatItem(List<Item> listOfItems, decimal expectedResult)
        {
            var checkOutSystem = new CheckOutSystem();

            //Action
            var actualResult = checkOutSystem.CheckOut(listOfItems);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    [TestFixture]
    public class WhenIHaveTwoItemsInTheList
    {
        //Arrange
        private static readonly object[] SourceList =
        {
            new object[]
            {
                new List<Item> {new Item(ProductName.ChickenWings), new Item(ProductName.Samosas)}, 8.80m
            }, // 2 Starters
            new object[]
                {new List<Item> {new Item(ProductName.Lasagna), new Item(ProductName.FishAndChips)}, 14.00m}, // 2 Mains
            new object[]
            {
                new List<Item> {new Item(ProductName.ChickenWings), new Item(ProductName.FishAndChips)}, 11.40m
            } // 1 Starter, 1 Main
        };

        [TestCaseSource(nameof(SourceList))]
        public void ThenTheTotalCostIsTheCostOfThoseTwoItems(List<Item> listOfItems, decimal expectedResult)
        {
            var checkOutSystem = new CheckOutSystem();

            //Action
            var actualResult = checkOutSystem.CheckOut(listOfItems);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    [TestFixture]
    public class WhenIHaveMoreThanTwoItemsInTheList
    {
        //Arrange
        private static readonly object[] SourceList =
        {
            new object[]
            {
                new List<Item>
                    {new Item(ProductName.ChickenWings), new Item(ProductName.Samosas), new Item(ProductName.Lasagna)},
                15.80m
            }, // 2 Starters, 1Main
            new object[]
            {
                new List<Item>
                {
                    new Item(ProductName.Lasagna), new Item(ProductName.FishAndChips),
                    new Item(ProductName.ChickenWings)
                },
                18.40m
            }, // 2 Mains, 1 Starter
            new object[]
            {
                new List<Item>
                {
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.FishAndChips),
                    new Item(ProductName.ChickenWings),
                    new Item(ProductName.Lasagna),
                    new Item(ProductName.Samosas),
                    new Item(ProductName.RoastChicken)
                },
                134.80m
            } // 2 Starter, 18 Main 
        };

        [TestCaseSource(nameof(SourceList))]
        public void ThenTheTotalCostIsTheCostOfAllTheItemsInTheList(List<Item> listOfItems, decimal expectedResult)
        {
            var checkOutSystem = new CheckOutSystem();

            //Action
            var actualResult = checkOutSystem.CheckOut(listOfItems);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}