using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.utils;

namespace HCI_big_project.repository
{
    public class PictureRepository
    {
        private const string FilePath = "../../files/pictures.json";
        private List<Picture> Pictures { get; set; }

        public PictureRepository()
        {
            Pictures = ListHandler.ReadList<Picture>(FilePath);
        }

        public void AddPicture(Picture picture)
        {
            Pictures.Add(picture);
        }

        public void DeletePicture(Picture picture)
        {
            Pictures.Remove(picture);
        }

        public List<Picture> GetAllPictures()
        {
            return Pictures;
        }

        public Picture FindPictureByName(string name)
        {
            return Pictures.FirstOrDefault(picture => picture.Name.Equals(name));
        }

        public void SaveAll()
        {
            ListHandler.WriteList(Pictures, FilePath);
        }
    }
}
