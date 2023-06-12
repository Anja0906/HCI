using System.Collections.Generic;
using System.IO;

namespace HCI_big_project.model
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Address { get; set; }
        public string Caption { get; set; }
        public List<Picture> Pictures { get; set; }

        public Attraction(){}

        public Attraction(int id,string name, Location address, string caption, List<Picture> pictures)
        {
            Id       = id;
            Name     = name;
            Address  = address;
            Caption  = caption;
            Pictures = pictures;
        }
        public override string ToString()
        {
            string picturesString = string.Join("\n", Pictures);

            return $"Attraction ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Address: {Address}\n" +
                   $"Caption: {Caption}\n" +
                   $"Pictures:\n{picturesString}";
        }
    }
}