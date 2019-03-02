using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DragAndDrapMVC.Models;

namespace DragAndDrapMVC.Interface
{
    public interface IImageRepository
    {
        IEnumerable<File> GetAll();

        File Get(int id);

        File Add(File item);

        bool Update(File item);

        bool Delete(int id);
    }
}