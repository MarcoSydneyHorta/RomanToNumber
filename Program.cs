using System;
using System.Collections.Generic;

namespace RomanToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Type roman number: ");
            string s = Console.ReadLine();
            if (valid(s) == true) // Checks if there is a sequence of roman numbers longer than 3 repeated characters
            {
                if (s.Length >= 1 && s.Length <= 15)
                {
                    int number = RomanToInt(s);
                    if (number != -1) // Checks that the roman number has a minimum of one and a maximum of fifteen characters
                    {
                        Console.WriteLine("The converted number is: " + number.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("The Roman numeral must have one to fifteen characters");
                }
            }
        }
        static public int RomanToInt(string s)
        {
            int sum = 0;
            Dictionary<char, int> romanNumbersDic = new()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
            for (int i = 0; i < s.Length; i++)
            {
                char romanAct = s[i];
                romanNumbersDic.TryGetValue(romanAct, out int num);
                if (i + 1 < s.Length && romanNumbersDic[s[i + 1]] > romanNumbersDic[romanAct])
                {
                    sum -= num;
                }
                else
                {
                    sum += num;
                }
            }
            if (sum >= 1 && sum <= 3999)
            {
                return sum;
            }
            else
            {
                Console.WriteLine("Roman number must be between I and MMMCMXCIX (1 and 3999)");
                return -1;
            }
        }
        static public bool valid(string s)
        {
            bool val = true;
            int tam = s.Length;
            for (int i = 0; i < tam; i++)
            {
                int count = 0;
                for (int j = 0; j < tam; j++)
                {
                    if (s[i] == s[j])
                    {
                        count++;
                    }
                }
                if (count > 3)
                {
                    Console.WriteLine("Sequence of more then 3 letters is invalid.");
                    return false;
                }

            }
            return val;
        }
    }
}

