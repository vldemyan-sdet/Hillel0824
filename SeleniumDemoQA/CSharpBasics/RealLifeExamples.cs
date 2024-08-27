using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houses;

namespace CSharpBasics
{
    
    internal class RealLifeExamples
    {
        [Test]
        public void SomeTest()
        {
            var adminHouse = new AdminHouse();

            adminHouse.floorsNumber = 3;
            adminHouse.numberOfWorkRoom = 100;
            adminHouse.ElevatorToFloor(2).CallSupportToWorkRoom(50);

            var adminHouse2 = new AdminHouse();
            adminHouse2.floorsNumber = 5;
            adminHouse2.numberOfWorkRoom = 10;
            adminHouse2.ElevatorToFloor(4).CallSupportToWorkRoom(20);

            var privateHouse = new PrivateHouse();
            privateHouse.floorsNumber = 1;
            privateHouse.yardArea = 100;

        }

    }
}
