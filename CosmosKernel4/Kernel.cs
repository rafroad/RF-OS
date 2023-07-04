using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using System.Runtime.InteropServices;
using Cosmos.System.FileSystem;

namespace CosmosKernel4
{
    public class Kernel_main : Sys.Kernel
    {
        misc_func misc_func = new misc_func();
        Sys.FileSystem.CosmosVFS fs;
        string current_directory = "0:\\";
        public List<Disk> Disks { get; }
        public void entry1()
        {
            Run();
        }
        public void entry2()
        {
            //this causes the entire os to freeze for some reason i'll figure it out tmrw
            //debug
            Console.Clear();
            Console.WriteLine("debug mode");
            Console.WriteLine(fs.GetTotalFreeSpace(aDriveId: current_directory));
            Console.WriteLine(fs.GetFileSystemType(current_directory));
            Console.WriteLine(fs.GetDirectoryListing(aPath: "0:\\"));
            Console.WriteLine(Disks);
            Console.WriteLine("press any key to return login screen");
            Console.ReadKey();
            misc_func.login_func();
        }
        protected override void BeforeRun()
        {
        //filesystem
        A:
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            fs.Initialize(aShowInfo: false);
            fs.CreateDirectory("0:\\PROGRAM");
            fs.CreateDirectory("0:\\OS");
            fs.CreateDirectory("0:\\document");

            //text color
            var textscr = Cosmos.HAL.Global.TextScreen;
            Cosmos.System.Global.Console = new Cosmos.System.Console(textscr);
            Cosmos.HAL.Global.TextScreen = textscr;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            misc_func.login_func();
        }
         

        protected override void Run()
        {
            Console.Clear();
            while (true)
            {
                var A = "user";
                Console.WriteLine("RF OS V 1.1 TERMLINK");
                Console.WriteLine("WELCOME " + A);
                Console.WriteLine("[text editor]");
                Console.WriteLine("[copyright notice]");
                Console.WriteLine("[calculator]");
                Console.WriteLine("[RF INDUSTRIES STOCK FELL]");
                Console.WriteLine("[logout]");
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
                        Console.WriteLine("copyright RF INDUSTRIES 2023");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "text editor":
                        //rewrote this into it's own class since this is not working out well
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("RF TEXT EDITOR V 1.0");
                            Console.WriteLine("[create file]");
                            Console.WriteLine("[read file]");
                            Console.WriteLine("[delete file]");
                            Console.WriteLine("[list files]");
                            Console.WriteLine("[quit]");
                            Console.Write(">");
                            var inputt = Console.ReadLine();
                            switch (inputt)
                            {
                                default:
                                    Console.WriteLine("no option");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "quit":
                                    Run();
                                    break;
                                case "read file":
                                    Console.Write("input filename: ");
                                    string filename_rf = Console.ReadLine();
                                    readlines(filename_rf);
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "list files":
                                    Console.WriteLine(fs.GetDirectoryListing(aPath: "0:\\document"));
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
                    case "logout":
                        misc_func.login_func();
                        break;
                   
                }
            }
            object readlines(String fileadr)
            {
                string fileread = "";
                fileread = File.ReadAllText("0:\\document\\"+fileread);
                return fileread;
            }

        }
    }
    public class misc_func
    {
        public void login_func()
        {
            Kernel_main Kernel_main = new Kernel_main();
            Console.Clear();
            Console.WriteLine("RF OS V 1.1 TERMLINK");
            Console.WriteLine("[SHUTDOWN]");
            Console.Write("login user password:");
            const string password = "admin";
            string inputp = Console.ReadLine();
            switch (inputp)
            {
                case password:
                    Console.Clear();
                    Kernel_main.entry1();
                    break;
                case "rundebugmode":
                    Kernel_main.entry2();
                    break;
                case "shutdown":
                    Sys.Power.Shutdown();
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
    }
}
