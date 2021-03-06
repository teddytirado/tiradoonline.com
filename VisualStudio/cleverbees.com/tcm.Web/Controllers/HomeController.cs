﻿using System;
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
        DBDataContext db = new DBDataContext();

        private string nameSpaceName = "tcm.Controllers";
        private string className = "HomeController : Controller";

        public ActionResult Index()
        {
            string directoryPath = string.Empty;

            //Members.KillExcel();
            try
            {
                directoryPath = Server.MapPath("~/uploads").ToString();
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
            }
            catch (Exception ex)
            {
                Logs.Insert(nameSpaceName, className, "ActionResult Index()", ex, "try to create directory: " + directoryPath);
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase fileToUpload, string SchoolID, string UserID)
        {
            //Members.KillExcel();

            //Thread.Sleep(3000);
            
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
                        try
                        {
                            fileToUpload.SaveAs(path);
                        }
                        catch (Exception ex)
                        {
                            Logs.Insert(nameSpaceName, className, "[HttpPost] ActionResult UploadFile(HttpPostedFileBase fileToUpload, string SchoolID, string UserID)", ex, "fileToUpload.SaveAs(path): " + path);
                        }

                        
                        ModelState.Clear();

                        listMembersModel = tcm.Models.Members.ImportExcel(path);
                        

                        ViewBag.Message = "File uploaded successfully";
                    }
                }
            }

            if (listMembersModel != null)
            {
                DBDataContext db = new DBDataContext();

                foreach (var item in listMembersModel)
                {
                    string DOB = item.DOB;
                    if (String.IsNullOrEmpty(DOB))
                        DOB = DateTime.Now.ToString();

                    try
                    {
                        var ors = db.sp_Member_insert
                            (
                                new Guid(UserID),
                                new Guid(SchoolID),
                                item.FirstName,
                                item.LastName,
                                item.Address,
                                item.City,
                                item.State,
                                item.Zip,
                                item.HomeNumber,
                                item.MotherCell,
                                item.DadCell,
                                Convert.ToDateTime(DOB),
                                item.Code
                            ).ToList();

                        //string memberID = ors.MemberID.ToString();
                    }
                    catch (Exception ex)
                    {
                        Logs.Insert(nameSpaceName, className, "[HttpPost] ActionResult UploadFile(HttpPostedFileBase fileToUpload, string SchoolID, string UserID)", ex, "Error in sp_Member_insert");
                    }
                }
            }
            return View("Index", listMembersModel);
        }
    }
}