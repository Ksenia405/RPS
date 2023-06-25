using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2C
{
    class Interface
    {
        public void Hello()
        {
            Console.WriteLine(
                "Работу выполнила: Емельянова Ксения гр.405\n" +
                "Лабораторная работа №2\n" +
                "Вариант 7\n"
                );
        }

        public void Menu()
        {
            Console.WriteLine("Выберите одно из следующих:\n 1-Шифрование\n 2-Дешифрование\n 3-Выбрать алгоритм шифрования\n 4-Выход\n");
        }

        public void ChoiceCiper1() {
            Console.WriteLine(" ____________________________________\n" +
                              "|Используемый алгоритм:  Шифр  Бофора|\n"+
                              "|____________________________________|\n");
        }

        public void ChoiceCiper2()
        {
            Console.WriteLine(" ____________________________________\n" +
                  "|Используемый алгоритм: Шифр Плейфера|\n" +
                  "|____________________________________|\n");
        }

        public void FirstPoint()
        {
            Console.WriteLine("Выберите одно из следующих:\n 1-Ввод с клавиатуры\n 2-Загрузка из файла\n");
        }


        public void SecondPoint()
        {
            Console.WriteLine("Выберите одно из следующих:\n 1-Текущий текст\n 2-Ввод с клавиатуры\n 3-Загрузка из файла\n");
        }

        public void SaveChoice()
        {
            Console.WriteLine("Сохранить результат? \n 1-Да\n 0-Нет");
        }

        public void Mistake(int kind)
        {
            switch (kind)
            {
                case (401): Console.WriteLine("Неверно задано значение ключа, повторите попытку"); break;
                case (404): Console.WriteLine("Ошибка, такого пункта не существует, повторите попытку"); break;

            }
        }
    }
}
