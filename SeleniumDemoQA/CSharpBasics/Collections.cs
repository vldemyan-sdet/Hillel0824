namespace CSharpBasics
{
    internal class Collections
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestArrayInitialization()
        {
            // Initialize an array of integers with 5 elements
            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };

            // Verify the length of the array
            Assert.That(numbers.Length, Is.EqualTo(5));

            // Verify the content of the array
            Assert.That(numbers[0], Is.EqualTo(1));
            Assert.That(numbers[4], Is.EqualTo(5));
        }

        [Test]
        public void TestArrayModification()
        {
            // Initialize an array of strings
            string[] students = new string[] { "John", "Jane", "Bill", "Sue" };

            // Modify an element in the array
            students[2] = "Bob";

            // Verify the modification
            Assert.That(students[2], Is.EqualTo("Bob"));
            Assert.That(students[2], Is.Not.EqualTo("Bill"));
        }

        [Test]
        public void TestArrayBounds()
        {
            // Initialize an array
            int[] numbers = [1, 2, 3];

            // Accessing out-of-bounds element should throw an exception
            Assert.Throws<System.IndexOutOfRangeException>(() =>
            {
                var invalidAccess = numbers[3];
            });
        }


        [Test]
        public void TestListInitialization()
        {
            // Initialize a list of integers
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Verify the count of the list
            Assert.That(numbers.Count, Is.EqualTo(5));

            // Verify the content of the list
            Assert.That(numbers[0], Is.EqualTo(1));
            Assert.That(numbers[4], Is.EqualTo(5));
        }

        [Test]
        public void TestListModification()
        {
            // Initialize a list of strings
            List<string> students = new List<string> { "John", "Jane", "Bill", "Sue" };

            // Modify an element in the list
            students[2] = "Bob";

            // Verify the modification
            Assert.That(students[2], Is.EqualTo("Bob"));
            Assert.That(students[2], Is.Not.EqualTo("Bill"));
        }

        [Test]
        public void TestListAdditionAndRemoval()
        {
            // Initialize an empty list of strings
            List<string> students = new List<string>();

            // Add elements to the list
            students.Add("John");
            students.Add("Jane");

            // Verify the count after addition
            Assert.That(students.Count, Is.EqualTo(2));

            // Remove an element from the list
            students.Remove("John");

            // Verify the count after removal
            Assert.That(students.Count, Is.EqualTo(1));

            // Verify the remaining element
            Assert.That(students[0], Is.EqualTo("Jane"));
        }

        [Test]
        public void TestListContains()
        {
            // Initialize a list of strings
            List<string> students = new() { "John", "Jane", "Bill" };

            // Verify the list contains certain elements
            Assert.That(students.Contains("Jane"), Is.True);
            Assert.That(students.Contains("Sue"), Is.False);
        }
    }

}