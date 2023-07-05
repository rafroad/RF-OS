using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using System.Runtime.InteropServices;
using vfs=Cosmos.System.FileSystem.VFS;
using System.Security.Cryptography.X509Certificates;
using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem;

namespace CosmosKernel4
{
    public class fs
    {
        Sys.FileSystem.CosmosVFS vfs;
        public string root => $"{vfs.Disks.Count - 1}:\\";

        public void format_fs()
        {
            Disk SelectedDisk = vfs.Disks[vfs.Disks.Count-1];
            SelectedDisk.Clear();
        }
    }
}
