using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem;
using sys = Cosmos.System;
using System.Windows.Input;


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
                pr.drawtitle("RF TEXT EDITOR V 1.1","A new a text editor for a new era",false);
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
                        listfile();
                        pr.drawtext("press any key to exit");
                        Console.ReadKey();
                        Console.Clear();
                        text_editor();
                        break;
                    case "create file":
                        Console.Clear();
                        pr.drawtitle("pleas ename your file", "this can't be changed beware", false);
                        Console.Write(">");
                        string filename= Console.ReadLine();   
                        createfile(filename);
                        pr.drawtext("file  creation successpress any key to edit the file");
                        Console.ReadKey();
                        editfile(filename);
                        break;
                }
            }
        }
        void readlines(String fileadr)
        {
            try
            {
                string fileread = "";
                fileread = File.ReadAllText($"{root}document" + @"\" + fileadr);
                pr.drawtext(fileread);
            }
            catch(Exception e)
            {
                pr.milderror(e.ToString());

            }
        }
        void createfile(string name)
        {
            try
            {
                var file_stream = File.Create($"{root}document" + @"\" + name);
            }
            catch (Exception e)
            {
                pr.milderror(e.ToString());
            }
        }
        void listfile()
        {
            try
            {
                var directory_list = Directory.GetFiles($"{root}document");
                foreach (var file in directory_list)
                {
                    pr.drawoption(file);
                }
            }
            catch(Exception e) { pr.milderror(e.ToString()); }
        }
        void editfile(string file)
        {
            Console.Clear();
            pr.drawtitle("RF TEXT EDITOR V 1.1 EDITOR MODE", $"currently editing: {file} {Environment.NewLine} Lwindows to save ", false);
            Console.Write(">:");
            var text = Console.ReadLine();
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.LeftWindows)
            {
                try
                {
                    File.WriteAllText($"{root}document" + @"\" +file, text);
                    pr.drawtext($"file save successfully {Environment.NewLine} press any key to return to main screen");
                    Console.ReadKey();
                    text_editor();
                    
                }
                catch(Exception e)
                {
                    pr.milderror(e.ToString());
                }
            }
        }
    }
}
