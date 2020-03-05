using System;
using System.IO;
using TranslatorLibrary;

namespace TranslatorConsole
{
    class Program
    {
        static string GetText(string[] args)
        {
            if (args.Length >= 1)
            {
                string fileName = args[0];
                try
                {
                    return File.ReadAllText(fileName);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"Ошибка при чтении файла {fileName}: {e.Message}");
                    return "";
                }
            }
            else
            {
                Console.WriteLine("Введите текст для перевода:");
                return Console.ReadLine();
            }
        }

        static string GetLang(string[] args, int argIndex, string question)
        {
            if (args.Length >= 2)
            {
                return args[1];
            }
            else
            {
                Console.WriteLine(question);
                return Console.ReadLine();
            }
        }


        static void Main(string[] args)
        {
            string text = GetText(args);
            string toLang = GetLang(args, 1, "На какой язык переводить? (en, ru, de, ...)");
            string fromLang = GetLang(args, 2, "С какого языка переводить? (en, ru, de, ..., пусто - автоопределение)");

            ITranslator translator = new XmlTranslator();

            Console.WriteLine("Перевод:");
            Console.WriteLine(translator.Translate(text, toLang, fromLang));
        }
    }
}
