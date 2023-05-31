using System;

namespace HCI_big_project.model
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public byte[] Content { get; set; }
        public string Type { get; set; }

        public Picture(int id, string name, int size, byte[] content, string type)
        {
            Id        = id;
            Name      = name;
            Size      = size;
            Content   = content;
            Type      = type;                       
        }    
        public override string ToString()
        {
            string contentString = Convert.ToBase64String(Content);

            return $"Picture ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Size: {Size}\n" +
                   $"Content: {contentString}\n" +
                   $"Type: {Type}";
        }
    }
}