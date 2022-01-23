using System;

namespace Telefon_Rehberi
{
    public class Person
    {
        private string name;
        private string surename;
        private string phoneNumber;

        public Person(string _name, string _surename, string _phoneNumber)
        {
            this.name = _name;
            this.surename = _surename;
            this.phoneNumber = _phoneNumber;
        }

        public string Name 
        {
            get
            {
                return name;
            }
            set => name = value;
        }
        public string Surename { get => surename; set => surename = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }  
         

    }
}