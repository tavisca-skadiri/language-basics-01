using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args){
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }
        public static int FindDigit(string equation){
            string[] equationOperands = equation.Split('=');
            string firstOperand = equationOperands[0].Split('*')[0];
            string secondOperand = equationOperands[0].Split('*')[1];
            string resultOperand = equationOperands[1];
            return QuestionMarkDetection(firstOperand,secondOperand,resultOperand);
        }
        public static int QuestionMarkDetection(string firstOperand, string secondOperand, string resultOperand) {
            if (firstOperand.IndexOf('?') != -1) {
                return FirstOperandAnalyzer(firstOperand, secondOperand, resultOperand);
            }
            else if (secondOperand.IndexOf('?') != -1) {
                return SecondOperandAnalyzer(firstOperand, secondOperand, resultOperand);
            }
            else if (resultOperand.IndexOf('?') != -1) {
                return ResultOperandAnalyzer(firstOperand, secondOperand, resultOperand);
            }
            else {
                return -1;//no question mark present in equation
            }
        }
        public static int FirstOperandAnalyzer(string firstOperand, string secondOperand, string resultOperand) {
            if (int.Parse(resultOperand) % int.Parse(secondOperand) != 0)//not divisible
                return -1;
            string actualNumber = (int.Parse(resultOperand) / int.Parse(secondOperand)).ToString();
            return FindDigit(actualNumber, firstOperand);
        }
        public static int SecondOperandAnalyzer(string firstOperand, string secondOperand, string resultOperand) {
            if (int.Parse(resultOperand) % int.Parse(firstOperand) != 0)//not divisible
                return -1;
            string actualNumber = (int.Parse(resultOperand) / int.Parse(firstOperand)).ToString();
            return FindDigit(actualNumber, secondOperand);
        }
        public static int ResultOperandAnalyzer(string firstOperand, string secondOperand, string resultOperand) {
            string actualNumber = (int.Parse(firstOperand) * int.Parse(secondOperand)).ToString();
            return FindDigit(actualNumber, resultOperand);
        }
        public static int FindDigit(string actualNumber, string operand) {
            if (actualNumber.Length != operand.Length)
                return -1;
            return int.Parse(actualNumber[operand.IndexOf('?')].ToString());
        }
        private static void Test(string args, int expected) {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

    }
}
