using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;
using NReco.VideoConverter;
using Wohnungstausch24.Core.Files;
using Wohnungstausch24.DataAccess.Interfaces;
using Wohnungstausch24.Migrations;
using Wohnungstausch24.Models.Entites;
using Wohnungstausch24.Models.Enums;
using Wohnungstausch24.Models.Images;

namespace Wohnungstausch24.DataAccess.Implementations
{
    public class FileService : IFileService
    {
        private ApplicationDbContext _dbContext;

        public FileService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public FileDto SaveProfilePicture(HttpPostedFileBase file, string userId)
        {
            var agent = _dbContext.Users.Find(userId);
            if (agent == null) throw new ArgumentNullException(nameof(agent));

            var uploadRelativePath = PathHelper.GetUploadRelativePath(userId);
            var fullFileName = HttpContext.Current.Server.MapPath(Path.Combine(uploadRelativePath, file.FileName));

            var uploadThumbRelativePath = PathHelper.GetUploadThumbRelativePath(userId);
            var fullThumbName = HttpContext.Current.Server.MapPath(Path.Combine(uploadThumbRelativePath, file.FileName));

            if (agent.Avatar != null)
            {
                DeleteAvatarByUserId(userId);
            }

            file.SaveAs(fullFileName);

            var wt24File = new Wt24File
            {
                Name = file.FileName,
                Mime = file.ContentType,
                Extension = Path.GetExtension(fullFileName),
                ContentLengthInBytes = file.ContentLength,
                RelativePath = Path.Combine(uploadRelativePath, file.FileName),
                Filetype = FileTypesHelper.FindTypeByExtension(fullFileName),
            };

            if (FileTypesHelper.ImageExtensions.Any(c => c.ToLower() == Path.GetExtension(file.FileName).ToLower()))
            {
                var source = File.ReadAllBytes(fullFileName);
                using (var inStream = new MemoryStream(source))
                {
                    using (var imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream).Watermark(new TextLayer()
                            {
                                DropShadow = true,
                                FontFamily = FontFamily.GenericSansSerif,
                                Text = "wohnungstausch24",
                                Style = FontStyle.Bold,
                                FontColor = Color.Black,
                                Opacity = 48,
                                FontSize = 48
                            })
                            .Format(new JpegFormat())
                            .Save(fullFileName)
                            .Resize(new ResizeLayer(new Size(240,240), ResizeMode.Max))
                            .Save(fullThumbName);
                    }
                }
                wt24File.Name = file.FileName;
                wt24File.ContentLengthInBytes = file.ContentLength;
                wt24File.Filetype = FileTypesHelper.FindTypeByExtension(fullFileName);

                wt24File.Mime = FileTypesHelper.GetMimeFromFile(fullFileName);
                wt24File.Extension = Path.GetExtension(fullFileName);
                wt24File.ThumbnailPath = Path.Combine(uploadThumbRelativePath, file.FileName);
                wt24File.RelativePath = Path.Combine(uploadRelativePath, file.FileName);
            }
            else if (FileTypesHelper.VideoExtensions.Any(c => c == Path.GetExtension(file.FileName)))
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullFileName);

                var outputFormat = NReco.VideoConverter.Format.webm;

                var thumbName = fileNameWithoutExtension + ".jpg";
                var newVideoFileName = outputFormat + "_" + FrameSize.hd720 + "_" + fileNameWithoutExtension + "." + outputFormat;
                var fullVideoThumbName = HttpContext.Current.Server.MapPath(Path.Combine(uploadThumbRelativePath, thumbName));
                var convertedVideoRelativePath = Path.Combine(uploadRelativePath, newVideoFileName);
                var convertedVideoFullPath = HttpContext.Current.Server.MapPath(convertedVideoRelativePath);

                var ffMpeg = new FFMpegConverter();
                var settings = new ConvertSettings { VideoFrameSize = FrameSize.hd480 };
                FFMpegInput[] input = { new FFMpegInput(fullFileName) };
                ffMpeg.ConvertMedia(input, convertedVideoFullPath, outputFormat, settings);
                ffMpeg.GetVideoThumbnail(convertedVideoFullPath, fullVideoThumbName);

                File.Delete(fullFileName);

                var fileInfo = new FileInfo(convertedVideoFullPath);

                wt24File.Filetype = FileTypesHelper.FindTypeByExtension(convertedVideoFullPath);
                wt24File.Mime = FileTypesHelper.GetMimeFromFile(convertedVideoFullPath);
                wt24File.Extension = Path.GetExtension(convertedVideoFullPath);
                wt24File.ContentLengthInBytes = (int)fileInfo.Length;
                wt24File.ThumbnailPath = Path.Combine(uploadThumbRelativePath, thumbName);
                wt24File.RelativePath = convertedVideoRelativePath;
                wt24File.Name = newVideoFileName;
            }

            agent.Avatar = wt24File;
            _dbContext.SaveChanges();
            return new FileDto
            {
                Name = wt24File.Name,
                Id = wt24File.Id,
                Length = wt24File.ContentLengthInBytes,
                FileUrl = wt24File.RelativePath,
                ThumbnailUrl = wt24File.ThumbnailPath,
                Filetype = FileTypesHelper.FindTypeByExtension(fullFileName),
                Extension = wt24File.Extension
            };
        }

        public FileDto SaveFile(HttpPostedFileBase file, string getUserId, int listingId)
        {
            var listing = _dbContext.Listings.Find(listingId);
            if (listing == null) throw new ArgumentNullException(nameof(listing));

            var uploadRelativePath = PathHelper.GetUploadRelativePath(listingId);
            var fullFileName = HttpContext.Current.Server.MapPath(Path.Combine(uploadRelativePath, file.FileName));

            var uploadThumbRelativePath = PathHelper.GetUploadThumbRelativePath(listingId);
            var fullThumbName = HttpContext.Current.Server.MapPath(Path.Combine(uploadThumbRelativePath, file.FileName));

            file.SaveAs(fullFileName);

            var wt24File = new Wt24File
            {
                Name = file.FileName,
                Mime = file.ContentType,
                Extension = Path.GetExtension(fullFileName),
                ContentLengthInBytes = file.ContentLength,
                RelativePath = Path.Combine(uploadRelativePath, file.FileName),
                Filetype = FileTypesHelper.FindTypeByExtension(fullFileName),
            };

            if (FileTypesHelper.ImageExtensions.Any(c=>c.ToLower() ==Path.GetExtension(file.FileName).ToLower()))
            {
                //todo: save different sizes for thumbs
                var source = File.ReadAllBytes(fullFileName);
                using (var inStream = new MemoryStream(source))
                {
                    using (var imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream).Watermark(new TextLayer()
                            {
                                DropShadow = true,
                                FontFamily = FontFamily.GenericSansSerif,
                                Text = "wohnungstausch24",
                                Style = FontStyle.Bold,
                                FontColor = Color.Black,
                                Opacity = 48,
                                FontSize = 48
                            })
                            .Format(new JpegFormat())
                            .Save(fullFileName)
                            .Resize(new ResizeLayer(new Size(390,260),ResizeMode.Max))
                            .Save(fullThumbName);
                    }
                }
                wt24File.Name = file.FileName;
                wt24File.ContentLengthInBytes = file.ContentLength;
                wt24File.Filetype = FileTypesHelper.FindTypeByExtension(fullFileName);

                wt24File.Mime = FileTypesHelper.GetMimeFromFile(fullFileName);
                wt24File.Extension = Path.GetExtension(fullFileName);
                wt24File.ThumbnailPath = Path.Combine(uploadThumbRelativePath, file.FileName);
                wt24File.RelativePath = Path.Combine(uploadRelativePath, file.FileName);
            }
            else if (FileTypesHelper.VideoExtensions.Any(c => c == Path.GetExtension(file.FileName)))
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullFileName);

                var outputFormat = NReco.VideoConverter.Format.webm;

                var thumbName = fileNameWithoutExtension + ".jpg";
                var newVideoFileName = outputFormat + "_" + FrameSize.hd720 +"_"+ fileNameWithoutExtension + "."+outputFormat;
                var fullVideoThumbName = HttpContext.Current.Server.MapPath(Path.Combine(uploadThumbRelativePath, thumbName));
                var convertedVideoRelativePath = Path.Combine(uploadRelativePath,newVideoFileName);
                var convertedVideoFullPath = HttpContext.Current.Server.MapPath(convertedVideoRelativePath);

                var ffMpeg = new FFMpegConverter();
                var settings = new ConvertSettings {VideoFrameSize = FrameSize.hd480};
                FFMpegInput[] input = {new FFMpegInput(fullFileName)};
                ffMpeg.ConvertMedia(input, convertedVideoFullPath, outputFormat,settings);
                ffMpeg.GetVideoThumbnail(convertedVideoFullPath, fullVideoThumbName);

                File.Delete(fullFileName);

                var fileInfo = new FileInfo(convertedVideoFullPath);

                wt24File.Filetype = FileTypesHelper.FindTypeByExtension(convertedVideoFullPath);
                wt24File.Mime = FileTypesHelper.GetMimeFromFile(convertedVideoFullPath);
                wt24File.Extension = Path.GetExtension(convertedVideoFullPath);
                wt24File.ContentLengthInBytes = (int) fileInfo.Length;
                wt24File.ThumbnailPath = Path.Combine(uploadThumbRelativePath, thumbName);
                wt24File.RelativePath = convertedVideoRelativePath;
                wt24File.Name = newVideoFileName;
            }


            var listingFile = new ListingFile {File = wt24File };
            _dbContext.Listings.Find(listingId).Files.Add(listingFile);
            _dbContext.SaveChanges();
            return new FileDto
            {
                Name = wt24File.Name,
                Id = wt24File.Id,
                Length = wt24File.ContentLengthInBytes,
                FileUrl = wt24File.RelativePath,
                ThumbnailUrl = wt24File.ThumbnailPath,
                Filetype = FileTypesHelper.FindTypeByExtension(fullFileName),
                Extension = wt24File.Extension
            };
        }

        public ClientDocument SaveDocument(HttpPostedFileBase file, string getUserId, ClientDocumentType docType,int id)
        {
            var client = _dbContext.Clients.Find(id);

            if (client == null) throw new ArgumentNullException(nameof(client));

            var uploadRelativePath = PathHelper.GetUploadRelativePath(id);
            var fullFileName = HttpContext.Current.Server.MapPath(Path.Combine(uploadRelativePath, file.FileName));

            var uploadThumbRelativePath = PathHelper.GetUploadThumbRelativePath(id);
            var fullThumbName = HttpContext.Current.Server.MapPath(Path.Combine(uploadThumbRelativePath, file.FileName));



            file.SaveAs(fullFileName);

            var wt24File = new Wt24File
            {
                Name = file.FileName,
                Mime = file.ContentType,
                Extension = Path.GetExtension(fullFileName),
                ContentLengthInBytes = file.ContentLength,
                RelativePath = Path.Combine(uploadRelativePath, file.FileName),
                Filetype = FileTypesHelper.FindTypeByExtension(fullFileName),
            };

            if (FileTypesHelper.ImageExtensions.Any(c => c.ToLower() == Path.GetExtension(file.FileName).ToLower()))
            {
                //todo: save different sizes for thumbs
                var source = File.ReadAllBytes(fullFileName);
                using (var inStream = new MemoryStream(source))
                {
                    using (var imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream).Watermark(new TextLayer()
                            {
                                DropShadow = true,
                                FontFamily = FontFamily.GenericSansSerif,
                                Text = "wohnungstausch24",
                                Style = FontStyle.Bold,
                                FontColor = Color.Black,
                                Opacity = 48,
                                FontSize = 48
                            })
                            .Format(new JpegFormat())
                            .Save(fullFileName)
                            .Resize(new ResizeLayer(new Size(390, 260), ResizeMode.Max))
                            .Save(fullThumbName);
                    }
                }
                wt24File.Name = file.FileName;
                wt24File.ContentLengthInBytes = file.ContentLength;
                wt24File.Filetype = FileTypesHelper.FindTypeByExtension(fullFileName);

                wt24File.Mime = FileTypesHelper.GetMimeFromFile(fullFileName);
                wt24File.Extension = Path.GetExtension(fullFileName);
                wt24File.ThumbnailPath = Path.Combine(uploadThumbRelativePath, file.FileName);
                wt24File.RelativePath = Path.Combine(uploadRelativePath, file.FileName);
            }
            else if (FileTypesHelper.VideoExtensions.Any(c => c == Path.GetExtension(file.FileName)))
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullFileName);

                var outputFormat = NReco.VideoConverter.Format.webm;

                var thumbName = fileNameWithoutExtension + ".jpg";
                var newVideoFileName = outputFormat + "_" + FrameSize.hd720 + "_" + fileNameWithoutExtension + "." + outputFormat;
                var fullVideoThumbName = HttpContext.Current.Server.MapPath(Path.Combine(uploadThumbRelativePath, thumbName));
                var convertedVideoRelativePath = Path.Combine(uploadRelativePath, newVideoFileName);
                var convertedVideoFullPath = HttpContext.Current.Server.MapPath(convertedVideoRelativePath);

                var ffMpeg = new FFMpegConverter();
                var settings = new ConvertSettings { VideoFrameSize = FrameSize.hd480 };
                FFMpegInput[] input = { new FFMpegInput(fullFileName) };
                ffMpeg.ConvertMedia(input, convertedVideoFullPath, outputFormat, settings);
                ffMpeg.GetVideoThumbnail(convertedVideoFullPath, fullVideoThumbName);

                File.Delete(fullFileName);

                var fileInfo = new FileInfo(convertedVideoFullPath);

                wt24File.Filetype = FileTypesHelper.FindTypeByExtension(convertedVideoFullPath);
                wt24File.Mime = FileTypesHelper.GetMimeFromFile(convertedVideoFullPath);
                wt24File.Extension = Path.GetExtension(convertedVideoFullPath);
                wt24File.ContentLengthInBytes = (int)fileInfo.Length;
                wt24File.ThumbnailPath = Path.Combine(uploadThumbRelativePath, thumbName);
                wt24File.RelativePath = convertedVideoRelativePath;
                wt24File.Name = newVideoFileName;
            }


            var docFile = new ClientDocument{ File = wt24File,DocumentType = docType,Client = client,ClientId = id,FileId = wt24File.Id};

            _dbContext.Clients.Find(id).ClientDocuments.Add(docFile);

            _dbContext.SaveChanges();

            return docFile;
        }


        public List<FileDto> GetAllByListingId(int id)
        {
            return _dbContext.Listings.Find(id).Files.Select(c=>new FileDto
            {
                Name = c.File.Name,
                Id = c.File.Id,
                Length = c.File.ContentLengthInBytes,
                FileUrl = c.File.RelativePath,
                ThumbnailUrl = c.File.ThumbnailPath,
                Filetype = c.File.Filetype,
                Mime = c.File.Mime,
                Extension = c.File.Extension
            }).ToList();
        }

        public List<FileDto> GetProfilePicture(string userId)
        {
            var list = new List<FileDto>();
            var user = _dbContext.Users.Find(userId);
            if (user?.Avatar != null)
            {
                var userAvatar = user.Avatar;
                var picture = new FileDto
                {
                    Name = userAvatar.Name,
                    Id = userAvatar.Id,
                    Length = userAvatar.ContentLengthInBytes,
                    FileUrl = userAvatar.RelativePath,
                    ThumbnailUrl = userAvatar.ThumbnailPath,
                    Filetype = userAvatar.Filetype,
                    Mime = userAvatar.Mime,
                    Extension = userAvatar.Extension
                };
                list.Add(picture);
            }
            return list;
        }

        public List<ClientDocument> GetAllDocsByClientId(int id)
        {
            var client = _dbContext.Clients.Find(id);

            return client.ClientDocuments.Select(c => new ClientDocument
            {
                File = c.File,
                Client = c.Client,
                DocumentType = c.DocumentType,
                ClientId = c.ClientId,
                FileId = c.FileId
            }).ToList();
        }


        public void DeleteImageById(string getUserId, int id)
        {
            var listingFile = _dbContext.ListingFiles.FirstOrDefault(c => c.FileId == id);
            if (listingFile != null && listingFile.Listing.UserId.Equals(getUserId))
            {
                var file = listingFile.File;
                if (file != null)
                {
                    if (!string.IsNullOrEmpty(file.ThumbnailPath))
                    {
                        var fullThumbPath = HttpContext.Current.Server.MapPath(file.ThumbnailPath);
                        File.Delete(fullThumbPath);
                    }

                    var fullFilePath = HttpContext.Current.Server.MapPath(file.RelativePath);
                    File.Delete(fullFilePath);
                    _dbContext.ListingFiles.Remove(listingFile);
                    _dbContext.Files.Remove(file);
                    _dbContext.SaveChanges();
                }
            }
        }

        public void DeleteAvatarByUserId(string userId)
        {
            var user = _dbContext.Users.Find((userId));
            var wt24File = user.Avatar;

            if (wt24File == null) return;

            if (!string.IsNullOrEmpty(wt24File.ThumbnailPath))
            {
                var fullThumbPath = HttpContext.Current.Server.MapPath(wt24File.ThumbnailPath);
                if (fullThumbPath != null) File.Delete(fullThumbPath);
            }

            var fullFilePath = HttpContext.Current.Server.MapPath(wt24File.RelativePath);
            File.Delete(fullFilePath);
            _dbContext.Files.Remove(wt24File);
            _dbContext.SaveChanges();
        }

        public void DeleteDocById( int id)
        {
            var docFile = _dbContext.ClientDocuments.FirstOrDefault(c => c.Id == id);

            if (docFile != null)
            {
                if (!string.IsNullOrEmpty(docFile.File.ThumbnailPath))
                {
                    var fullThumbPath = HttpContext.Current.Server.MapPath(docFile.File.ThumbnailPath);
                    File.Delete(fullThumbPath);
                }
                var fullFilePath = HttpContext.Current.Server.MapPath(docFile.File.RelativePath);
                File.Delete(fullFilePath);
                _dbContext.ClientDocuments.Remove(docFile);
                _dbContext.SaveChanges();
            }
            else return;

        }
    }
}
