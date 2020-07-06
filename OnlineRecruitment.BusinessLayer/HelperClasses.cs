using OnlineRecruitment.DataAccessLayer;
using OnlineRecruitment.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitment.BusinessLayer
{
    public class HelperClasses
    {
        private DBHelper database = null;
        public HelperClasses()
        {
            database = new DBHelper();
        }

        public int RegisterJobSeeker(PersonDTO personDTO)
        {
            try
            {
                var person = new Person()
                {
                    Age = personDTO.Age,
                    Role = "Job Seeker",
                    Email = personDTO.Email,
                    Experience = personDTO.Experience,
                    Gender = personDTO.Gender,
                    Location = personDTO.Location,
                    Name = personDTO.Name,
                    PhoneNo = personDTO.PhoneNo,
                    Photo = personDTO.Photo,
                    Resume = personDTO.Resume,
                    Profession = personDTO.Profession,
                };

                return database.CreatePerson(person); // Create person Entry to the database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
            
        }

        public bool RegisterEmployer(EmployerDTO employerDTO)
        {
            try
            {
                var employer = new Employer()
                {
                    Description = employerDTO.Description,
                    EmployerName = employerDTO.EmployerName,
                    EstablishmentDate = employerDTO.EstablishmentDate,
                };
                database.CreateEmployer(employer);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        public List<Person> GetAllPersons()
        {
            return database.GetPersonsList();
        }

        public Person GetPersonById(int personId)
        {
            return database.GetPersonById(personId);
        }

        public void UpdatePerson(Person person)
        {
            database.UpdatePerson(person);
        }

        public Person DeletePerson(int id)
        {
            return database.DeletePerson(id);
        }
        //public bool CreateEmployerPost(PostDTO postDTO)
        //{
        //    try
        //    {
        //        var skills = new List<Skill>();

        //        foreach(var item in postDTO.SkillsNeeded)
        //        {
        //            Skill skill = null; 
        //            if (item.SkillId != 0)
        //            {
        //                skills.Add(item);
        //            }
        //            else
        //            {
        //                skill = database.IsSkillExists(item.Technology.ToLower().Trim());
        //                if(skill == null)
        //                {
        //                    skill = database.CreateSkill(item);
        //                    skills.Add(skill);
        //                }
        //            }
        //        }


        //        var post = new Post()
        //        {
        //            EmployerDescription = postDTO.EmployerDescription,
        //            EmployerDuration = postDTO.EmployerDuration,
        //            EmployerName = postDTO.EmployerName,
        //            ExperienceLevel = postDTO.ExperienceLevel,
        //            isEnabled = postDTO.isEnabled,
        //            JobDescription = postDTO.JobDescription,
        //            Location = postDTO.Location,
        //            SkillsNeeded = skills
        //        };
        //        database.CreatePost(post);
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return false;
        //    }
        //}

        //public List<PostDTO> GetAllPosts()
        //{
        //    database.GetActivePosts();
        //    return null;
        //}
       

        public List<Person> GetJobSeekersList()
        {
            database.GetPersonsList();
            return null;
        }

        public bool HireEmployee(int JobSeekerId, int EmployerId,string Designation, string Role)
        {
            try
            {
                if (database.IsPersonExists(JobSeekerId) && database.IsEmployerExists(EmployerId))
                {
                    var employee = new Employee()
                    {
                        Designation = Designation,
                        EmployerId = EmployerId,
                        PersonId = JobSeekerId,
                        Role = Role,
                        EmployerName = database.GetEmployerNameById(EmployerId),
                        PersonName = database.GetPersonNameById(JobSeekerId)
                    };
                    //database.CreateEmployee(employee);
                    database.UpdatePersonRole(JobSeekerId, "Employee");
                    
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //public List<Employee> GetEmployees(int EmployerId)
        //{
        //    if (database.IsEmployerExists(EmployerId))
        //    {
        //        return database.GetEmployeeList(EmployerId);
        //    }
        //    return null;
        //}

        //public bool FireEmployee(int EmployeeId)
        //{
        //    if (database.IsEmployeeExists(EmployeeId))
        //    {
        //        var employee = database.GetEmployeeById(EmployeeId);
                
        //        if (database.UpdatePersonRole(employee.PersonId,"Job Seeker"))
        //        {
        //            database.DeleteEmployee(EmployeeId);
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        
    }
}
