/**********************************************************************************************
 Name:				Rutvik Patel
 Student number:	040915445
 Lab:				1

 **********************************************************************************************/


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Lab1
{

    class App
    {
        public static int userInput;

        //Save Words into List
        public static List<string> fileWord = new List<string>();

        static void Main(string[] args)
        {
            bool temp = true;
            do
            {
                Console.WriteLine("Hello World!!! My First Application of C# \n");
                Console.WriteLine("Options" + "----------");
                Console.WriteLine("1 - Import Words From File" +
                                "\n2 - Bubble Sort words" +
                                "\n3 - LINQ / Lambda sort words" +
                                "\n4 - Count the Distinct Words" +
                                "\n5 - Take the first 10 words" +
                                "\n6 - Get the number of words that start with 'j' and display the count" +
                                "\n7 - Get and display of words that end with 'd' and display the count" +
                                "\n8 - Get and display of words that are greater than 4 characters long, and display the count" +
                                "\n9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count" +
                                "\nx – Exit\n");

                Console.WriteLine("Make a selection: ");
                string select = Console.ReadLine();
                Console.WriteLine("\n");
                Console.Clear();

                switch (select)
                {
                    case "1":
                        getInput(fileWord);
                        Console.WriteLine("Reading Words complete");
                        Console.WriteLine("Number of words found: " + fileWord.Count());
                        Console.WriteLine("\n\n");
                        break;

                    case "2":
                        Bubble(fileWord);// Bubble sort
                        break;

                    case "3":
                        SortbyLinq();// Linq || Lamada sort
                        break;

                    case "4":
                        countDis(); // Count the distinct words
                        break;

                    case "5":
                        First_ten(); // take the first 10 words
                        break;

                    case "6":
                        Jletter(); // number of words start from the 'J' letter
                        break;

                    case "7":
                        Dletter(); // Get and display the words that end with ‘d’ and display the count
                        break;

                    case "8":
                        MoreFour(); // Get and display of words that are greater than 4 characters long, and display the count
                        break;

                    case "9":
                        LessThree(); //  Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count
                        break;

                    case "x":
                        Console.WriteLine("Thanks for choosing my program :)");
                        temp = false;
                        break;

                    default:
                        Console.WriteLine("Please enter valid input!!!!!");
                        break;
                }

                Console.WriteLine();
            } while (temp);
        }

        // Take input from user and store 
        public static void getInput(List<string> fileWord)
        {
            string line;
            userInput = 0;

            Console.WriteLine("Reading Words");

            try
            {
                using (StreamReader readFile = new StreamReader("Words.txt"))
                {
                    while ((line = readFile.ReadLine()) != null)
                    {
                        fileWord.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file couldn't be read !!!");
                Console.WriteLine(e.Message);
            }

        }

        //	Sort the words as Bubble sorting method

        public static IList<string> Bubble(IList<string> fileWord)
        {
            // List  instade of array 
            // exception handeling

            var tempList = fileWord.ToList();
            int n = tempList.Count();

            Stopwatch timer = new Stopwatch();
            timer.Start();
            var didswap = true;

            try
            {

                while (didswap)
                {
                    didswap = false;

                    for (var i = 0; i < n - 1; i++)
                    {
                        var left = tempList[i];
                        var right = tempList[i + 1];

                        if (left.CompareTo(right) > 0)
                        {
                            var temp = tempList[i];
                            tempList[i] = tempList[i + 1];
                            tempList[i + 1] = temp;
                            didswap = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The list couldn't be sort !!!");
                Console.WriteLine(e.Message);
            }

            timer.Stop();
            TimeSpan sec = timer.Elapsed;
            Console.Write("Time elasped: " + sec.Milliseconds + " ms" + "\n\n");

            return tempList;

        }

        public static void SortbyLinq()
        {
            // Linq sort for words

            Stopwatch sec = new Stopwatch();
            sec.Start();

            var total = from words in fileWord orderby words.ToString() select words;

            foreach (var i in total) { }
            sec.Stop();

            TimeSpan time = sec.Elapsed;
            Console.Write("Time elapsed: " + time.Milliseconds + " ms" + "\n\n");

        }

        public static void countDis()
        {
            // Count the distinct words
            var num = fileWord.Count();
            num = 0;
            // Distinct() method filters special words from list
            var dn = fileWord.Distinct();

            foreach (var i in dn)
            {
                num++;
            }
            Console.Write("The number of distinct words is: " + num + "\n\n");
        }


        public static void First_ten()
        {
            // Take() method takes the first words and value 10 in perameter to take 10 
            var ten = fileWord.Take(10);
            foreach (var i in ten)
            {
                Console.WriteLine(i);
            }

        }

        public static void Jletter()
        {
            //Get the number of words that start with ‘j’ and display the count
            var num = fileWord.Count();
            num = 0;

            var jstart = from words in fileWord where words.StartsWith("j") select words;

            foreach (var i in jstart)
            {
                num++;
                Console.WriteLine(i);
            }

            Console.Write("Number of words that start with 'j': " + num + "\n\n");
        }

        public static void Dletter()
        {
            //	Get and display the words that end with ‘d’ and display the count
            var num = fileWord.Count();
            num = 0;
            var Dend = from words in fileWord where words.EndsWith("d") select words;

            foreach (var i in Dend)
            {
                num++;
                Console.WriteLine(i);
            }
            Console.Write("Number of words that end with 'd': " + num + "\n\n");
        }

        public static void MoreFour()
        {
            //Get and display of words that are greater than 4 characters long, and display the count
            var num = fileWord.Count();
            num = 0;
            var four = from words in fileWord where words.Length > 4 select words;

            foreach (var i in four)
            {
                num++;
                Console.WriteLine(i);
            }
            Console.Write("Number of words longer than 4 characters:" + num + "\n\n");
        }

        public static void LessThree()
        {
            //Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count		
            var num = fileWord.Count();
            num = 0;
            var three = from words in fileWord where words.StartsWith("a") && words.Length < 3 select words;

            foreach (var i in three)
            {
                num++;
                Console.WriteLine(i);
            }
            Console.Write("Number of words longer less than 3 characters and start with 'a': " + num + "\n\n");
        }


    }// end of class

}// end of namespace