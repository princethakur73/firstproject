using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class TransferCertificateModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Class")]
        [UIHint("ClassMasterRomanId")]
        public int ClassMasterId { get; set; }
        public string ClassName { get; set; }
        public string StudentName { get; set; }
        public string AdmissionNumber { get; set; }

        [Display(Name = "File")]
        [DataType(DataType.Upload)]
        public string FileName { get; set; }
        public string Extenstion { get; set; }

        public DateTime CreateByDate { get; set; }

        public int CreateByUserId { get; set; }

        public DateTime ModifyByDate { get; set; }

        public int ModifyByUserId { get; set; }
    }
}