using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        //whichever averageGrade is passed as a parameter to the method GetLetterGrade you will get a corresponding grade for that value
        public override char GetLetterGrade(double averageGrade)
        {
           //get the value of each grade and order
           //find which 20% bracket the averageGrade input falls in the list
           //return a corresponding grade
          
            if (Students.Count < 5)
                throw new InvalidOperationException();

            var twentyPercent = Students.Count / 5;
            
            List<double> allGrades = new List<double>() { averageGrade };

            if (allGrades.Count == Students.Count)
            {
                for (var i = 1; i <= 5; i++)
                {
                    var orderedGrades =
                     from a in allGrades
                     orderby a descending
                     select a;
                }
            }

            switch (gradeBook)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
                case 5:
                    return 'E';
            }
            
            

            
            
                return 'F';
        }
    }
}
