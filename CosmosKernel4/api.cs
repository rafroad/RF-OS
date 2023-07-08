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
            var numarradd = new List<double>(new[] { 0D });
            var numarrsub = new List<double>(new[] { 0D });
            var numarrmul = new List<double>(new[] { 0D });
            var numarrdiv = new List<double>(new[] { 0D });

            float[] num = { };
            for (int i = 0; i < am; i++)
            {
                if (i < 1)
                {
                    numarradd.RemoveAt(0); numarrsub.RemoveAt(0); numarrmul.RemoveAt(0); numarrdiv.RemoveAt(0);
                }
                Console.Write($"input {i + 1} number out of {am} number: ");
                string strnum = Console.ReadLine();
                double flnum = double.Parse(strnum);
                numarradd.Add(flnum); numarrsub.Add(flnum); numarrmul.Add(flnum); numarrdiv.Add(flnum);
            }
            double add = 0; double sub = 0; double mul = 1; double div = 1;
            pr.drawtext("num in string");
            for (int i = 0; i < numarradd.Count; i++)
            {
                add = numarradd[i] + add;
            }
            for (int i = 0; i < numarrsub.Count; i++)
            {
                sub = numarrsub[i] - sub;
            }
            for (int i = 0; i < numarrmul.Count; i++)
            {
                mul = numarrsub[i] * mul;
            }
            for (int i = 0; i < numarrdiv.Count; i++)
            {
                div = numarrsub[i] / div;
            }
            string[] resultarr = { "result", $"addition: {add}", $"subtraction: {sub}", $"multiplication: {mul}", $"division: {div}" };
            var result = new List<string>(); result.AddRange(resultarr);
            pr.drawmultext(result);
            Console.Write("redo a calculation? [y/n]: ");
            string confcalc = Console.ReadLine();
            if(confcalc == "y")
            {
                app.calculator();
            }
            else
            {
                pr.drawtext("press any key to exit");
                Console.ReadKey();
                Console.Clear();
                kernel.entry1();
            }
        }
    }
}
