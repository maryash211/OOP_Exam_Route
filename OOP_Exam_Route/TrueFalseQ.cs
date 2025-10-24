using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_Route
{
    internal class TrueFalseQ : Question
    {
        public override void CreateQuestion()
        {
            Header = "True/False Question";
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

            do
            {
                Console.Write("Enter the Right answer of the question ( 1 for True \t 2 for false): ");
                isparsed = int.TryParse(Console.ReadLine(), out rightAns);
            }
            while (!isparsed || (rightAns != 1 || rightAns != 2));

            RightAnswer.AnswerId = rightAns;
           
            RightAnswer.AnswerText = rightAns == 1 ? "True" : "False";

            Console.Clear();



        }
    }


}
