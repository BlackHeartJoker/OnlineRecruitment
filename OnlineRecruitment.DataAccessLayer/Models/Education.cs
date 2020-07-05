using System;

namespace OnlineRecruitment.DataAccessLayer.Models
{
    public class Education
    {
        public int EducationId { get; set; }
        public string InstituteName { get; set; }
        public float StudyDuration { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime EndYear { get; set; }
    }
}
