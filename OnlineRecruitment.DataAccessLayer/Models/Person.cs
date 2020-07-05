using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitment.DataAccessLayer.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Resume { get; set; }
        public string Photo { get; set; }
        public string Location { get; set; }
        public string Profession { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual Stack Stack { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
    }

    public class PersonDTO
    {
        public string Name { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Resume { get; set; }
        public string Photo { get; set; }
        public string Location { get; set; }
        public string Profession { get; set; }
        public List<Education> Educations { get; set; }
        public List<ProjectDTO> Projects { get; set; }
        public StackDTO Stack { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }
    }
}
