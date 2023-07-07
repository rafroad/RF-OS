using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem;
using sys = Cosmos.System;
using vfs = Cosmos.System.FileSystem;
using Microsoft.VisualBasic;

namespace CosmosKernel4
{
    internal class proccess
    {
        Kernel_main kernel_Main = new Kernel_main();
        public void drawmultoption(List<string> text)
        {
            for(int i = 0; i < text.Count; i++)
            {
                Console.WriteLine($"[{text[i].ToString()}]");
            }
        }
        public void criterror()
        {
            Console.Clear();
            drawtitle(null, null, true);
            drawtext("a critical error has occured please reboot the system or contact your system administrator");
            drawtext("press any key to reboot");
            Console.ReadKey();
            sys.Power.Reboot();
        }
        public void drawtitle(string titletext, string descrtext, bool ismaintitle)
        {
            if (ismaintitle == true)
            {
                titletext = "RF OS V 1.1 TERMLINK";
            }
            Console.WriteLine(titletext);
            if (descrtext != null)
            {
                Console.WriteLine(descrtext);
            }
            if (descrtext.Length > titletext.Length)
            {
                for (int i = 0; i < descrtext.Length; i++)
                {
                    Console.Write("-");
                }
            }
            else
            {
                for (int i = 0; i < titletext.Length; i++)
                {
                    Console.Write("-");
                }
            }
            Console.Write(Environment.NewLine);
        }
        public void drawtext(string txt)
        {
            Console.WriteLine(txt);
        }
        public void drawoption(string text)
        {
            string drawedtext = $"[{text}]";
            Console.WriteLine(drawedtext);
        }
        public void drawtextlist(List<string> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                try
                {
                    drawtext(list[i].ToString());
                }
                catch(Exception e)
                {
                    milderror(e.ToString());
                }
            }
        }
        public void milderror(string exc)
        {
            drawtext($"an error has occured: {exc}");
            drawtext("press any key to exit the application");
            Console.ReadLine();
            kernel_Main.entry1();
        }
    }
}
