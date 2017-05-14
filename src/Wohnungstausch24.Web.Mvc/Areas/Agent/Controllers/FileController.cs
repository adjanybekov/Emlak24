using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Wohnungstausch24.Core;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Entites.SearchProfiles.Tenant;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.ViewModels;
using Wohnungstausch24.Models.Images;
using Wohnungstausch24.Models.ViewModels.Agent;
using Constants = Wohnungstausch24.Core.Constants;

namespace Wohnungstausch24.Web.Mvc.Areas.Agent.Controllers
{
    public class FileController : BaseController
    {
        private readonly IListingService _listingService;
        private readonly IFileService _fileService;
        private readonly IAgentService _agentService;
        private IUserService _userService;

        public FileController(IListingService listingService, IFileService fileService, IAgentService agentService, IUserService userService)
        {
            _listingService = listingService;
            _fileService = fileService;
            _agentService = agentService;
            _userService = userService;
        }

        public ActionResult Upload(int id)
        {
            List<FileUploadResponse> files = new List<FileUploadResponse>() ;

            foreach (string fileName in HttpContext.Request.Files)
            {
                var file = Request.Files[fileName];
                if (file != null && file.ContentLength > 0)
                {
                    FileDto fileDto = _fileService.SaveFile(file, User.Identity.GetUserId(),id);
                    files.Add(new FileUploadResponse
                    {
                        name = fileDto.Name,
                        size = fileDto.Length,
                        thumbnailUrl = fileDto.ThumbnailUrl ?? "/Content/assets/img/filetypes/" + fileDto.Extension.Replace(".", "") + ".png",
                        deleteUrl = Url.Action("Delete", "File", new { id = fileDto.Id, area = "Agent", fn = fileDto.Name }),
                        deleteType = "GET",
                        url = fileDto.FileUrl
                    });
                }
            }
            return Json(new FileResponseModel { files=files}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExistingFiles(int id)
        {
            var list = _fileService.GetAllByListingId(id);
            var images = list.Select(c => new FileUploadResponse
            {
                deleteUrl = Url.Action("Delete","File",new {id=c.Id, area = "Agent",fn=c.Name }),
                deleteType = "GET",
                url = c.FileUrl,
                name = c.Name,
                thumbnailUrl = c.ThumbnailUrl?? "/Content/assets/img/filetypes/" +c.Extension.Replace(".","")+".png",
                size = c.Length
            }).ToList();
            return Json(new FileResponseModel {files = images },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string fn, int id)
        {
            var deleteresp = new DeleteResponse();
            try
            {
                _fileService.DeleteImageById(User.Identity.GetUserId(), id);
                deleteresp.files.Add(fn, true);
            }
            catch (Exception e)
            {
                deleteresp.files.Add(fn, false);
            }
            return Json(deleteresp, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetProfilePicture()
        {
            var pictures = _fileService.GetProfilePicture(User.Identity.GetUserId());
            var images = pictures.Select(c => new FileUploadResponse
            {
                deleteUrl = Url.Action("DeleteAvatar", "File", new { area = "Agent", fn = c.Name }),
                deleteType = "GET",
                url = c.FileUrl,
                name = c.Name,
                thumbnailUrl = c.ThumbnailUrl ?? "/Content/assets/img/filetypes/" + c.Extension.Replace(".", "") + ".png",
                size = c.Length
            }).ToList();
            return Json(new FileResponseModel { files = images }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult UploadProfilePicture()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadAvatar()
        {
            List<FileUploadResponse> files = new List<FileUploadResponse>();

            foreach (string fileName in HttpContext.Request.Files)
            {
                var file = Request.Files[fileName];
                if (file != null && file.ContentLength > 0)
                {
                    FileDto fileDto = _fileService.SaveProfilePicture(file, User.Identity.GetUserId());
                    files.Add(new FileUploadResponse
                    {
                        name = fileDto.Name,
                        size = fileDto.Length,
                        thumbnailUrl = fileDto.ThumbnailUrl ?? "/Content/assets/img/filetypes/" + fileDto.Extension.Replace(".", "") + ".png",
                        deleteUrl = Url.Action("DeleteAvatar", "File", new {area = "Agent", fn = fileDto.Name}),
                        deleteType = "GET",
                        url = fileDto.FileUrl
                    });
                }
            }
            return Json(new FileResponseModel { files = files }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeleteAvatar(string fn)
        {
            var deleteresp = new DeleteResponse();
            try
            {
                _fileService.DeleteAvatarByUserId(User.Identity.GetUserId());
                deleteresp.files.Add(fn, true);
            }
            catch (Exception e)
            {
                deleteresp.files.Add(fn, false);
            }
            return Json(deleteresp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProfilePicturePathByUserId(string id)
        {
            var agent = _userService.FindById(id);

            if (agent?.Avatar == null)
            {
                return Content(Constants.DefaultImagePath);
            }
            return Content(agent.Avatar.ThumbnailPath);
        }


        public ActionResult UploadDocument(int id, ClientDocumentType docType)
        {
            List<FileUploadResponse> files = new List<FileUploadResponse>();

            foreach (string fileName in HttpContext.Request.Files)
            {
                var file = Request.Files[fileName];
                if (file != null && file.ContentLength > 0)
                {
                    ClientDocument clientDoc = _fileService.SaveDocument(file, User.Identity.GetUserId(), docType, id);

                    files.Add(new FileUploadResponse
                    {
                        name = clientDoc.File.Name,
                        size = clientDoc.File.ContentLengthInBytes,
                        thumbnailUrl = clientDoc.File.ThumbnailPath?? "/Content/assets/img/filetypes/" + clientDoc.File.Extension.Replace(".", "") + ".png",
                        deleteUrl = Url.Action("DeleteDoc", "File", new { id = clientDoc.FileId, area = "Agent", fn = clientDoc.File.Name }),
                        deleteType = "GET",
                        url = clientDoc.File.RelativePath,
                        docType = clientDoc.DocumentType.ToString()
                    });
                }
            }
            return Json(new FileResponseModel { files = files }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExistingDocuments(int id)
        {
            var docs = _fileService.GetAllDocsByClientId(id);//get a client somehow; et that client's documents from ClientDocument table. and return them as a json.

            var images = docs.Select(c => new FileUploadResponse
            {
                deleteUrl = Url.Action("DeleteDoc", "File", new { id = c.Id, area = "Agent", fn = c.File.Name }),
                deleteType = "GET",
                url = c.File.RelativePath,
                name = c.File.Name,
                thumbnailUrl = c.File.ThumbnailPath?? "/Content/assets/img/filetypes/" + c.File.Extension.Replace(".", "") + ".png",
                size = c.File.ContentLengthInBytes,
                docType = c.DocumentType.ToString()
            }).ToList();
            return Json(new FileResponseModel { files = images }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteDoc(int id, string fn)
        {
            var deleteresp = new DeleteResponse();
            try
            {
                _fileService.DeleteDocById(id);
                deleteresp.files.Add(fn, true);
            }
            catch (Exception e)
            {
                deleteresp.files.Add(fn, false);
            }
            return Json(deleteresp, JsonRequestBehavior.AllowGet);
        }
    }

}