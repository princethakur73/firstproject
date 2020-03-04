namespace WebApplication.Core
{
    public class TransferCerticate : Base
    {
        public string StudentName { get; set; }

        public string ClassName { get; set; }
        public int ClassMasterId { get; set; }

        public string AdmissionNumber { get; set; }

        public string FileName { get; set; }
        public string Extenstion { get; set; }

        public bool IsPublish { get; set; }
    }
}
