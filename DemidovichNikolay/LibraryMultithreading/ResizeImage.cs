using System;
using System.Threading;
using System.Drawing;

namespace LibraryMultithreading
{
    public class ResizeImage
    {


        public delegate void MessageHandler(string message);
        public event MessageHandler Notify;
        public void ResizedImagen(object image)
        {
            object locker = new object();

            string oldPath = (string)image;
            string newPath = oldPath + "1";



            lock (locker)
            {
                try
                {
                    Bitmap newImage = new Bitmap(Image.FromFile(oldPath));

                    newImage.SetResolution(800, 600);

                    newImage.Save(newPath);

                    Notify?.Invoke($" Image --> ({Thread.CurrentThread.ManagedThreadId}) created!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
