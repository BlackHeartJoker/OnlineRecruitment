using System.Collections.Generic;

namespace OnlineRecruitment.DataAccessLayer.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string EmployerName { get; set; }
        public string EmployerDescription { get; set; }
        public int ExperienceLevel { get; set; }
        public int EmployerDuration { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Skill> SkillsNeeded { get; set; }
        public string JobDescription { get; set; }
        public bool isEnabled { get; set; }
    }

    public class PostDTO
    {
        public int PostId { get; set; }
        public string EmployerName { get; set; }
        public string EmployerDescription { get; set; }
        public int ExperienceLevel { get; set; }
        public int EmployerDuration { get; set; }
        public string Location { get; set; }
        public List<Skill> SkillsNeeded { get; set; }
        public string JobDescription { get; set; }
        public bool isEnabled { get; set; }
    }

}
