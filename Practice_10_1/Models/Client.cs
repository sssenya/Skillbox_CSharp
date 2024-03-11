using System;
using System.Collections.Generic;

namespace Practice_10_1
{
    internal class Client
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }

        public string DataChangeAuthor { get; set; }
        public DateTime DataChangeTime { get; set; }
        public List<string> DataChangeInfo { get; set; }

        public class SortByName : IComparer<Client>
        {
            public int Compare(Client x, Client y)
            {
                return string.Compare(x.FirstName, y.FirstName);
            }
        }

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
