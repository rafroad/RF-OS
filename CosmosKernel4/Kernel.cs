using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;

namespace CosmosKernel4
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;
        string current_directory = "0:\\";

        protected override void BeforeRun()
        {
            //filesystem
            A:
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            fs.Initialize();
            fs.CreateDirectory("0:\\PROGRAM");
            fs.CreateDirectory("0:\\OS");
            fs.CreateDirectory("0:\\document");
            var CD = fs.CreateFile("0:\\document\\test.txt");
            var GD = fs.GetFile("0:\\document\\test.txt");
            string RD = GD.ToString();
            Console.WriteLine(RD);
            //text color
            var textscr = Cosmos.HAL.Global.TextScreen;
            Cosmos.System.Global.Console = new Cosmos.System.Console(textscr);
            Cosmos.HAL.Global.TextScreen = textscr;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            //debug
            Kernel.PrintDebug("test");
            
        //login
        E:
            Console.WriteLine("RF OS V 1.0 TERMLINK");
            Console.Write("login user password:");
            string password = "admin";
            string inputp = Console.ReadLine();
            if (inputp == password)
            {
                Console.Clear();
                Run();
            }
            else
            {
                Console.WriteLine("ENTRY DENIED TRY AGAIN");
                Console.WriteLine("press any key to repeat");
                Console.ReadKey();
                Console.Clear();
                goto E;
            }
            if(inputp=="rundebugmode")
            {
                Console.Clear();
                goto A;
            }
            if (inputp == "shutdown")
            {
                Sys.Power.Shutdown();
            }
        }

        protected override void Run()
        {
            while (true)
            {
                var A = "user";
                Console.WriteLine("RF OS V 1.0 TERMLINK");
                Console.WriteLine("WELCOME " + A);
                Console.WriteLine("[text editor]");
                Console.WriteLine("[copyright notice]");
                Console.WriteLine("[calculator]");
                Console.WriteLine("[RF INDUSTRIES STOCK FELL]");
                Console.WriteLine("[reboot]");
                Console.WriteLine("[shutdown]");
                Console.Write(">");
                var input = Console.ReadLine();
                switch (input)
                {
                    default:
                        Console.WriteLine("no option");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "shutdown":
                        Sys.Power.Shutdown();
                        break;
                    case "copyright notice":
                        Console.Clear();
                        Console.WriteLine("copyright RF INDUSTRIES 2020");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "text editor":
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("RF TEXT EDITOR V 1.0");
                            Console.WriteLine("[create file]");
                            Console.WriteLine("[read file]");
                            Console.WriteLine("[delete file]");
                            Console.WriteLine("[quit]");
                            Console.Write(">");
                            var inputt = Console.ReadLine();
                            switch (inputt)
                            {
                                default:
                                    Console.WriteLine("no option");
                                    Console.ReadKey();
                                    break;
                                case "quit":
                                    Run();
                                    break;
                            }
                        }
                        break;
                    case "calculator":
                        Console.Clear();
                        Console.WriteLine("RF calculator v 1.0");
                        Console.Write("please input first number:");
                        var AA = Console.ReadLine();
                        Console.Write("please input second number");
                        var BB = Console.ReadLine();
                        float AAA = float.Parse(AA);
                        float BBB = float.Parse(BB);
                        float D = AAA + BBB;
                        float E = AAA - BBB;
                        float F = AAA * BBB;
                        float G = AAA / BBB;
                        Console.WriteLine("addition:" + D);
                        Console.WriteLine("subtraction:" + E);
                        Console.WriteLine("multiplication:" + F);
                        Console.WriteLine("division:" + G);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "RF INDUSTRIES STOCK FELL":
                        Console.Clear();
                        Console.WriteLine("RF INDUSTRIES STOCK FELL");
                        Console.WriteLine("today there is a stunning news");
                        Console.WriteLine("RF INDUSTRIES stock price fell");
                        Console.WriteLine("mr house says'is good to see my rival company crash-");
                        Console.WriteLine("he tries to be like me and end up in the dumpster'");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "reboot":
                        Sys.Power.Reboot();
                        break;
                   
                }
            }
            object readlines(String fileadr)
            {
                string fileread = "";
                fileread = File.ReadAllText("0:\\document\\A.txt");
                return fileread;
            }

        }
    }
}
