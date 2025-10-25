using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exam_Route
{
    internal abstract class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumOfQuestions { get; set; }

        public abstract void ShowExam();


        //these are to hold questions for each exam
        public List<Question> questions = new List<Question>();
        public abstract void CreateQuestionList();


        public override string ToString()
        {
            return $"Time = {TimeOfExam} minutes, Questions = {NumOfQuestions}";

        }

    }
}
