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
            //Find fruit grater then banana
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
            joinFruit = fruits.Aggregate((a, b) =>
            {
                a = "";
                return a + " ," + b;
            });//a,grape

            int[] numArr = { 2, 3, 4, 5 };
            int mulResult = numArr.Aggregate((a, b) => a * b);//120
            int mulResultAddtional = numArr.Aggregate(10, (a, b) => a * b);//1200
        }
        [Fact]
        public void AnyAllAvgTest()
        {
            List<Pet> pets1 = new List<Pet>{ new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 } };
            long?[] longs = { null, 10007L, 37L, 399846234235L };
            double? average = longs.Average();
            var duplicate = pets1.GroupBy(x => x.Age).Any(x => x.Count() > 1);

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
        [Fact]
        public void GroupByTest()
        {
            List<Pet> pets1 = new List<Pet>{ new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 } };

            var GraphD = pets1.GroupBy(x => x.Name, (key, group) => group.First()).ToList();// full collection obje
            var GraphDName = pets1.GroupBy(x => x.Name).ToList();
            var GraphDAge = pets1.GroupBy(x => x.Age).ToList();

            var duplicate = pets1.GroupBy(x => x.Age).Any(x => x.Count() > 1);//x.Count() == 1)

        }
        [Fact]
        public void EtcTest()
        {
            int[] numArr = { 2, 3, 0, 4, 5, 0 };
            int[] seedArr = { 2, 3, 0 };

            double avg = numArr.Average();
            numArr.Append(5);
            IEnumerable<string> query = numArr.Cast<string>().OrderBy(z => z);
            var filter = numArr.Concat(numArr.Where(x => x != 0)).ToArray();// { 2, 3,0, 4, 5,0 ,2,3,4,5} 10
            //Except
            var except = numArr.Except(seedArr).ToArray();//4,5
            //range
            var range = Enumerable.Range(1, 10).ToArray();
            //range
            var rangeRepeat = Enumerable.Repeat("hello", 10).ToArray();
        }
    }

    internal class Pet
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
