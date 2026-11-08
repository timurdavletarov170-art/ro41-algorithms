using System;
using System.Text;

namespace TextToolsProject
{
    public static class TextTools
    {
        public static int CountWords(string s)
        {
            if (s == null) return 0;
            int count = 0;
            bool inWord = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i]))
                {
                    if (!inWord)
                    {
                        count++;
                        inWord = true;
                    }
                }
                else
                {
                    inWord = false;
                }
            }
            return count;
        }

        public static bool IsPalindrome(string s)
        {
            if (s == null) return true;
            int l = 0, r = s.Length - 1;

            while (l < r)
            {
                while (l < r && char.IsWhiteSpace(s[l])) l++;
                while (l < r && char.IsWhiteSpace(s[r])) r--;

                if (char.ToLower(s[l]) != char.ToLower(s[r]))
                    return false;

                l++;
                r--;
            }
            return true;
        }

        public static string Initials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "";
            string[] parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < parts.Length; i++)
            {
                if (res.Length > 0) res.Append(' ');
                res.Append(char.ToUpper(parts[i][0])).Append('.');
            }
            return res.ToString();
        }

        public static string Repeat(string s, int n)
        {
            if (string.IsNullOrEmpty(s) || n <= 0) return "";
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                res.Append(s);
            }
            return res.ToString();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Выполнил: Давлетьяров Тимур\n");

            Console.WriteLine("--- Проверка CountWords ---");
            CheckWords("", 0);
            CheckWords("   ", 0);
            CheckWords(" a  b ", 2);
            CheckWords("А роза упала на лапу Азора", 6);
            CheckWords("Ахметов Ерлан", 2);

            Console.WriteLine("\n--- Проверка IsPalindrome ---");
            CheckPal("", true);
            CheckPal("   ", true);
            CheckPal(" a  b ", false);
            CheckPal("А роза упала на лапу Азора", true);
            CheckPal("Ахметов Ерлан", false);

            Console.WriteLine("\n--- Проверка Initials ---");
            CheckInit("", "");
            CheckInit("   ", "");
            CheckInit(" a  b ", "A. B.");
            CheckInit("Ахметов Ерлан", "А. Е.");
            CheckInit("Ахметов Ерлан Серикұлы", "А. Е. С.");

            Console.WriteLine("\n--- Проверка Repeat ---");
            CheckRep("", 4, "");
            CheckRep("   ", 2, "      ");
            CheckRep("xy", 3, "xyxyxy");
            CheckRep("Ахметов Ерлан", 0, "");
        }

        static void CheckWords(string s, int exp)
        {
            int act = TextTools.CountWords(s);
            Console.WriteLine($"Вход: \"{s}\" | Ожидалось: {exp} | Факт: {act} | {(act == exp ? "OK" : "FAIL")}");
        }

        static void CheckPal(string s, bool exp)
        {
            bool act = TextTools.IsPalindrome(s);
            Console.WriteLine($"Вход: \"{s}\" | Ожидалось: {exp} | Факт: {act} | {(act == exp ? "OK" : "FAIL")}");
        }

        static void CheckInit(string s, string exp)
        {
            string act = TextTools.Initials(s);
            Console.WriteLine($"Вход: \"{s}\" | Ожидалось: \"{exp}\" | Факт: \"{act}\" | {(act == exp ? "OK" : "FAIL")}");
        }

        static void CheckRep(string s, int n, string exp)
        {
            string act = TextTools.Repeat(s, n);
            Console.WriteLine($"Вход: \"{s}\" (n={n}) | Ожидалось: \"{exp}\" | Факт: \"{act}\" | {(act == exp ? "OK" : "FAIL")}");
        }
    }
}
