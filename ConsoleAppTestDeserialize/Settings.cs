using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleAppTestDeserialize
{
    [Serializable]
    public class Settings
    {
        public string field1;
        public string field2;
        public string field3 = "defaultvalue3";

        //empty contructor for serializer
        public Settings()
        {

        }
    }
}
