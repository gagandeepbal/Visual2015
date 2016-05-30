using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook()
        {
            grades = new List<float>();
        }


        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");
            GradeStatistics stats = new GradeStatistics();

            stats.highestGrade = 0;

            float sum = 0;

            foreach (float grade in grades)
            {
                if (grade > stats.highestGrade)
                {
                    stats.highestGrade = Math.Max(grade, stats.highestGrade);

                }
                sum = sum + grade;
                stats.lowestGrade = Math.Min(grade, stats.lowestGrade);
            }

            stats.averageGrade = sum / grades.Count;


            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }


        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        protected List<float> grades;
    }
}
