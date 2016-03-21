namespace Exceptions
{
    using Examination;
    using Methods;
    using System;
    using System.Collections.Generic;

    class ExceptionsMain
    {
        static void Main()
        {
            //Methods -> Numeric
            int[] numbers = { 23, 33, -1, 2 };
            foreach (var number in numbers)
            {
                try
                {
                    bool isPrime = Numeric.IsPrime(number);
                    Console.WriteLine($"{number} is prime -> {isPrime}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine();

            //Methods -> Extract.Ending
            Console.WriteLine(Extract.Ending("I love C#", 2));
            Console.WriteLine(Extract.Ending("Nakov", 4));
            Console.WriteLine(Extract.Ending("beer", 4));

            try
            {
                Console.WriteLine(Extract.Ending("Hi", 100));
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            //Methods -> Extract.Subsequence            
            var substr = Extract.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Extract.Subsequence(new[] { -1, 3, 2, 1 }, 1, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Extract.Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            try
            {
                var emptyarr = Extract.Subsequence(new[] { -1, 3, 2, 1 }, 0, 5);
                Console.WriteLine(string.Join(" ", emptyarr));
            }
            catch (IndexOutOfRangeException ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();


            //Examination 
            var simpleExamA = new SimpleMathExam(2);
            var simpleExamB = new SimpleMathExam(1);
            var cSharpExamA = new CSharpExam(55);
            var cSharpExamB = new CSharpExam(100);
            var cSharpExamC = new CSharpExam(0);
          
            List<Exam> peterExams = new List<Exam>
            {
                simpleExamA,
                simpleExamB,
                cSharpExamA,
                cSharpExamB,
                cSharpExamC
            };

            Student peter  = new Student("Peter", "Petrov", peterExams);

            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
