using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice_10_1
{
    internal class Client
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Client client)
            {
                return PassportNumber == client.PassportNumber;
            }
            return false;
        }

        public override int GetHashCode() => PassportNumber.GetHashCode();
    }
}
