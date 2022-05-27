using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public class LeetCodeSolutions
    {

        // Indicate if number is a palindrome. Do it without first changing the number into a string.
        public static bool IsPalindrome(int num)
        {
            int originalNum = num;
            int reverse = 0;

            for (int i = 0; num > 0; i++)
            {
                int last = num % 10;
                reverse = reverse * 10 + last;
                num = num / 10;
            }
            if (originalNum == reverse)
            {
                return true;
            }
            else return false;
        }

    }
}
