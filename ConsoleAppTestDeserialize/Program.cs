using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleAppTestDeserialize
{

    class Program
    {
        static void Main(string[] args)
        {
            string assemblypath = Assembly.GetExecutingAssembly().Location;
            string folder = System.IO.Path.GetDirectoryName(assemblypath);
            string xmlPath = System.IO.Path.Combine(folder, "settings.xml");

            Console.WriteLine("1 create new xml, 2 try to read xml:");
            string mode = Console.ReadLine();
            if (mode == "1")
            {
                Console.WriteLine("Create new settings xml file");
                Settings sts = new Settings();
                sts.field1 = "uservalue1";
                sts.field2 = "uservalue2";
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(xmlPath))
                {
                    serializer.Serialize(writer, sts);
                }
                Console.WriteLine("Success");
            }
            else if (mode == "2")
            {
                Settings sts = null;
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                using (System.IO.StreamReader reader = new System.IO.StreamReader(xmlPath))
                {
                    sts = (Settings)serializer.Deserialize(reader);
                    Console.WriteLine("value1 = " + sts.field1);
                    Console.WriteLine("value2 = " + sts.field2);
                    Console.WriteLine("value3 = " + sts.field3);
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
