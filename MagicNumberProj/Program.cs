using System;

namespace MagicNumberProj
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;bool flag = true;
            Console.WriteLine("Magical Number 6174 !!");
            Console.WriteLine("Take any 4 digit number let say 1234.Make its descending and ascending the subtract [descending number- ascending number] [4321-1234]=3087 then repeat the process again and again, at last u will get 6174");
            Console.WriteLine("Enter your four digit number :");
            input = Convert.ToInt16(Console.ReadLine());
            int DescendingNumber = OrderDigits(input, false);
            int AscendingNumber = OrderDigits(input, true);
            int DescendingNumber_Minus_AscendingNumber = DescendingNumber - AscendingNumber;


            while (flag)
            {                            
                Console.WriteLine(DescendingNumber.ToString() + "-" + AscendingNumber.ToString() + " = " + DescendingNumber_Minus_AscendingNumber.ToString());
            if (DescendingNumber_Minus_AscendingNumber == 6174) flag = false;
            DescendingNumber = OrderDigits(DescendingNumber_Minus_AscendingNumber, false);
            AscendingNumber = OrderDigits(DescendingNumber_Minus_AscendingNumber, true);

            DescendingNumber_Minus_AscendingNumber = DescendingNumber - AscendingNumber;

            }
            Console.ReadKey();
        }

        private static int OrderDigits(int number, bool asc)
        {
            // Extract each digit into an array
            int[] digits = new int[(int)Math.Floor(Math.Log10(Math.Abs(number)) + 1)];
            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = number % 10;
                number /= 10;
            }

            // Order the digits
            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = i + 1; j < digits.Length; j++)
                {
                    if ((!asc && digits[j] > digits[i]) ||
                        (asc && digits[j] < digits[i]))
                    {
                        int temp = digits[i];
                        digits[i] = digits[j];
                        digits[j] = temp;
                    }
                }
            }

            // Turn the array of digits back into an integer
            int result = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                result += digits[i] * (int)Math.Pow(10, digits.Length - 1 - i);
            }

            return result;
        }
    }
}
    
