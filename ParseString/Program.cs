using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] number = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" }; //Если цифры есть - их нужно удалить

            string text = "Этот12        текст написан7     с лишними пробелами. Так же в нём есть цифры, которые нужно удалить10";
            Console.WriteLine("Original text: " + text);
            Console.WriteLine();

            string newtext = "";
            //пока есть двойные пробелы - заменяем двойной на одиночный
            while (text.Contains("  "))         
            {
                text = text.Replace("  ", " ");                 
            }
            Console.WriteLine("Text with extra spaces: ");
            Console.WriteLine("     " + text);
            Console.WriteLine();
            //разбиваем текст на слова (в массив строк)
            string[] textArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); 
            // записываем каждое слово с заглавной буквы
            for (int i = 0; i < textArray.Length; i++)
            {
                string str1 = textArray[i].Substring(0, 1);
                str1 = str1.ToUpper();
                string str2 = textArray[i].Substring(1);
                textArray[i] = str1 + str2;
                newtext = newtext + textArray[i]+" ";
            }
            Console.WriteLine("All words of the text are written with a sick letter: ");
            Console.WriteLine("     " + newtext);
            Console.WriteLine();
            
            for (int i = 0; i < number.Length; i++)
                newtext = newtext.Replace(number[i], "");
            Console.WriteLine("Numbers removed from text: ");
            Console.WriteLine("     " + newtext);
            Console.WriteLine();

            //разбиваем  новый текст на слова (в массив строк)
            textArray = newtext.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // В каждом нечетном слове переставляем буквы в обратном порядке
            newtext = "";
            for (int i = 0; i < textArray.Length; i++)
            {
                if (i==0 || i % 2 == 0)
                {
                    char[] chars =textArray[i].ToCharArray();
                    Array.Reverse(chars);
                    textArray[i] = new string(chars);                               
                }
                newtext = newtext + textArray[i] + " ";
                


            }
            Console.WriteLine("Odd words are written backwards: ");
            Console.WriteLine("     " + newtext);
            Console.WriteLine();

            // Console.WriteLine("Processed text: " + newtext);
            // Console.WriteLine();
            Console.WriteLine("Text contains " + textArray.Length + " words");
            Console.WriteLine();

            Console.ReadLine();
        }
    }   
    
}
