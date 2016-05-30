using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();
            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged;


            //GetBookName(book);
            //finally
            //{

            //}
            //catch(NullReferenceException ex)
            //{
            //    Console.WriteLine("Something went wrong!");
            //}


            //book.Name = null;
            // book.Name = "Scotts Grade Book";
            //book.Name = "Grade Book";
            AddGrades(book);
            SaveGrades(book);
            WriteGrades(book);

        }

        private static IGradeTracker CreateGradeBook()
        {

            



            return new ThrowAwayGradeBook();
        }

        private static void WriteGrades(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            //Console.WriteLine(book.Name);
            WriteResult("Average", stats.averageGrade);
            WriteResult("Highest", (int)stats.highestGrade);
            WriteResult("Lowest", stats.lowestGrade);
            WriteResult(stats.Description, stats.Letter);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(85.5f);
            book.AddGrade(71);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //static void OnNameChanged(object sender, NameChangedEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}




        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}", description, result);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result:F2}", description, result);
        }
    }
}
