using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_Route
{
    internal class Answer
    {
        public Answer()
        {
            
        }
        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public override string ToString()
        {
            return $"Answer {AnswerId} = {AnswerText}";
        }
    }
}
