namespace Composition
{
    // Composition is a special form of aggregation. It is a relationship between two classes like association, however, it is a strong association.
    // It represents a "death" relationship.
    // In Composition, the child class cannot exist independently of the parent class.
    // Composition is represented by a filled diamond.
    // Composition is a strong relationship.
    // Composition is a relationship where the child cannot exist independently of the parent.
    // Let's take an example of a house and rooms. A house can have multiple rooms, but a room cannot exist without a house.
    // If a house is deleted, all rooms will be deleted.
    // The house and rooms are dependent entities.
    // The house is responsible for the creation and destruction of rooms.
    // The house can have a reference to rooms.
    // The room cannot have a reference to the house.
    // The house and rooms are strongly dependent on each other.
    // The house and rooms can be created and deleted together.
    // ************************************************
    // ************************************************
    // Car and Engine example
    // In this example, the car has an engine, and the engine cannot exist without the car.
    // If the car is deleted, the engine will be deleted.
    // The car and engine are dependent entities.
    // The car is responsible for the creation and destruction of the engine.
    // The car can have a reference to the engine.
    // The engine cannot have a reference to the car.
    // The car and engine are strongly dependent on each other.


    internal class Program
    {
        static void Main(string[] args)
        {
            House house = new House("123 Main St");
            house.AddRoom(1);
            house.AddRoom(2);
            house.AddRoom(3);
            foreach (var room in house.Rooms)
            {
                Console.WriteLine($"Room {room.RoomNumber} belongs to {house.Address} house");
            }
            Console.WriteLine("******************************");
            Console.WriteLine("******************************");
            Console.WriteLine("Car and Engine example \n");
            var car = new Car("Toyota Corolla", "V4");
            car.StartCar();
        }
    }
    class House
    {
        public string Address { get; private set; }
        public List<Room> Rooms { get; private set; } = new List<Room>();
        public House(string address)
        {
            Address = address;
        }
        public void AddRoom(int roomNumber)
        {
            Rooms.Add(new Room(roomNumber));// Room is created as part of the house
        }
    }
    class Room
    {
        public int RoomNumber { get; private set; }
        public Room(int roomNumber)
        {
            RoomNumber = roomNumber;
        }
    }
    public class Engine
    {
        public string Type { get; private set; }

        public Engine(string type)
        {
            Type = type;
        }

        public void Start()
        {
            Console.WriteLine($"The {Type} engine is starting...");
        }
    }

    public class Car
    {
        public string Model { get; private set; }
        public Engine CarEngine { get; private set; }

        public Car(string model, string engineType)
        {
            Model = model;
            CarEngine = new Engine(engineType); // Engine is created as part of the car
        }

        public void StartCar()
        {
            Console.WriteLine($"{Model} is starting...");
            CarEngine.Start();
        }
    }

}
