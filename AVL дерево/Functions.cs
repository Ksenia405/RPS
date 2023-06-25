﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaB1C
{
    class Functions
    {
        public int GetInt()
        {
            int a = 0;
            string b = null;
            b=Console.ReadLine();
            while (int.TryParse(b, out a) == false) 
            {
                Console.Write("Ошибка, пожалуйста введите число еще раз: ");
                b = Console.ReadLine();
            }
            a = Convert.ToInt32(b);
            return a;
        }
        public bool GetBool()
        {
            int nullOrOne;
            nullOrOne = GetInt();
            while ((nullOrOne != 0) && (nullOrOne != 1))
            {
                Console.WriteLine( "Такого пункта не существует. Попробуйте еще раз ");
                nullOrOne = GetInt();
            }
            return (Convert.ToBoolean(nullOrOne));
        }
    }
}
