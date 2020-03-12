using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSA;
using System.IO;
namespace RSA
{
    class Program
    {
        static void Main(string[] args)

        {
            string again = "";
            Console.WriteLine("\t\t\t\tweclome to RSA project");
            do
            {
                Console.WriteLine("Add from file-> 1");
                Console.WriteLine("Sub from file-> 2");
                Console.WriteLine("mul form file-> 3");
                Console.WriteLine("Encrypt or Decrypt file->4");
                Console.WriteLine("Add two numbers-> 5");
                Console.WriteLine("sub two numbers-> 6");
                Console.WriteLine("mul two numbers-> 7");
                Console.WriteLine("div two numbers-> 8");
                Console.WriteLine("mod of power two numbers-> 9");
                Console.WriteLine("Encrypt-> 10");
                Console.WriteLine("Decrypt->11");

                int input = Int16.Parse(Console.ReadLine());

                if (input == 1 || input == 2 || input == 3)
                {
                    string path_in = "";
                    string path_out = "";
                    if (input == 1)
                    {
                        path_in = "SampleRSA_I\\AddTestCases.txt";
                        path_out = "SampleRSA_I\\addResult.txt";
                    }
                    else if (input == 2)
                    {
                        path_in = "SampleRSA_I\\SubtractTestCases.txt";
                        path_out = "SampleRSA_I\\subResult.txt";
                    }
                    else if (input == 3)
                    {
                        path_in = "SampleRSA_I\\MultiplyTestCases.txt";
                        path_out = "SampleRSA_I\\mulResult.txt";
                    }
                    if (File.Exists(path_in))
                    {
                        FileStream file_in = new FileStream(path_in, FileMode.Open);
                        StreamReader reader = new StreamReader(file_in);
                        FileStream file_out = new FileStream(path_out, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(file_out);

                        int n = Int16.Parse(reader.ReadLine());
                        reader.ReadLine();
                        long before = System.Environment.TickCount;
                        for (int i = 0; i < n; i++)
                        {
                            string A = reader.ReadLine();

                            string B = reader.ReadLine();

                            string Z = "";
                            
                            if (input == 1) Z = Biginteger.Add(A, B);
                            else if (input == 2) Z = Biginteger.Sub(A, B);
                            else if (input == 3) Z = Biginteger.mul(A, B);

                            writer.WriteLine(Z);
                            writer.WriteLine();
                            reader.ReadLine();
                        }
                        long after = System.Environment.TickCount;
                        Console.WriteLine("time= " + (after - before));

                        Console.WriteLine("Done!");
                        writer.Close();
                        reader.Close();
                        file_out.Close();
                        file_in.Close();
                    }

                }
                else if (input == 4)
                {
                    string path_in = "";
                    string path_out = "";
                    Console.WriteLine("sample or complete test : (1/2)");
                    string ch = Console.ReadLine();
                    if (ch == "1")
                    {
                        path_in = "[MS2 Tests] RSA\\SampleRSA.txt";
                        path_out = "[MS2 Tests] RSA\\sampleoutput.txt";
                    }
                    else if (ch == "2")
                    {
                        path_in = "[MS2 Tests] RSA\\TestRSA.txt";
                        path_out = "[MS2 Tests] RSA\\RSAoutput.txt";
                    }
                    if (File.Exists(path_in))
                    {
                        FileStream file_in = new FileStream(path_in, FileMode.Open);
                        StreamReader reader = new StreamReader(file_in);
                        FileStream file_out = new FileStream(path_out, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(file_out);
                        int n = Int16.Parse(reader.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            string N = reader.ReadLine();
                            string power = reader.ReadLine();
                            string message = reader.ReadLine();
                            string EorD_in = reader.ReadLine();

                            string result = "";
                            long before = System.Environment.TickCount;
                            if (EorD_in == "0") result = Biginteger.Encrypt(message, power, N);
                            else if (EorD_in == "1") result = Biginteger.Encrypt(message, power, N);
                            long after = System.Environment.TickCount;

                            Console.WriteLine("time : " + (after - before));
                            
                            writer.WriteLine("case " + (i + 1) + " : " + result);
                        }
                        Console.WriteLine("Done!");
                        writer.Close();
                        reader.Close();
                        file_out.Close();
                        file_in.Close();

                    }

                }
                else if (input == 5 || input == 6 || input == 7 || input == 8)
                {
                    Console.WriteLine("please enter number 1: ");
                    string num1 = Console.ReadLine();
                    Console.WriteLine("please enter number 2: ");
                    string num2 = Console.ReadLine();

                    string Z = "";
                    
                    long before = System.Environment.TickCount;
                    if (input == 5) Z = Biginteger.Add(num1, num2);
                    else if (input == 6) Z = Biginteger.Sub(num1, num2);
                    else if (input == 7) Z = Biginteger.mul(num1, num2);
                    long after = System.Environment.TickCount;
                    if (input == 5 || input == 6 || input == 7)
                    {
                        Console.WriteLine("Result= " + Z);
                        Console.WriteLine("time= " + (after - before));
                    }
                    else if (input == 8)
                    {
                        before = System.Environment.TickCount;
                        string[] result = Biginteger.div(num1, num2);
                        after = System.Environment.TickCount;
                        Console.WriteLine("Result= " + result[0]);
                        Console.WriteLine("reminder= " + result[1]);
                        Console.WriteLine("tmie= " + (after - before));

                    }

                }
                else if (input == 9)
                {
                    Console.WriteLine("please enter number 1: ");
                    string X = Console.ReadLine();
                    Console.WriteLine("Please enter power: ");
                    string power = Console.ReadLine();
                    Console.WriteLine("please enter number 2: ");
                    string Y = Console.ReadLine();

                    long before = System.Environment.TickCount;
                    string result = Biginteger.ModofPow(X, power, Y);
                    long after = System.Environment.TickCount;
                    Console.WriteLine("result= " + result);
                    Console.WriteLine("time= " + (after - before));
                }
                else if (input == 10 || input == 11)
                {
                    Console.WriteLine("Please enter message: ");
                    string message = Console.ReadLine();
                    Console.WriteLine("please enter power: ");
                    string power = Console.ReadLine();
                    Console.WriteLine("please enter N: ");
                    string N = Console.ReadLine();

                    string result = "";
                    long before = System.Environment.TickCount;
                    if (input == 10) result = Biginteger.Encrypt(message, power, N);
                    else if (input == 11) result = Biginteger.Decrypt(message, power, N);
                    long after = System.Environment.TickCount;
                    Console.WriteLine("Result= " + result);
                    Console.WriteLine("time= " + (after - before));

                }

                else
                {
                    Console.WriteLine("invalid input!!");
                }
                Console.WriteLine("Do you want to test again?Y/N");

                again = Console.ReadLine();
            } while (again == "Y");


        }

    }
}