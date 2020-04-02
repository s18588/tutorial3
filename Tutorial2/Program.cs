using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Tutorial2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            var list = new List<Student>();

            using (var stream = new StreamReader(File.OpenRead(@"MOCK_DATA.csv"))) {
                string line = null;
                while ((line = stream.ReadLine()) != null) {
                    string[] student = line.Split(',');
                    Console.WriteLine(student.Length);

                    if (student.Length != 9)
                    {
                        File.WriteAllText(@"log.txt", line + " ERROR: empty columns!!!!");
                        continue;
                    }
                    var st = new Student
                    {
                        FirstName = student[0],
                        LastName = student[1],
                        MomName = student[7],
                        Email = student[6],
                        DadName = student[8],
                        SNumber = student[4],
                        Birthdate = DateTime.Parse(student[5]),
                        studies = new Studies()
                        {
                            Mode = student[3],
                            Name = student[2]
                        } 
                    };
                    
                    if (st.CheckDuplicate(list) && list.Count > 0)
                    {
                        {
                            File.WriteAllText(@"log.txt", line + " ERROR: duplicate student!!!!");
                            continue;
                        }
                    }
                    
                    list.Add(st);
                } }
            
            var uni = new University
            {
                CreatedAt = DateTime.Now.ToString("dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo),
                Author = "Michal Arent",
                Students = list
            };
            
            
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(University),new XmlRootAttribute("University"));
            serializer.Serialize(writer, uni);

            var Wrapper = new Wrapper() {University = uni};
            var jsonString = JsonSerializer.Serialize(Wrapper);
            File.WriteAllText("data.json", jsonString);
            
        }
    }
}