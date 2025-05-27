using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace customio
{
    public static class IO
    {
        static bool IsInArray(string? find, string[] arr)
        {
            foreach (string item in arr) if (item == find) return true;
            return false;
        }

        static bool IsInArray(int find, int[] arr)
        {
            foreach (int item in arr) if (item == find) return true;
            return false;
        }

        public static void Print(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string AwaitInput(string message, ConsoleColor message_color = ConsoleColor.White, ConsoleColor input_color = ConsoleColor.Cyan, bool spacing = false, string? def = null, params string[] expected)
        {
            string? val;
            if (def == null)
            {
                do
                {
                    Console.ForegroundColor = message_color;
                    Console.Write(message);
                    Console.ForegroundColor = input_color;
                    val = Console.ReadLine();
                } while (!IsInArray(val, expected));
            } else {
                Console.ForegroundColor = message_color;
                Console.Write(message);
                Console.ForegroundColor = input_color;
                val = Console.ReadLine();
                if ((val == "") || (val == null)) val = def;
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (spacing) Console.WriteLine();
            return val!; // "!" in the end strips the possibility of "null" value on return (it's already handled by the function)
        }

        public static int AwaitInput(string message, ConsoleColor message_color = ConsoleColor.White, ConsoleColor input_color = ConsoleColor.Cyan, bool spacing = false, int? def = null) // , params int[]? expected
        {   
            int val;
            string? input;
            if (def == null)
            {
                do
                {
                    Console.ForegroundColor = message_color;
                    Console.Write(message);
                    Console.ForegroundColor = input_color;
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out val));
            } else {
                Console.ForegroundColor = message_color;
                Console.Write(message);
                Console.ForegroundColor = input_color;
                input = Console.ReadLine();
                if (!int.TryParse(input, out val)) val = (int)def;
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (spacing) Console.WriteLine();
            return val;
        }

        static bool GetArrayFromString(string input, out int[] res)
        {
            int amount = 1;
            foreach(char c in input){
                if(char.IsWhiteSpace(c)){
                    amount++;
                }
            }

            res = new int[amount];
            int currentnum = 0;
            int i = 0;
            foreach(char c in input){
                if(!char.IsWhiteSpace(c) && !char.IsNumber(c)) return false;
                if(char.IsNumber(c)){
                    currentnum *= 10;
                    currentnum += c - '0';
                }
                if(char.IsWhiteSpace(c)){
                    res[i] = currentnum;
                    currentnum = 0;
                    i++;
                }
            }
            res[i] = currentnum;
            return true;
        }

        public static int[,] AwaitInput(string message, int length, int width, ConsoleColor message_color = ConsoleColor.White, ConsoleColor input_color = ConsoleColor.Cyan, bool spacing = false)
        {   
            int[,] val = new int[width,length];
            int[] temp;
            string? input;

            int message_length = message.Length;
            
            Console.ForegroundColor = message_color;
            Console.Write(message);
            Console.ForegroundColor = input_color;
            string bad_input_msg = "Bad input!";
            int bad_input_msg_len = bad_input_msg.Length;
            int bad_input_msg_len_total = message_length - 10;

            int att_cnt;
            for (int i = 0; i < width; i++){
                att_cnt = 0;
                do {
                    if (att_cnt > 0){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(bad_input_msg);
                        Console.ForegroundColor = input_color;
                        if (i > 0) for (int j = 0; j < bad_input_msg_len_total; j++) Console.Write(" ");
                    }
                    else if (i > 0) for (int j = 0; j < message_length; j++) Console.Write(" ");
                    //if (i > 0) for (int j = 0; j < message_length; j++) Console.Write(" ");
                    input = Console.ReadLine();
                    att_cnt++;
                } while (!GetArrayFromString(input!, out temp));
                
                for (int j = 0; j < length; j++){
                    // if (GlobVars.debug) WriteWithColor($"val[{i}, {j}] = temp[{j}] = {temp[j]}\n", color:ConsoleColor.DarkGray);
                    val[i, j] = temp[j];
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (spacing) Console.WriteLine();
            return val;
        }



        public static void PrintMatrix(int[,] mat, ConsoleColor color = ConsoleColor.DarkGray)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                Console.Write("\t");
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(" ");
                    Console.Write(mat[i, j]);
                }
                Console.Write("\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
        }
    }
}
