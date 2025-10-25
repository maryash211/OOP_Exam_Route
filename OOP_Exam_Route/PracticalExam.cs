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


        public override void CreateQuestionList()
        {
            for (int i = 0; i<NumOfQuestions; i++)
            {
                Console.WriteLine($"Question no.{i + 1}");

                MCQ q = new MCQ();
                q.CreateQuestion();
                questions.Add(q);
            }
        }

        public override void ShowExam()
        {
            //exam show up for student from here:

            Console.WriteLine("Answer the following questions: ");
            foreach (Question question in questions)
            {
                //show question
                Console.WriteLine(question);

                //show choices
                for (int i = 0; i < question.AnswerList.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.AnswerList[i].AnswerText}");
                }

                //take answer from user
                int choice;
                bool isparsed;
                do
                {
                    Console.Write("Enter your answer: ");
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


            //show right answers
            Console.WriteLine("\t* Exam finished! *");
            foreach (var question in questions)
            {
                Console.WriteLine("[Answers]");
                Console.WriteLine($"Question : {question.Body}");
                Console.WriteLine($"Right Answer: {question.RightAnswer.AnswerText}");
                Console.WriteLine();
            }

        
        }
    }
}
