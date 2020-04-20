using Models.Attributes;
using Models.Enums;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;


namespace Models
{
    [BioMetaData(BioPath = "E://samples/Biography/biography.txt")]
    public class Person : IInfoReadable
    {
        public string pathToFile;
        public Biography Bio { get; set; }

        public Person()
        {

        }
        public Person(Biography bio)
        {
            Bio = bio;
        }
        public void SetNewBiography(Biography biography)
        {
            if (biography != null)
            {
                Bio = biography;
            }
            else
            {
                Console.WriteLine($" Biography do not contain information about person (referense is NULL)!");
            }
        }
        public void SetPathToFile(string path)
        {
            pathToFile = path;
        }
        public void SerializeOrDeserializeBio(Biography bio, Mode mode)
        {
            try
            {
                if (bio == null && mode.ToString() == "Serialize")
                {
                }
                if (mode.ToString() == "Serialize")
                {
                    SerialiseBiography(bio);
                    return;
                }
                if (mode.ToString() == "Deserialize")
                {
                    Bio = DeserializeBiography();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error!!! : {ex.Message}");
            }
        }
        private void SerialiseBiography(Biography bio)
        {
            string path = "E://samples/Biography/biography.txt";
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                string jsonBiography = JsonSerializer.Serialize<Biography>(bio);

                sw.Write(jsonBiography);
                Console.WriteLine($"The object serialized to file {path}.\n");
            }
        }
        private Biography DeserializeBiography()
        {
            Biography biography = null;
            try
            {                
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    string jsonBiography = sr.ReadToEnd();
                    biography = JsonSerializer.Deserialize<Biography>(jsonBiography);
                    Console.WriteLine($"The object deserialized from the file {pathToFile}.\n");
                }
                return biography;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception in DeserializeBiography(): {ex.Message}\n" +
                    $" Method will return NULL!!!");
                return biography;
            }
        }
        public void GetBiography()
        {
            try
            {
                if (Bio != null)
                {
                    Console.WriteLine($" Name: {Bio.Name}, Surname: {Bio.Surname}," +
                        $" Date of birth: {Bio.BirthDate}, Age: {Bio.Age}");
                }
                if (Bio == null)
                {
                    Console.WriteLine($" ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception in GetBiography(): {ex.Message}");
            }
        }
    }
}
