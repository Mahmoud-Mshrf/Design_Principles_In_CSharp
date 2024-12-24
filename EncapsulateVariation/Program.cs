
namespace EncapsulateVariation
{
    internal class Program
    {
        // in this lecture, we will learn how to encapsulate the variation in the code.
        // we have a class Pizza which has three types of pizza Margherita, Capricciosa and Calzone.
        // we have a method OrderPizza(commented) which is responsible for creating the object of the pizza type and also preparing, baking and cutting the pizza.
        // this method is not a good practice because it is doing more than one thing. It is creating the object and also preparing, baking and cutting the pizza.
        // We should separate the creation of the object and the preparation, baking and cutting of the pizza.
        // because the creation of the Pizza will be changed frequently because of adding new types of pizza. So, we have separated the creation of the object but the preparation, baking and cutting of the pizza will remain the same.
        // so in case of any change in the creation of the object, we will change only the CreatePizza method and the rest of the code will remain the same.
        // so we will create a new method CreatePizza which will be responsible for creating the object of the pizza type.
        // and we will call this method in the OrderPizza method to create the object of the pizza type.
        // so we have separated the creation of the object and the preparation, baking and cutting of the pizza.
        static void Main(string[] args)
        {
            Pizza pizza = Pizza.OrderPizza(PizzaConstants.Capricciosa);
            Console.WriteLine(pizza);
        }
    }
    public class Pizza 
    {
        public virtual string Title => $"{nameof(Pizza)}";
        public virtual decimal Price => 10m;
        //public static Pizza OrderPizza(string type)
        //{
        //    Pizza pizza;
        //    if(type == nameof(Margherita))
        //    {
        //        pizza= new Margherita();
        //    }
        //    else if(type == nameof(Capricciosa))
        //    {
        //        pizza= new Capricciosa();
        //    }
        //    else
        //    {
        //        pizza= new Calzone();
        //    }
        //    Prepare();

        //    Bake();

        //    Cut();

        //    return pizza;
        //}// This method is not a good practice because it is doing more than one thing. It is creating the object and also preparing, baking and cutting the pizza.
        // We should separate the creation of the object and the preparation, baking and cutting of the pizza.

        public static Pizza OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);
            
            Prepare();

            Bake();

            Cut();

            return pizza;
        }// This method is a good practice because it is doing only one thing. It is creating the object of the pizza type (by calling CreatePizza) and then preparing, baking and cutting the pizza.
        // here we have separated the creation of the object and the preparation, baking and cutting of the pizza.
        // because the creation of the Pizza will be changed frequently because of adding new types of pizza. So, we have separated the creation of the object but the preparation, baking and cutting of the pizza will remain the same.
        // so in case of any change in the creation of the object, we will change only the CreatePizza method and the rest of the code will remain the same.

        private static Pizza CreatePizza(string type)
        {
            Pizza pizza;
            if (type == nameof(Margherita))
            {
                pizza = new Margherita();
            }
            else if (type == nameof(Capricciosa))
            {
                pizza = new Capricciosa();
            }
            else
            {
                pizza = new Calzone();
            }
            return pizza;
        }// This method is responsible for creating the object of the pizza type.
        // This method is doing only one thing. It is creating the object of the pizza type.

        private static void Prepare()
        {
            Console.Write("Preparing .....");
            Thread.Sleep(500);
            Console.WriteLine("Prepared");
        }
        private static void Bake()
        {
            Console.Write("Baking .....");
            Thread.Sleep(500);
            Console.WriteLine("Baked");
        }
        private static void Cut()
        {
            Console.Write("Cutting .....");
            Thread.Sleep(500);
            Console.WriteLine("Cut");
        }
        public override string ToString()
        {
            return $"{Title} - {Price}";
        }
    }
    public class Margherita : Pizza
    {
        public override string Title => $"{nameof(Pizza)} {nameof(Margherita)}";
        public override decimal Price => base.Price + 5m;
    }
    public class Capricciosa : Pizza
    {
        public override string Title => $"{nameof(Pizza)} {nameof(Capricciosa)}";
        public override decimal Price => base.Price + 10m;
    }
    public class Calzone : Pizza
    {
        public override string Title => $"{nameof(Pizza)} {nameof(Calzone)}";
        public override decimal Price => base.Price + 15m;
    }
}
