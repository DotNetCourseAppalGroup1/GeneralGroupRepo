using System;
using System.IO;

namespace LibraryMultithreading
{
    public class AddImage
    {
        public void PathImage(string path, out string[] image)
        {
            try
            {
                string[] addres = Directory.GetFiles(path);
                image = addres;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                image = default;
            }
        }
    }
}
