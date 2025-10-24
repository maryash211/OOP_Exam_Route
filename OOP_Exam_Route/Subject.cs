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
            int examType, time, NumOfQuestions;
            bool isparsed;
            do
            {
                Console.WriteLine("Enter the type of Exam : \n1 -> Practical\n2 -> Final");
                isparsed = int.TryParse(Console.ReadLine(), out examType);
            }
            while (!isparsed || (examType != 1 || examType != 2));

            do
            {
                Console.WriteLine("Enter the time of the exam: ");
                isparsed = int.TryParse(Console.ReadLine(), out time);
            }
            while (!isparsed || (time <0 ));

            do
            {
                Console.WriteLine("Enter the number of questions: ");
                isparsed = int.TryParse(Console.ReadLine(), out NumOfQuestions);
            }
            while (!isparsed || (NumOfQuestions < 0));

            if (examType == 1)
            {
                PracticalExam p = new PracticalExam(time, NumOfQuestions);
            }
            else
            {
                FinalExam f = new FinalExam(time, NumOfQuestions);
            }
            Console.Clear();
        }

    }
}
