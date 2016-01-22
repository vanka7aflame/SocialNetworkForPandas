namespace Panda
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Xml.Schema;

    public class Panda
    {
        private string name;
        private string email;
        private bool isMale = false, isFemale = false;

        private string Gender()
        {
            if (isMale)
            {
                return "Male";
            }
            return "Female";
        }

        public enum GenderType
        {
            Male,
            Female
        };

        public Panda(string name, string email, GenderType gender)
        {
            this.Name = name;
            this.Email = email;
            if (GenderType.Male == gender)
            {
                this.IsMale = true;
            }
            else
            {
                this.IsFemale = true;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
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
        
        public override bool Equals(object obj)
        {
            Panda panda = (Panda)obj;
            if (this.name == panda.name && this.email == panda.email && this.Gender() == panda.Gender())
            {
                return true;
            }
            return false;
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
