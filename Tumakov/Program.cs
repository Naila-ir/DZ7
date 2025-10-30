using Tumakov.Classes;
using Tumakov.Enumes;

namespace Tumakov
{
    class Program
    {

        //Метод для упр 8.2

        /// <summary> Переворачивает строку </summary>
        /// <param name="str">исходная строка</param>
        /// <returns></returns>
        static string ReverseString(string str)
        {
            if (str is null)
            {
                return str;
            }
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        //Метод для упр 8.4

        /// <summary> Проверяет, реализует ли объект интерфейс</summary>
        /// <param name="obj">объект</param>
        static void SystemIFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                Console.WriteLine($"Объект {obj} реализует IFormattable.");
            }
            else
            {
                Console.WriteLine($"Объект {obj} не реализует IFormattable.");
            }
            IFormattable formattableObj = obj as IFormattable;
            if (formattableObj is not null)
            {
                Console.WriteLine($"Форматированный вывод: {formattableObj.ToString("F2", null)}.");
            }
            else
            {
                Console.WriteLine($"Объект {obj} не реализует IFormattable.");
            }
            Console.WriteLine();
        }

        //Метод для дз 8.1

        /// <summary> Возвращает адрес электронной почты из строки </summary>
        /// <param name="s">строка</param>
        public static void SearchMail(ref string s)
        {
            int index = s.IndexOf('#');
            if (index != -1)
            {
                s = s.Substring(index + 1).Trim();
            }
            else
            {
                s = string.Empty;
            }
        }

        static void Main()
        {
            //Упр 8.2
            Console.WriteLine("Упражнение 8.2");
            Console.Write("Введите строку:");
            Console.WriteLine($"Перевернутая строка: {ReverseString(Console.ReadLine())}");

            //Упр 8.3
            Console.WriteLine("\nУпражнение 8.3");
            Console.Write("Введите имя файла (например: input.txt): ");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден. Программа завершена.");
                Environment.Exit(0);
            }
            string text = File.ReadAllText(fileName);
            string upperText = text.ToUpper();
            string outputFile = "output.txt";
            File.WriteAllText(outputFile, upperText);
            Console.WriteLine($"Содержимое файло {fileName} записано в файл {outputFile} заглавными буквами.");

            //Упр 8.4
            Console.WriteLine("\nУпражнение 8.4");
            object obj1 = 18;
            object obj2 = "Hi";
            object obj3 = 2.577777;
            SystemIFormattable(obj1);
            SystemIFormattable(obj2);
            SystemIFormattable(obj3);

            //Дз 8.1
            Console.WriteLine("\nДомашнее задание 8.1");
            Console.Write("Введите имя файла (например: input.txt): ");
            string inputFile = Console.ReadLine();
            string outputFileName = "emails_" + inputFile;
            string[] lines = File.ReadAllLines(inputFile);
            for (int i = 0; i < lines.Length; i++)
            {
                SearchMail(ref lines[i]);
            }
            File.WriteAllLines(outputFileName, lines);
            Console.WriteLine($"Адреса электронной почты записаны в файл {outputFileName}");

            //Дз 8.2
            Console.WriteLine("\nДомашнее задание 8.2");
            List<Song> songs = new List<Song>();

            Song song1 = new Song();
            song1.SetName("Растает лед");
            song1.SetAuthor("Андрей Бирин");
            songs.Add(song1);

            Song song2 = new Song();
            song2.SetName("Это цель");
            song2.SetAuthor("Анна Бутурлина");
            song2.SetPrev(song1);
            songs.Add(song2);

            Song song3 = new Song();
            song3.SetName("Крылья");
            song3.SetAuthor("лампабикт");
            song3.SetPrev(song2);
            songs.Add(song3);

            Song song4 = new Song();
            song4.SetName("Wonderful! Wonderful!");
            song4.SetAuthor("Johnny Mathis");
            song4.SetPrev(song3);
            songs.Add(song4);

            Console.WriteLine("\nСписок песен:");
            foreach (Song song in songs)
            {
                Console.WriteLine(song.PrintInfo());
            }
            Console.WriteLine("\nСравнение первой и второй песни:");
            if (song1.Equals(song2))
                Console.WriteLine("Песни одинаковы.");
            else
                Console.WriteLine("Песни различаются.");
        }
    }
}