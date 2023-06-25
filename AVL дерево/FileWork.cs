using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaB1C
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

        public async Task<List<int>> ReadFile(string path)
        {

            List<int> data = new List<int>();
            StreamReader reader = new StreamReader(path);
            string text = await reader.ReadToEndAsync();
            if (text == "") { Console.WriteLine("Ошибка, файл пуст"); return null; }
            string[] intArray = null;
            intArray = File.ReadAllText(path).Split(' ').ToArray();

            Console.WriteLine("Загрузка данных из файла...");
            try {
                for (int i = 0; i < intArray.Length; i++) {
                    if(intArray[i] !="")
                    data.Add(Int32.Parse(intArray[i]));
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка, файл не может быть прочитан:");
                return null;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка, некоректные значения в файле");
                return null;
            }
            reader.Close();
            return data;
        }

        public void SaveData(AVLnode tree)
        {
            string path;
            Functions get= new Functions();
            Console.WriteLine("Введите путь и имя файла");
            path = Console.ReadLine();
            if (File.Exists(path)) {
                Console.WriteLine("Такой файл уже существует, презаписать? Да-1, Нет-0");
               bool reWriting = get.GetBool();
                if (reWriting) { StreamWriter writer = new StreamWriter(path, false); tree.SaveTree(tree, writer); writer.Close(); }
                else { StreamWriter writer = new StreamWriter(path, true); tree.SaveTree(tree, writer); writer.Close(); }
            }
            else {
                try
                {
                    StreamWriter writer = new StreamWriter(path);
                    tree.SaveTree(tree, writer);
                    writer.Close();
                }
                catch (Exception) { Console.WriteLine("Указан неверный формат пути или имя файла"); }
            }
        }
}
}
