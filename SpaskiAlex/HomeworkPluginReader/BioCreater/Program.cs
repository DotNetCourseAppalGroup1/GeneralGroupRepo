using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace BioCreater
{
    class Program
    {
        static void Main(string[] args)
        {
            var paulBrown = new Biography("Paul", "Brown", "07,12,1995");
            Console.WriteLine($"{paulBrown.Name}, {paulBrown.Surname}, {paulBrown.BirthDate}, {paulBrown.Age} ");
            var person = new Person(paulBrown);
            person.GetBiography();
            person.SerializeOrDeserializeBio(paulBrown, Mode.Serialize);                 
            Console.ReadLine();
        }
    }
}
