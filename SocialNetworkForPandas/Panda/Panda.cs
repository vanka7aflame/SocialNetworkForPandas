namespace Panda
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Schema;

    public enum GenderType
    {
        Male,
        Female
    };

    public class Panda
    {
        private string name;
        private string email;
        private bool isMale = false, isFemale = false;
        public GenderType gender;
        public List<Panda> friends = new List<Panda>(); 

        public Panda(string name, string email, GenderType gender)
        {
            this.Name = name;
            this.Email = email;
            this.gender = gender;
            if (GenderType.Male == gender)
            {
                this.IsMale = true;
            }
            else
            {
                this.IsFemale = true;
            }
            this.friends = new List<Panda>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (IsNameValid(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Invalid name!");
                }

            }
        }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (IsEmailValid(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("This email is not valid!");
                }

            }
        }

        public bool IsMale
        {
            get { return this.isMale; }
            set { this.isMale = value; }
        }

        public bool IsFemale
        {
            get { return this.isFemale; }
            set { this.isFemale = value; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat(
                    "Panda Name: {0}, Email: {1}, Gender: {2}, IsMale: {3}, IsFemale: {4} \nList of friends: \n",
                    this.name, this.email, this.gender, this.isMale, this.isFemale);
                foreach (var friend in friends)
                {
                    result.Append(friend.Name + " ");
                }
            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            Panda panda = (Panda)obj;
            if (this.name == panda.name && this.email == panda.email && this.gender == panda.gender)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + name.GetHashCode();
                hash = hash * 23 + email.GetHashCode();
                hash = hash * 23 + gender.GetHashCode();
                return hash;
            }
        }

        public static bool IsNameValid(string name)
        {
            if (!Regex.Match(name, "^[A-Z][a-zA-Z]*$").Success)
            {
                return false;
            }

            return true;
        }

        public static bool IsEmailValid(string strEmail)
        {
            Regex rgxEmail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                       @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                       @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return rgxEmail.IsMatch(strEmail);
        }

    }
}
