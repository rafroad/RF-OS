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
    internal class api
    {
        string root = @"0:\";
        app app = new app();
        fs fs = new fs();
        proccess pr = new proccess();
        Kernel_main kernel = new Kernel_main();
        private static sys.FileSystem.CosmosVFS vfs;
        public void readlines(String fileadr)
        {

            try
            {
                string fileread = "";
                fileread = File.ReadAllText($"{root}document" + @"\" + fileadr);
                pr.drawtext(fileread);
            }
            catch (Exception e)
            {
                pr.milderror(e.ToString());

            }
        }
        public void createfile(string name)
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
        public void listfile()
        {
            try
            {
                var directory_list = Directory.GetFiles($"{root}document");
                foreach (var file in directory_list)
                {
                    pr.drawoption(file);
                }
            }
            catch (Exception e) { pr.milderror(e.ToString()); }
        }
        public void editfile(string file)
        {
            Console.Clear();
            pr.drawtitle("RF TEXT EDITOR V 1.1 EDITOR MODE", $"currently editing: {file} {Environment.NewLine} enter to save ", false);
            Console.Write($">:{File.ReadAllText($"{root}document" + @"\" + file)}");
            var text = Console.ReadLine();
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                try
                {
                    File.WriteAllText($"{root}document" + @"\" + file, text);
                    pr.drawtext($"file save successfully {Environment.NewLine} press any key to return to main screen");
                    Console.ReadKey();
                    app.text_editor();

                }
                catch (Exception e)
                {
                    pr.milderror(e.ToString());
                }
            }
        }
        public void deletefile(string file)
        {
            try
            {
                File.Delete($"{root}document" + @"\" + file);

            }
            catch(Exception e)
            {
                pr.milderror(e.ToString());
            }
        }
        public void calc(int am)
        {
            var numarr= new List<float>();
            float[] empty = { 0 };
            //dirty fix
            IEnumerable<float> emptyenum = empty;
            numarr.InsertRange(0,emptyenum);
            float[] num = { };
            for(int i = 0; i < am; i++)
            {
                Console.Write($"input {i+1} number out of {am} number: ");
                string strnum = Console.ReadLine();
                float flnum = float.Parse(strnum);
                numarr.Insert(i, flnum);
                pr.drawtext(numarr[i].ToString());
            }
            for (int a = 0; a < numarr.Count; a++)
            {
                float add = 0;
                add = numarr[1] + add;
                if (a == numarr.Count)
                {
                    pr.drawoption($"addition: {add}");
                }
            }
        }
    }
}
