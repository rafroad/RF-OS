using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using System.Runtime.InteropServices;
using Cosmos.System.FileSystem;
using CosmosKernel4;
using System.ComponentModel.Design.Serialization;
using System.Linq.Expressions;

namespace CosmosKernel4
{
    public class Kernel_main : Sys.Kernel
    {
        loginfunc loginfunc = new loginfunc();
        public string root = @"0:\";
        fs fs = new fs();
        proccess pr = new proccess();
        misc_func misc_func = new misc_func();
        app app = new app();
        private static Sys.FileSystem.CosmosVFS vfs;
        public void entry1()
        {
            Run();
        }
        protected override void BeforeRun()
        {
            Kernel_main.PrintDebug("here");
            vfs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(vfs);
            vfs.Initialize(aShowInfo: true);
            //pr.drawtext("success init fs ");
            Kernel_main.PrintDebug("success init fs");
            vfs.CreateDirectory($"{root}PROGRAM");
            vfs.CreateDirectory($"{root}OS");
            vfs.CreateDirectory($"{root}document");
            pr.drawtext("success start disk");
            Kernel_main.PrintDebug("success start disk");
            misc_func.loadset();
            loginfunc.login_func();

        }


        protected override void Run()
        {
            Console.Clear();
            while (true)
            {
                var A = "user";
                pr.drawtitle(null, $"WELCOME {A}",true);
                var options_array = new List<string>();
                string[] options= new string[] { "text editor", "copyright notice", "calculator" , "RF INDUSTRIES STOCK FELL", "logout", "reboot", "shutdown",};
                options_array.AddRange(options);
                pr.drawmultoption(options_array);
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
                        Cosmos.Core.CPU.Halt();
                        break;
                    case "copyright notice":
                        Console.Clear();
                        Console.WriteLine("copyright RF INDUSTRIES 2023");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "text editor":
                        //rewrote this into it's own class since this is not working out well
                        app.text_editor();
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
                    case "logout":
                        loginfunc.login_func();
                        break;

                }
            }
        }
    }
    public class misc_func
    {
        fs fs = new fs();
        proccess pr = new proccess();
        public static Sys.FileSystem.CosmosVFS vfs;
        public void loadset()
        {
            var textscr = Cosmos.HAL.Global.TextScreen;
            Cosmos.System.Global.Console = new Cosmos.System.Console(textscr);
            Cosmos.HAL.Global.TextScreen = textscr;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
    public class loginfunc
    {
        proccess pr = new proccess();
        misc_func misc_Func = new misc_func();
        public void login_func()
        {
            Kernel_main Kernel_main = new Kernel_main();
            Console.Clear();
            pr.drawtitle(null, "login page please enter password for user",true);
            pr.drawoption("SHUTDOWN");
            Console.Write("password: ");
            const string password = "admin";
            string inputp = Console.ReadLine();
            switch (inputp)
            {
                case password:
                    Console.Clear();
                    Kernel_main.entry1();
                    break;
                case "rundebugmode":
                    debugmode();
                    break;
                case "shutdown":
                    Cosmos.Core.CPU.Halt();
                    break;
                default:
                    Console.WriteLine("ENTRY DENIED TRY AGAIN");
                    Console.WriteLine("press any key to repeat");
                    Console.ReadKey();
                    Console.Clear();
                    login_func();
                    break;
            }
        }
        void debugmode()
        {
            fs fs = new fs();
            proccess pr = new proccess();
            //this causes the entire os to freeze for some reason i'll figure it out tmrw
            //debug
            Console.Clear();
            pr.drawtitle(null, "debug mode", true);

            Console.WriteLine("press any key to return login screen");
            Console.ReadKey();
            login_func();
        }
    }
}

