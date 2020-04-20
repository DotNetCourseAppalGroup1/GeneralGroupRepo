using System;
using ImageResizeLib;
using System.Diagnostics;
using System.IO;
using ImageResizeLib;
using System.Threading;
using System.Configuration;

namespace HomeWorkImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = Convert.ToInt32(ConfigurationManager.AppSettings["width"]);
            int height = Convert.ToInt32(ConfigurationManager.AppSettings["height"]);
            string pathIn = ConfigurationManager.AppSettings["pathIn"];
            string pathOut = ConfigurationManager.AppSettings["pathOut"];

            var x = new ResizeClass(pathIn, pathOut, width, height);

            x.ResizeTaskArray();

            Console.WriteLine("Press F1 button to stop resizing");
            while(true)
            {
                if (Console.ReadKey().Key==ConsoleKey.F1)
                {
                    x.cancelTokenSource.Cancel();
                    Console.WriteLine("Resizing cancelled");
                    break;
                }
            }

            Console.ReadLine();

        }
    }
}
