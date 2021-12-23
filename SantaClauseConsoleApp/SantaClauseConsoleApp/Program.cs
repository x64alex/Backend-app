using System;
using System.IO;
using System.Text;

namespace SantaClauseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Ddroidd!");


            Question1();
            Question2();
            Question3();
            Question4();
            Question5();
            Question6();
        }

        static void Question1()
        {
            Console.WriteLine("\nQ1:");
            Child child1 = new(0,"Alex", "1.1.2010", "Lacramioarelor, Cluj-Napoca");
            Child child2 = new(1,"Andrei", "1.1.2009","Principala, Cluj-Napoca");
            Child child3 = new(2,"Mircea", "1.1.2008","Secundara, Cluj-Napoca");
            Console.WriteLine(child1.name);
            Console.WriteLine(child2.name);  
            Console.WriteLine(child3.name);

            Item toy1 = new(0,"toy","Lego");
            Item toy2 = new(1,"toy","Iron man");
            Letter l1 = new(0,"Hello Santa!", "01.12.2021",toy1,toy2);
            Letter l2 = new(1,"Hello!","10.12.2021",toy1,toy2);
            Letter l3 = new(2,"Hello!","10.12.2021",toy1,toy2);


        }		

                static void Question2()
        {
            Console.WriteLine("\nQ2:");
            //Path is the place where the text files are located
            string path1 = @"C:\Users\Alex\source\repos\WinterInternship2022-Backend\SantaClauseConsoleApp\SantaClauseConsoleApp\letters\1.txt";
            string path2 = @"C:\Users\Alex\source\repos\WinterInternship2022-Backend\SantaClauseConsoleApp\SantaClauseConsoleApp\letters\2.txt";
            string path3 = @"C:\Users\Alex\source\repos\WinterInternship2022-Backend\SantaClauseConsoleApp\SantaClauseConsoleApp\letters\3.txt";

            string file1 = File.ReadAllText(path1);
            string file2 = File.ReadAllText(path2);
            string file3 = File.ReadAllText(path3);

            static Child createChild(string file,int id)
            {
                
                //Find the name of the child
                string name = file.Split("I am")[1];

                //Remove the last character('\n') and the first one ' '
                name = name.Remove(name.Length - 1, 1);
                name = name.Remove(0, 1);
                

                //Find the age and dob of the child
                string age = file.Split("I am ")[2];
                age = age.Split(" years old")[0];
                string dob = ageToDob(age);

                //Find the address of the child
                string address = file.Split("I live at ")[1];
                address = address.Split(".")[0];

                //Create the child
                Child childNew = new(id,name, dob, address);

                return childNew;
            }

            static string ageToDob(string age)
            {
                //Calculate the dob(not exactly) using the age
                int intAge = 0-Int32.Parse(age)*365;
                var myDate = DateTime.Now;
                var newDate = myDate.AddDays(intAge);
                string dateString = newDate.ToString();

                return dateString.Split(" ")[0];
            }

            Child child1 = createChild(file1,0);
            Console.WriteLine(child1.name);

            Child child2 = createChild(file2,1);
            Console.WriteLine(child1.name);

            Child child3 = createChild(file3,2);
            Console.WriteLine(child3.name);
        }

        static void Question3()
        {
            //Path is the place where the letter format is located
            string path = @"C:\Users\Alex\source\repos\WinterInternship2022-Backend\SantaClauseConsoleApp\SantaClauseConsoleApp\letter-template.txt";
            //Path where the text file will be created
            string pathNew = @"C:\Users\Alex\source\repos\WinterInternship2022-Backend\SantaClauseConsoleApp\SantaClauseConsoleApp\letters\Q3.txt";
            string format = File.ReadAllText(path);

            Item toy1 = new("toy", "Lego");
            Item toy2 = new("toy", "Iron Man");
            Letter l1 = new(0,"Hello Santa!", "01.12.2021",toy1,toy2);
            Child child1 = new(0,"Alex", "1.1.2010", "Bratianu, Dej");

            string l1Text = l1.letterFormat(format, child1,toy1,toy2);

            using (FileStream fs = File.Create(pathNew))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(l1Text);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }
            //Console.WriteLine(l1Text);
        }

        static void Question4()
        {
            Console.WriteLine("\nQ5:");
            //Path where the files are located
            string path1 = @"C:\Users\Alex\source\repos\WinterInternship2022-Backend\SantaClauseConsoleApp\SantaClauseConsoleApp\letters\1.txt";
            string path2 = @"C:\Users\Alex\source\repos\WinterInternship2022-Backend\SantaClauseConsoleApp\SantaClauseConsoleApp\letters\2.txt";
            string path3 = @"C:\Users\Alex\source\repos\WinterInternship2022-Backend\SantaClauseConsoleApp\SantaClauseConsoleApp\letters\3.txt";

            string file1 = File.ReadAllText(path1);
            string file2 = File.ReadAllText(path2);
            string file3 = File.ReadAllText(path3);

            static string toys(string file)
            {
                string toys = file.Split("is:")[1];
                return toys.Remove(0,2);
            }
            string[] list_toys = {toys(file1),toys(file2),toys(file3)};

            string toyReport = "";
            string toysList = "";
            foreach(string toy in list_toys)
            {
                string toy1 = toy.Split(",")[0];
                string toy2 = toy.Split(",")[1];

                string[] toysArray = toysList.Split(",");
                int ok1 = 0;
                int ok2 = 0;
                foreach(string t in toysArray)
                {
                    if (t == toy1){
                        ok1+=1;
                    }

                    if (t == toy2)
                    {
                        ok2+=1;
                    }
                }
                if (ok1 == 0)
                {
                    toysList += toy1 + ",";
                }
                if (ok2 == 0)
                {
                    toysList += toy2 + ",";
                }

            }
            toysList = toysList.Remove(toysList.Length - 1,1);
            //Console.WriteLine(toysList);

            string[] toysListArray = toysList.Split(",");
            int[] quantityList = new int[4];
            int i = 0;
            foreach(string t in toysListArray)
            {
                int num = 0;
                foreach(string toy in list_toys)
                {
                    string toy1 = toy.Split(",")[0];
                    string toy2 = toy.Split(",")[1];
                    if (toy1 == t || toy2 == t)
                    {
                        num++;
                    }
                }
                quantityList[i] = num;
                i += 1;
                toyReport += t + " - "+num.ToString()+"\n";
            }
            toyReport = toyReport.Remove(toyReport.Length - 1, 1);
            Console.WriteLine("Unsorted:");
            Console.WriteLine(toyReport);

            string[] toyReportList = toyReport.Split("\n"); 

            string newToyReport = "";
            Array.Sort(quantityList);

            foreach(int num in quantityList)
            {
                int ok = 1;
                foreach (string toy in toyReportList)
                {
                    int n = Int32.Parse(toy.Split(" - ")[1]);
                    if(n == num && ok == 1)
                    {
                        newToyReport = toy +"\n"+ newToyReport;
                        ok = 0;
                    }
                }

            }
            Console.WriteLine("\nSorted:\n"+ newToyReport);
            
        }


        static void Question5()
        {
        /*
        I do not think that applying Singleton pattern would be a good choice.
        */
        }

        static void Question6()
        {
            Console.WriteLine("\nQ6:");
            Child child1 = new(1,"Alex", "1.1.2010", "Lacramioarelor, Cluj-Napoca");
            Child child2 = new(2,"Andrei", "1.1.2009", "Principala, Cluj-Napoca");
            Child child3 = new(3,"Mircea", "1.1.2008", "Secundara, Cluj-Napoca");
            Child child4 = new(4,"Alex", "1.1.2010", "Lacramioarelor, Gherla");
            Child child5 = new(5,"Andrei", "1.1.2009", "Principala, Dej");
            Child child6 = new(6,"Mircea", "1.1.2008", "Secundara, Turda");

            Child[] childs = new Child[] { child1, child2, child3, child4, child5, child6 };


            string cities="";
            string travel = "";

            foreach (Child c in childs)
            {
                int ok = 0;
                string[] citiesSplited = cities.Split(" ");
                foreach (string city in citiesSplited)
                {
                    if (city == c.getCity())
                    {
                        ok = 1;
                    }
                }
                if(ok == 0)
                {
                    cities += c.getCity() + " ";
                }
            }
            //Console.WriteLine(cities);

            string[] NewCitiesSplited = cities.Split(" ");

            foreach (string city in NewCitiesSplited)
            {
                travel = travel + city + ": ";
                foreach(Child c in childs)
                {
                    if (city == c.getCity())
                    {
                        travel += c.getAddress() + ",";
                    }
                }
                travel = travel.Remove(travel.Length - 1, 1);

                travel += "\n";
            }
            travel = travel.Remove(travel.Length - 2, 2);

            Console.WriteLine(travel);

        }


    }
}
