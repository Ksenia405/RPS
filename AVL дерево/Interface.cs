using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaB1C
{
    class Interface
    {
       public void Hello()
        {
            Console.WriteLine(
                "Работу выполнила: Емельянова Ксения гр.405\n" +
                "Лабораторная работа №1\n" +
                "Вариант 7\n"
                );
        }

        public void Menu()
        {
            Console.WriteLine("Выберите одно из следующих:\n 1-Вставка нового узла\n 2-Удаление узла\n 3-Вывод дерева на экран\n 4-Сохранение дерева\n 5-Очистка дерева\n 6-Выход\n");
        }

        public void FirstPoint()
        {
            Console.WriteLine("Выберите одно из следующих:\n 1-Ввод с клавиатуры\n 2-Случайная генерация данных\n 3-Загрузка из файла\n");
        }

        public void Mistake(int kind)
        {
            switch (kind) {
                case (401): Console.WriteLine("Ошибка, данные некоректны, повторите попытку"); break;
                case (402): Console.WriteLine("Ошибка, такой узел уже существует, повторите попытку"); break;
                case (403): Console.WriteLine("Ошибка, такого узла не существует, повторите попытку"); break;
                case (404): Console.WriteLine("Ошибка, такого пункта не существует, повторите попытку"); break;

            }
        }

        public void InterfaceRange(int kind)
        {
            switch (kind)
            {
                case (201): Console.WriteLine("Введите диапазон значений"); break;
                case (202): Console.WriteLine("Минимальное значение: "); break;
                case (203): Console.WriteLine("Максимальное значение: "); break;
                case (204): Console.WriteLine("Диапазон значений слишком маленький, повторите попытку"); break;

            }
        }
    }
}
