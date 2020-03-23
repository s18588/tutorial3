using System;
using System.Collections.Generic;
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
            
            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),new XmlRootAttribute("University"));
            
            
            
            serializer.Serialize(writer, list);
            
            var jsonString = JsonSerializer.Serialize(list); 
            File.WriteAllText("data.json", jsonString);
            
        }
    }
}