using System;
using System.IO;

namespace Assignment6
{
    //Program 1
    class Books
    {
        public string BookName;
        public string AuthorName;

        public Books(string bname, string aname)
        {
            BookName = bname;
            AuthorName = aname;
        }

        public void Display()
        {
            Console.WriteLine("Book Name: " + BookName);
            Console.WriteLine("Author: " + AuthorName);
            Console.WriteLine();
        }
    }
    class BookShelf
    {
        Books[] b = new Books[5];

        public Books this[int index]
        {
            get { return b[index]; }
            set { b[index] = value; }
        }
    }

    class FilePrograms
    {
        static FileStream fs;

        static void Main()
        {
            //Program 1
            BookShelf shelf = new BookShelf();
            shelf[0] = new Books("The Alchemist", "Paul");
            shelf[1] = new Books("Wings of Fire", "A.P.J Abdul Kalam");
            shelf[2] = new Books("1984", "George");
            shelf[3] = new Books("Rich Dad Poor Dad", "Robert");
            shelf[4] = new Books("Harry Potter", "J.K Rowling");
            Console.WriteLine("Books in Shelf:\n");
            for (int i = 0; i < 5; i++)
            {
                shelf[i].Display();
            }

            //Program 2
            WriteArray();
            ReadArray();

            //Program 3
            CountLines();
            Console.Read();
        }

        //Program 2 - Write
        public static void WriteArray()
        {
            fs = new FileStream("MyFile.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            Console.WriteLine("Enter number of strings:");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr = new string[n];
            Console.WriteLine("Enter the strings:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Console.ReadLine();
                sw.WriteLine(arr[i]);
            }
            sw.Close();
            fs.Close();
        }

        //Program 2 - Read
        public static void ReadArray()
        {
            fs = new FileStream("MyFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            Console.WriteLine("\nFile Contents:\n");
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }

            sr.Close();
            fs.Close();
        }
         
        //Program 3 - Count the number of lines
        public static void CountLines()
        {
            fs = new FileStream("MyFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            int count = 0;
            string str = sr.ReadLine();
            while (str != null)
            {
                count++;
                str = sr.ReadLine();
            }
            Console.WriteLine("\nNumber of lines: " + count);
            sr.Close();
            fs.Close();
        }
    }
}