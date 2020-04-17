using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class CircularsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "File")]
        [DataType(DataType.Upload)]
        public string FileName { get; set; }
        public string Extenstion { get; set; }
        public DateTime CreateByDate { get; set; }
        public int CreateByUserId { get; set; }
        public DateTime ModifyByDate { get; set; }
        public int ModifyByUserId { get; set; }
        public bool IsActive { get; set; }
        public int SortId { get; set; }
    }
}