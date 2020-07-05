using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRecruitment.DataAccessLayer.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int EmployerId { get; set; }
        public string EmployerName { get; set; }
        public int PersonId{ get; set; }
        public string PersonName { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }

    }
}
