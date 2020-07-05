using System.Collections.Generic;

namespace OnlineRecruitment.DataAccessLayer.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public float Duration { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Skill> SkillsUsed { get; set; }
        public string Role { get; set; }
        public string Designation { get; set; }
    }

    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public float Duration { get; set; }
        public string Description { get; set; }
        public List<Skill> SkillsUsed { get; set; }
        public string Role { get; set; }
        public string Designation { get; set; }
    }
}
