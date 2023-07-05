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

namespace CosmosKernel4
{
    internal class proccess
    {
        public void drawoption(string text)
        {
            string drawedtext = $"{text}";
            Console.WriteLine(drawedtext);
        }
        public void error()
        {
            Console.Clear();
            drawtitle("RF OS V 1.1 TERMLINK", null);
            drawtext("a critical error has occured please reboot the system or contact your system administrator");
            drawtext("press any key to reboot");
            Console.ReadKey();
            sys.Power.Reboot();
        }
        public void drawtitle(string titletext, string descrtext)
        {
            Console.WriteLine(titletext);
            if (descrtext != null)
            {
                Console.WriteLine(descrtext);
            }
            Console.WriteLine("-----------------------"); 
        }
        public void drawtext(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
