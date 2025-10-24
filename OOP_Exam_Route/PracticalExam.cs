using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_Route
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int t, int QuestionsNum)
        {
            TimeOfExam = t;
            NumOfQuestions = QuestionsNum;
        }
        public override void ShowExam()
        {
            var questions = new List<Question>();
            for (int i = 0; i < NumOfQuestions; i++)
            {
                Console.WriteLine($"Question no.{i + 1}");
                MCQ q = new MCQ();
                q.CreateQuestion();
                questions.Add( q );
            }

            //exam show up for student from here:

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
            Console.Clear();


            Console.WriteLine("Exam finished! Right Answer: ");
            foreach (var question in questions)
            {
                Console.WriteLine($"Question: {question.Body}");
                Console.WriteLine($"Right Answer: {question.RightAnswer.AnswerText}");
                Console.WriteLine();
            }

        
        }
    }
}
