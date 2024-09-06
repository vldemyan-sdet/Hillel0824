namespace NUnitHomeworks
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    [TestFixture]
    public class LambdaTests
    {

        [Test]
        public void ValueTypes1()
        {
            int i = 5;
            int j = i;
            i = 10;
            Assert.That(i, Is.EqualTo(0));
            Assert.That(j, Is.EqualTo(0));
        }

        [Test]
        public void ValueTypes2()
        {
            string s1 = "initial value";
            string s2 = s1;
            s1 = "another value";
            Assert.That(s2, Is.EqualTo(""));
        }

        [Test]
        public void ReferenceTypes1()
        {
            List<int> list1 = [1, 2, 3];
            List<int> list2 = [10, 20, 30];
            list2 = list1;
            list1[1] = 200;
            list2[2] = 300;

            Assert.That(list2[0], Is.EqualTo(0));
            Assert.That(list2[1], Is.EqualTo(0));
            Assert.That(list2[2], Is.EqualTo(0));
        }

        [Test]
        public void ReferenceTypes2()
        {
            var person1 = new Person { Name = "Alex", Age = 10 };
            var person2 = new Person { Name = "Jane", Age = 20 };
            person2 = person1;
            person1.Age = 30;

            Assert.That(person1.Name, Is.EqualTo(""));
            Assert.That(person1.Age, Is.EqualTo(0));
            Assert.That(person2.Name, Is.EqualTo(""));
            Assert.That(person2.Age, Is.EqualTo(0));
        }

        [Test]
        public void ReferenceTypes3()
        {
            var name1 = "Alex";
            var name2 = "Jane";

            var person1 = new Person { Name = name1, Age = 10 };
            var person2 = new Person { Name = name2, Age = 20 };

            List<Person> persones = new()
        {
            person1,
            person2
        };

            person1.Age = 100;
            name2 = "Mary";

            Assert.That(persones[0].Age, Is.EqualTo(0));
            Assert.That(persones[0].Name, Is.EqualTo(""));
            Assert.That(persones[1].Age, Is.EqualTo(0));
            Assert.That(persones[1].Name, Is.EqualTo(""));
        }

        private int Increment5(int input)
        {
            int result = input + 5;
            return result;
        }

        [Test]
        public void LambdaFunctions()
        {

            var result1 = Increment5(5);
            var result2 = Increment5(result1);

            Assert.That(result1, Is.EqualTo(0));
            Assert.That(result2, Is.EqualTo(0));

            var lambda1 = (int i) => { return i + 5; };
            Func<int, int> lambda2 = (i) => { return i + 5; };

            var result3 = lambda1(5);
            var result4 = lambda2(result3);

            Assert.That(result3, Is.EqualTo(0));
            Assert.That(result4, Is.EqualTo(0));

            var lambda3 = () => { Console.WriteLine("lambda 3"); };
            Action lambda4 = () => { Console.WriteLine("lambda 4"); };
            lambda3();
            var l = lambda4;
            l();
        }

        [Test]
        public void TestWhere()
        {
            var people = new List<Person>
        {
            new Person { Name = "John", Age = 25, City = "New York" },
            new Person { Name = "Anna", Age = 30, City = "London" },
            new Person { Name = "Mike", Age = 35, City = "New York" },
            new Person { Name = "Sara", Age = 20, City = "Paris" },
            new Person { Name = "Paul", Age = 28, City = "Berlin" }
        };

            var result = people.Where(p => p.City == "New York").ToList();

            var lambda1 = (Person p) => { return p.City == "New York"; };
            Func<Person, bool> lambda2 = (Person p) => {
                if (p.City == "New York")
                {
                    return true;
                }

                return false;
            };

            var result1 = people.Where(lambda1);
            var result2 = people.Where(lambda2);


            Assert.That(result.Count, Is.EqualTo(0));
            Assert.That(result1.Count, Is.EqualTo(0));
            Assert.That(result2.Count, Is.EqualTo(0));
            Assert.That(result[0].Name, Is.EqualTo(""));
            Assert.That(result[1].Name, Is.EqualTo(""));
            Assert.That(result1.First().Name, Is.EqualTo(""));
            Assert.That(result1.Last().Name, Is.EqualTo(""));
            Assert.That(result2.First().Name, Is.EqualTo(""));
            Assert.That(result2.Last().Name, Is.EqualTo(""));

            // IEnumerable VS List see IEnumerableTests
        }

        private string GetPesoneName(Person person)
        {
            return person.Name;
        }

        [Test]
        public void TestSelect()
        {
            var people = new List<Person>
        {
            new Person { Name = "Alice", Age = 22, City = "New York" },
            new Person { Name = "Bob", Age = 28, City = "San Francisco" },
            new Person { Name = "Charlie", Age = 32, City = "Chicago" },
            new Person { Name = "Diana", Age = 26, City = "Los Angeles" },
            new Person { Name = "Eve", Age = 29, City = "Seattle" }
        };

            var result = people.Select(p => p.Name).ToList();

            var lambda1 = (Person p) => { return p.Name; };
            Func<Person, string> lambda2 = (Person p) => {
                return p.Name;
            };

            var result1 = people.Select(lambda1);
            var result2 = people.Select(lambda2);
            var result3 = people.Select(GetPesoneName);

            var expectedCount = 0;
            var expectedName = "";

            Assert.Multiple(() =>
            {
                Assert.That(result.Count, Is.EqualTo(expectedCount));
                Assert.That(result1.Count, Is.EqualTo(expectedCount));
                Assert.That(result2.Count, Is.EqualTo(expectedCount));
                Assert.That(result3.Count, Is.EqualTo(expectedCount));
                Assert.That(result[2], Is.EqualTo(expectedName));
                Assert.That(result1.ElementAt(2), Is.EqualTo(expectedName));
                Assert.That(result2.ElementAt(2), Is.EqualTo(expectedName));
                Assert.That(result3.ElementAt(2), Is.EqualTo(expectedName));
            });
        }

    }
}
