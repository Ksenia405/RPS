using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LAB2C
{
    class FileWork
    {
        public string FileName()
        {
            string fileName = null;
            bool fileAvailability = false;
            fileName = Console.ReadLine();
            while (!fileAvailability)
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine("Файл не найден, повторите попытку:");
                    fileName = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Файл найден");
                    fileAvailability = true;
                }
            }
            return fileName;
        }

        public string ReadFile(string path)
        {
            string text;
            StreamReader reader = new StreamReader(path);
            try { 
            text =  reader.ReadToEnd();
            if (text == "") { Console.WriteLine("Ошибка, файл пуст"); return null; }
            Console.WriteLine("Загрузка данных из файла...");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка, файл не может быть прочитан:");
                return null;
            }
            reader.Close();
            return text;
        }

        public bool SaveData(char[] text)//char
        {
            string path;
            Functions get = new Functions();
            Console.WriteLine("Введите путь и имя файла");
            path = Console.ReadLine();
            if (File.Exists(path))
            {
                Console.WriteLine("Такой файл уже существует, презаписать? Да-1, Нет-0");
                bool reWriting = get.GetBool();
                if (reWriting) {
                    StreamWriter writer = new StreamWriter(path, false);
                    for (int i=0; i<text.Length; i++)
                    writer.Write(text[i]); 
                    writer.Close();
                    Console.WriteLine("Файл успешно перезаписан");
                    return true; }
                else { StreamWriter writer = new StreamWriter(path, true);
                    for (int i = 0; i < text.Length; i++)
                    writer.Write(text[i]);
                    writer.Close();
                    Console.WriteLine("Данные успешно записаны");
                    return true; }
            }
            else
            {
                try
                {
                    StreamWriter writer = new StreamWriter(path);
                    for(int i = 0; i < text.Length; i++)
                    writer.Write(text[i]);
                    writer.Close();
                    Console.WriteLine("Данные успешно записаны");
                    return true;
                }
                catch (Exception) { Console.WriteLine("Указан неверный формат пути или имя файла"); return false; }
            }
        }
    }
}
