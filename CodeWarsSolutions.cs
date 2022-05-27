using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public class CodeWarsSolutions
    {
        //Triangular numbers are so called because of the equilateral triangular shape that they occupy when laid out as dots. i.e.
        //You need to return the nth triangular number. You should return 0 for out of range values:

       // For example: (Input --> Output)
       // 0 --> 0
       // 2 --> 3
       // 3 --> 6
       //-10 --> 0
        public static int Triangular(int n)
        {
            int answer = 0;

            for (int i = 0; i < n; i++)
            {
                answer += n - i;
            }

            return answer;
        }
        public static int TriangularReverse(int n)
        {
            int answer = 0;

            if (n > 0)
            {
                for (int i = 1; 0 < n; i++)
                {
                    n = n - i;


                    answer = i;

                }
            }

            return answer;
        }
        // Take a array of numbers and make return the lowest number possible from multiplying a pair and then adding thos products together
        public static int MinSumOne(int[] a)
        {
            Array.Sort(a);
            List<int> intList = new List<int>();
            for (int i = 0; i < a.Length * .5; i++)
            {
                int num = a[i] * a[(a.Length - 1) - i];

                intList.Add(num);
            }
            int answer = intList.Sum();
            return answer;
        }

        //Complete the function that accepts a string parameter, and reverses each word in the string. All spaces in the string should be retained.

        public static string ReverseWords(string str)
        {
            string[] strArray = str.Split(' ');
            List<string> strList = new List<string>();

            foreach (string subStr in strArray)
            {
                int end = subStr.Length - 1;

                char[] chars = subStr.ToCharArray();
                char[] result = new char[subStr.Length];

                for (int i = 0; i < subStr.Length; i++)
                {
                    result[i] = chars[end];
                    end--;
                }

                strList.Add(new string(result));

            }

            return String.Join(" ", strList.ToArray());
        }

        //top answer from CodeWars for^^^^
        //public static class Kata
        //{
        //    public static string ReverseWords(string str)
        //    {
        //        return string.Join(" ", str.Split(' ').Select(i => new string(i.Reverse().ToArray())));
        //    }
        //}


        //   We want to know the index of the vowels in a given word, for example, there are two vowels in the word super(the second and fourth letters).

        //So given a string "super", we should return a list of[2, 4].

        //Some examples:
        //Mmmm  => []
        //        Super => [2,4]
        //        Apple => [1,5]
        //        YoMama -> [1,2,4,6]
        //        NOTES
        //        Vowels in this context refers to: a e i o u y(including upper case)
        //This is indexed from[1..n] (not zero indexed!)
        public static int[] VowelIndices(string word)
        {
            char[] chars = { 'a', 'e', 'i', 'o', 'u', 'y' };

            string newWord = word.ToLower();

            List<int> answer = new List<int>();

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < newWord.Length; j++)
                {
                    int temp = newWord.IndexOf(chars[i], j);
                    if (temp >= 0)
                    {
                        j = temp;
                        answer.Add(j + 1);
                    }

                }
            }

            return answer.OrderBy(x => x).ToArray();
        }



        // Return the number of vowels found in a string.
        public static int GetVowelCount(string str)
        {
            string vowel = "aeiou";
            Stack<char> stack = new Stack<char>();


            foreach (char ch in str)
            {
                foreach (char ch2 in vowel)
                {
                    if (ch == ch2)
                    {
                        stack.Push(ch);
                    }

                }
            }

            return stack.Count;

            //public static int GetVowelCount(string str)    best answer from codewar
            //{
            //    return str.Count(i => "aeiou".Contains(i));
            //}
        }

        public static String Accum(string s)
        {
            char temp;
            string str = s.ToLower();

            char[] charstr = str.ToCharArray();

            for (int i = 1; i < charstr.Length; i++)
            {
                for (int j = 0; j < charstr.Length - 1; j++)
                {
                    if (charstr[j] > charstr[j + 1])
                    {
                        temp = charstr[j];
                        charstr[j] = charstr[j + 1];
                        charstr[j + 1] = temp;


                    }
                }
            }
            return s;
        }

        public static bool validBraces(String braces)
        {
            char[] braceArray = braces.ToArray();


            Dictionary<char, char> braceDictionary = new Dictionary<char, char>();
            braceDictionary.Add('(', ')');
            braceDictionary.Add('[', ']');
            braceDictionary.Add('{', '}');
            //braceDictionary.Add('}', '{');
            //braceDictionary.Add(']', '[');
            //braceDictionary.Add(')', '(');

            KeyValuePair<char, char> key = new KeyValuePair<char, char>();

            for (int i = 0; i < braceArray.Length; i++)
            {
                foreach (KeyValuePair<char, char> pair in braceDictionary)
                {
                    if (EqualityComparer<char>.Default.Equals(pair.Key, braceArray[i]))
                    {
                        key = pair;
                    }
                }


                if (key.Value == braceArray[i + 1] && key.Value == braceArray[braceArray.Length - (i + 1)])
                {
                    if (braceArray.Length == 2)
                    {
                        return true;
                    }
                    else if (key.Key == braceArray[braceArray.Length - (i + 2)])
                    {
                        return false;
                    }

                }
                else if (key.Value == braceArray[i + 1])
                {
                    i = i + 1;
                }
                else if (key.Value == braceArray[braceArray.Length - (i + 1)])
                {

                }
                else return false;
            }



            return true;
        }

        //The Answer
        //public class Brace
        //{
        //    public static bool validBraces(string braces)
        //    {
        //        var st = new Stack<char>();
        //        foreach (var c in braces)
        //            switch (c)
        //            {
        //                case '(':
        //                case '[':
        //                case '{':
        //                    st.Push(c);
        //                    continue;
        //                case ')':
        //                    if (st.Count == 0 || st.Pop() != '(') return false;
        //                    continue;
        //                case ']':
        //                    if (st.Count == 0 || st.Pop() != '[') return false;
        //                    continue;
        //                case '}':
        //                    if (st.Count == 0 || st.Pop() != '{') return false;
        //                    continue;
        //            }
        //        return st.Count == 0;


        //    foreach(char key in braceDictionary.Keys.Where(x => x.Equals(braceArray[0])))
        //    {
        //        if(key.Value == braceArray[])
        //    }
        //}

        // Iterative Binary Search. Returns the postion NOT the index hence the mid++
        public static int BinarySearch(int[] inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
