using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;

namespace WebApplication.Core
{
    public class FilesHelper
    {

        String DeleteURL = null;
        String DeleteType = null;
        String StorageRoot = null;
        String UrlBase = null;
        String tempPath = null;
        //ex:"~/Files/something/";
        String serverMapPath = null;
        public FilesHelper(String DeleteURL, String DeleteType, String StorageRoot, String UrlBase, String tempPath, String serverMapPath)
        {
            this.DeleteURL = DeleteURL;
            this.DeleteType = DeleteType;
            this.StorageRoot = StorageRoot;
            this.UrlBase = UrlBase;
            this.tempPath = tempPath;
            this.serverMapPath = serverMapPath;
        }

        public void DeleteFiles(String pathToDelete)
        {

            string path = HostingEnvironment.MapPath(pathToDelete);

            System.Diagnostics.Debug.WriteLine(path);
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo fi in di.GetFiles())
                {
                    System.IO.File.Delete(fi.FullName);
                    System.Diagnostics.Debug.WriteLine(fi.Name);
                }

                di.Delete(true);
            }
        }

        public String DeleteFile(String file, string type = null)
        {
            System.Diagnostics.Debug.WriteLine("DeleteFile");
            //    var req = HttpContext.Current;
            System.Diagnostics.Debug.WriteLine(file);

            String fullPath = Path.Combine(StorageRoot, type, file);
            System.Diagnostics.Debug.WriteLine(fullPath);
            System.Diagnostics.Debug.WriteLine(System.IO.File.Exists(fullPath));
            String thumbPath = string.Concat(type ?? "", "/", file, "-250x250.jpg");
            String partThumb1 = Path.Combine(StorageRoot + type ?? "", "thumbs");
            string fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
            String partThumb2 = Path.Combine(partThumb1, fileWithoutExtension + "-250x250.jpg");

            System.Diagnostics.Debug.WriteLine(partThumb2);
            System.Diagnostics.Debug.WriteLine(System.IO.File.Exists(partThumb2));
            if (System.IO.File.Exists(fullPath))
            {
                //delete thumb 
                if (System.IO.File.Exists(partThumb2))
                {
                    System.IO.File.Delete(partThumb2);
                }
                System.IO.File.Delete(fullPath);
                String succesMessage = "Ok";
                return succesMessage;
            }
            String failMessage = "Error Delete";
            return failMessage;
        }
        public JsonFiles GetFileList()
        {

            var r = new List<ViewDataUploadFilesResult>();

            String fullPath = Path.Combine(StorageRoot);
            if (Directory.Exists(fullPath))
            {
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                foreach (FileInfo file in dir.GetFiles())
                {
                    int SizeInt = unchecked((int)file.Length);
                    r.Add(UploadResult(file.Name, SizeInt, file.FullName));
                }

            }
            JsonFiles files = new JsonFiles(r);

            return files;
        }

        public void UploadAndShowResults(HttpContextBase ContentBase, List<ViewDataUploadFilesResult> resultList, string[] fileExtensions = null)
        {
            var httpRequest = ContentBase.Request;
            if (httpRequest.Form["MediaUploadType"] == MediaUploadType.Link)
            {
                UploadResultLink(ContentBase, resultList);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(Directory.Exists(tempPath));

                String fullPath = Path.Combine(StorageRoot);
                Directory.CreateDirectory(fullPath);
                // Create new folder for thumbs
                // Directory.CreateDirectory(fullPath + "/thumbs/");

                foreach (String inputTagName in httpRequest.Files)
                {

                    var headers = httpRequest.Headers;

                    var file = httpRequest.Files[inputTagName];
                    System.Diagnostics.Debug.WriteLine(file.FileName);

                    if (string.IsNullOrEmpty(headers["X-File-Name"]))
                    {

                        UploadWholeFile(ContentBase, resultList, fileExtensions);
                    }
                    else
                    {

                        UploadPartialFile(headers["X-File-Name"], ContentBase, resultList, fileExtensions);
                    }
                }
            }
        }

        public void UploadResultLink(HttpContextBase httpContext, List<ViewDataUploadFilesResult> list)
        {
            var result = new ViewDataUploadFilesResult()
            {
                entityId = int.Parse(httpContext.Request.Form["EntityId"].ToString()),
                title = "",
                name = httpContext.Request.Form["Name"].ToString(),
                extension = "",
                size = 0,
                type = httpContext.Request.Form["MediaUploadType"].ToString(),
                url = "",
                MediaType = MediaUploadType.Link,
                deleteUrl = "",
                thumbnailUrl = "",
                deleteType = "",
                altAttribute = "",
                titleAttribute = "",
                error = ""
            };
            list.Add(result);
        }

        private void UploadWholeFile(HttpContextBase requestContext, List<ViewDataUploadFilesResult> statuses, string[] fileExtensions = null)
        {

            var request = requestContext.Request;
            string error = null;
            int entityId = int.Parse(request.Form["EntityId"].ToString());

            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];
                if (!fileExtensions.Contains(Path.GetExtension(file.FileName)))
                {
                    error = "file not support.";
                    statuses.Add(UploadResult(file.FileName, file.ContentLength, file.FileName, entityId: 0, GUID: null, error: error));
                    continue;
                }

                String pathOnServer = Path.Combine(StorageRoot);
                var fileName = Guid.NewGuid().ToString();
                var fullPath = Path.Combine(pathOnServer, fileName + Path.GetExtension(file.FileName));

                file.SaveAs(fullPath);

                //Create thumb
                string[] imageArray = file.FileName.Split('.');
                if (imageArray.Length != 0)
                {
                    String extansion = imageArray[imageArray.Length - 1].ToLower();
                    if (extansion != "jpg" && extansion != "png" && extansion != "jpeg") //Do not create thumb if file is not an image
                    {

                    }
                    else
                    {
                        var ThumbfullPath = Path.Combine(pathOnServer, "thumbs");
                        //String fileThumb = file.FileName + ".200x200.jpg";
                        String fileThumb = fileName + "-250x250.jpg";
                        var ThumbfullPath2 = Path.Combine(ThumbfullPath, fileThumb);
                        using (MemoryStream stream = new MemoryStream(System.IO.File.ReadAllBytes(fullPath)))
                        {
                            Bitmap bitmap = new Bitmap(stream);
                            ImageHandler imageHandler = new ImageHandler();
                            imageHandler.Save(bitmap, 250, 250, 1, ThumbfullPath2);

                            //var thumbnail = new WebImage(stream).Resize(250, 250);
                            //thumbnail.Save(ThumbfullPath2, "jpg");
                        }

                    }
                }
                statuses.Add(UploadResult(file.FileName, file.ContentLength, file.FileName, entityId, fileName, error));
            }
        }

        private void UploadPartialFile(string fileName, HttpContextBase requestContext, List<ViewDataUploadFilesResult> statuses, string[] fileExtensions = null)
        {
            var request = requestContext.Request;
            if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var file = request.Files[0];
            var inputStream = file.InputStream;
            String patchOnServer = Path.Combine(StorageRoot);
            var fullName = Path.Combine(patchOnServer, Path.GetFileName(file.FileName));
            var ThumbfullPath = Path.Combine(fullName, Path.GetFileName(file.FileName + "-250x250.jpg"));
            ImageHandler handler = new ImageHandler();

            var ImageBit = ImageHandler.LoadImage(fullName);
            handler.Save(ImageBit, 80, 80, 10, ThumbfullPath);
            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(UploadResult(file.FileName, file.ContentLength, file.FileName));
        }

        public ViewDataUploadFilesResult UploadResult(String FileName, int fileSize, String FileFullPath, int entityId = 0, string GUID = null, string error = null)
        {
            String getType = System.Web.MimeMapping.GetMimeMapping(FileFullPath);
            var result = new ViewDataUploadFilesResult()
            {
                entityId = entityId,
                title = FileName,
                name = GUID,
                extension = Path.GetExtension(FileName),
                size = fileSize,
                type = getType,
                url = UrlBase + GUID + Path.GetExtension(FileName),
                deleteUrl = error == null ? DeleteURL + entityId : null,
                thumbnailUrl = CheckThumb(getType, GUID + Path.GetExtension(FileName)),
                deleteType = DeleteType,
                altAttribute = FileName.ToLower().Replace(" ", "-"),
                titleAttribute = FileName,
                error = error
            };
            return result;
        }

        public String CheckThumb(String type, String FileName)
        {
            var splited = type.Split('/');
            if (splited.Length == 2)
            {
                string extansion = splited[1].ToLower();
                if (extansion.Equals("jpeg") || extansion.Equals("jpg") || extansion.Equals("png") || extansion.Equals("gif"))
                {
                    String thumbnailUrl = UrlBase + "thumbs/" + Path.GetFileNameWithoutExtension(FileName) + "-250x250.jpg";
                    return thumbnailUrl;
                }
                else
                {
                    if (extansion.Equals("octet-stream")) //Fix for exe files
                    {
                        return "/Content/Free-file-icons/48px/exe.png";

                    }
                    if (extansion.Contains("zip")) //Fix for exe files
                    {
                        return "/Content/Free-file-icons/48px/zip.png";
                    }
                    String thumbnailUrl = "/Content/Free-file-icons/48px/" + extansion + ".png";
                    return thumbnailUrl;
                }
            }
            else
            {
                return UrlBase + "/thumbs/" + Path.GetFileNameWithoutExtension(FileName) + "-250x250.jpg";
            }

        }

        public List<String> FilesList()
        {

            List<String> Filess = new List<String>();
            string path = HostingEnvironment.MapPath(serverMapPath);
            System.Diagnostics.Debug.WriteLine(path);
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo fi in di.GetFiles())
                {
                    Filess.Add(fi.Name);
                    System.Diagnostics.Debug.WriteLine(fi.Name);
                }

            }
            return Filess;
        }
    }

    public class JsonFiles
    {
        public ViewDataUploadFilesResult[] files;
        public string TempFolder { get; set; }
        public JsonFiles(List<ViewDataUploadFilesResult> filesList)
        {
            files = new ViewDataUploadFilesResult[filesList.Count];
            for (int i = 0; i < filesList.Count; i++)
            {
                files[i] = filesList.ElementAt(i);
            }

        }
    }
}
