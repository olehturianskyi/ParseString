using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Ввести в консоль текст и распарсить ее как строку. Текст должен состоять
минимум из 5 слов разделенных пробелом:
1) Удалить все цифры из текста и в каждом нечетном слове заменить буквы
в обратном порядке
2) Преобразовать эту строку так, чтобы в каждом слове текста первая буква
была в верхнем регистре, а остальная часть слов в нижнем.
3) Если слово начинается с буквы ‘Т’, то заменить ее на ‘С’. Если
заканчивается на ‘И’ то заменить на ‘О’. Заменять на буквы в верхнем
регистре, но исходное значение буквы не учитывает регистр. Например
не важно это ‘т’ или ‘Т’ то все равно заменить на С’.
 */

namespace ParseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" }; //Если цифры есть - их нужно удалить

            string text = "Этот12        текст написан7     с лишними пробелами. Так же в нём есть цифры, которые нужно удалить10";
            Console.WriteLine("Original text: " + '\n' + text);
            Console.WriteLine();

            string newtext = RemovingExtraSpaces(text);
            OutputResult(newtext);
             
            newtext = NumbersRemoved(text, number);
            OutputResult(newtext);

            newtext = Capitalize(newtext);
            OutputResult(newtext);

            newtext = ChangingLetters(newtext);
            OutputResult(newtext);

            newtext = WritingReverse(newtext);
            OutputResult(newtext); 

            Console.ReadLine();
        }
            //-------------------------------------------------------------
            public static void OutputResult(string newtext)
            {
                string text = newtext;
                Console.WriteLine(text);

                Console.WriteLine();
            }
            //-------------------------------------------------------------
            public static string RemovingExtraSpaces(string text)
            {
                while (text.Contains("  "))
                {
                    text = text.Replace("  ", " ");
                }
                text = "Text with extra spaces: " + '\n' + text;
                return text;
            }
            //-------------------------------------------------------------
            public static string WritingReverse(string text)
            {
                string newtext = "";                
                string[] textArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < textArray.Length; i++)
                {
                    if (i == 0 || i % 2 == 0)
                    {
                        char[] chars = textArray[i].ToCharArray();
                        Array.Reverse(chars);
                        textArray[i] = new string(chars);
                    }
                    newtext = newtext + textArray[i] + " ";
                }            
                newtext = "Odd words are written backwards: " + '\n' + newtext;
               
                return newtext;
            }
            //-------------------------------------------------------------
            public static string ChangingLetters(string text)
            {//разбиваем  новый текст на слова (в массив строк)
                string newtext = "";

                string[] textArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Заменяем буковки, согласно условию
                for (int i = 0; i < textArray.Length; i++)
                {
                    if (textArray[i].StartsWith("Т", StringComparison.InvariantCultureIgnoreCase))
                    {
                        string str1 = textArray[i].Substring(0, 1);
                        string str2 = textArray[i].Substring(1);
                        str1 = "C";
                        textArray[i] = str1 + str2;
                    }
                    if (textArray[i].EndsWith("и", StringComparison.InvariantCultureIgnoreCase))
                    {
                        int length = textArray[i].Length;
                        string str1 = textArray[i].Substring(0, length - 1);
                        string str2 = "О";
                        textArray[i] = str1 + str2;
                    }
                    newtext = newtext + textArray[i] + " ";
                }
                newtext = "Letters have been replaced according to the condition: " + '\n' + newtext;
                return newtext;
            }
        //-------------------------------------------------------------
        public static string Capitalize(string text)
            {
                //разбиваем текст на слова (в массив строк)
                string[] textArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string newtext = "";
                // записываем каждое слово с заглавной буквы
                for (int i = 0; i < textArray.Length; i++)
                {
                    string str1 = textArray[i].Substring(0, 1);
                    str1 = str1.ToUpper();
                    string str2 = textArray[i].Substring(1);
                    textArray[i] = str1 + str2;
                    newtext = newtext + textArray[i] + " ";
                }
                newtext = "All words of the text are written with a sick letter: " +'\n' + newtext;
                return newtext;
            }
        //-------------------------------------------------------------
        public static string NumbersRemoved(string newtext,string[] number)
        {
            string text = newtext;
            newtext = "";
            for (int i = 0; i < number.Length; i++)
                text = text.Replace(number[i], "");
            text = RemovingExtraSpaces(text);
            newtext = "Numbers removed from text: " + '\n' + text;
            return newtext;
        }

    }


}
    
    

