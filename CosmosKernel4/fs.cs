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
    public class fs
    {
        private string root = @"0:\";
        private static sys.FileSystem.CosmosVFS vfs;
        proccess pr = new proccess();

        public void startfs()
        {

        }
    }
}

