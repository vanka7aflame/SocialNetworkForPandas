namespace SocialNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Panda;

    class Program
    {
        static void Main(string[] args)
        {
            PandaSocialNetwork pandaSocialNetwork = new PandaSocialNetwork();
            Panda panda1 = new Panda("A", "asd@abv.bg", GenderType.Male);
            Panda panda2 = new Panda("B", "asd@abv.bg", GenderType.Female);
            Panda panda3 = new Panda("C", "asd@abv.bg", GenderType.Male);
            Panda panda4 = new Panda("D", "asd@abv.bg", GenderType.Female);
            Panda panda5 = new Panda("E", "asd@abv.bg", GenderType.Male);
            Panda panda6 = new Panda("F", "asd@abv.bg", GenderType.Female);
            pandaSocialNetwork.AddPanda(panda1);
            pandaSocialNetwork.AddPanda(panda2);
            pandaSocialNetwork.AddPanda(panda3);
            pandaSocialNetwork.AddPanda(panda4);
            pandaSocialNetwork.AddPanda(panda5);
            pandaSocialNetwork.AddPanda(panda6);
            pandaSocialNetwork.MakeFriends(panda1, panda2);
            pandaSocialNetwork.MakeFriends(panda1, panda3);
            pandaSocialNetwork.MakeFriends(panda2, panda4);
            pandaSocialNetwork.MakeFriends(panda2, panda6);
            pandaSocialNetwork.MakeFriends(panda3, panda5);
            pandaSocialNetwork.MakeFriends(panda3, panda4);
            pandaSocialNetwork.MakeFriends(panda4, panda6);
            pandaSocialNetwork.MakeFriends(panda5, panda6);
            Console.WriteLine(pandaSocialNetwork.Connectionlevel(panda1, panda6));
            Console.WriteLine(pandaSocialNetwork.HowManyGenderInNetwork(2, panda1, GenderType.Male));


        }
    }
}
