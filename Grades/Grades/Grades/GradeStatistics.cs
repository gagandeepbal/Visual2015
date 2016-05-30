using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeStatistics
    {

        public GradeStatistics()
        {
            highestGrade = 0;
            lowestGrade = float.MaxValue;
        }

        public string Description
        {
            get
            {
                string result;
                switch (Letter)
                {
                    case "A":
                        result = "Excellent";
                        break;
                    case "B":
                        result = "Good";
                        break;
                    case "C":
                        result = "Average";
                        break;
                    case "D":
                        result = "Below Average";
                        break;
                   default:
                        result = "Failing";
                        break;
                }
                return result;
            }
        }

        public string Letter
        {
            get
            {
                string result;
                if(averageGrade >= 90)
                {
                    result = "A";
                }
                else if(averageGrade >=80)
                {
                    result = "B";
                }
                else if(averageGrade >= 70)
                {
                    result = "C";
                }
                else if(averageGrade >= 60)
                {
                    result = "D";

                }
                else
                {
                    result = "F";
                }
                return result;
            }
        }

        public float averageGrade;
        public float lowestGrade;
        public float highestGrade;
    }
}
