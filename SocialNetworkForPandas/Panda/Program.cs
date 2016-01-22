using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panda
{
    class Program
    {
        static void Main(string[] args)
        {
            Panda panda = new Panda("Ivan", "asd@abv.bg", Panda.GenderType.Female);
            Console.WriteLine(panda.Name);
        }
    }
}
