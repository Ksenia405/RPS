using System;

namespace LAB2C
{
    enum MenuItem { Encryption = 1, Decryption, AlgorithmSelection, Quit };
    enum EncryptionItem { Manually=1, FileWork };
    enum DecryptionItem { Сurrent = 1,  InputText, FileWork};
    class Program
    {
        static void Main()
        {

            int userChoice = 0;
            int encryptionChoice = 0;
            int decryptionChoice = 0;
            string text=null;
            string dectext = null;
            string key;
            bool checkKey = true;
            bool save, success=false;
            int algorithSelection = 0;
            Interface menu = new Interface();
            Functions choice = new Functions();
            BoferCipher boferMessage = new BoferCipher();
            PlayfairCipher playfairMessage = new PlayfairCipher();
            FileWork fileWork=new FileWork();
            menu.Hello();
            do
            {
                if (algorithSelection == 0) menu.ChoiceCiper1();
                if (algorithSelection == 1) menu.ChoiceCiper2();
                menu.Menu();
                userChoice = choice.GetInt();
                switch (userChoice)
                {
                    case ((int)MenuItem.Encryption):{
                        menu.FirstPoint();
                            encryptionChoice = choice.GetInt();
                            switch (encryptionChoice)
                            {
                                case ((int)EncryptionItem.Manually): {
                                        Console.WriteLine("Введите текст для шифрования:");
                                        text= choice.GetText();
                                        Console.WriteLine("Введите ключ:");
                                        key = choice.GetText();
                                        if (algorithSelection == 0) 
                                        { 
                                            for (int i=0; i<key.Length; i++)
                                            {
                                                if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                { checkKey = false; break; }
                                            }
                                            while ((text.Length < key.Length)||(checkKey==false)||(key.Length==0)) 
                                            {
                                                menu.Mistake(401);
                                                key = choice.GetText();
                                                checkKey = true;
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                    checkKey = false;
                                                }

                                            }
                                            boferMessage = new BoferCipher(text, key);                                 
                                            boferMessage.Encode();
                                            boferMessage.Print();

                                        }
                                        if (algorithSelection == 1) 
                                        {
                                            for (int i = 0; i < key.Length; i++)
                                            {
                                                if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                { checkKey = false; break; }
                                            }
                                            while ((checkKey == false)||(key.Length==0))
                                            {
                                                menu.Mistake(401);
                                                key = choice.GetText();
                                                checkKey = true;
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                        checkKey = false;
                                                }

                                            }
                                            playfairMessage = new PlayfairCipher(text, key);
                                            playfairMessage.Encode();
                                            playfairMessage.Print();
                                        }
                                        menu.SaveChoice();
                                        save = choice.GetBool();
                                        if (save) while (!success) {
                                                if (algorithSelection == 0) success = fileWork.SaveData(boferMessage.RetResult());
                                                if (algorithSelection == 1) success = fileWork.SaveData(playfairMessage.RetResult());
                                        }
                                        success = false;
                                    }
                                    break;
                                case ((int)EncryptionItem.FileWork): {
                                        Console.WriteLine("Введите путь и имя файла");
                                        string fileName;
                                        fileName = fileWork.FileName();
                                        var data = fileWork.ReadFile(fileName);
                                        if (data != null)
                                        {
                                            Console.WriteLine("Введите ключ:");
                                            key = choice.GetText();
                                            if (algorithSelection==0) {
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                    { checkKey = false; break; }
                                                }
                                                while ((data.Length < key.Length) || (checkKey == false))
                                                {
                                                    menu.Mistake(401);
                                                    key = choice.GetText();
                                                    checkKey = true;
                                                    for (int i = 0; i < key.Length; i++)
                                                    {
                                                        if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                            checkKey = false;
                                                    }

                                                }
                                                boferMessage = new BoferCipher(data, key);
                                                boferMessage.Encode();
                                                boferMessage.Print();
                                            }
                                        if (algorithSelection==1)
                                            {
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                    { checkKey = false; break; }
                                                }
                                                while (checkKey == false)
                                                {
                                                    menu.Mistake(401);
                                                    key = choice.GetText();
                                                    checkKey = true;
                                                    for (int i = 0; i < key.Length; i++)
                                                    {
                                                        if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                            checkKey = false;
                                                    }

                                                }
                                                playfairMessage = new PlayfairCipher(data, key);                                               
                                                playfairMessage.Encode();
                                                playfairMessage.Print();
                                            }
                                            menu.SaveChoice();
                                            save = choice.GetBool();
                                            if (save) while (!success)
                                                {
                                                    if (algorithSelection == 0) success = fileWork.SaveData(boferMessage.RetResult());
                                                    if (algorithSelection == 1) success = fileWork.SaveData(playfairMessage.RetResult());
                                                }
                                            success = false;
                                        } } break;
                                default: menu.Mistake(404); break; 
                            }
                    } break;

                    case ((int)MenuItem.Decryption):{
                            menu.SecondPoint();
                            decryptionChoice = choice.GetInt();
                            switch (decryptionChoice)
                            {
                                case ((int)DecryptionItem.Сurrent): {
                                    if (algorithSelection == 0)
                                        {
                                            dectext = new string(boferMessage.RetResult());
                                            if (dectext != null)
                                            {
                                                Console.WriteLine("Введите ключ:");
                                                key = choice.GetText();
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                    { checkKey = false; break; }
                                                }
                                                while ((dectext.Length < key.Length) || (checkKey == false))
                                                {
                                                    menu.Mistake(401);
                                                    key = choice.GetText();
                                                    checkKey = true;
                                                    for (int i = 0; i < key.Length; i++)
                                                    {
                                                        if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                            checkKey = false;
                                                    }

                                                }
                                                boferMessage = new BoferCipher(dectext, key);                                              
                                                boferMessage.Encode();
                                                boferMessage.Print();
                                            }
                                            else Console.WriteLine("Текущее сообщение пустое");
                                        }
                                    if (algorithSelection == 1) {
                                                dectext = new string(playfairMessage.RetResult());
                                                if (dectext != null)
                                                {
                                                    Console.WriteLine("Введите ключ:");
                                                    key = choice.GetText();
                                                    for (int i = 0; i < key.Length; i++)
                                                    {
                                                        if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                        {       checkKey = false;
                                                            break;
                                                        }
                                                    }
                                                    while (checkKey == false)
                                                    {
                                                        menu.Mistake(401);
                                                        key = choice.GetText();
                                                        checkKey = true;
                                                        for (int i = 0; i < key.Length; i++)
                                                        {
                                                            if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                                checkKey = false;
                                                        }

                                                    }
                                                    playfairMessage = new PlayfairCipher(dectext, key);
                                                    playfairMessage.Decode();
                                                    playfairMessage.Print();
                                            }
                                                else Console.WriteLine("Текущее сообщение пустое");
                                            
                                    }
                                    }
                                    break;
                                case ((int)DecryptionItem.InputText): {
                                        Console.WriteLine("Введите текст для дешифрования:");
                                        text = choice.GetText();
                                        Console.WriteLine("Введите ключ:");
                                        key = choice.GetText();
                                        if (algorithSelection == 0)
                                        {
                                            for (int i = 0; i < key.Length; i++)
                                            {
                                                if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                { checkKey = false; break; }
                                            }
                                            while ((text.Length < key.Length) || (checkKey == false))
                                            {
                                                menu.Mistake(401);
                                                key = choice.GetText();
                                                checkKey = true;
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                        checkKey = false;
                                                }

                                            }
                                            boferMessage = new BoferCipher(text, key);
                                            
                                            boferMessage.Encode();
                                            boferMessage.Print();
                                        }
                                        if (algorithSelection == 1) {
                                            for (int i = 0; i < key.Length; i++)
                                            {
                                                if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                { checkKey = false; break; }
                                            }
                                            while (checkKey == false)
                                            {
                                                menu.Mistake(401);
                                                key = choice.GetText();
                                                checkKey = true;
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                        checkKey = false;
                                                }

                                            }
                                            playfairMessage = new PlayfairCipher(text, key);
                                            
                                            playfairMessage.Decode();
                                            playfairMessage.Print();
                                        }
                                        menu.SaveChoice();
                                        save = choice.GetBool();
                                        if (save) while (!success)
                                            {
                                                if (algorithSelection == 0) success = fileWork.SaveData(boferMessage.RetResult());
                                                if (algorithSelection == 1) success = fileWork.SaveData(playfairMessage.RetResult());
                                            }
                                        success = false;
                                    }
                                    break;
                                    case ((int)DecryptionItem.FileWork): {
                                        Console.WriteLine("Введите путь и имя файла");
                                        string fileName;
                                        fileName = fileWork.FileName();
                                        var data = fileWork.ReadFile(fileName);
                                        if (data != null)
                                        {
                                            Console.WriteLine("Введите ключ:");
                                            key = choice.GetText();
                                            if (algorithSelection == 0)
                                            {
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                    { checkKey = false; break; }
                                                }
                                                while ((data.Length < key.Length) || (checkKey == false))
                                                {
                                                    menu.Mistake(401);
                                                    key = choice.GetText();
                                                    checkKey = true;
                                                    for (int i = 0; i < key.Length; i++)
                                                    {
                                                        if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                            checkKey = false;
                                                    }

                                                }
                                                boferMessage = new BoferCipher(data, key);
                                                boferMessage.Encode();
                                                boferMessage.Print();
                                            }
                                            if (algorithSelection == 1)
                                            {
                                                for (int i = 0; i < key.Length; i++)
                                                {
                                                    if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                    { checkKey = false; break; }
                                                }
                                                while (checkKey == false)
                                                {
                                                    menu.Mistake(401);
                                                    key = choice.GetText();
                                                    checkKey = true;
                                                    for (int i = 0; i < key.Length; i++)
                                                    {
                                                        if ((key.ToCharArray()[i] == ' ') || (key.ToCharArray()[i] == ',') || (key.ToCharArray()[i] == '.') || (key.ToCharArray()[i] == '?') || (key.ToCharArray()[i] == '!'))
                                                            checkKey = false;
                                                    }

                                                }
                                                playfairMessage = new PlayfairCipher(data, key);
                                                playfairMessage.Decode();
                                                playfairMessage.Print();
                                            }
                                            menu.SaveChoice();
                                            save = choice.GetBool();
                                            if (save) while (!success)
                                                {
                                                    if (algorithSelection == 0) success = fileWork.SaveData(boferMessage.RetResult());
                                                    if (algorithSelection == 1) success = fileWork.SaveData(playfairMessage.RetResult());
                                                }
                                            success = false;
                                        }
                                    }
                                    break;
                                default: menu.Mistake(404); break;
                            }
                    } break;

                    case ((int)MenuItem.AlgorithmSelection): {
                            Console.WriteLine("Выберите алгоритм шифрования: 0-Шифр Бофора 1-Шифр Плейфера");
                            algorithSelection = choice.GetInt();
                            while ((algorithSelection != 0) && (algorithSelection != 1))
                            {
                                Console.WriteLine("Такого пункта не существует. Попробуйте еще раз ");
                                algorithSelection = choice.GetInt();
                            }
                        }
                        break;
                    case ((int)MenuItem.Quit): break;
                    default: menu.Mistake(404); break;
                }
            } while (userChoice != (int)MenuItem.Quit);
        }
    }
}
