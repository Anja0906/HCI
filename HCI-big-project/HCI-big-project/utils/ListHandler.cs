namespace HCI_big_project.utils
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    public static class ListHandler
    {
        // Function to write the list to a file in JSON format
        public static void WriteList<T>(List<T> list, string filePath)
        {
            string json = JsonConvert.SerializeObject(list);

            using (StreamWriter file = new StreamWriter(filePath))
            {
                file.Write(json);
            }
        }

        // Function to read the list from a file in JSON format
        public static List<T> ReadList<T>(string filePath)
        {
            using (StreamReader file = new StreamReader(filePath))
            {
                string json = file.ReadToEnd();
                List<T> list = JsonConvert.DeserializeObject<List<T>>(json);

                return list;
            }
        }
    }


}