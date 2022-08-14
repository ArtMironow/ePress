using System;
using System.IO;
using System.Collections.Generic;
using EPress;

namespace Runner
{
    class Program
    {
        static void Main()
        {
            RunProgram runProgram = new RunProgram();
            runProgram.Run();
        }      
    }
    class RunProgram
    {
        SaleDept sale = new SaleDept();

        public void Run()
        {           
            char sw = '0';
            while (sw != '8')
            {
                Console.Write("\n");
                Console.WriteLine("----------MENU----------");
                Console.WriteLine("Press 1- Sell Product");
                Console.WriteLine("Press 2- Send Request");
                Console.WriteLine("Press 3- Add Employ");
                Console.WriteLine("Press 4- Del Employ");
                Console.WriteLine("Press 5- Print Employ");
                Console.WriteLine("Press 6- Read");
                Console.WriteLine("Press 7- Write");
                Console.WriteLine("Press 8- Exit");
                Console.WriteLine("------------------------");
                Console.Write("Your choise: ");

                ConsoleKeyInfo cki = Console.ReadKey();
                sw = (char)cki.Key;

                switch (sw)
                {
                    case '1':
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("SELL PRODUCT:");
                        Console.WriteLine("------------------------");
                        Case1();
                        break;
                    case '2':
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("SEND REQUEST:");
                        Console.WriteLine("------------------------");
                        Case2();
                        break;
                    case '3':
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("ADD EMPLOY:");
                        Console.WriteLine("------------------------");
                        Case3();
                        break;
                    case '4':
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("DEL EMPLOY:");
                        Console.WriteLine("------------------------");
                        Case4();
                        break;
                    case '5':
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("PRINT EMPLOY:");
                        Console.WriteLine("------------------------");
                        Case5();
                        break;
                    case '6':
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("READ:");
                        Console.WriteLine("------------------------");
                        Case6();
                        break;
                    case '7':
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("WRITE:");
                        Console.WriteLine("------------------------");
                        Case7();
                        break;
                    case '8':
                        sw = '8';
                        break;
                    default:
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("Input error. Try again...");
                        Console.WriteLine("------------------------");
                        break;
                }
            }
        }
        public void Case1()
        {
            if (sale.GetProgramDept().GetPublicationList().Count != 0)
            {
                int count = 0;
                foreach (Publication item in sale.GetProgramDept().GetPublicationList())
                {
                    count++;
                    Console.Write(count + ". ");
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
            
                int result = 0;
                bool res = false;
                while (!res)
                {
                    Console.WriteLine("Input number of Publication that you want to sell and press Enter: ");
                    res = Int32.TryParse(Console.ReadLine(), out result);
                    if (result <= 0 || result > sale.GetProgramDept().GetPublicationList().Count)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Input error. Try again...");
                        Console.WriteLine("------------------------");
                        res = false;
                    }
                }

                int amount = 0;
                Console.WriteLine("Input amount: ");
                res = Int32.TryParse(Console.ReadLine(), out amount);
                Console.WriteLine("------------------------");
                //
                if (sale.SellProduct(result, amount))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Publication nr. " + result + ". Sold " + amount + " exemplars");
                    Console.WriteLine("------------------------");
                }
                else
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Input error. Try again...");
                    Console.WriteLine("------------------------");
                }
            }
            else
            {
                Console.WriteLine("Publication List is empty");
                Console.WriteLine("------------------------");
            }
        }
        public void Case2()
        {
            string title = "";
            string genre = "";
            string serialNum = "";
            int amount;

            Console.WriteLine("Input Publication Title: ");
            title = Console.ReadLine();

            Console.WriteLine("Input number of Genre with GENRE MENU:");
            bool flag = true;
            char sw1 = '0';
            while (flag)
            {
                Console.Write("\n");
                Console.WriteLine("-------GENRE MENU-------");
                Console.WriteLine("Press 1- Bestseller");
                Console.WriteLine("Press 2- Novel");
                Console.WriteLine("Press 3- Detective");
                Console.WriteLine("Press 4- Weekly");
                Console.WriteLine("Press 5- Monthly");
                Console.WriteLine("------------------------");
                Console.Write("Your choise: ");

                ConsoleKeyInfo cki1 = Console.ReadKey();
                sw1 = (char)cki1.Key;

                switch (sw1)
                {
                    case '1':
                        genre = "Bestseller";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    case '2':
                        genre = "Novel";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    case '3':
                        genre = "Detective";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    case '4':
                        genre = "Weekly";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    case '5':
                        genre = "Monthly";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("Input error. Try again...");
                        Console.WriteLine("------------------------");
                        break;
                }
            }
            Console.WriteLine();

            Console.WriteLine("Input serial number of publication: ");
            serialNum = Console.ReadLine();

            Console.WriteLine("Input amount: ");
            bool res = Int32.TryParse(Console.ReadLine(), out amount);
            Console.WriteLine("------------------------");

            if (res && amount > 0)
            {
                if (sale.SendRequest(title, genre, serialNum, amount))
                {
                    Console.WriteLine("Publication was printed.");
                    int tmp = sale.GetProgramDept().GetPublicationList().Count - 1;
                    Publication tmpPbl = sale.GetProgramDept().GetPublicationList()[tmp];
                    Console.WriteLine(tmpPbl);
                    Console.WriteLine("was added to the list.");
                    Console.WriteLine("------------------------");
                }
                else
                {
                    Console.WriteLine("There are no correct authors.");
                    Console.WriteLine("------------------------");
                }
            }
            else
            {
                Console.WriteLine("There are no correct amount.");
                Console.WriteLine("------------------------");
            }
        }
        public void Case3()
        {
            string firstName = "";
            string lastName = "";
            string pesel = "";
            string genre = "";
            string contractType = "";
            Console.WriteLine("Input First Name:");
            firstName = Console.ReadLine();
            Console.WriteLine("Input Last Name:");
            lastName = Console.ReadLine();
            Console.WriteLine("Input PESEL:");
            pesel = Console.ReadLine();

            Console.WriteLine("Input number of Genre with GENRE MENU:");
            bool flag = true;
            char sw1 = '0';
            while (flag)
            {
                Console.Write("\n");
                Console.WriteLine("-------GENRE MENU-------");
                Console.WriteLine("Press 1- Bestseller");
                Console.WriteLine("Press 2- Novel");
                Console.WriteLine("Press 3- Detective");
                Console.WriteLine("Press 4- Weekly");
                Console.WriteLine("Press 5- Monthly");
                Console.WriteLine("------------------------");
                Console.Write("Your choise: ");

                ConsoleKeyInfo cki1 = Console.ReadKey();
                sw1 = (char)cki1.Key;

                switch (sw1)
                {
                    case '1':
                        genre = "Bestseller";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    case '2':
                        genre = "Novel";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    case '3':
                        genre = "Detective";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    case '4':
                        genre = "Weekly";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    case '5':
                        genre = "Monthly";
                        Console.Write("- " + genre);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("Input error. Try again...");
                        Console.WriteLine("------------------------");
                        break;
                }
            }
            Console.WriteLine();

            Console.WriteLine("Input number of Contract Type with CONTRACT TYPE MENU:");
            flag = true;
            char sw2 = '0';
            while (flag)
            {
                Console.Write("\n");
                Console.WriteLine("---CONTRACT TYPE MENU---");
                Console.WriteLine("Press 1- Job");
                Console.WriteLine("Press 2- Deal");
                Console.WriteLine("------------------------");
                Console.Write("Your choise: ");

                ConsoleKeyInfo cki2 = Console.ReadKey();
                sw2 = (char)cki2.Key;

                switch (sw2)
                {
                    case '1':
                        contractType = "Job";
                        Console.Write("- " + contractType);
                        flag = false;
                        break;
                    case '2':
                        contractType = "Deal";
                        Console.Write("- " + contractType);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\n------------------------");
                        Console.WriteLine("Input error. Try again...");
                        Console.WriteLine("------------------------");
                        break;
                }
            }
            Console.WriteLine();

            Console.WriteLine("------------------------");
            bool res = sale.GetProgramDept().AddEmploy(firstName, lastName, pesel, genre, contractType);
            if (res)
            {
                Console.WriteLine("\nEmploy: " + firstName + " " + lastName + "\n\tPESEL: " + pesel +
                    "\n\tGenre: " + genre + "\n\tContract type: " + contractType + "\nwas added.");
            }
            else
            {
                Console.WriteLine("Input error. Try again...");
            }
        }
        public void Case4()
        {
            if (sale.GetProgramDept().GetEmployList().Count != 0)
            {
                int count = 0;
                foreach (Employ item in sale.GetProgramDept().GetEmployList())
                {
                    count++;
                    Console.Write(count + ". ");
                    Console.WriteLine(item);
                }
                int result = 0;
                bool res = false;
                while (!res)
                {
                    Console.WriteLine("Input number of Employ who you want to delete " +
                    "and press Enter:");

                    res = Int32.TryParse(Console.ReadLine(), out result);

                    if (sale.GetProgramDept().DelEmploy(result - 1) && res)
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Employ nr. " + result + " was deleted");
                        Console.WriteLine("------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Input error. Try again...");
                        Console.WriteLine("------------------------");
                        res = false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Employ List is empty");
                Console.WriteLine("------------------------");
            }
        }
        public void Case5()
        {
            if (sale.GetProgramDept().GetEmployList().Count != 0)
            {
                foreach (Employ item in sale.GetProgramDept().GetEmployList())
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Employ List is empty");
                Console.WriteLine("------------------------");
            }
        }
        public void Case6()
        {
            try
            {
                sale.GetProgramDept().ReaderPbl();
                Console.WriteLine("Publication.txt - OK.");
                Console.WriteLine("------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("File reader error. " + e.Message);
                Console.WriteLine("Check file \"Publication.txt\" and try again...");
                Console.WriteLine("------------------------");
            }
            try
            {
                sale.GetProgramDept().ReaderEmpl();
                Console.WriteLine("Employ.txt - OK.");
                Console.WriteLine("------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("File reader error. " + e.Message);
                Console.WriteLine("Check file \"Employ.txt\" and try again...");
                Console.WriteLine("------------------------");
            }
        }
        public void Case7()
        {
            try
            {
                sale.GetProgramDept().WriterPbl();
                Console.WriteLine("Publication.txt - OK.");
                Console.WriteLine("------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("File writer error. " + e.Message);
                Console.WriteLine("Check file \"Publication.txt\" and try again...");
                Console.WriteLine("------------------------");
            }
            try
            {
                sale.GetProgramDept().WriterEmpl();
                Console.WriteLine("Employ.txt - OK.");
                Console.WriteLine("------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine("File writer error. " + e.Message);
                Console.WriteLine("Check file \"Employ.txt\" and try again...");
                Console.WriteLine("------------------------");
            }
        }
    }
}

namespace EPress
{
    class Author
    {
        string firstName;
        string lastName;
        string pesel;
        string genre;
        public Author(string firstName, string lastName, string pesel, string genre)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.pesel = pesel;
            this.genre = genre;
        }
        public string GetFirstName()
        {
            return firstName;
        }
        public string GetLastName()
        {
            return lastName;
        }
        public string GetPesel()
        {
            return pesel;
        }
        public string GetGenre()
        {
            return genre;
        }
        public override string ToString()
        {
            return firstName + " " + lastName + "\n\tPESEL: " + pesel + "\n\tGenre: " + genre;
        }
        public override int GetHashCode()
        {
            return firstName.GetHashCode() + lastName.GetHashCode() + pesel.GetHashCode() + genre.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Author tmp = obj as Author;
            if (tmp == null)
            {
                return false;
            }
            return tmp.firstName == this.firstName &&
                tmp.lastName == this.lastName &&
                tmp.pesel == this.pesel &&
                tmp.genre == this.genre;
        }
        public bool Equals(Author obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj.firstName == this.firstName &&
                obj.lastName == this.lastName &&
                obj.pesel == this.pesel &&
                obj.genre == this.genre;
        }
    }
    abstract class Employ
    {
        protected Author author;
        public Employ(Author author)
        {
            this.author = author;
        }
        public Author GetAuthor()
        {
            return author;
        }
    }
    class Job : Employ
    {
        public Job(Author author) : base(author) { }
        public override string ToString()
        {
            return "Employ: " + author.ToString() + "\n\tType Of contract: Permanent contract\n";
        }
        public override int GetHashCode()
        {
            return author.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Job tmp = obj as Job;
            if (tmp == null)
            {
                return false;
            }
            return this.author.Equals(tmp.author);
        }
        public bool Equals(Job obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.author.Equals(obj.author);
        }
    }
    class Deal : Employ
    {
        public Deal(Author author) : base(author) { }
        public override string ToString()
        {
            return "Employ: " + author.ToString() + "\n\tType Of contract: Temporary contract\n";
        }
        public override int GetHashCode()
        {
            return author.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Deal tmp = obj as Deal;
            if (tmp == null)
            {
                return false;
            }
            return this.author.Equals(tmp.author);
        }
        public bool Equals(Deal obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.author.Equals(obj.author);
        }
    }
    abstract class Publication
    {
        protected string title;
        protected string author;
        protected int amount;
        public Publication(string title, string author, int amount)
        {
            this.title = title;
            this.author = author;
            this.amount = amount;
        }
        public string GetTitle()
        {
            return title;
        }
        public string GetAuthor()
        {
            return author;
        }
        public int GetAmount()
        {
            return amount;
        }
        public void SetAmount(int amount)
        {
            this.amount = amount;
        }
        public override string ToString()
        {
            return "Publication: " + title + "\n\tAuthor: " + author + "\n\tAmount: " + amount;
        }
    }
    abstract class Book : Publication
    {
        protected string isbn;
        public Book(string isbn, string title, string author, int amount) :
            base(title, author, amount)
        {
            this.isbn = isbn;
        }
        public string GetIsbn()
        {
            return isbn;
        }
        public override string ToString()
        {
            return base.ToString() + "\n\tType: Book\n\tISBN: " + isbn;
        }
    }
    class Bestseller : Book
    {
        public Bestseller(string isbn, string title, string author, int amount) :
            base(isbn, title, author, amount) { }
        public override string ToString()
        {
            return base.ToString() + "\n\tGenre: Bestseller";
        }
    }
    class Novel : Book
    {
        public Novel(string isbn, string title, string author, int amount) :
            base(isbn, title, author, amount) { }
        public override string ToString()
        {
            return base.ToString() + "\n\tGenre: Novel";
        }
    }
    class Detective : Book
    {
        public Detective(string isbn, string title, string author, int amount) :
            base(isbn, title, author, amount) { }
        public override string ToString()
        {
            return base.ToString() + "\n\tGenre: Detective";
        }
    }
    abstract class Newspaper : Publication
    {
        protected string nr;
        public Newspaper(string nr, string title, string author, int amount) :
            base(title, author, amount)
        {
            this.nr = nr;
        }
        public string GetNr()
        {
            return nr;
        }
        public override string ToString()
        {
            return base.ToString() + "\n\tType: Newspaper\n\tNR: " + nr;
        }
    }
    class Weekly : Newspaper
    {
        public Weekly(string nr, string title, string author, int amount) :
            base(nr, title, author, amount) { }
        public override string ToString()
        {
            return base.ToString() + "\n\tGenre: Weekly";
        }
    }
    class Monthly : Newspaper
    {
        public Monthly(string nr, string title, string author, int amount) :
            base(nr, title, author, amount) { }
        public override string ToString()
        {
            return base.ToString() + "\n\tGenre: Monthly";
        }
    }
    interface IPrintUnit
    {
        void Print(Publication pbl, List<Publication> pblList);
    }
    class BestsAndNovelPrint : IPrintUnit
    {
        public void Print(Publication pbl, List<Publication> pblList)
        {
            pblList.Add(pbl);
        }
    }
    class WeekAndMonthPrint : IPrintUnit
    {
        public void Print(Publication pbl, List<Publication> pblList)
        {
            pblList.Add(pbl);
        }
    }
    class DetectPrint : IPrintUnit
    {
        public void Print(Publication pbl, List<Publication> pblList)
        {
            pblList.Add(pbl);
        }
    }
    class ProgramDept
    {
        List<Employ> employList;
        List<Publication> publList;
        List<IPrintUnit> printUList;
        public ProgramDept()
        {
            employList = new List<Employ>();
            publList = new List<Publication>();
            printUList = new List<IPrintUnit>();

            IPrintUnit printUnit1 = new BestsAndNovelPrint();
            IPrintUnit printUnit2 = new WeekAndMonthPrint();
            IPrintUnit printUnit3 = new DetectPrint();
            printUList.Add(printUnit1);
            printUList.Add(printUnit2);
            printUList.Add(printUnit3);
        }
        public List<Employ> GetEmployList()
        {
            return employList;
        }
        public List<Publication> GetPublicationList() 
        {
            return publList;
        }
        public List<IPrintUnit> GetIPrintUnitList()
        {
            return printUList;
        }
        public bool AddEmploy(string firstName, string lastName, string pesel, string genre, string contractType)
        {
            bool res = false;
            Author tmpAuthor = new Author(firstName, lastName, pesel, genre);
            Employ tmpEmploy = null;
            if (contractType == "Job")
            {
                tmpEmploy = new Job(tmpAuthor);
            }
            else if (contractType == "Deal")
            {
                tmpEmploy = new Deal(tmpAuthor);
            }
            if (tmpEmploy != null)
            {
                employList.Add(tmpEmploy);
                res = true;;
            }
            return res;
        }
        public bool DelEmploy(int number)
        {
            bool res = false;
            if (number >= 0 && number < employList.Count)
            {
                employList.RemoveAt(number);
                res = true;
            }
            return res;
        }
        public bool DelPublication(int number)
        {
            bool res = false;
            if (number >= 0 && number < publList.Count)
            {
                publList.RemoveAt(number);
                res = true;
            }
            return res;
        }
        public bool BuildPublication(string title, string genre, string serialNum, int amount)
        {
            Author author = null;
            string strAuthor = "";
            bool flag = false;
            foreach (Employ item in employList)
            {
                if (item.GetAuthor().GetGenre() == genre)
                {
                    author = item.GetAuthor();
                    strAuthor = author.GetFirstName() + " " + author.GetLastName();
                    flag = true;
                    break;
                } 
            }
            if (flag)
            {
                CreatePublication(genre, serialNum, title, strAuthor, amount);
            }
            return flag;
        }
        public void CreatePublication(string genre, string serialNum, string title, string strAuthor, int amount)
        {
            Publication publication = null;
            if (genre == "Bestseller")
            {
                publication = new Bestseller(serialNum, title, strAuthor, amount);
                printUList[0].Print(publication, publList);
            }
            else if (genre == "Novel")
            {
                publication = new Novel(serialNum, title, strAuthor, amount);
                printUList[0].Print(publication, publList);
            }
            else if (genre == "Detective")
            {
                publication = new Detective(serialNum, title, strAuthor, amount);
                printUList[2].Print(publication, publList);
            }
            else if (genre == "Weekly")
            {
                publication = new Weekly(serialNum, title, strAuthor, amount);
                printUList[1].Print(publication, publList);
            }
            else if (genre == "Monthly")
            {
                publication = new Monthly(serialNum, title, strAuthor, amount);
                printUList[1].Print(publication, publList);
            }
        }
        public void WriterEmpl()
        {
            string line;
            string fileEmployName = "Employ.txt";
            StreamWriter sw = new StreamWriter(fileEmployName, false);
            try
            {
                if (employList.Count > 0)
                {
                    int countEmpl = 0;
                    foreach (Employ employ in employList)
                    {
                        line = "";
                        line += employ.GetAuthor().GetFirstName();
                        line += ">";
                        line += employ.GetAuthor().GetLastName();
                        line += ">";
                        line += employ.GetAuthor().GetPesel();
                        line += ">";
                        line += employ.GetAuthor().GetGenre();
                        line += ">";
                        if (employ is Job)
                        {
                            line += "Job";
                        }
                        else if (employ is Deal)
                        {
                            line += "Deal";
                        }
                        
                        countEmpl++;
                        if (countEmpl == employList.Count)
                        {
                            sw.Write(line);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }                 
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }
        }
        public void WriterPbl()
        {
            string line;
            string filePublicationName = "Publication.txt";
            StreamWriter sw = new StreamWriter(filePublicationName, false);
            try
            {
                if (publList.Count > 0)
                {
                    int countPbl = 0;
                    foreach (Publication publication in publList)
                    {
                        line = "";
                        if (publication is Bestseller)
                        {
                            line += "Bestseller";
                            line += ">";
                            Bestseller tmp = publication as Bestseller;
                            line += tmp.GetIsbn();
                        }
                        else if (publication is Novel)
                        {
                            line += "Novel";
                            line += ">";
                            Novel tmp = publication as Novel;
                            line += tmp.GetIsbn();
                        }
                        else if (publication is Detective)
                        {
                            line += "Detective";
                            line += ">";
                            Detective tmp = publication as Detective;
                            line += tmp.GetIsbn();
                        }
                        else if (publication is Weekly)
                        {
                            line += "Weekly";
                            line += ">";
                            Weekly tmp = publication as Weekly;
                            line += tmp.GetNr();
                        }
                        else if (publication is Monthly)
                        {
                            line += "Monthly";
                            line += ">";
                            Monthly tmp = publication as Monthly;
                            line += tmp.GetNr();
                        }
                        line += ">";
                        line += publication.GetTitle();
                        line += ">";
                        line += publication.GetAuthor();
                        line += ">";
                        line += publication.GetAmount().ToString();
                        
                        countPbl++;
                        if (countPbl == publList.Count)
                        {
                            sw.Write(line);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
        public void ReaderEmpl()
        {
            string firstName;
            string lastName;
            string pesel;
            string genre;
            string contractType;

            string line;
            string fileEmployName = "Employ.txt";
            StreamReader sr = new StreamReader(fileEmployName);

            if (File.Exists(fileEmployName))
            {
                try
                {
                    employList.Clear();
                    while ((line = sr.ReadLine()) != null)
                    {         
                        string[] words = line.Split(new string[]{">"}, StringSplitOptions.RemoveEmptyEntries);
                        firstName = words[0];
                        lastName = words[1];
                        pesel = words[2];
                        genre = words[3];
                        contractType = words[4];

                        AddEmploy(firstName, lastName, pesel, genre, contractType);
                    }
                }
                catch(Exception e)
                {
                    employList.Clear();
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
            }     
        }
        public void ReaderPbl()
        {
            string genre;
            string serialNum;
            string title;
            string author;
            string amountStr;
            int amount;
           
            string line;
            string filePublicationName = "Publication.txt";
            StreamReader sr = new StreamReader(filePublicationName);

            if (File.Exists(filePublicationName))
            {
                try
                {
                    publList.Clear();
                    while ((line = sr.ReadLine()) != null)
                    {         
                        string[] words = line.Split(new string[]{">"}, StringSplitOptions.RemoveEmptyEntries);
                        genre = words[0];
                        serialNum = words[1];
                        title = words[2];
                        author = words[3];
                        amountStr = words[4];

                        bool isConvert = Int32.TryParse(amountStr, out amount);
                        if (!isConvert)
                        { 
                            throw new Exception("Parse exception");
                        }

                        CreatePublication(genre, serialNum, title, author, amount);
                    }
                }
                catch(Exception e)
                {
                    publList.Clear();
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();
                    }
                }
            }     
        }
    }
    class SaleDept
    {
        ProgramDept programDept;
        public SaleDept()
        {
            programDept = new ProgramDept();
        }
        public ProgramDept GetProgramDept()
        {
            return programDept;
        }
        public bool SellProduct(int index, int amount)
        {
            bool res = false;
            index -= 1;
            Publication tmpPbl = programDept.GetPublicationList()[index];
            int tmpAmount = tmpPbl.GetAmount();
            if (amount == 0)
            {
                res = false; 
            }
            else if (tmpAmount > amount)
            {
                tmpAmount = tmpAmount - amount;
                programDept.GetPublicationList()[index].SetAmount(tmpAmount);  
                res = true;
            }
            else if (tmpAmount == amount)
            {
                tmpAmount = 0;
                res = programDept.DelPublication(index);
            }
            return res;
        }
        public bool SendRequest(string title, string genre, string serialNum, int amount)
        {
            return programDept.BuildPublication(title, genre, serialNum, amount);
        }
    }
}
