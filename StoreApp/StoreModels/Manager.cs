using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StoreModels
{
    public class Manager
    {
        private string managerName;
        private string managerEmail;
        public int Id { get; set; }
        public string ManagerName
        {
            get
            {
                return managerName;
            }
            set
            {
                if (IsEmptyOrNull(value))
                {
                    throw new ArgumentNullException("Manager name can't be empty or null.");
                }
                else if (!IsValidName(value))
                {
                    throw new Exception("Manager name can't have numbers in it.");
                }
                managerName = value;
            }
        }

        public string ManagerEmail
        {
            get
            {
                return managerEmail;
            }
            set
            {
                if (IsEmptyOrNull(value))
                {
                    throw new ArgumentNullException("Manager email can't be empty or null.");
                }
                else if (!IsValidEmail(value))
                {
                    throw new Exception("Must be a valid email address.");
                }

                managerEmail = value;
            }
        }

        public bool IsEmptyOrNull(string str)
        {
            //check to see if email has the required characters
            if (str == null || str.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsValidName(string name)
        {
            //check to see if name contains numbers
            if (Regex.IsMatch(name, ".*\\d+.*"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsValidEmail(string email)
        {
            //check to see if email has the required characters
            if (Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString() => $"Manager Information: \n\t Name: {this.ManagerName} \n\t Email: {this.ManagerEmail}";
    }
}
