﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class AuthenticationClass
    {
        public static (string, string) AuthenticatorMethod(string auth)
        {
            //No existing authenticator
            if (auth == "")
            {
                Console.WriteLine("No authenticator detected.\nDo you want to setup an authenticator?");
                Console.WriteLine("\n     Yes \n     No");

                int cursorPos = 3;
                Console.SetCursorPosition(0, cursorPos);
                Console.CursorVisible = false;
                Console.Write("-->");
                ConsoleKeyInfo navigator;
                do
                {
                    navigator = Console.ReadKey();
                    Console.SetCursorPosition(0, cursorPos);
                    Console.Write("   ");
                    if (navigator.Key == ConsoleKey.UpArrow && cursorPos > 3)
                    {
                        cursorPos--;
                    }
                    else if (navigator.Key == ConsoleKey.DownArrow && cursorPos < 4)
                    {
                        cursorPos++;
                    }
                    Console.SetCursorPosition(0, cursorPos);
                    Console.Write("-->");
                } while (navigator.Key != ConsoleKey.Enter);

                Console.Clear();
                Console.CursorVisible = true;

                if (cursorPos == 3)
                {
                    Console.Clear();                    
                    Console.WriteLine("Choose authenticator question");
                    Console.WriteLine("\n     What's your favourite resturant?");
                    Console.WriteLine("     What's the name of your hometown?");
                    Console.WriteLine("     What's the name of your mother?");
                    Console.WriteLine("     What's the name of your father?");
                    Console.WriteLine("     What was your nickname in school?");

                    cursorPos = 2;
                    Console.SetCursorPosition(0, cursorPos);
                    Console.CursorVisible = false;
                    Console.Write("-->");
                    //ConsoleKeyInfo navigator;
                    do
                    {
                        navigator = Console.ReadKey();
                        Console.SetCursorPosition(0, cursorPos);
                        Console.Write("   ");
                        if (navigator.Key == ConsoleKey.UpArrow && cursorPos > 2)
                        {
                            cursorPos--;
                        }
                        else if (navigator.Key == ConsoleKey.DownArrow && cursorPos < 6)
                        {
                            cursorPos++;
                        }
                        Console.SetCursorPosition(0, cursorPos);
                        Console.Write("-->");
                    } while (navigator.Key != ConsoleKey.Enter);

                    Console.Clear();
                    Console.CursorVisible = true;

                    string answer = "";
                    switch (cursorPos)
                    {                        
                        case 2:
                            Console.WriteLine("Answer your choosen authenticator question. . .\n");
                            Console.WriteLine("What's your favourite resturant?");
                            answer = Console.ReadLine();
                            return (answer, "What's your favourite resturant?");                           
                        case 3:
                            Console.WriteLine("Answer your choosen authenticator question. . .\n");
                            Console.WriteLine("What's the name of your hometown?");
                            answer = Console.ReadLine();
                            return (answer, "What's the name of your hometown?");
                        case 4:
                            Console.WriteLine("Answer your choosen authenticator question. . .\n");
                            Console.WriteLine("What's the name of your mother?");
                            answer = Console.ReadLine();
                            return (answer, "What's the name of your mother?");
                        case 5:
                            Console.WriteLine("Answer your choosen authenticator question. . .\n");
                            Console.WriteLine("What's the name of your father?");
                            answer = Console.ReadLine();
                            return (answer, "What's the name of your father?");
                        case 6:
                            Console.WriteLine("Answer your choosen authenticator question. . .\n");
                            Console.WriteLine("What was your nickname in school?");
                            answer = Console.ReadLine();
                            return (answer, "What was your nickname in school?");
                    }


                }
                //No authenticator and No as answer
                else if (cursorPos == 4)
                {
                    return ("", "");
                }
            }
            //If authenticator already exists
            else
            {
                return ("", "");
            }
            return ("", "");
        }
    }
}
