using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_Route
{
    internal class FinalExam : Exam
    {
        public FinalExam(int t, int QuestionsNum)
        {
            TimeOfExam = t;
            NumOfQuestions = QuestionsNum;
        }
        public override void ShowExam()
        {
            var questions = new List<Question>(); //to contain questions
            Console.WriteLine($"Final Exam: Time = {TimeOfExam} minutes, Questions = {NumOfQuestions}");

            for (int i = 0; i < NumOfQuestions; i++)
            {
                int qtype;
                bool isparsed;
                do
                {
                    Console.WriteLine($"Choose type for Question : {i + 1}: 1 -> True/False, 2 -> MCQ");
                    isparsed = int.TryParse(Console.ReadLine(), out qtype);
                }
                while (!isparsed || (qtype != 1 || qtype != 2));

                Question q;

                if (qtype == 1)
                {
                    q = new TrueFalseQ();
                }
                else
                {
                    q = new MCQ();
                }
                q.CreateQuestion();
                questions.Add(q);
            }


            Console.WriteLine("Answer the following questions: ");
            foreach (var question in questions)
            {
                Console.WriteLine(question);
                for (int i = 0; i < question.AnswerList.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.AnswerList[i].AnswerText}");
                }
                int choice;
                bool isparsed;
                do
                {
                    Console.WriteLine("Enter your answer: ");
                    isparsed = int.TryParse(Console.ReadLine(), out choice);
                }
                while (!isparsed || (choice < 1 || choice > question.AnswerList.Length));
                question.UserAnswer = new Answer
                {
                    AnswerId = choice,
                    AnswerText = question.AnswerList[choice - 1].AnswerText
                };
            }
        }




    }
}
