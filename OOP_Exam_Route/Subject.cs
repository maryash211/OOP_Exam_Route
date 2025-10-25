using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_Exam_Route
{
    internal class Subject 
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam SubjectExam { get; set; }

        public void CreateExam()
        {
            Console.WriteLine("\n\t#\t Exam Creation \t\t# ");
            int examType, time, NumOfQuestions;
            bool isparsed;
            do
            {
                Console.Write("Choose the type of Exam : \n1 -> Practical\n2 -> Final\ntype: ");
                isparsed = int.TryParse(Console.ReadLine(), out examType);
            }
            while (!isparsed || (examType != 1 && examType != 2));

            do
            {
                Console.Write("Enter the time of the exam: ");
                isparsed = int.TryParse(Console.ReadLine(), out time);
            }
            while (!isparsed || (time <0 ));

            do
            {
                Console.Write("Enter the number of questions: ");
                isparsed = int.TryParse(Console.ReadLine(), out NumOfQuestions);
            }
            while (!isparsed || (NumOfQuestions < 0));

            if (examType == 1)
            {
                SubjectExam = new PracticalExam(time, NumOfQuestions);
            }
            else
            {
                SubjectExam = new FinalExam(time, NumOfQuestions);
            }
            Console.Clear();
            SubjectExam.CreateQuestionList(); 
        }

        public override string ToString()
        {
            return $"Subject name = {SubjectName}\t Subject id = {SubjectId}";
        }

    }
}
