namespace OOP_Exam_Route
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool isparsed;
            int id;
            Subject s = new Subject();
            do
            {
                Console.Write("Enter the id of subject: ");
                isparsed = int.TryParse(Console.ReadLine(), out id);
            }
            while (!isparsed);
            s.SubjectId = id;

            Console.Write("Enter the name subject: ");
            s.SubjectName = Console.ReadLine();

            s.CreateExam();
            char c;
            Console.WriteLine("Enter Exam? [Y | N]");
            do
            {
                isparsed = char.TryParse(Console.ReadLine().ToUpper(), out c);

                if (c == 'Y')
                {
                    if (s.SubjectExam != null)
                    {
                        s.SubjectExam.ShowExam();
                    }
                    else
                    {
                        Console.WriteLine("No exam was created.");
                    }
                }
                else if (c == 'N')
                {
                    Console.WriteLine("Exiting without taking the exam.");
                }
            }
            while (!isparsed || (c != 'Y' && c != 'N'));
        }
    }
}
