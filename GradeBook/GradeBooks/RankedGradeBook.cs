using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GradeBook;


namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
           
            var twentyPercent = Students.Count / 5;

            var orderedDescendingAverageGrades =
                     from Student in Students
                     orderby Student.AverageGrade descending
                     select Student.AverageGrade;

            var orderedList = orderedDescendingAverageGrades.ToList();

            if (orderedList[twentyPercent - 1] <= averageGrade)
                return 'A';
            else if (orderedList[(twentyPercent * 2) - 1] <= averageGrade)
                return 'B';
            else if (orderedList[(twentyPercent * 3) - 1] <= averageGrade)
                return 'C';
            else if (orderedList[(twentyPercent * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
                
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
