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

        public void text_editor()
        {
            api api = new api();
            fs fs = new fs();
            proccess pr = new proccess();
            Kernel_main kernel = new Kernel_main();
            Console.Clear();
            while (true)
            {
                pr.drawtitle("RF TEXT EDITOR V 1.1","A new a text editor for a new era",false);
                string[] options = new string[] { "create file" , "read file","edit file" ,"delete file", "list files", "quit" };
                var options_arr = new List<string>();
                options_arr.AddRange(options);
                pr.drawmultoption(options_arr);
                Console.Write(">");
                var inputt = Console.ReadLine();
                switch (inputt)
                {
                    default:
                        pr.drawtext("no option");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "quit":
                        kernel.entry1();
                        break;
                    case "read file":
                        Console.Write("input filename: ");
                        string filename_rf = Console.ReadLine();
                        api.readlines(filename_rf);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "list files":
                        api.listfile();
                        pr.drawtext("press any key to exit");
                        Console.ReadKey();
                        Console.Clear();
                        text_editor();
                        break;
                    case "create file":
                        Console.Clear();
                        pr.drawtitle("please enter the name  of your file", "this can't be changed beware", false);
                        Console.Write(">");
                        string filename= Console.ReadLine();   
                        api.createfile(filename);
                        pr.drawtext("file  creation success press any key to edit the file");
                        Console.ReadKey();
                        api.editfile(filename);
                        break;
                    case "edit file":
                        Console.Write("input filename: ");
                        string editfilename = Console.ReadLine();
                        api.editfile(editfilename);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "delete file":
                        Console.Write("input filename: ");
                        string filenamedel= Console.ReadLine();
                        Console.Write("are you sure [y/n]: ");
                        string delconf = Console.ReadLine();
                        if(delconf == "y")
                        {
                            api.deletefile(filenamedel);
                            pr.drawtext("delete operation success");
                            pr.drawtext("press any key to return");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            pr.drawtext("delete operation cancelled");
                            pr.drawtext("press any key to return");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                }
            }
        }
        public void calculator()
        {
            api api = new api();
            fs fs = new fs();
            proccess pr = new proccess();
            Kernel_main kernel = new Kernel_main();
            Console.Clear();
            pr.drawtitle("RF calculator v 1.1","WARNING DIVISION IS NOT ACCURATE YET ",false);
            Console.Write("input amount of number: ");
            string amstr=Console.ReadLine();
            try
            {
                int amint=int.Parse(amstr);
                api.calc(amint);
            }
            catch(Exception e)
            {
                pr.milderror(e.ToString());
            }
            //Console.Write("please input first number:");
            //var AA = Console.ReadLine();
            //Console.Write("please input second number");
            //var BB = Console.ReadLine();
            //float AAA = float.Parse(AA);
            //float BBB = float.Parse(BB);
            //float D = AAA + BBB;
            //float E = AAA - BBB;
            //float F = AAA * BBB;
            //float G = AAA / BBB;
            //Console.WriteLine("addition:" + D);
            //Console.WriteLine("subtraction:" + E);
            //Console.WriteLine("multiplication:" + F);
            //Console.WriteLine("division:" + G);
            //Console.ReadKey();
            //Console.Clear();
        }
    }
}
