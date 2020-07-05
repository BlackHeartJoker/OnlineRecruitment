using OnlineRecruitment.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineRecruitment.DataAccessLayer
{
    public class DBHelper
    {
        private static ApplicationDbContext dbContext = null;
        public DBHelper()
        {
            dbContext = new ApplicationDbContext();
        }
        public Skill CreateSkill(Skill skill)
        {
            var temp = dbContext.SkillsTable.Where(i => i.Technology == skill.Technology).ToList();
            if(temp.Count == 0 )
            {
                dbContext.SkillsTable.Add(skill);
                dbContext.SaveChanges();
                return skill;
            }
            else
            {
                return temp[0];
            }
        }

        public Stack CreateStack(Stack stack)
        {
            var temp = dbContext.StackTable.Where(i => (i.Skill==stack.Skill && i.Competence == stack.Competence)).ToList();
            if (temp.Count == 0)
            {
                dbContext.StackTable.Add(stack);
                dbContext.SaveChanges();
                return stack;
            }
            else
            {
                return temp[0];
            }
        }

        public Education CreateEducation(Education education)
        {
            var temp = dbContext.EducationTable.Where(i => (
                i.EndYear == education.EndYear &&
                i.InstituteName == education.InstituteName &&
                i.StartYear == education.StartYear &&
                i.StudyDuration == education.StudyDuration
            )).ToList();
            if (temp.Count == 0)
            {
                dbContext.EducationTable.Add(education);
                dbContext.SaveChanges();
                return education;
            }
            else
            {
                return temp[0];
            }
        }

        public Project CreateProject(Project project)
        {
            var temp = dbContext.ProjectTable.Where(i => (
                i.Description == project.Description &&
                i.Designation == project.Designation&&
                i.Duration == project.Duration &&
                i.ProjectName== project.ProjectName&&
                i.Role == project.Role
            )).ToList();
            if (temp.Count == 0)
            {
                dbContext.ProjectTable.Add(project);
                dbContext.SaveChanges();
                return project;
            }
            else
            {
                return temp[0];
            }
        }
        public void CreatePerson(Person person)
        {
            dbContext.PersonTable.Add(person);
            dbContext.SaveChanges();
        }

        public void CreateEmployer(Employer employer)
        {
            dbContext.EmployerTable.Add(employer);
            dbContext.SaveChanges();
        }

        public PersonDTO GetPersonById(int PersonId)
        {
            var person = dbContext.PersonTable
                .Where(i=>i.PersonId == PersonId)
                .Include(i => i.Educations)
                .Include(i => i.Projects)
                .Include(i => i.Stack)
                .Single();

            var stack = new StackDTO()
            {
                Competence = person.Stack.Competence,
                Skill = person.Stack.Skill,
                StackId = person.Stack.StackId
            };

            var projects = new List<ProjectDTO>();
            foreach(var item in person.Projects)
            {
                var project = new ProjectDTO()
                {
                    Description = item.Description,
                    Designation = item.Designation,
                    Duration = item.Duration,
                    ProjectId = item.ProjectId,
                    ProjectName = item.ProjectName,
                    Role = item.Role,
                    SkillsUsed = item.SkillsUsed.ToList()
                };
            }

            var PersonDTO = new PersonDTO()
            {
                Name = person.Name,
                Stack = stack,
                Projects = projects,
                Educations = person.Educations.ToList(),
                Age = person.Age,
                Email = person.Email,
                Experience = person.Experience,
                Gender = person.Gender,
                Location = person.Location,
                PhoneNo = person.PhoneNo,
                Photo = person.Photo,
                Profession = person.Profession,
                Resume = person.Resume,
                Role = person.Role
            };
            return PersonDTO;
        }

        public bool IsPersonExists(int PersonId)
        {
            var temp = dbContext.PersonTable.Find(PersonId);
            return temp != null ? true : false;
        }
        public bool IsEmployerExists(int EmployerId)
        {
            var temp = dbContext.EmployerTable.Find(EmployerId);
            return temp != null ? true : false;
        }
        public string GetEmployerNameById(int EmployerId)
        {
            return (from item in dbContext.EmployerTable where item.EmployerId == EmployerId select item.EmployerName).ToString();
        }

        public string GetPersonNameById(int PersonId)
        {
            return (from item in dbContext.PersonTable where item.PersonId == PersonId select item.Name).ToString();
        }

        public void CreateEmployee(Employee employee)
        {
            dbContext.EmployeeTable.Add(employee);
            dbContext.SaveChanges();
        }

        public void CreatePost(Post post)
        {
            dbContext.PostTable.Add(post);
            dbContext.SaveChanges();
        }

        public Skill IsSkillExists(string Technology)
        {
            var skill = dbContext.SkillsTable.Where(item => item.Technology.ToLower().Trim() == Technology);

            return skill != null ? skill.FirstOrDefault() : null;
        }

    }

}
