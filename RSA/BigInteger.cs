using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class Biginteger
    {

        public static bool max(string num1, string num2)
        {
            int i = 0,
            j = 0;
            int len1 = num1.Length;
            int len2 = num2.Length;

           
            if (len1 > len2) return true;

            else if (len1 < len2) return false;

            else
            {
                while (i < len1 && j < len2)
                {
                    if (num1[i] > num2[j]) return true;
                    else if (num1[i] < num2[j]) return false;

                    i++;
                    j++;
                }
            }
            return true;
        }

        public static string Add(string NUM1, string NUM2)
        {
            if (NUM2.Length > NUM1.Length)
            {
                string tmp = NUM1;
                NUM1 = NUM2;
                NUM2 = tmp;
            }
            StringBuilder result = new StringBuilder(NUM1);
            int LenOfNUM1,
            j;
            int carry = 0;
            char res = ' ';
            LenOfNUM1 = NUM1.Length - 1;
            j = NUM2.Length - 1;

            while (LenOfNUM1 > -1 && j > -1)
            {
                int x = NUM1[LenOfNUM1] - '0';
                int y = NUM2[j] - '0';
                int z = x + y + carry;
                carry = 0;

                if (z > 9)
                {
                    res = Convert.ToChar((z % 10) + 48);
                    carry = 1;
                }
                else
                {
                    res = Convert.ToChar(z + 48);
                    carry = 0;
                }

                result[LenOfNUM1] = res;

                LenOfNUM1 -= 1;
                j -= 1;

            }
            while (LenOfNUM1 > -1)
            {

                int x = NUM1[LenOfNUM1] - '0';
                x += carry;

                if (x > 9)
                {
                    res = Convert.ToChar((x % 10) + 48);
                    carry = 1;
                }
                else
                {
                    res = Convert.ToChar(x + 48);
                    carry = 0;
                }
                result[LenOfNUM1] = res;
                LenOfNUM1 -= 1;

            }

            if (carry > 0)
            {

                return carry.ToString() + (result.ToString());
            }
            else if (result[0] != '0')
            {
                return result.ToString();
            }
            int beforecount = 0;
            int aftercount = result.Length;
            int zerocount = 0;
            while (beforecount < aftercount)
            {
                if (result[beforecount] == '0')
                {

                    beforecount++;
                    zerocount++;
                }
                else break;
            }
            result.Remove(0, zerocount);

            if (result.Length == 0) return "0";

            return result.ToString();

        }
        public static string Sub(string NUM1, string NUM2)
        {
           

                bool islarge = max(NUM1, NUM2);
                if (islarge == false)
                {
                    string tmp = NUM1;
                    NUM1 = NUM2;
                    NUM2 = tmp;
                }
            
            StringBuilder result = new StringBuilder(NUM1);

            int i,
            j;
            int borrow = 0;
            i = NUM1.Length - 1;
            j = NUM2.Length - 1;

            while (i > -1 && j > -1)
            {
                int x = NUM1[i] - '0';
                if (borrow == 1) x -= 1;
                int y = NUM2[j] - '0';
                int z;
                if (y > x)
                {
                    borrow = 1;
                    z = (10 + x) - y;
                }
                else
                {
                    borrow = 0;
                    z = x - y;
                }
                result[i] = Convert.ToChar(z + 48);
                i -= 1;
                j -= 1;
            }

            while (i > -1)
            {
                int x = NUM1[i] - '0';
                if (borrow == 1)
                {
                    if (x > 0)
                    {
                        x -= 1;
                        borrow = 0;
                    }
                    else
                    {
                        x += 9;
                        borrow = 1;
                    }
                }
                result[i] = Convert.ToChar(x + 48);
                i -= 1;
            }
            if (result[0] != '0')
            {
                return result.ToString();
            }
            int beforecount = 0;
            int aftercount = result.Length;
            int zerocount = 0;
            while (beforecount < aftercount)
            {
                if (result[beforecount] == '0')
                {
                    beforecount++;
                    zerocount++;
                }
                else break;
            }
            result.Remove(0, zerocount);

            if (result.Length == 0) return "0";

            return result.ToString();

        }

        public static string mul(string num1, string num2)
        {
            StringBuilder NUM1 = new StringBuilder();
            StringBuilder NUM2 = new StringBuilder();

            StringBuilder result = new StringBuilder();
            int len1 = num1.Length;
            int len2 = num2.Length;
            int max = Math.Max(len1, len2);
            if (len1 != len2)
            {
                if (len1 > len2)
                {
                    long dif = len1 - len2;
                    while (dif > 0)
                    {
                        NUM2.Append('0');
                        dif--;
                    }
                }
                if (len2 > len1)
                {
                    long dif = len2 - len1;
                    while (dif > 0)
                    {
                        NUM1.Append('0');
                        dif--;
                    }
                }
            }
            if (len1 == 0 && len2 == 0)
            {
                return "0";
            }

            else if (len1 == 1 && len2 == 1)
            {

                int res = ((num2[0] - '0') * (num1[0] - '0'));
                return res.ToString();

            }
            else
            {
                if (max % 2 != 0)
                {
                    NUM2.Append('0');
                    NUM1.Append('0');
                }
                NUM1.Append(num1);
                NUM2.Append(num2);
                num1 = NUM1.ToString();
                num2 = NUM2.ToString();
                int mid = num1.Length / 2;
                string B = num1.Substring(0, mid);

                string A = num1.Substring(mid);

                string D = num2.Substring(0, mid);

                string C = num2.Substring(mid);

                string A_C = mul(A, C);

                string B_D = mul(B, D);
                StringBuilder BB_DD = new StringBuilder(B_D);

                string A_B = Add(A, B);

                string C_D = Add(C, D);

                string A_B_C_D = mul(A_B, C_D);

                string M2 = Sub(Sub(A_B_C_D, A_C), B_D);
                StringBuilder MM2 = new StringBuilder(M2);
                int count = Math.Max(NUM1.Length, NUM2.Length) / 2;
                for (int n = 0; n < count; n++)
                {

                    MM2.Append('0');

                }
                count = Math.Max(NUM1.Length, NUM2.Length);
                for (int n = 0; n < count; n++)
                {
                    BB_DD.Append('0');
                }

                return Add(Add(BB_DD.ToString(), MM2.ToString()), A_C);
            }
        }

        static public string[] div(string A, string B)
        {
            string[] pair = new string[2];
            pair[0] = "0";
            pair[1] = "0";
            bool islarge = max(A, B);
            if (islarge == false)
            {
                string y = "0";
                pair[0] = (y);
                pair[1] = (A);
                return pair;
            }
            pair = div(A, Add(B, B));
            pair[0] = Add(pair[0], pair[0]);

            islarge = max(pair[1], B);
            if (islarge == false)
            {
                return pair;

            }
            else
            {
                pair[0] = Add(pair[0], "1");
                pair[1] = Sub(pair[1], B);
                return pair;
            }

        }

        public static string ModofPow(string A, string power, string B)
        {
            string result = "";
            if (power == "0")
            {
                string[] res = div("1", B);
                return res[1];
            }
            else if (power == "1")
            {
                string[] res = div(A, B);
                return res[1];
            }
            else
            {
                string[] res = div(power, "2");
                if (res[1] == "0")
                {

                    string half = ModofPow(A, res[0], B);
                    half = mul(half, half);
                    res = div(half, B);
                    return res[1];
                }
                else
                {

                    string halff = ModofPow(A, res[0], B);
                    halff = mul(halff, halff);
                    string[] newA = div(A, B);
                    result = mul(halff, newA[1]);
                    res = div(result, B);
                    return res[1];

                }
            }

        }
        public static string Encrypt(string A, string power, string B)
        {
            return ModofPow(A, power, B);
        }

        public static string Decrypt(string A, string power, string B)
        {
            return ModofPow(A, power, B);
        }

    }
}