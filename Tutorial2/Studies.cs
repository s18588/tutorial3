using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Tutorial2
{
    [Serializable]
    public class Studies
    {
        [XmlElement("name", typeof(string))] public string Name { get; set; }
        [XmlElement("mode", typeof(string))] public string Mode { get; set; }
    }
        
}