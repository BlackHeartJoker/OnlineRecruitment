using System.Collections.Generic;

namespace OnlineRecruitment.DataAccessLayer.Models
{
    public class Stack
    {
        public int StackId { get; set; }
        public virtual Skill Skill { get; set; }
        public float Competence { get; set; }
    }

    public class StackDTO
    {
        public int StackId { get; set; }
        public Skill Skill { get; set; }
        public float Competence { get; set; }
    }
}
