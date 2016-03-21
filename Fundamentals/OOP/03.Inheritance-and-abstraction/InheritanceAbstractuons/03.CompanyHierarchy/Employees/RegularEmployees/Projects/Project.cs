using System;
using _03.CompanyHierarchy.Employees.Enums;

namespace _03.CompanyHierarchy.Employees.RegularEmployees.Projects
{
    public class Project
    {
        private string projectName;

        public Project(string projectName, DateTime startDate, State state) 
            : this(projectName, startDate, null, state)
        {
        }

        public Project(string projectName, DateTime startDate, string details, State state)
        {
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.Details = details;
            this.State = state;
        }

        public string ProjectName
        {
            get { return this.projectName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter a valid project name.");
                }
                this.projectName = value;
            }
        }
        public DateTime StartDate { get; set; }
        public string Details { get; set; }
        public State State { get; set; }

        public State CloseProject()
        {
            return State.Closed;
        }
    }
}