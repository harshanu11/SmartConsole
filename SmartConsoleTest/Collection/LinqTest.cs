using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CollectionTest
{
    public class LinqTest
    {
        // select and selectmany return smae result for nasted object 
        List<Employee> employees = new List<Employee>();
        public LinqTest()
        {

            Employee emp1 = new Employee {Id=1,Age=35, Name = "Deepak", Skills = new List<string> { "C", "C++", "Java" } };
            Employee emp2 = new Employee {Id=2,Age=35, Name = "Karan", Skills = new List<string> { "SQL Server", "C#", "ASP.NET" } };
            Employee emp3 = new Employee {Id=7,Age=55, Name = "Lalit", Skills = new List<string> { "C#", "ASP.NET MVC", "Windows Azure", "SQL Server" } };
            Employee emp3 = new Employee {Id=7,Age=55, Name = "we", Skills = new List<string> { "C#", "ASP.NET MVC", "Windows Azure", "SQL Server" } };

            employees.Add(emp1);
            employees.Add(emp2);
            employees.Add(emp3);
        }

        [Fact]
        public void AggrigateTest()
        {
            //Find fruit grater then banana
            int[] numArr = { 2, 3, 4, 5 };
            string[] fruits = { "apple", "mango", "orange", "passionfruit", "passionfruit1", "grape" };
            string longestName = fruits.Aggregate("banana", (first, second) =>
            {
                var data = second.Length > first.Length ? second : first;
                return data;
            }, (x) =>
            {
                return x.ToUpper();
            });//PASSIONFRUIT1

            longestName = fruits.Aggregate("passionfruit1", (first, second) =>
            {
                var data = second.Length > first.Length ? second : first;
                return data;
            }, (x) =>
            {
                return x.ToUpper();
            });//PASSIONFRUIT1....




            int mulResultAddtional = numArr.Aggregate(10, (a, b) => a * b);//1200




            string joinFruit = fruits.Aggregate((a, b) => { return a + " ," + b; });//apple ,mango ,orange ,passionfruit ,passionfruit1 ,grape
            var data  = fruits.Aggregate((a, b) =>
            {
                a = "";
                return a + " ," + b;
            }).ToArray();//a,grape

            int mulResult = numArr.Aggregate((a, b) => a * b);//120



            
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
        public void DefaultIfEmptyTest()
        {
            Pet defaultPet = new Pet { Name = "Default Pet", Age = 0 };

            List<Pet> pets2 = new List<Pet>();
            List<Pet> pets1 =
                new List<Pet>{ new Pet { Name="Barley", Age=8 },
                       new Pet { Name="Boots", Age=4 },
                       new Pet { Name="Whiskers", Age=1 } };

            foreach (Pet pet in pets1.DefaultIfEmpty(defaultPet))
            {
                Console.WriteLine("Name: {0}", pet.Name);
            }


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



            // Query using Select()
            IEnumerable<List<String>> resultSelect = employees.Select(e => e.Skills);//"C,C++,Java,SQL Server,C#,ASP.NET,C#,ASP.NET MVC,Windows Azure,SQL Server"
            // Query using SelectMany()
            IEnumerable<string> resultSelectMany = employees.SelectMany(emp => emp.Skills);//"C,C++,Java,SQL Server,C#,ASP.NET,C#,ASP.NET MVC,Windows Azure,SQL Server"

            var thenBy = employees.OrderBy(x => x.Age).ThenBy(x => x.Id).ThenBy(x => x.Id).ToArray();
            var thenByDec = employees.OrderBy(x => x.Age).ThenByDescending(x => x.Id).ThenBy(x => x.Id).ToArray();


            /// take takewhilw skip skipwhile
            var takewhile = employees.TakeWhile(x => {

                x = x;
                return x.Name.Length >2;
            }).ToArray();
        }
    }

    internal class Pet
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class Employee
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public List<string> Skills { get; set; }
    }
}
