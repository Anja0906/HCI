using System.Collections.Generic;
using System.IO;

namespace HCI_big_project.model
{
    public class Accommodation
    {
        public string Name { get; set; }
        public Location Address { get; set; }
        public string Caption { get; set; }
        public List<Picture> Pictures { get; set; }
        public double Rating { get; set; }
        public string Link { get; set; }

        public Accommodation(){}

        public Accommodation(string name, Location address, string caption, List<Picture> pictures, double rating, string link)
        {
            Name        = name;
            Address     = address;
            Caption     = caption;
            Pictures    = pictures;
            Rating      = rating;
            Link        = link;
        }
    }
}