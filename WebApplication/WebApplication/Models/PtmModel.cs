using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class PtmModel
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public string Title { get; set; }
        public string Class { get; set; }
        public string Time { get; set; }
        public int SortId { get; set; }
        public bool IsActive { get; set; }
        public int TotalRecords { get; set; }
        public DateTime CreateByDate { get; set; }
        public int CreateByUserId { get; set; }
        public DateTime ModifyByDate { get; set; }
        public int ModifyByUserId { get; set; }
    }
}