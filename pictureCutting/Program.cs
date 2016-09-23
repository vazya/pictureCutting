using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ImageCropper
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // директория входных данных
            string[] files = Directory.GetFiles(@"inputs\");
            foreach (var filePath in files)
            {
                Image image = Image.FromFile(filePath);
                // итоговое разрешение результата
                Bitmap croppedBmp = new Bitmap(1892, 896);
                Graphics g = Graphics.FromImage(croppedBmp);
                // минус левая и минус верхняя границы для обрезки
                g.DrawImageUnscaled(image, 0, -100);
                g.Dispose();
                FileInfo imageFileInfo = new FileInfo(filePath);
                // директория выходных данных
                croppedBmp.Save(@"outputs\" + imageFileInfo.Name);
                croppedBmp.Dispose();
                image.Dispose();
            }
        }
    }
}