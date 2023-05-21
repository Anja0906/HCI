using System.IO;

namespace HCI_big_project.model
{
    public class Restaurant
    {
        public string Name { get; set; }
        public Location Address { get; set; }
        public string Caption { get; set; }
        public FileStream Pictures { get; set; }
        public string Link { get; set; }

        public Restaurant()
        {
        }

        public Restaurant(string name, Location address, string caption, FileStream pictures, string link)
        {
            Name = name;
            Address = address;
            Caption = caption;
            Pictures = pictures;
            Link = link;
        }
    }
}