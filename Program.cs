using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4Assignment
{
   
    //Array of size N
    //so we can use a list to accept inputs and den convert it to and array.
    //Accepting inputs(Scores of students) and storing it in and list.
    //Note Inputs must be converted to double so that calculations can be done.
    //When all inputs have been stored in the array calculations can begin.
    //use a for loop to loop through the array and get each score out..
    //basing all score out of 100 to get the average we use the formular
    // converting scores to base 10 and adding them in a variable 
    
    class Program
    {
        static void Main(string[] args)
        {
            studentCgpaCalculator myStudentCgpaCalculator = new studentCgpaCalculator();
            myStudentCgpaCalculator.acceptInputAndStoreInList();
            myStudentCgpaCalculator.cgpaCalculation();
        }
    }

   public class studentCgpaCalculator
   {
       string _studentName;
       int _score;
       string studentScore;
       List<double> _studentScoreList = new List<double>();
       List<double> base10ScoreStoredInList = new List<double>();
       double _cgpaScore;
       double cgpaPercentage;
       
       
       public void acceptInputAndStoreInList()
       {
            string reply = "NO";
            bool invalidInput = false;
           Console.WriteLine("Welcome To the student Cgpa Calculator");
           Console.WriteLine("We need your name and scores.");
           Console.WriteLine("Please input Your Name\n");
           _studentName = Console.ReadLine();
          
           //creating a list to store the scores coming in by the user.
           do{
           Console.WriteLine("And scores to calculate your Cgpa and Cgpa Percentage.");
           string studentScore =  Console.ReadLine();
           if(Int32.TryParse(studentScore, out _score))
           {
                _score = Convert.ToInt32(studentScore);
                _studentScoreList.Add(_score);
                break;
           }else
           {
               Console.WriteLine("Invalid Score Provided..Input Again");
               invalidInput = true;
           }
           }while(invalidInput);
           
           
           do{
            Console.WriteLine("Would you like to add More Scores. YES OR NO");
            reply = Console.ReadLine().ToUpper();
            if(reply == "YES")
            {
            Console.WriteLine("Add Score");
            studentScore = Console.ReadLine();
            _score = Convert.ToInt32(studentScore);
            _studentScoreList.Add(_score);
            }
            }while(reply == "YES");

           Console.WriteLine("Thank you all your scores have been stored.");
       }

       public void cgpaCalculation()
       {    
           double[] studentScoreListConvertedToArray = _studentScoreList.ToArray();
           foreach(var singleScore in studentScoreListConvertedToArray)
           {
               double base10Score = singleScore / 10;            
               base10ScoreStoredInList.Add(base10Score);
               
           }
           double[] base10ScoreArray = base10ScoreStoredInList.ToArray();
           double totalScore = base10ScoreArray.Sum();
           _cgpaScore = totalScore / base10ScoreArray.Length;
            cgpaPercentage = _cgpaScore * 9.5;
           Console.WriteLine($"[Mr/Mrs/Miss] : {_studentName}\nYour Cgpa score is : {_cgpaScore:F2}.");       
           Console.WriteLine($"Your cgpa percentage = {cgpaPercentage:F2}%\nThank you.");
       }
    }
}
