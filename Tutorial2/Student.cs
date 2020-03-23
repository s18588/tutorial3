using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Tutorial2
{
    [XmlType("student")]
    [Serializable]
    public class Student
    {

        public bool CheckEmptyColumns()
        {
            if (FirstName.Equals("") ||
                LastName.Equals("") ||
                SNumber.Equals("") ||
                Birthdate.Equals("") ||
                MomName.Equals("") ||
                DadName.Equals("") ||
                studies.Mode.Equals("") ||
                studies.Name.Equals(""))
            {
                return true;
            }
        return false;
    }
        public bool CheckDuplicate(List<Student> list)
        {
            foreach (Student s in list)
            {
                if (s.FirstName.Equals(FirstName) &&
                    s.LastName.Equals(LastName) &&
                    s.SNumber.Equals(SNumber))
                {
                    return true;
                }
            }
            return false;
        }
        
        [XmlElement(ElementName = "fname")]
        [JsonPropertyName("fname")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("lname")]
        [XmlElement(ElementName = "lname")]
        public string LastName { get; set; }
        
        [JsonPropertyName("snumber")]
        [XmlAttribute(AttributeName = "snumber")]
        public string SNumber { get; set; }
       
        [JsonPropertyName("birthdate")]
        [XmlElement(ElementName = "birthdate")]
        public DateTime Birthdate { get; set; }
        
        [JsonPropertyName("email")]
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
        
        [JsonPropertyName("mothersName")]
        [XmlElement(ElementName = "mothersName")]
        public string MomName { get; set; }
        
        [JsonPropertyName("fathersName")]
        [XmlElement(ElementName = "fathersName")]
        public string DadName { get; set; }

        [JsonPropertyName("studies")]
        [XmlElement("studies")]
        public Studies studies { get; set; }
        
        

    }
        
        
    




    
}