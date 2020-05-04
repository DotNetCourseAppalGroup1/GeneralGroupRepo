using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Biography
    {
        public int _age;
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age 
        {
            get
            {
                return _age;
            }                                   
            set
            {
                _age = SetAge();          
            }
        }
        public Biography(string name, string surname, string birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = BirthDateConverter(birthDate);
            _age = SetAge();
        }
        public Biography()
        {
        
        }
        private DateTime BirthDateConverter(string dateOfBirth)
        {
            DateTime date = new DateTime();
            try
            {
                date = Convert.ToDateTime(dateOfBirth);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception! \n {ex.Message}");
            }
            return date;
        }
        private int SetAge()
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            TimeSpan time = now.Subtract(BirthDate);
            DateTime counter = new DateTime();
            int age = (counter + time).Year;
            return age;
        }
    }
}
