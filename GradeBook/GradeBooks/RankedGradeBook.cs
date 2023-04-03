using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.GradeBooks;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            int top20Percent = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (averageGrade >= grades[top20Percent - 1])
            {
                return 'A';
            }
            else if (averageGrade >= grades[(top20Percent * 2) - 1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[(top20Percent * 3) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[(top20Percent * 4) - 1])
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
        public override void CalculateStatistics()
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }           
                base.CalculateStatistics();           
        }
        public override void CalculateStudentStatistics(string name)
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}