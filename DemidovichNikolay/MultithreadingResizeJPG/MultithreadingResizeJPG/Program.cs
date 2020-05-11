using System;
using System.Threading;
using LibraryMultithreading;


namespace MultithreadingResizeJPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            ResizeImage resizeImage = new ResizeImage();
            AddImage addImagi = new AddImage();
            string[] images;
            resizeImage.Notify += DisplayEvent;

            addImagi.PathImage(@"C:\Users\Mikalai\source\repos\MultithreadingResizeJPG\drawings", out images);

            foreach (var j in images)
            {
                ThreadPool.QueueUserWorkItem(resizeImage.ResizedImagen, j);
            }

            Console.ReadKey();
        }

        public static void DisplayEvent(string message)
        {
            Console.WriteLine(message);
        }
    }
}
