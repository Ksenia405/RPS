using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2C
{
     public class  ICipher
    {

public virtual void Encode() {}
public virtual void Decode() {}
    }


   public  class BoferCipher: ICipher
    {
        string text;
        string key;
        char[] result;

       public BoferCipher() { }
       public BoferCipher(string t, string k) { text = t; key = k; }
       public override void Encode() 
        {
            string[,] tabulaRecta = new string[,] {
            { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" },
            { "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А" },
            { "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б" },
            { "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В" },
            { "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г" },
            { "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д" },
            { "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е" },
            { "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё" },
            { "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж" },
            { "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З" },
            { "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И" },
            { "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й" },
            { "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К" },
            { "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л" },
            { "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М" },
            { "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н" },
            { "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О" },
            { "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П" },
            { "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р" },
            { "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С" },
            { "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т" },
            { "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У" },
            { "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф" },
            { "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х" },
            { "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц" },
            { "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч" },
            { "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш" },
            { "Ъ", "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ" },
            { "Ы", "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ" },
            { "Ь", "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы" },
            { "Э", "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь" },
            { "Ю", "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э" },
            { "Я", "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю" }};
            int j = 0;
            char signText = ' ';
            int comparisonElement = -2;
            string arrayElement = " ";
            char[] keyArray = new char[text.Length];
            result = new char[text.Length];
         for (int i=0; i<text.Length; i++)
            {
                signText = text.ToCharArray()[i];
                if ((signText != ' ') && (signText != ',') && (signText != '.') && (signText != '?') && (signText != '!'))
                {
                    keyArray[i] = key.ToCharArray()[j];
                    j++;
                    if (j == key.Length) j = 0;
                }
                else keyArray[i] = signText;
            }

         for(int i=0; i<text.Length; i++)
            {
                signText = text.ToCharArray()[i];
                if ((signText != ' ') && (signText != ',') && (signText != '.') && (signText != '?') && (signText != '!'))
                {
                    for (int k = 0; k < 33; k++)
                    {
                        comparisonElement = String.Compare(text.ToCharArray()[i].ToString(), tabulaRecta[0, k], true);
                        if (comparisonElement == 0)
                        {
                            for (int l = 0; l < 33; l++)
                            {
                                comparisonElement = String.Compare(keyArray[i].ToString(), tabulaRecta[l, k], true);
                                if (comparisonElement == 0) { arrayElement = tabulaRecta[0, l]; result[i] = arrayElement.ToCharArray()[0]; break; }
                            }
                        }
                    }
                }
                else result[i] = signText;
            }
           
        }

        public char[] RetResult() { return result; }
        public void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < result.Length; i++)
                Console.Write(result[i]);
            Console.WriteLine();
        }
    
    }

    public class PlayfairCipher : ICipher
    {
        string text;
        string key;
        char[] result;

        public PlayfairCipher() { }
        public PlayfairCipher(string t, string k) { text = t.ToUpper(); key = k.ToUpper();}
        public override void Encode()
        {
            char[] alphabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
            char[,] tabula = new char[4, 8];
            bool repeat;
            bool write;
            char signText = ' ';
            int change;
            int m1=-1, m2=-1, n1=-1, n2=-1;
            List<char> resultArray = new List<char>();
            List<char> textArray = new List<char>();
            List<char> textSpace = new List<char>();
            for (int i = 0; i < key.Length; i++)
            {
                repeat = false;
                write = false;
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            if ((tabula[k, l] != '\0') && (tabula[k, l] == key.ToCharArray()[i])) repeat = true;
                            if ((tabula[k, l] == '\0') && (repeat == false)) { tabula[k, l] = key.ToCharArray()[i]; write = true; break; }
                        }
                        if (write) break;
                    }
                }
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                repeat = false;
                write = false;
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            if ((tabula[k, l] != '\0') && (tabula[k, l] == alphabet[i])) repeat = true;
                            if ((tabula[k, l] == '\0') && (repeat == false)) { tabula[k, l] = alphabet[i]; write = true; break; }
                        }
                        if (write) break;
                    }
                }
            }
            
            

            for (int i = 0; i < text.Length; i++)
            {
                signText = text.ToCharArray()[i];
                if ((signText != ' ') && (signText != ',') && (signText != '.') && (signText != '?') && (signText != '!'))
                {
                    textArray.Add(signText);
                }
                else {
                     textSpace.Add(Convert.ToChar(i));
                    
                }
            }
            for (int i=1; i<textArray.Count(); i++)
            {
                if (textArray[i] == textArray[i - 1]) { textArray.Insert(i, 'Ъ'); i--; }
            }
            if (textArray.Count() % 2 == 1) textArray.Add('Ъ');
            result = new char[textArray.Count()+textSpace.Count()];

            for (int i = 0; i < textArray.Count(); i = i + 2)
            {
                for (int m = 0; m < 4; m++)
                {
                    for (int n = 0; n < 8; n++)
                    {
                        if (textArray[i] == tabula[m, n]) { m1 = m; n1 = n; }
                        if (textArray[i + 1] == tabula[m, n]) { m2 = m; n2 = n; }
                    }
                }

                if (m1 == m2) 
                {
                    if (n1 < n2) { n1++; if (n2 != 7) n2++; else n2 = 0; }
                    else if (n2 < n1) { n2++; if (n1 != 7) n1++; else n1 = 0; }
                }
                else if (n1 == n2)
                {
                    if (m1 < m2) { m1++; if (m2 != 3) m2++; else m2 = 0; }
                    else if (m2 < m1) { m2++; if (m1 != 3) m1++; else m1 = 0; }
                }
                else 
                {
                    change = n1; 
                    n1 = n2; 
                    n2 = change; 
                }
                resultArray.Add(tabula[m1, n1]);
                resultArray.Add(tabula[m2, n2]);
            }
            for(int i=0; i<textSpace.Count; i++) { 
                resultArray.Insert(textSpace[i], ' ');
            }
            for (int i=0; i<resultArray.Count; i++) { result[i] = resultArray[i]; }
        }
        public override void Decode()
        {
            char[] alphabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
            char[,] tabula = new char[4, 8];
            bool repeat;
            bool write;
            char signText = ' ';
            int change;
            int m1 = -1, m2 = -1, n1 = -1, n2 = -1;
            List<char> resultArray = new List<char>();
            List<char> textArray = new List<char>();
            List<char> textSpace = new List<char>();
            for (int i = 0; i < key.Length; i++)
            {
                repeat = false;
                write = false;
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            if ((tabula[k, l] != '\0') && (tabula[k, l] == key.ToCharArray()[i])) repeat = true;
                            if ((tabula[k, l] == '\0') && (repeat == false)) { tabula[k, l] = key.ToCharArray()[i]; write = true; break; }


                        }
                        if (write) break;
                    }
                }
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                repeat = false;
                write = false;
                {
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            if ((tabula[k, l] != '\0') && (tabula[k, l] == alphabet[i])) repeat = true;
                            if ((tabula[k, l] == '\0') && (repeat == false)) { tabula[k, l] = alphabet[i]; write = true; break; }
                        }
                        if (write) break;
                    }
                }
            }


            for (int i = 0; i < text.Length; i++)
            {
                signText = text.ToCharArray()[i];
                if ((signText != ' ') && (signText != ',') && (signText != '.') && (signText != '?') && (signText != '!'))
                {
                    textArray.Add(signText);
                }
                else
                {
                    textSpace.Add(Convert.ToChar(i));
                }
            }

            result = new char[textArray.Count() + textSpace.Count()];

            for (int i = 0; i < textArray.Count(); i = i + 2)
            {
                for (int m = 0; m < 4; m++)
                    for (int n = 0; n < 8; n++)
                    {
                        if (textArray[i] == tabula[m, n]) { m1 = m; n1 = n; }
                        if (textArray[i + 1] == tabula[m, n]) { m2 = m; n2 = n; }
                    }
                if (m1 == m2)
                {
                    if (n1 < n2) { n2--; if (n1 != 0) n1--; else n1 = 7; }
                    else if (n2 < n1) { n1--; if (n2 != 0) n2--; else n2 = 7; }
                }
                else if (n1 == n2)
                {
                    if (m1 < m2) { m2--; if (m1 != 0) m1--; else m1 = 3; }
                    else if (m2 < m1) { m1--; if (m2 != 0) m2--; else m2 = 3; }
                }
                else
                {
                    change = n1;
                    n1 = n2;
                    n2 = change;
                }
                resultArray.Add(tabula[m1, n1]);
                resultArray.Add(tabula[m2, n2]);
            }
            for (int i = 1; i < resultArray.Count - 1; i++)
            {
                if ((resultArray[i - 1] == resultArray[i + 1]) && (resultArray[i] == 'Ъ')) resultArray.RemoveAt(i);
            }
            if (resultArray[resultArray.Count - 1] == 'Ъ') resultArray.RemoveAt(resultArray.Count - 1);
            for (int i = 0; i < textSpace.Count; i++) { resultArray.Insert(textSpace[i], ' '); }
            for (int i = 0; i < resultArray.Count; i++) { result[i] = resultArray[i]; }

        }
        public char[] RetResult() { return result; }
        public void Print()
        {
            Console.WriteLine();
            for (int i=0; i<result.Length; i++)
            Console.Write(result[i]);
            Console.WriteLine();
        }

    }

}
