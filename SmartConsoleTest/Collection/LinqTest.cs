using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CollectionTest
{
    public class LinqTest
    {
        [Fact]
        public void AggrigateTest()
        {
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "passionfruit1", "grape" };
            string longestName = fruits.Aggregate("banana", (longest, next) =>
            {
                var data = next.Length > longest.Length ? next : longest;
                return data;
            }, (x) =>
            {
                return x.ToUpper();
            });//PASSIONFRUIT1

            string joinFruit = fruits.Aggregate((a, b) => { return a + " ," + b; });//apple ,mango ,orange ,passionfruit ,passionfruit1 ,grape

            int[] numArr = { 2, 3, 4, 5 };
            int mulResult = numArr.Aggregate((a, b) => a * b);//120
            int mulResultAddtional = numArr.Aggregate(10, (a, b) => a * b);//1200
        }
        [Fact]
        public void AnyAllAvgTest()
        {
            long?[] longs = { null, 10007L, 37L, 399846234235L };
            double? average = longs.Average();
            // This code produces the following output:
            //
            // The average is 133282081426.333.
        }
        [Fact]
        public void AppendTest()
        {
            List<int> numbers = new List<int> { 1, 2, 0, 3, 4 };
            // Trying to append any value of the same type
            numbers.Append(5);
        }
        [Fact]
        public void ContainTest()
        {
            
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "passionfruit1", "grape" };
            var sdfsd = fruits.Contains("mango");

        }
        [Fact]
        public void ConcatTest()
        {
            int[] numArr = { 2, 3, 4, 5 };
            var data = numArr.Concat(numArr.Where(x => x != 0)).ToList();
            Assert.Equal(8, data.Count);
        }
        [Fact]
        public void DefaultIfEmptyTest()
        {
            Pet defaultPet = new Pet { Name = "Default Pet", Age = 0 };

            List<Pet> pets1 =
                new List<Pet>{ new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 } };

            foreach (Pet pet in pets1.DefaultIfEmpty(defaultPet))
            {
                Console.WriteLine("Name: {0}", pet.Name);
            }

            List<Pet> pets2 = new List<Pet>();

            foreach (Pet pet in pets2.DefaultIfEmpty(defaultPet))
            {
                Console.WriteLine("\nName: {0}", pet.Name);
            }

        }
    }

    internal class Pet
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
