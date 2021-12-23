using System;

namespace SantaClauseConsoleApp
{
    class Child
    {

        public Child(int childId,string childName,string childDob,string childAddress)
        {
            id = childId;
            name = childName;
            dob = childDob;
            address = childAddress;
        }
        public int id { get;}
        public string name { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public BehaviorEnum behavior = new();

        public string age()
        {
            //Calculate the age of the child
            int ageInt = DateTime.Now.Subtract(Convert.ToDateTime(dob)).Days / 365;
            return ageInt.ToString();
        }

        public string getCity()
        {
            string city = address.Split(", ")[1];
            city = city.Split(".")[0];

            return city;
        }


        public string getAddress()
        {
            string NewAddress = address.Split(",")[0];

            return NewAddress;
        }
    }
}
