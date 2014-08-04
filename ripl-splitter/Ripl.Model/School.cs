using System;
using System.Collections.Generic;

namespace Ripl.Model
{
    class School
    {
        string name;
        List<Applicant> applicants = new List<Applicant>();

        public School() { }

        public School(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Applicant> Applicants
        {
            get { return applicants; }
        }
    }
}
