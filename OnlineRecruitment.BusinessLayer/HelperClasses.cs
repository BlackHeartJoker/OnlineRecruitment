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

        public bool RegisterJobSeeker(PersonDTO personDTO)
        {
            try
            {
                var skill = new Skill()
                {
                    Technology = personDTO.Stack.Skill.Technology
                };
                skill = database.CreateSkill(skill); //returns created skill object
                var stack = new Stack()
                {
                    Competence = personDTO.Stack.Competence,
                    Skill = skill
                };
                stack = database.CreateStack(stack); // returns stack object
                var educations = new List<Education>();
                foreach (var item in personDTO.Educations)
                {
                    var education = new Education()
                    {
                        EndYear = item.EndYear,
                        InstituteName = item.InstituteName,
                        StartYear = item.StartYear,
                        StudyDuration = item.StudyDuration
                    };
                    education = database.CreateEducation(education); // returns educationObject
                    educations.Add(education);
                }

                var projects = new List<Project>();
                foreach (var item in personDTO.Projects)
                {
                    var projectSkills = new List<Skill>();
                    foreach (var element in item.SkillsUsed)
                    {
                        var projectSkill = database.CreateSkill(element);
                        projectSkills.Add(projectSkill);
                    }
                    var project = new Project()
                    {
                        Description = item.Description,
                        Designation = item.Designation,
                        Duration = item.Duration,
                        ProjectName = item.ProjectName,
                        Role = item.Role,
                        SkillsUsed = projectSkills,
                    };

                    project = database.CreateProject(project); // returns project object
                    projects.Add(project);
                }

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
                    Stack = stack,
                    Educations = educations,
                    Projects = projects
                };

                database.CreatePerson(person); // Create person Entry to the database
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
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
                    Employees = null
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

        public bool CreateEmployerPost(PostDTO postDTO)
        {
            try
            {
                var skills = new List<Skill>();

                foreach(var item in postDTO.SkillsNeeded)
                {
                    Skill skill = null; 
                    if (item.SkillId != 0)
                    {
                        skills.Add(item);
                    }
                    else
                    {
                        skill = database.IsSkillExists(item.Technology.ToLower().Trim());
                        if(skill == null)
                        {
                            skill = database.CreateSkill(item);
                            skills.Add(skill);
                        }
                    }
                }


                var post = new Post()
                {
                    EmployerDescription = postDTO.EmployerDescription,
                    EmployerDuration = postDTO.EmployerDuration,
                    EmployerName = postDTO.EmployerName,
                    ExperienceLevel = postDTO.ExperienceLevel,
                    isEnabled = postDTO.isEnabled,
                    JobDescription = postDTO.JobDescription,
                    Location = postDTO.Location,
                    SkillsNeeded = skills
                };
                database.CreatePost(post);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<PostDTO> GetAllPosts()
        {

            return null;
        }

        public Person GetJobSeekerResume(int personId)
        {
            return null;
        }

        public List<Person> GetJobSeekersList()
        {
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
                    database.CreateEmployee(employee);
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

        public List<Employee> GetEmployees(int EmployerId)
        {
            return null;
        }

        public bool FireEmployee(int EmployerId, int EmployeeId)
        {
            return true;
        }
    }
}
