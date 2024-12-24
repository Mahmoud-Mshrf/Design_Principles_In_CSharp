namespace CompositionOverInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var choice = 0;
            do
            {
                Console.Clear();
                choice = ReadChoice(choice);
                if(choice>=1&&choice<=3)
                {
                    Pizza pizza = CreatePizza(choice);
                    Console.WriteLine(pizza);
                    Console.WriteLine("Press 0 to exit or any other key to continue: ");
                }
                Console.ReadKey();
            } while (choice!=0);
        }
        private static Pizza CreatePizza(int choice)
        {
            Pizza pizza = null;
            switch (choice)
            {
                case 1:
                    pizza = new Margherita();
                    break;
                case 2:
                    pizza = new Capricciosa();
                    break;
                case 3:
                    pizza = new Calzone();
                    break;
                default:
                    break;
            }
            return pizza;
        }
        private static int ReadChoice(int choice)
        {
            Console.WriteLine("Today's Menu");
            Console.WriteLine("1. Margherita");
            Console.WriteLine("2. Capricciosa");
            Console.WriteLine("3. Calzone");
            Console.Write("Enter your choice: ");
            if(int.TryParse(Console.ReadLine(), out int ch))
            {
                choice=ch;
            }
            return choice;
        }
    }
    class Pizza
    {
        public virtual string Title => $"{nameof(Pizza)}";
        public virtual decimal Price => 10m;

        public override string ToString()
        {
            return $"\n{Title}" +
                $"\n\tPrice: {Price.ToString("C")}";
        }
    }
    // this is bad design because for every new pizza type we have to create a new class and override the properties
    // this is not scalable
    // we can use composition to solve this problem by making the new addition to the pizza as list of toppings
    class Margherita : Pizza
    {
        public override string Title => $"{nameof(Margherita)}";
        public override decimal Price => 5m;
    }
    class Capricciosa : Pizza
    {
        public override string Title => $"{nameof(Capricciosa)}";
        public override decimal Price => 10m;
    }
    class Calzone : Pizza
    {
        public override string Title => $"{nameof(Calzone)}";
        public override decimal Price => 15m;
    }
}
