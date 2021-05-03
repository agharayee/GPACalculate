namespace GPACalculate.Classes
{
    public class Course
    {
        public string CourseCode { get; private set; }
        public double CourseScore { get; private set; }
        public int NumberOfUnits { get; private set; }

        public Course(string code, double score, int numberOfUnits)
        {
            this.CourseCode = code;
            this.CourseScore = score;
            this.NumberOfUnits = numberOfUnits;

        }
    }
}