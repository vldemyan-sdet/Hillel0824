namespace Houses
{
    public class AdminHouse : House
    {
        public AdminHouse() 
        {
            this.floorsNumber = null;
        }

        public int numberOfWorkRoom;
        public AdminHouse ElevatorToFloor(int floor) 
        {
            Console.WriteLine("Moving to floor " + floor);
            Console.WriteLine("Number of floors " + this.floorsNumber);
            return this;
        }

        public AdminHouse CallSupportToWorkRoom(int workRoomNumber)
        {
            Console.WriteLine("Calling support to room " + workRoomNumber);
            return this;
        }

    }
}

