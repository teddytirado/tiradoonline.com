using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tcm.Models;
using System.IO;
using System.Threading;
using tcm.App_Data;

namespace tcm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Members.KillExcel();

            string directoryPath =  Server.MapPath("~/uploads").ToString();
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase fileToUpload)
        {
            Members.KillExcel();

            Thread.Sleep(3000);
            
            string directoryPath = Server.MapPath("~/uploads").ToString();
            string path = string.Empty;

            List<MembersModel> listMembersModel = new List<MembersModel>();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            if (ModelState.IsValid)
            {
                if (fileToUpload == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (fileToUpload.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] { ".xlsx" };
                    if (!AllowedFileExtensions.Contains(fileToUpload.FileName.Substring(fileToUpload.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (fileToUpload.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(fileToUpload.FileName);
                        path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                        fileToUpload.SaveAs(path);
                        ModelState.Clear();

                        listMembersModel = tcm.Models.Members.ImportExcel(path);
                        

                        ViewBag.Message = "File uploaded successfully";
                    }
                }
            }
            return View("Index", listMembersModel);
        }
    }
}