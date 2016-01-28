namespace ConsoleInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SocialNetwork;
    using Panda;

    public class Program
    {
        static void Main(string[] args)
        {
            PandaSocialNetwork socialNetwork = new PandaSocialNetwork();
            Console.WriteLine("WELCOME TO THE PANDAS SOCIAL NETWORK!");
            StringBuilder helper = new StringBuilder();
            helper.Append("-------- HELP MENU --------").AppendLine()
                  .Append("To display the HELP MENU again please type - help").AppendLine()
                  .Append("To add new panda use - addpanda <name> <email> <male/female>").AppendLine()
                  .Append("To make two pandas Friends use - makefriends <panda1><panda1's email> <panda2><panda2's email>").AppendLine()
                  .Append("To view the Friends of a panda use - friendsof <panda><panda's email>").AppendLine()
                  .Append("To see the connection level between two pandas use - connectionlevel <panda1> <panda2>").AppendLine()
                  .Append("To see if two pandas are connected use - areconnected <panda1> <panda2>").AppendLine()
                  .Append("To see how many pandas of certain gender are in the network use - HowManyGenderInNetwork <level> <panda> <gender>").AppendLine()
                  .Append("-------- HAVE FUN --------");
            Console.WriteLine(helper.ToString());
            while (true)
            {
                string wholeCommand = Console.ReadLine();
                string[] command = wholeCommand.ToLower().Split(' ');
                switch (command[0])
                {
                    case "help":
                        Console.WriteLine(helper.ToString());
                        break;
                    case "addpanda":
                        try
                        {
                            GenderType gender;
                            if (command[3] == "male")
                            {
                                gender = GenderType.Male; ;
                            }
                            else
                            {
                                gender = GenderType.Female;
                            }
                            var panda = new Panda(command[1], command[2], gender);
                            socialNetwork.AddPanda(panda);
                        }
                        catch (PandaAlreadyExistException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case "makefriends":
                        try
                        {
                            var friendPanda1 = new Panda();
                            var friendPanda2 = new Panda();
                            foreach (var user in socialNetwork._pandaUsers)
                            {
                                if (user.Name == command[1] && user.Email == command[2])
                                {
                                    friendPanda1 = user;
                                }
                                if (user.Name == command[3] && user.Email == command[4])
                                {
                                    friendPanda2 = user;
                                }
                            }
                            socialNetwork.MakeFriends(friendPanda1, friendPanda2);
                        }
                        catch (PandaAlreadyFriendsException exception)
                        {
                            Console.WriteLine(exception.Message);
                            continue;    
                        }
                        break;
                    case "friendsof":
                        var friendsOfPanda = new Panda();
                        foreach (var user in socialNetwork._pandaUsers)
                        {
                            if (user.Name == command[1] && user.Email == command[2])
                            {
                                friendsOfPanda = user;
                                break;
                            }
                        }
                        foreach (var friend in socialNetwork.FriendsOf(friendsOfPanda))
                        {
                            Console.WriteLine(friend.Name);
                        }
                        break;
                    case "connectionlevel":
                        //Console.WriteLine(socialNetwork.Connectionlevel(command[1], command[2]));
                        break;
                    case "areconnected":
                        //Console.WriteLine(socialNetwork.AreConnected(command[1], command[2]));
                        break;
                    case "howmanygenderinnetwork":
                        //Console.WriteLine(socialNetwork.HowManyGenderInNetwork(int.Parse(command[1]), command[2], command[3]));
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid command! Type \"help\" to see list with functions.");
                        break;
                }
            }
        }
    }
}