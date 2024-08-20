namespace CSharpBasics
{
    internal class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_AddTwoNumbers_Correctly()
        {
            // Variables
            int number1 = 5;
            int number2 = 10;

            // Act
            int result = number1 + number2;

            // Assert
            Assert.That(result, Is.EqualTo(15), "The sum of the numbers should be 15.");
        }

        [Test]
        public void Should_CheckLoginStatus()
        {
            // Variable
            bool isLoggedIn = false;

            // Simulate a login process
            string username = "testUser";
            string password = "testPassword";

            // If condition
            if (username == "testUser" && password == "testPassword")
            {
                isLoggedIn = true;
            }

            // Assert
            Assert.That(isLoggedIn, Is.True, "The user should be logged in.");
        }

        [Test]
        public void Should_Verify_MultiplePageTitles()
        {
            // Array of expected page titles
            string[] expectedTitles = { "Home", "About Us", "Contact", "Services" };

            // Simulate an array of actual titles fetched during testing
            string[] actualTitles = { "Home", "About Us", "Contact", "Services" };

            // For loop to compare titles
            for (int i = 0; i < expectedTitles.Length; i++)
            {
                Assert.That(actualTitles[i], Is.EqualTo(expectedTitles[i]), $"The title at index {i} should be {expectedTitles[i]}.");
            }
        }

        [Test]
        public void Should_VerifyEachElementIsValid()
        {
            // List of user data
            List<string> userData = new List<string> { "Alice", "Bob", "Charlie" };

            // Foreach loop to check if all names are non-empty
            foreach (var user in userData)
            {
                Assert.That(user, Is.Not.Null, "User name should not be null.");
                Assert.That(user, Is.Not.Empty, "User name should not be empty.");
            }
        }

        [Test]
        public void Test1()
        {
            // Creating an object from the class
            Car myCar1 = new Car("Red", "Toyota");
            Car myCar2 = new Car("Blue", "BMW");
            myCar1.Drive();
            myCar2.Drive();

            Assert.Multiple(() =>
            {
                Assert.That(myCar1.Color, Is.EqualTo("Red"));
                Assert.That(myCar2.Color, Is.EqualTo("Blue"));
            });
        }
    }

    public class Car
    {
        // Fields (Data)
        public string Color;
        public string Model;

        // Constructor (Special method to initialize objects)
        public Car(string color, string model)
        {
            Color = color;
            Model = model;
        }

        // Method (Behavior)
        public void Drive()
        {
            Console.WriteLine("The car is driving.");
        }
    }
}