using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            string[] eq = equation.Split('=');
            string r = eq[1];
            string[] eq1 = eq[0].Split('*');
            string n1 = eq1[0];
            string n2 = eq1[1];
            string ans;
            if (r.IndexOf('?') != -1) {
                ans = (int.Parse(n1) * int.Parse(n2)).ToString();
                if (ans.Length != r.Length)
                    return -1;
                return int.Parse(ans[r.IndexOf('?')].ToString());
            }
            else if (n1.IndexOf('?') != -1) {
                if (int.Parse(r) % int.Parse(n2) != 0)
                    return -1;
                ans = (int.Parse(r) / int.Parse(n2)).ToString();
                if (ans.Length != n1.Length)
                    return -1;
                return int.Parse(ans[n1.IndexOf('?')].ToString());
            }
            else if (n2.IndexOf('?') != -1) {
                if (int.Parse(r) % int.Parse(n1) != 0) return -1;
                ans = (int.Parse(r) / int.Parse(n1)).ToString();
                if (ans.Length != n2.Length)
                    return -1;
                return int.Parse(ans[n2.IndexOf('?')].ToString());
            }
            else {
                return -1;
            }
        }
    }
}
