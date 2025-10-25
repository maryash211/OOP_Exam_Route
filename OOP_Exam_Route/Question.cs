using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_Route
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public double Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }

        public Answer UserAnswer { get; set; }

        public abstract void CreateQuestion();

        public override string ToString() 
        {
            return $"{Header}:  {Body} [Mark: {Mark}]";
        }



    }
}
