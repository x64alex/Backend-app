using System;

namespace SantaClauseConsoleApp
{
    class Letter
    {
        public Letter(int letterId,string lettertext, string letterdate,Item letterToy1, Item letterToy2)
        {
            date = letterdate;
            text = lettertext;
            toy1 = letterToy1;    
            toy2 = letterToy2;   
        }

       
        public Item[] items { get; set; }
        public string text { get; set; }
        public string date;
        public Item toy1 { get; set; }
        public Item toy2 { get; set; }

        public string letterFormat(string format,Child child,Item toy1,Item toy2)
        {
            return string.Format(format, child.name, DateTime.Now.Subtract(Convert.ToDateTime(child.dob)).Days/365, child.address, child.behavior, toy1.Name, toy2.Name);
        }

        public void setFormat(string format, Child child, Item toy1, Item toy2)
        {
            text = string.Format(format, child.name,child.age() , child.address, child.behavior, toy1.Name, toy2.Name);
        }
    }
}
