using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using System.Runtime.InteropServices;
using Cosmos.System.FileSystem;
using CosmosKernel4;
using System.ComponentModel.Design.Serialization;
using System.Linq.Expressions;
using Cosmos.System.Graphics;
using System.Drawing;

namespace CosmosKernel4
{
    public class guiclass
    {
        Canvas canvas;
        public void bg(Color color)
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Clear(color);
        }
        public void taskbar(Color color)
        {
            canvas.DrawFilledRectangle(color,0,0,100,10);
        }
    }
}