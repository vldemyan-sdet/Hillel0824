using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitHomeworks
{
    // Value type (struct)
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // Reference type (class)
    public class Person2
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Override Equals to compare properties instead of references
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //        return false;

        //    Person2 other = (Person2)obj;
        //    return Name == other.Name && Age == other.Age;
        //}

        //public override int GetHashCode()
        //{
        //    return (Name, Age).GetHashCode();
        //}
    }


    internal class EqualsTests
    {
        // Test for value type (Point is a struct)
        [Test]
        public void ValueType_Equals_ReturnsTrueForSameValues()
        {
            Point p1 = new Point { X = 5, Y = 10 };
            Point p2 = new Point { X = 5, Y = 10 };

            // Value types compare based on value
            Assert.That(p1.Equals(p2), Is.True);
            Assert.That(p2, Is.EqualTo(p1));  // This uses the Equals method internally
        }

        [Test]
        public void ValueType_Equals_ReturnsFalseForDifferentValues()
        {
            Point p1 = new Point { X = 5, Y = 10 };
            Point p2 = new Point { X = 10, Y = 20 };

            Assert.That(p1.Equals(p2), Is.False);
            Assert.That(p2, Is.Not.EqualTo(p1));
        }

        // Test for reference type (Person2 is a class)
        [Test]
        public void ReferenceType_DefaultEquals_ReturnsFalseForDifferentInstances()
        {
            Person2 p1 = new Person2 { Name = "John", Age = 30 };
            Person2 p2 = new Person2 { Name = "John", Age = 30 };

            // Without overriding Equals, this would check for reference equality (false)
            Assert.That(object.ReferenceEquals(p1, p2), Is.False);  // Different instances
        }

        [Test]
        public void ReferenceType_OverrideEquals_ReturnsTrueForSameValues()
        {
            Person2 p1 = new Person2 { Name = "John", Age = 30 };
            Person2 p2 = new Person2 { Name = "John", Age = 30 };

            // With overridden Equals, this checks for value equality (true)
            Assert.That(p1.Equals(p2), Is.True);
            Assert.That(p2, Is.EqualTo(p1));  // Same effect, uses Equals
        }

        [Test]
        public void ReferenceType_OverrideEquals_ReturnsFalseForDifferentValues()
        {
            Person2 p1 = new Person2 { Name = "John", Age = 30 };
            Person2 p2 = new Person2 { Name = "Jane", Age = 25 };

            Assert.That(p1.Equals(p2), Is.False);
            Assert.That(p2, Is.Not.EqualTo(p1));
        }
    }
}
