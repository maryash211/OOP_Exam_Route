using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_Route
{
    internal class MCQ : Question
    {
        public override void CreateQuestion()
        {
            Header = "MCQ Question";
            Console.WriteLine(Header);

            double mark;
            int rightAns;
            bool isparsed;
            do
            {
                Console.Write("Enter Question Body: ");
                Body = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(Body));

            do
            {
                Console.Write("Enter the Mark of Question : ");
                isparsed = double.TryParse(Console.ReadLine(), out mark);
            }
            while (!isparsed || (mark < 0));
            Mark = mark;

            AnswerList = new Answer[4];
            for (int i = 0; i < AnswerList.Length; i++) 
            {
                Console.WriteLine("You can dd 4 choices for each question");
                do
                {
                    Console.Write($"Enter answer choice no.{i + 1}: ");
                    AnswerList[i].AnswerText = Console.ReadLine();
                }
                while (string.IsNullOrWhiteSpace(AnswerList[i].AnswerText));
            }



            do
            {
                Console.Write("Which is the Right answer?");
                Console.WriteLine($"1- {AnswerList[0]}\n2- {AnswerList[1]}\n3- {AnswerList[2]}\n4- {AnswerList[3]}\n");
                isparsed = int.TryParse(Console.ReadLine(), out rightAns);
            }
            while (!isparsed || (rightAns != 1 || rightAns != 2 || rightAns != 3 || rightAns != 4));

            RightAnswer.AnswerId = rightAns;
            RightAnswer.AnswerText = AnswerList[rightAns - 1].AnswerText;


            Console.Clear();


        }
    }
}
