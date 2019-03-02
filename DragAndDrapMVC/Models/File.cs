using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragAndDrapMVC.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}