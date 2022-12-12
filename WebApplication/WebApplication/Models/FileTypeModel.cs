using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class FileTypeModel
    {
        public int Id { get; set; }
        public DateTime Session { get; set; }
        public string FileName { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public bool IsRemoveFile { get; set; }
        public DateTime CreateByDate { get; set; }
        public int CreateByUserId { get; set; }
        public DateTime ModifyByDate { get; set; }
        public int ModifyByUserId { get; set; }
        public int Type { get; set; }

    }
}