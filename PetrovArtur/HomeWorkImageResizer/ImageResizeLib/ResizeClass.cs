using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ImageResizeLib
{
    public class ResizeClass
    {
        public CancellationTokenSource cancelTokenSource;

        private string pathIn, pathOut;
        private int width, height;
        private DirectoryInfo imgDirectory;
        private FileInfo[] imageFiles;
        private bool inOutExist;
        private CancellationToken myToken;

        public ResizeClass(string pathIn, string pathOut, int width, int height)
        {
            cancelTokenSource = new CancellationTokenSource();
            myToken = cancelTokenSource.Token;
            this.pathIn = pathIn;
            this.pathOut = pathOut;
            this.width = width;
            this.height = height;
            inOutExist = Directory.Exists(pathIn) && Directory.Exists(pathOut) && width > 0 && height > 0;

            if (inOutExist)
            {
                imgDirectory = new DirectoryInfo(pathIn);
                imageFiles = imgDirectory.GetFiles("*.jpg");
            }
        }

        public void ResizeTaskArray()
        {

            Task[] tasks1 = new Task[4]
            {
                new Task(()=>ResizePart(1,4,myToken)),
                new Task(()=>ResizePart(2,4,myToken)),
                new Task(()=>ResizePart(3,4,myToken)),
                new Task(()=>ResizePart(4,4,myToken)),
            };

            foreach (var task in tasks1)
            {
                task.Start();
            }
        }

        private void ResizePart(int number, int taskAmmount, CancellationToken token)
        {
            for (int i = number - 1; i < imageFiles.Length; i += taskAmmount)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                ResizeSingle(i);
            }
        }
        private void ResizeSingle(int number)
        {
            Bitmap picture = new Bitmap(Image.FromFile(imageFiles[number].FullName), width, height);
            picture.Save(pathOut + "RESIZED " + imageFiles[number].Name);

        }

        //just for testing
        private void ResizeImagesInFolder()
        {
            Stopwatch sw = new Stopwatch();

            if (inOutExist)
            {
                sw.Start();
                foreach (var img in imageFiles)
                {
                    Bitmap picture = new Bitmap(Image.FromFile(img.FullName), width, height);
                    picture.Save(pathOut + "RESIZED " + img.Name);
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
        }
    }
}
