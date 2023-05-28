using System.Collections.Generic;
using System.IO;

namespace HCI_big_project.model
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Address { get; set; }
        public string Caption { get; set; }
        public List<Picture> Pictures { get; set; }
        public string Link { get; set; }

        public Restaurant()
        {
        }

        public Restaurant(int id,string name, Location address, string caption, List<Picture> pictures, string link)
        {
            Id              = id;
            Name            = name;
            Address         = address;
            Caption         = caption;
            Pictures        = pictures;
            Link            = link;
        }
        public override string ToString()
        {
            string picturesString = string.Join("\n", Pictures);

            return $"Restaurant ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Address: {Address}\n" +
                   $"Caption: {Caption}\n" +
                   $"Pictures:\n{picturesString}\n" +
                   $"Link: {Link}";
        }
    }
}