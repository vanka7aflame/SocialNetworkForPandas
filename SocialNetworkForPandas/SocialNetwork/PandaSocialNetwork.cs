using System.CodeDom;
using System.Runtime.InteropServices;

namespace SocialNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Panda;

    

    public class PandaSocialNetwork
    {
        private List<Panda> _pandaUsers = new List<Panda>();

        public void AddPanda(Panda panda)
        {
            _pandaUsers.Add(panda);
        }

        public bool HasPanda(Panda panda)
        {
            if (_pandaUsers.Contains(panda))
            {
                return true;
            }
            return false;
        }

        public void MakeFriends(Panda panda1, Panda panda2)
        {
            if (!HasPanda(panda1))
            {
                AddPanda(panda1);
            }
            else
            if (!HasPanda(panda2))
            {
                AddPanda(panda2);
            }

            if (!panda1.friends.Contains(panda2))
            {
                panda1.friends.Add(panda2);
            }
            else if (!panda2.friends.Contains(panda1))
            {
                panda2.friends.Add(panda1);
            }
            else
            {
                throw new ArgumentException("Already friends!");
            }
        }

        public bool AreFriends(Panda panda1, Panda panda2)
        {
            if (panda1.friends.Contains(panda2) && panda2.friends.Contains(panda1))
            {
                return true;
            }
            return false;
        }

        public List<Panda> FriendsOf(Panda panda)
        {
            List<Panda> result = new List<Panda>();

            if (HasPanda(panda))
            {
                result = panda.friends;
            }

            return result;
        }

        public int Connectionlevel(Panda panda1, Panda panda2)
        {   
            var inQueue = new Queue<PandaWithLevel>();
            var visited = new List<int>();

            inQueue.Enqueue(new PandaWithLevel {Level = 0, Panda = panda1.GetHashCode()});
            while (inQueue.Count > 0)
            {
                var currPandaWithLevel = inQueue.Dequeue();

                if (currPandaWithLevel.Panda == panda2.GetHashCode())
                {
                    return currPandaWithLevel.Level;
                }
                if (!visited.Contains(currPandaWithLevel.Panda))
                {
                    visited.Add(currPandaWithLevel.Panda);
                }

                Panda currPanda = _pandaUsers.FirstOrDefault(p => p.GetHashCode() == currPandaWithLevel.Panda.GetHashCode());

                if (currPanda != null && currPanda.friends != null && currPanda.friends.Count > 0)
                {
                    foreach (var friend in currPanda.friends)
                    {
                        if (!visited.Contains(friend.GetHashCode()))
                        {
                            inQueue.Enqueue(new PandaWithLevel {Level = currPandaWithLevel.Level + 1, Panda = friend.GetHashCode()});
                        }
                    }
                }
            }
            return -1;
        }

        public bool AreConnected(Panda panda1, Panda panda2)
        {
            return Connectionlevel(panda1, panda2) > 0 ? true : false;
        }

        public int HowManyGenderInNetwork(int level, Panda panda, GenderType gender)
        {
            var inQueue = new Queue<PandaWithLevel>();
            var visited = new List<int>();
            int genderCounter = 0;

            inQueue.Enqueue(new PandaWithLevel {Level = 0, Panda = panda.GetHashCode()});
            foreach (var friend in panda.friends)
            {
                inQueue.Enqueue(new PandaWithLevel {Level = 1, Panda = friend.GetHashCode()});
            }
            while (inQueue.Count > 0)
            {
                var currPandaWithLevel = inQueue.Dequeue();
                Panda currPanda = _pandaUsers.FirstOrDefault(p => p.GetHashCode() == currPandaWithLevel.Panda.GetHashCode());
                if (!visited.Contains(currPanda.GetHashCode()) && currPanda.gender == gender)
                {
                    visited.Add(currPandaWithLevel.Panda);
                    genderCounter++;
                }
                if (currPandaWithLevel.Level < level)
                {
                    foreach (var friend in currPanda.friends)
                    {
                        if (!visited.Contains(friend.GetHashCode()))
                        {
                            inQueue.Enqueue(new PandaWithLevel { Level = currPandaWithLevel.Level + 1, Panda = friend.GetHashCode() });
                        }
                    }
                }
            }
            return genderCounter;
        }

    }

    public class PandaWithLevel
    {
        public int Panda;
        public int Level;
    }
}
