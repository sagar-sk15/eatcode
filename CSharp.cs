using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp
{
    public class CSharp
    {
        string strr = "sagar k";
        

        int[] s = new int[] { 1, 2 };
        int[] aa = { 1, 2 };
        int[] k = new int[4] { 1, 2, 3, 4 };
        // as passing parameter 
        //MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
        //LongestCommonPrefix(new string[] { "flower", "flow", "flight" });

        //string array initilisation options
        string[] str = { "carrot", "fox", "explorer" };


        string[] itemsString = new string[]{"Item1", "Item2", "Item3", "Item4"};

        List<string> mylist = new List<string>(new string[] { "element1", "element2", "element3" });
        List<string> mylist1 = new List<string>() { "element1", "element2", "element3" };

        List<int> list = new List<int>(new int[]{ 1, 2 });
        List<int> list1 = new List<int>(){ 1, 2 };
        //List with Class object
        //List<Test> list1 = new List<Test>()
        //{
        //    new Test(){ A = 1, B = "B1" },
        //    new Test(){ A = 2, B = "B2" }
        //};

        // Two 2D/rectangular array with same Number of columns in every row
        //one [] with comma
        // size is optional column length is same for every row
        string[,] twoDArray = new string[,]
        {
            {"s","k"},
            {"A","k"}
        };

        int[,] twoDArrayInt = new int[2, 3]
        {
            {1,2,3},
            {4,5,6}
        };


        int[,] twoDArrayInt1 = {
            {1,2,3},
            {4,5,6}
       };


        //column in each row may differ
        // two [] []
        //size for row is optional //column size can not be given
        // new string/int [] is required within new {} i.e. single dimensional array defn withing new of jagged array
        string[][] jagged = new string[2][] {
        new string[] {"val1","val2"},
        new string[] {"val1bis"}
        };

        string[][] jagged1 =  {
        new string[] {"val1","val2"},
        new string[] {"val1bis"}
        };

        string[][] jaggedwithRow = new string[3][] {
        new string[] {"val1","val2"},
        new string[] {"val1bis"},
        new string[] {"val1bis","s","k"}
        };
        //jaggeed array as argument -- > rotateMatrixClockWise(int[][] matrix)

        //see fun function below
        int[][] jaggedInt = new int[3][];


        public void Fun()
        {
            twoDArrayInt[0, 0] = 1;
            int numRows = twoDArrayInt.GetLength(0);
            int numColumns = twoDArrayInt.GetLength(1);

            for (int row = 0; row < numRows; ++row)
            {
                for (int col = 0; col < numColumns; ++col)
                { }
            }

            int uBound0 = twoDArrayInt.GetUpperBound(0);
            int uBound1 = twoDArrayInt.GetUpperBound(1);
            for (int i = 0; i <= uBound0; i++)
            {
                for (int j = 0; j <= uBound1; j++)
                { }
            }

            jaggedInt[0] = new int[2];
            jaggedInt[0][0] = 1;
            jaggedInt[0][1] = 2;
            jaggedInt[1] = new int[1];
            jaggedInt[2] = new int[3] { 3, 4, 5 };

            //this assignment of string array to list is possible in Function only;

            List<string> mylist = new List<string>(itemsString);
            int aaa = 0;
            StringBuilder builder = new StringBuilder(aaa);
            //StringBuilder vs string ???


        }

        static void IndexOf()
        {
            // Input.
            const string s = "I have a cat";

            // Location of the letter c.
            int i = s.IndexOf('c');//-->8

            // Remainder of string starting at position i i.e. c.
            string d = s.Substring(i);
            Console.WriteLine(d);//-->cat

            //e.g flow.IndextOf(flower) will return -1
            //as flower is not present in flow word
            
        }
        public static void RoundingEg()
        {
            var roundedA = Math.Round(1.1, 0); // Output: 1
            var roundedB = Math.Round(10692472.50, 0, MidpointRounding.AwayFromZero); // Output: 2
            var roundedC = Math.Round(10692472.50, 0, MidpointRounding.ToEven); // Output: 2

            var roundedD = Math.Round(2.5, 0); // Output: 2
            var roundedE = Math.Round(2.5, 0, MidpointRounding.AwayFromZero); // Output: 3

            var roundedF = Math.Round(10692472.49, 0, MidpointRounding.AwayFromZero); // Output: 3
            var roundedG = Math.Round(10692472.49, 0, MidpointRounding.ToEven); // Output: 3
            Console.WriteLine("A: " + roundedA);

            Console.WriteLine("B:AwayFromZero: " + roundedB);
            Console.WriteLine("C:ToEven: " + roundedC);

            Console.WriteLine("D:AwayFromZero: " + roundedD);
            Console.WriteLine("E:ToEven: " + roundedE);

            Console.WriteLine("F:AwayFromZero: " + roundedF);
            Console.WriteLine("G: To Even: " + roundedG);

            Console.ReadLine();
        }
    }
}
//https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
//https://www.softwaretestinghelp.com/c-sharp/oops-concepts-in-csharp/
// yeild return : https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/
//https://code-maze.com/csharp-basics-access-modifiers/
// Indexes are always zero based but not length
// in 2D array function that return index -->GetUpperBound() == GetLength() -1;

// what is .net Framework ?
// -> .Net Framework is a software development platform developed by Microsoft for
// building and running Windows applications.
// The .Net framework consists of developer tools, programming languages,
// and libraries to build desktop and web applications. (web services, games)

// what is .net core ?
// ->.NET Core is a new version of . NET Framework which is an open-source,
// created by Microsoft and can run on various platform such as Windows, Linux, and macOS

// C# is typeSafe and object oriented Managed programming language:
//--> Managed code is a code whose execution is manageed by CLR.(CLR : IL Code to Native COde (Just-in-time compilationn).
// --> Type Safe : Type safety in .NET has been introduced to prevent the objects of
// one type from sneaking into the memory assigned for the other object.
// Writing safe code also means to prevent data loss during conversion of one type to another
//e.g : 
public class MyType
{
    public int Prop { get; set; }
}
public class YourType
{
    public int Prop { get; set; }
    public int Prop1 { get; set; }

    
}
//MyType obj = new MyType();obj would be referencing the 4 bytes of space 
//YourType obj1 = (YourType)obj; // Here we will get compile time error  

// OOP : is a programming structure where programs are organised around objects.
// Class: depicts structure of data , how data is stored and manged within the program. 

//C# 9.0 features
//https://www.codemag.com/Article/2010032/Introducing-C
// top level statments, init only setters, fit and finish,record type
//https://lukemerrett.com/record-types-in-c-9-0/

// == equality comparer on objects (class) returns true if objects are refercing to same type
//it does not check for actual values within array or properties