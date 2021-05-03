using System;
using System.Collections.Generic;
using System.Linq;

namespace GPACalculate.Classes
{
    public class Db
    {
        private List<Course> CourseTable;

        private Db()
        {
            this.CourseTable = new List<Course>();
            
        }

        public static Db Initialize()
        {
            return new Db();
        }

        public void AddCourse(Course c)
        {
            this.CourseTable.Add(c);
        }

        /// <summary>
        /// removeCourse("svy101") when the courseCode in db is SVY101
        /// </summary>
        /// <param name="courseCode"> code of coure to remove</param>
        public void RemoveCourse(string courseCode)
        {
            Course c = this.CourseTable.FirstOrDefault(c => c.CourseCode.ToLower() == courseCode.ToLower());
            this.CourseTable.Remove(c);
        }


        public IEnumerable<Course> getAllCourses()
        {
            return this.CourseTable;
        }

        /// <summary>
        /// in the works
        /// </summary>
        /// <param name="c"></param>
        public void UpdateCourse(Course c)
        {

        }

        string letterGrade;
        int totalUnit = 0;
       double QualityPoint = 0;
        double cgpa = 0; 
       double newValue = 0;

       int divide = 0;

        
        public void CalculateGpa()
        {
            foreach (var course in CourseTable)
            {
                var scores = course.CourseScore;
                if (scores > 70)
                {
                    letterGrade = "A";
                    QualityPoint = 5;
                }
                else if (scores >= 60 && scores <= 69)
                {
                    letterGrade = "B";
                    QualityPoint = 4;
                }
                else if (scores >= 50 && scores <= 59)
                {
                    letterGrade = "C";
                    QualityPoint = 3;
                }
                else if (scores >= 46 && scores <= 49)
                {
                    letterGrade = "D";
                    QualityPoint = 2;
                }
                else if (scores >= 40 && scores <= 44)
                {
                    letterGrade = "E";
                    QualityPoint = 2;
                }
                else
                {
                    letterGrade = "F";
                    QualityPoint = 0;
                }
                    divide = course.NumberOfUnits;
                    QualityPoint = divide * QualityPoint;
                    newValue = QualityPoint + newValue;
                    totalUnit += course.NumberOfUnits;

                
                Console.WriteLine($"{course.CourseCode}                        {course.CourseScore}                       {course.NumberOfUnits}                        {letterGrade}");

            }
            cgpa = newValue / totalUnit;
            Console.WriteLine($"This is total unit {totalUnit}");
            Console.WriteLine($"this is the quality point {newValue}");
            Console.WriteLine($"Your GPA {Math.Round(cgpa, 2)}");
        }
    }
}