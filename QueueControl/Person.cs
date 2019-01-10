using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace QueueControl
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }

        public Person() { }

        public Person(int id,string phoneNumber)
        {
            if (IsPhoneNumber(phoneNumber))
            {
                PersonId = id;
                PhoneNumber = phoneNumber;
            }
        }
        public bool IsPhoneNumber(string number)
        {
            return true;  // Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }

        public override string ToString()
        {
            return "Person: " + PersonId + " " + PhoneNumber;
        }
    }
}
