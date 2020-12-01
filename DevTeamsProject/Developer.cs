using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        // Developer POCO
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DevID { get; set; }
        public string TeamName { get; set; }
        public bool PluralsightAccess { get; set; }
        public bool PluralsightLicense { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, string devID, string teamName, bool pluralsightAccess, bool pluralsightLicense)
        {
            FirstName = firstName;
            LastName = lastName;
            DevID = devID;
            TeamName = teamName;
            PluralsightAccess = pluralsightAccess;
            PluralsightLicense = pluralsightLicense;
        }
    }
}
