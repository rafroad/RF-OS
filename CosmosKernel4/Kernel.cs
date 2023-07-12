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
        private static Sys.FileSystem.CosmosVFS vfs;
        public void entry1()
        {
            Run();
        }
        protected override void BeforeRun()
        {
            loginfunc loginfunc = new loginfunc();
            string root = @"0:\";
            proccess pr = new proccess();
            misc_func misc_func = new misc_func();
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
            string root = @"0:\";
            loginfunc loginfunc = new loginfunc();
            proccess pr = new proccess();
            app app = new app();
            Console.Clear();
            while (true)
            {
                var A = "user";
                pr.drawtitle(null, $"WELCOME {A}",true);
                var options_array = new List<string>();
                string[] options= new string[] { "file manager","text editor", "copyright notice", "calculator" , "RF INDUSTRIES STOCK FELL", "logout", "reboot", "shutdown",};
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
                        app.text_editor();
                        break;
                    case "calculator":
                        app.calculator();
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
                    case "file manager":
                        app.filemanager(root);
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
        //bug not inputting user cause it to crash fixed in testing ground but not here somehow
        proccess pr = new proccess();
        misc_func misc_Func = new misc_func();
        public void login_func()
        {
            var userlist = new List<string>(); var passlist = new List<string>();
            string[] user = { "user" }; string[] pass = { "admin" };
            userlist.AddRange(user); passlist.AddRange(pass);
            Kernel_main Kernel_main = new Kernel_main();
            Console.Clear();
            pr.drawtext("RF OS V 1.1 TERMLINK");
            pr.drawtitle("LOGIN PAGE PLEASE ENTER USER ID AND PASSWORD", "USER LIST:", false);
            for (int i = 0; i < userlist.Count; i++)
            {
                pr.drawoption($"{userlist[i]}");
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
            pr.drawtextnew(null, false, true);
            Console.WriteLine(Environment.NewLine);
            pr.drawtextnew(pr.optionint("SHUTDOWN"), false, true);
            Console.WriteLine(Environment.NewLine);
            Console.Write(">: ");
            string inputuser = Console.ReadLine();
            int userid = 0;
            try
            {
                userid = int.Parse(inputuser) - 1;
            }
            catch (Exception e)
            {
                login_func();
            }
            Console.Write("password: ");
            string inputpass = Console.ReadLine();
            if (inputpass == passlist[userid])
            {
                Console.Clear();
                Kernel_main.entry1();
            }
            else if (inputpass == "rundebugmode")
            {
                pr.debugmode();
            }
            else if (inputpass == "shutdown")
            {
                Cosmos.Core.CPU.Halt();
            }
            else
            {
                Console.WriteLine("ENTRY DENIED TRY AGAIN");
                Console.WriteLine("press any key to repeat");
                Console.ReadKey();
                Console.Clear();
                login_func();
            }
        }
    }
}

