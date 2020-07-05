using System;
using System.Collections.Generic;

namespace OnlineRecruitment.DataAccessLayer.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public string EmployerName { get; set; }
        public string Description { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public class EmployerDTO
    {
        public string EmployerName { get; set; }
        public string Description { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
