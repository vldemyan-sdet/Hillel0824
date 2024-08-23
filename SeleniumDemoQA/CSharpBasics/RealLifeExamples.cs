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
        public void SomeTest()
        {
            var adminHouse = new AdminHouse();
            adminHouse.floorsNumber = 3;
            adminHouse.numberOfWorkRoom = 100;
            adminHouse.ElevatorToFloor(1);

            var privateHouse = new PrivateHouse();
            privateHouse.floorsNumber = 1;
            privateHouse.yardArea = 100;

        }

    }
}
