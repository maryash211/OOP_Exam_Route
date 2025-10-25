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

        public override void CreateQuestionList()
        {
            Console.Write($"Final Exam: ");
            Console.WriteLine(this);

            for (int i = 0; i < NumOfQuestions; i++)
            {
                int qtype;
                bool isparsed;
                do
                {
                    Console.WriteLine($"Choose type for Question no.{i + 1}: [1 -> True/False, 2 -> MCQ]");
                    Console.Write("type: ");
                    isparsed = int.TryParse(Console.ReadLine(), out qtype);
                }
                while (!isparsed || (qtype != 1 && qtype != 2));

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


        }

        public override void ShowExam()
        {
            Console.WriteLine("Answer the following questions: ");

            foreach (Question question in questions)
            {
                Console.WriteLine(question);
            
                for (int i = 0; i < question.AnswerList.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.AnswerList[i].AnswerText}");
                }

                int Stdchoice = 0;
                bool isparsed;

                if (question is MCQ)
                {
                    do
                    {
                        Console.WriteLine("Enter your answer (choose between 4 choices): ");
                        isparsed = int.TryParse(Console.ReadLine(), out Stdchoice);
                    }
                    while (!isparsed || (Stdchoice < 1 || Stdchoice > question.AnswerList.Length));

                }
                else if (question is TrueFalseQ)
                {
                    do
                    {
                        Console.WriteLine("Enter your answer (1 => \"True\"\t2 => \"False\"): ");
                        isparsed = int.TryParse(Console.ReadLine(), out Stdchoice);
                    }
                    while (!isparsed || (Stdchoice < 1 || Stdchoice > 2));
                }

     
                question.UserAnswer = new Answer
                {
                    AnswerId = Stdchoice,
                    AnswerText = question.AnswerList[Stdchoice - 1].AnswerText
                };
            }
            Console.Clear();

            double totalMarks = 0;
            double grade = 0;
            foreach (Question q in questions)
            {
                totalMarks += q.Mark;

                if (q.UserAnswer.AnswerId == q.RightAnswer.AnswerId)
                {
                    grade += q.Mark;
                }

                Console.WriteLine($"Question: {q.Body}");
                Console.WriteLine($"Your Answer = {q.UserAnswer.AnswerText}");
                Console.WriteLine($"The Right Answer = {q.RightAnswer.AnswerText}");
            }
            Console.WriteLine($"Your grade = {grade} out of {totalMarks}");
        }
    }
}
