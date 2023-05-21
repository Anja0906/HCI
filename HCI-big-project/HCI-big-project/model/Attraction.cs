using System.IO;

namespace HCI_big_project.model
{
    public class Attraction
    {
        public string Name { get; set; }
        public Location Address { get; set; }
        public string Caption { get; set; }
        public FileStream Pictures { get; set; }

        public Attraction(){}

        public Attraction(string name, Location address, string caption, FileStream pictures)
        {
            Name = name;
            Address = address;
            Caption = caption;
            Pictures = pictures;
        }
    }
}