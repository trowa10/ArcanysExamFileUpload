using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DragAndDrapMVC.Models
{
    public class UploadViewModel
    {
        public string UserEmail { get; set; }
        public int FileSizeLimitMB { get; set; }
        public int MaxFiles { get; set; }
        public string ContentTypes { get; set; }
    }
}