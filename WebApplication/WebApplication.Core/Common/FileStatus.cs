using System.IO;

namespace WebApplication.Core.Common
{
    public class FileStatus
    {
        #region Constructors

        public FileStatus()
        {

        }

        public FileStatus(FileInfo fileInfo)
        {
            SetValues(fileInfo.Name, (long)fileInfo.Length);
        }

        public FileStatus(string name, int length)
        {
            SetValues(name, length);
        }

        public FileStatus(string name, long length, string storageFolder)
        {
            SetValues(name, length, storageFolder);
        }

        #endregion

        #region Properties

        public string group { get; set; }

        public string name { get; set; }

        public string type { get; set; }

        public long size { get; set; }

        public string progress { get; set; }

        public string url { get; set; }

        public string complete_url { get; set; }

        public string error_url { get; set; }

        public string delete_url { get; set; }

        public string delete_type { get; set; }

        public string error { get; set; }

        #endregion

        private void SetValues(string fileName, long fileLength)
        {
            name = fileName;
            type = "image/png";
            size = fileLength;
            progress = "1.0";
            url = string.Concat("api/upload?f=", fileName);
            complete_url = string.Concat("api/filecomplete?f=", fileName);
            error_url = string.Concat("api/fileerror?f=", fileName);
            delete_url = string.Concat("api/upload?f=", fileName);
            delete_type = "DELETE";
        }

        private void SetValues(string fileName, long fileLength, string storageFolder)
        {
            name = fileName;
            type = "image/png";
            size = fileLength;
            progress = "1.0";
            url = string.Concat("api/upload?f=", fileName, "&storageFolder=", storageFolder);
            complete_url = string.Concat("api/filecomplete?f=", fileName, "&storageFolder=", storageFolder);
            error_url = string.Concat("api/fileerror?f=", fileName, "&storageFolder=", storageFolder);
            delete_url = string.Concat("api/upload?f=", fileName, "&storageFolder=", storageFolder);
            delete_type = "DELETE";
        }
    }
}
