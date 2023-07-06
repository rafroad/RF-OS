using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem;
using sys = Cosmos.System;

namespace CosmosKernel4
{
    internal class app
    {
        public string root = @"0:\";
        fs fs = new fs();
        proccess pr = new proccess();
        Kernel_main kernel = new Kernel_main();
        private static sys.FileSystem.CosmosVFS vfs;
        public void text_editor()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("RF TEXT EDITOR V 1.0");
                string[] options = new string[] { "create file" , "read file", "delete file", "list files", "quit" };
                var options_arr = new List<string>();
                options_arr.AddRange(options);
                pr.drawmultoption(options_arr);
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
                        kernel.entry1();
                        break;
                    case "read file":
                        Console.Write("input filename: ");
                        string filename_rf = Console.ReadLine();
                        readlines(filename_rf);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "list files":
                        pr.drawtext(vfs.GetDirectoryListing(aPath: $"{root}document").ToString());
                        break;
                }
            }
        }
        object readlines(String fileadr)
        {
            string fileread = "";
            fileread = File.ReadAllText(root + fileread);
            return fileread;
        }

    }
}
