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
        public bool init_fs()
        {
            try
            {
                vfs = new sys.FileSystem.CosmosVFS();
                sys.FileSystem.VFS.VFSManager.RegisterVFS(vfs);
                vfs.Initialize(aShowInfo: true);
                pr.drawtext("success init fs ");
                Kernel_main.PrintDebug("success init fs");
                return true;
            }
            catch (Exception ex)
            {
                
                Kernel_main.PrintDebug("fail to init fs");
                pr.drawtext(ex.ToString());
                return false;
            }
        }
        public void startfs()
        {
            init_fs();
            if (init_fs() == true)
            {
                vfs.CreateDirectory($"{root}PROGRAM");
                vfs.CreateDirectory($"{root}OS");
                vfs.CreateDirectory($"{root}document");
                pr.drawtext("success start disk");
                Kernel_main.PrintDebug("success start disk");
                
            }
            else
            {
                Kernel_main.PrintDebug("fail to start fs");
                pr.error();
            }
        }
    }
}
