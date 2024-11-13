using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeAlgorithms
{
    internal class IntegerToRoman
    {
        /* Seven different symbols represent Roman numerals with the following values:
        Symbol	Value
        I	1
        V	5
        X	10
        L	50
        C	100
        D	500
        M	1000

        Roman numerals are formed by appending the conversions of decimal place values from highest to lowest. Converting a decimal place value into a Roman numeral has the following rules:

        If the value does not start with 4 or 9, select the symbol of the maximal value that can be subtracted from the input, 
        append that symbol to the result, subtract its value, and convert the remainder to a Roman numeral.
        If the value starts with 4 or 9 use the subtractive form representing one symbol subtracted from the following symbol, 
        for example, 4 is 1 (I) less than 5 (V): IV and 9 is 1 (I) less than 10 (X): IX. Only the following subtractive forms 
        are used: 4 (IV), 9 (IX), 40 (XL), 90 (XC), 400 (CD) and 900 (CM).
        Only powers of 10 (I, X, C, M) can be appended consecutively at most 3 times to represent multiples of 10. 
        You cannot append 5 (V), 50 (L), or 500 (D) multiple times. 
        If you need to append a symbol 4 times use the subtractive form.*/

        public string IntegerToRomanConvert(int num)
        {
            string ans = "";

            var dic = new Dictionary<int, string>();
            dic[1000] = "M";
            dic[900] = "CM";
            dic[500] = "D";
            dic[400] = "CD";
            dic[100] = "C";
            dic[90] = "XC";
            dic[50] = "L";
            dic[40] = "XL";
            dic[10] = "X";
            dic[9] = "IX";
            dic[5] = "V";
            dic[4] = "IV";
            dic[1] = "I";

            foreach (var kv in dic)
            {
                int div = num / kv.Key;
                for (int i = 0; i < div; i++)
                {
                    ans += kv.Value;
                }
                num %= kv.Key;
                if (num == 0)
                    break;
            }
            return ans;
        }

        public string IntToRoman(int num)
        {
            //Time complexity:
            //O(n)

            //Space complexity:
            //O(n)

            if (num >= 1000) return "M" + IntToRoman(num - 1000);

            if (num >= 900) return "CM" + IntToRoman(num - 900);

            if (num >= 500) return "D" + IntToRoman(num - 500);

            if (num >= 400) return "CD" + IntToRoman(num - 400);

            if (num >= 100) return "C" + IntToRoman(num - 100);

            if (num >= 90) return "XC" + IntToRoman(num - 90);

            if (num >= 50) return "L" + IntToRoman(num - 50);

            if (num >= 40) return "XL" + IntToRoman(num - 40);

            if (num >= 10) return "X" + IntToRoman(num - 10);

            if (num >= 9) return "IX" + IntToRoman(num - 9);

            if (num >= 5) return "V" + IntToRoman(num - 5);

            if (num >= 4) return "IV" + IntToRoman(num - 4);

            if (num >= 1) return "I" + IntToRoman(num - 1);

            return "";
        }

        //Pure C# solution
        List<Tuple<char, int>> numerals = new List<Tuple<char, int>>() {
        new Tuple<char, int>('M', 1000),
        new Tuple<char, int>('D', 500),
        new Tuple<char, int>('C', 100),
        new Tuple<char, int>('L', 50),
        new Tuple<char, int>('X', 10),
        new Tuple<char, int>('V', 5),
        new Tuple<char, int>('I', 1)
        };

        List<Tuple<string, int>> subNumerals = new List<Tuple<string, int>>() {
        new Tuple<string, int>("CM", 900),
        new Tuple<string, int>("CD", 400),
        new Tuple<string, int>("XC", 90),
        new Tuple<string, int>("XL", 40),
        new Tuple<string, int>("IX", 9),
        new Tuple<string, int>("IV", 4)
        };

        public string IntToRomanWithTuple(int num)
        {
            string toRet = "";

            while (num != 0)
            {
                for (int i = 0; i < numerals.Count; i++)
                {
                    var lookingAt = numerals.ElementAt(i);
                    while (num >= lookingAt.Item2 && !(num.ToString().First() == '4' || num.ToString().First() == '9'))
                    {
                        num -= lookingAt.Item2;
                        toRet += lookingAt.Item1;
                    }
                }
                for (int i = 0; i < subNumerals.Count; i++)
                {
                    var lookingAt = subNumerals.ElementAt(i);
                    while (num >= lookingAt.Item2 && (num.ToString().First() == '4' || num.ToString().First() == '9'))
                    {
                        num -= lookingAt.Item2;
                        toRet += lookingAt.Item1;
                    }
                }
            }

            return toRet;
        }

        //GeekForGeeks Solution
        // To add corresponding base symbols in the 
        // array to handle cases which follow subtractive 
        // notation. Base symbols are added index 'i'. 
        static int sub_digit(char num1, char num2,
                                 int i, char[] c)
        {
            c[i++] = num1;
            c[i++] = num2;
            return i;
        }

        // To add symbol 'ch' n times after index i in c[] 
        static int digit(char ch, int n, int i, char[] c)
        {
            for (int j = 0; j < n; j++)
            {
                c[i++] = ch;
            }
            return i;
        }

        // Function to convert decimal to Roman Numerals 
        static void printRoman(int number)
        {
            char[] c = new char[10001];
            int i = 0;

            // If number entered is not valid 
            if (number <= 0)
            {
                Console.WriteLine("Invalid number");
                return;
            }

            // TO convert decimal number to 
            // roman numerals 
            while (number != 0)
            {
                // If base value of number is 
                // greater than 1000 
                if (number >= 1000)
                {
                    // Add 'M' number/1000 times after index i 
                    i = digit('M', number / 1000, i, c);
                    number = number % 1000;
                }

                // If base value of number is greater 
                // than or equal to 500 
                else if (number >= 500)
                {
                    // To add base symbol to the character array 
                    if (number < 900)
                    {

                        // Add 'D' number/1000 times after index i 
                        i = digit('D', number / 500, i, c);
                        number = number % 500;
                    }

                    // To handle subtractive notation in case 
                    // of number having digit as 9 and adding 
                    // corresponding base symbol 
                    else
                    {

                        // Add C and M after index i/. 
                        i = sub_digit('C', 'M', i, c);
                        number = number % 100;
                    }
                }

                // If base value of number is greater 
                // than or equal to 100 
                else if (number >= 100)
                {
                    // To add base symbol to the character array 
                    if (number < 400)
                    {
                        i = digit('C', number / 100, i, c);
                        number = number % 100;
                    }

                    // To handle subtractive notation in case 
                    // of number having digit as 4 and adding 
                    // corresponding base symbol 
                    else
                    {
                        i = sub_digit('C', 'D', i, c);
                        number = number % 100;
                    }
                }

                // If base value of number is greater
                // than or equal to 50 
                else if (number >= 50)
                {

                    // To add base symbol to the character array 
                    if (number < 90)
                    {
                        i = digit('L', number / 50, i, c);
                        number = number % 50;
                    }

                    // To handle subtractive notation in case
                    // of number having digit as 9 and adding 
                    // corresponding base symbol 
                    else
                    {
                        i = sub_digit('X', 'C', i, c);
                        number = number % 10;
                    }
                }

                // If base value of number is greater 
                // than or equal to 10 
                else if (number >= 10)
                {

                    // To add base symbol to the character array 
                    if (number < 40)
                    {
                        i = digit('X', number / 10, i, c);
                        number = number % 10;
                    }

                    // To handle subtractive notation in case of 
                    // number having digit as 4 and adding 
                    // corresponding base symbol 
                    else
                    {
                        i = sub_digit('X', 'L', i, c);
                        number = number % 10;
                    }
                }

                // If base value of number is greater
                // than or equal to 5 
                else if (number >= 5)
                {
                    if (number < 9)
                    {
                        i = digit('V', number / 5, i, c);
                        number = number % 5;
                    }

                    // To handle subtractive notation in case 
                    // of number having digit as 9 and adding 
                    // corresponding base symbol 
                    else
                    {
                        i = sub_digit('I', 'X', i, c);
                        number = 0;
                    }
                }

                // If base value of number is greater 
                // than or equal to 1 
                else if (number >= 1)
                {
                    if (number < 4)
                    {
                        i = digit('I', number, i, c);
                        number = 0;
                    }

                    // To handle subtractive notation in 
                    // case of number having digit as 4 
                    // and adding corresponding base symbol 
                    else
                    {
                        i = sub_digit('I', 'V', i, c);
                        number = 0;
                    }
                }
            }

            // Printing equivalent Roman Numeral 
            Console.WriteLine("Roman numeral is: ");
            for (int j = 0; j < i; j++)
            {
                Console.Write("{0}", c[j]);
            }
        }
    }
}
