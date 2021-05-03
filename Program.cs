using System.Linq;
using System;
using GPACalculate.Classes;

namespace GPACalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            // a program that calculates gradePoint average 
            // Input -->a series of  course codes,a series of scores for each course code.
            // a gradePointCalculator that calculates the GradePoint of a course given its score
            // some sort of dashboard that prints grade points
            //a menu that prompts the users on what they want to do
            // i can probably use an enum to check my current stage
            Menu menu = new Menu();
            menu.setCurrentStage(1);
            Db appDb = Db.Initialize();

            bool appIsRunning = true;
            // always perform this when the user is in top menu

            while (appIsRunning)
            {
                while (menu.getCurrentStage() == 1)
                {
                    Menu.PromptUser("What Would you like to Do Today : ?");
                    Menu.PromptUser("1. Add Courses To DB : ");
                    Menu.PromptUser("2. Calculate Grade Point Averages Of Courses In Db : ");
                    Menu.PromptUser("3. Exit");
                    string selectedMenuOption = Console.ReadLine();
                    switch (selectedMenuOption)
                    {
                        case "1":
                            menu.setCurrentStage(2);
                            break;


                        case "2":
                            menu.setCurrentStage(3);
                            break;
                        case "3":
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                }

                while (menu.getCurrentStage() == 2)
                {
                    // we want to tell the user to add a set of courses and their scores
                    // and then we want to store those courses in some sort of Database/ collection
                    // we need to know how many courses the user is entering a score for ..
                    // we can design a prompt that runs for each of the courses 

                    Menu.PromptUser("Select An Option :");
                    Menu.PromptUser("Enter Number Of Courses (enter a number): ");
                    Menu.PromptUser("Back To Main Menu (b)");
                    string input = Console.ReadLine();
                    int numberOfCourses;
                    if (input.ToLower() == "b")
                    {
                        menu.setCurrentStage(1);
                    }
                    else if (Int32.TryParse(input, out numberOfCourses))
                    {
                        for (int i = 1; i <= numberOfCourses; i++)
                        {
                            Menu.PromptUser($"Enter A Course Code For Course {i} : ");
                            string courseCode = Console.ReadLine();
                            Menu.PromptUser($"Enter a Score for {courseCode} : ");
                            double score = Convert.ToDouble(Console.ReadLine());

                            Menu.PromptUser($"Enter a number Of Units for {courseCode} : ");
                            int units = Convert.ToInt32(Console.ReadLine());
                            appDb.AddCourse(new Course(courseCode, score, units));
                        }

                        menu.setCurrentStage(1);
                    }


                }

                while (menu.getCurrentStage() == 3)
                {

                    if (appDb.getAllCourses().Any())
                    {
                        
                        Console.WriteLine("Course Code    ||      Course Grade    ||     Course Unit    ||     Course Letter Grade");
                        appDb.CalculateGpa();
                    }
                    else
                    {
                        Console.WriteLine("No grade found int the database.Please provide a grade");
                        menu.setCurrentStage(1);
                    }
                    break;
                }
                menu.setCurrentStage(1);
            }

        }
    }
}
