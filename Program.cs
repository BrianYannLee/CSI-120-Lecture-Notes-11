//Programmer: Brian Lee
//Date: 05/29/2024

//Title: Lecture Notes 11
using System.Text.RegularExpressions;

namespace CSI_120_Lecture_Notes_11
{
    internal class Program
    {
        //--------------INITILIZATION---------------
        #region
        static string[] firstName = { "Alice", "Bob", "Charlie", "David", "Eva" };
        static string[] lastName = { "Smith", "Johnson", "Williams", "Jones", "Brown" };
        #endregion
        //------------------MAIN-------------------
        static void Main(string[] args)
        {
            try
            {
                MainMenu();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error has occured: {ex.Message}");
            }
        }//end of Main
         //------------------MENU METHODS----------------------
        #region
        public static void MainMenu()
        {
            string userInputLastName;
            int userMenuInput;
            bool exit = false;

            const int firstChoice = 1;
            const int lastChoice = 3;

            while(!exit)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Search Students by Last Name");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your choice: ");
                userMenuInput = userMenuInputCheck(firstChoice, lastChoice);
                switch (userMenuInput)
                {
                    case 1:
                        DisplayAllStudents();
                        break;
                    case 2:
                        Console.Write("Enter the Last Name you want to search: ");
                        userInputLastName = userStringInputCheck();
                        EnrolledInClassByLastName(userInputLastName);
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }
            }
            Console.WriteLine();
        }//end of MainMenu
        public static int userMenuInputCheck(int firstChoice, int lastChoice)  //Method to check user Input for Menu.
        {
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < firstChoice || userInput > lastChoice)
            {
                Console.WriteLine("Inalid Input. Try Again.");
            }
            Console.WriteLine();
            return userInput;
        }//end of userIntInputCheck
        public static string userStringInputCheck()
        {
            string userStringInput;
            string pattern = @"^[a-zA-Z]+$";
            while (!Regex.IsMatch(userStringInput = Console.ReadLine(), pattern))
            {
                Console.WriteLine("Invalid Input. Try Again");
            }
            Console.WriteLine();
            return userStringInput;
        }//end of userStringCheck
        #endregion
        //--------------STUDENT DISPLAY METHODS--------------------
        #region
        public static string FullName(int studentIndex)
        {
            string fullName;
            fullName = firstName[studentIndex] + " " + lastName[studentIndex];
            return fullName;
        }//end of FullName
        public static void DisplayStudentInformation(int studentIndex)
        {
            Console.WriteLine($"Student Id: {studentIndex}");
            Console.WriteLine($"Full Name: {FullName(studentIndex)}");
            Console.WriteLine($"First Name: {firstName[studentIndex]}");
            Console.WriteLine($"Last Name: {lastName[studentIndex]}");
        }//end of DisplayStudentInformation
        public static void DisplayAllStudents()
        {
            for (int i = 0; i < firstName.Length; i++)
            {
                DisplayStudentInformation(i);
                Console.WriteLine();
            }
            Console.WriteLine();
        }//end of DisplayAllStudents

        #endregion
        //------------STUDENT SEARCH METHODS-------------
        #region
        public static void EnrolledInClassByLastName(string studentsLastName)
        {
            int index = Array.FindIndex(lastName,name => name.Equals(studentsLastName, StringComparison.OrdinalIgnoreCase));

            if(index >= 0)
            {
                Console.WriteLine($"Name found at index: {index}");
                DisplayStudentInformation(index);
            }
            else
            {
                Console.WriteLine("Name not found");
            }
            Console.WriteLine();
        }//end of EnrolledInClassByLastName
        #endregion
    }//end of Program
}//end of namespace
