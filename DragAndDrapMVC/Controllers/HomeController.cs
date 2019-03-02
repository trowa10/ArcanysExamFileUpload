using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model = DragAndDrapMVC.Models;

namespace DragAndDrapMVC.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            try
            {

                var repo = _unitOfWork.Repository;
                int fileCOunt = repo.Get().Where(x => x.OriginalName == file.FileName).Count();
                var isFileExist = fileCOunt > 0 ? true : false;
                string newFileName = file.FileName;
                if (isFileExist)
                    newFileName = $"{file.FileName.ToString()}_Copy{(fileCOunt + 1).ToString()}";


                var memStream = new MemoryStream();
                file.InputStream.CopyTo(memStream);

                byte[] fileData = memStream.ToArray();

                //save file to database using fictitious repository

                var data = new Model.File()
                {
                    Name = newFileName,
                    OriginalName = file.FileName,
                    Extension = file.ContentType,
                    Size = file.ContentLength,
                    Content = fileData
                };

                repo.Insert(data);
                _unitOfWork.Save();
            }
            catch (Exception exception)
            {
                return Json(new
                {
                    success = false,
                    response = exception.Message
                });
            }

            return Json(new
            {
                success = true,
                response = "File uploaded."
            });
        }

        public ActionResult GetFiles()
        {
            var repo = _unitOfWork.Repository;
            var files = repo.Get().Select(x => new { x.Id, x.Name, x.Size, x.Extension }).OrderByDescending(x => x.Id).ToList();

            return Json(new
            {
                success = true,
                datas = files
            }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var repo = _unitOfWork.Repository;
            repo.Delete(id);
            _unitOfWork.Save();

            return Json(new
            {
                success = true,
                response = "File removed."
            });
           
        }     

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}