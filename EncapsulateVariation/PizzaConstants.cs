using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulateVariation
{
    internal class PizzaConstants
    {
        public const string Margherita = nameof(Margherita);
        public const string Capricciosa = nameof(Capricciosa);
        public const string Calzone = nameof(Calzone);
        // we have created a class PizzaConstants which has three constants Margherita, Capricciosa and Calzone.
        // we have created these constants because we have to use these constants in the OrderPizza method to create the object of the pizza type.
        // so we have created these constants to avoid the hardcoding of the string values in the OrderPizza method.

    }
}
