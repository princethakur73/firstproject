using System;

namespace WebApplication.Core
{
    public class StaffDetail : Base
    {
        public string Name { get; set; }

        public string GroupId { get; set; }

        public string Image { get; set; }

        public string Desigination { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string ProfessionalQualification { get; set; }

        public string AcadmicQualification { get; set; }

        public string TrainingStatus { get; set; }

        public string JobStatus { get; set; }

        public int SortId { get; set; }

        public bool IsActive { get; set; }
    }
}
